using IS4.HyperNumerics.NumberTypes;
using System;
using System.Dynamic;
using System.Linq.Expressions;
using System.Reflection;

namespace IS4.HyperNumerics.Operations
{
    public abstract class DynamicNumberOperation<TInterface> : IDynamicMetaObjectProvider
    {
        DynamicMetaObject IDynamicMetaObjectProvider.GetMetaObject(Expression parameter)
        {
            return new MetaObject(parameter, this);
        }

        public class MetaObject : DynamicMetaObject
        {
            private static readonly Type InterfaceType = typeof(TInterface);
            private static readonly MethodInfo Invoke = InterfaceType.GetMethod("Invoke", BindingFlags.Public | BindingFlags.Instance | BindingFlags.DeclaredOnly);

            private static readonly Type NumberOperation = typeof(INumberOperation);
            private static readonly Type PrimitiveNumberOperation = typeof(IPrimitiveNumberOperation);
            private static readonly ConstructorInfo Constructor = typeof(AbstractNumber).GetConstructor(new[] { NumberOperation });
            private static readonly ConstructorInfo PrimitiveConstructor = typeof(PrimitiveAbstractNumber).GetConstructor(new[] { PrimitiveNumberOperation });

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
                        return new DynamicMetaObject(Expression.Convert(Expression.New(Constructor, Expression.Convert(Expression, NumberOperation)), binder.ReturnType), restrictions);
                    }
                    if(PrimitiveNumberOperation.Equals(InterfaceType))
                    {
                        return new DynamicMetaObject(Expression.Convert(Expression.New(PrimitiveConstructor, Expression.Convert(Expression, PrimitiveNumberOperation)), binder.ReturnType), restrictions);
                    }
                }
                return base.BindInvoke(binder, args);
            }
        }
    }
}
