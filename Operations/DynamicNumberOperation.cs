using IS4.HyperNumerics.NumberTypes;
using System;
using System.Dynamic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;

namespace IS4.HyperNumerics.Operations
{
    public abstract class DynamicNumberOperation<TInterface> : IDynamicMetaObjectProvider
    {
        public DynamicNumberOperation()
        {
            if(!(this is TInterface))
            {
                throw new TypeLoadException("The type must implement " + typeof(TInterface));
            }
        }

        DynamicMetaObject IDynamicMetaObjectProvider.GetMetaObject(Expression parameter)
        {
            return new MetaObject(parameter, this);
        }

        public class MetaObject : DynamicMetaObject
        {
            private static readonly Type InterfaceType = typeof(TInterface);
            private static readonly MethodInfo Invoke = InterfaceType.GetMethod("Invoke", BindingFlags.Public | BindingFlags.Instance | BindingFlags.DeclaredOnly);

            private static readonly Type NumberOperation = typeof(INumberOperation);
            private static readonly Type ComponentNumberOperation = typeof(IComponentNumberOperation);
            private static readonly ConstructorInfo AbstractConstructor = typeof(AbstractNumber).GetConstructor(new[] { NumberOperation });
            private static readonly ConstructorInfo ComponentAbstractConstructor = typeof(ComponentAbstractNumber).GetConstructor(new[] { ComponentNumberOperation });

            public MetaObject(Expression expression, DynamicNumberOperation<TInterface> value) : base(expression, BindingRestrictions.GetTypeRestriction(expression, InterfaceType), value)
            {

            }

            public override DynamicMetaObject BindInvoke(InvokeBinder binder, DynamicMetaObject[] args)
            {
                int numParams = Invoke.GetParameters().Length;
                if(numParams == args.Length)
                {
                    var restrictions = BindingRestrictions.GetTypeRestriction(Expression, LimitType);
                    if(NumberOperation.Equals(InterfaceType))
                    {
                        return new DynamicMetaObject(Expression.Convert(Expression.New(AbstractConstructor, Expression.Convert(Expression, NumberOperation)), binder.ReturnType), restrictions);
                    }
                    if(ComponentNumberOperation.Equals(InterfaceType))
                    {
                        return new DynamicMetaObject(Expression.Convert(Expression.New(ComponentAbstractConstructor, Expression.Convert(Expression, ComponentNumberOperation)), binder.ReturnType), restrictions);
                    }
                    MethodInfo method = null;
                    foreach(var arg in args)
                    {
                        try{
                            method = Invoke.MakeGenericMethod(arg.LimitType);
                        }catch(ArgumentException)
                        {

                        }
                        if(method != null)
                        {
                            break;
                        }else{
                            var componentType = TypeTools.GetComponentType(arg.LimitType);
                            if(componentType != null)
                            {
                                try{
                                    method = Invoke.MakeGenericMethod(arg.LimitType, componentType);
                                }catch(ArgumentException)
                                {

                                }
                                if(method != null)
                                {
                                    break;
                                }
                            }
                        }
                    }
                    if(method != null)
                    {
                        var expression = Expression.Call(Expression.Convert(Expression, InterfaceType), method, args.Select(arg => arg.Expression));
                        return new DynamicMetaObject(Expression.Convert(expression, binder.ReturnType), restrictions);
                    }
                }
                return base.BindInvoke(binder, args);
            }
        }
    }
}
