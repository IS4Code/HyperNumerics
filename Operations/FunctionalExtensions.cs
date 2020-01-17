using IS4.HyperNumerics.NumberTypes;
using System;
using System.Reflection;

namespace IS4.HyperNumerics.Operations
{
    public static class FunctionalExtensions
    {
        public static TResult DynamicInvoke<TResult, TComponent>(this IComponentNumberFunc<TResult> func, Type numberType, Type componentType = null) where TComponent : struct, IEquatable<TComponent>, IComparable<TComponent>
        {
            if(func == null)
            {
                throw new ArgumentNullException(nameof(func));
            }
            if(numberType == null)
            {
                throw new ArgumentNullException(nameof(numberType));
            }
            MethodInfo method;
            if(componentType == null && func is INumberFunc<TResult>)
            {
                method = typeof(INumberFunc<TResult>).GetMethod(nameof(INumberFunc<TResult>.Invoke), BindingFlags.Public | BindingFlags.Instance | BindingFlags.DeclaredOnly);
                method = method.MakeGenericMethod(numberType);
            }else{
                method = typeof(IComponentNumberFunc<TResult>).GetMethod(nameof(IComponentNumberFunc<TResult>.Invoke), BindingFlags.Public | BindingFlags.Instance | BindingFlags.DeclaredOnly);
                if(componentType == null)
                {
                    componentType = TypeTools.GetComponentType(numberType);
                    if(componentType == null)
                    {
                        throw new ArgumentException("Type does not provide its component type.", nameof(numberType));
                    }
                }
                method = method.MakeGenericMethod(numberType, componentType);
            }
            return (TResult)method.Invoke(func, null);
        }

        public static INumber DynamicInvoke(this IComponentNumberOperation func, Type numberType, Type componentType = null)
        {
            if(func == null)
            {
                throw new ArgumentNullException(nameof(func));
            }
            if(numberType == null)
            {
                throw new ArgumentNullException(nameof(numberType));
            }
            MethodInfo method;
            if(componentType == null && func is INumberOperation)
            {
                method = typeof(INumberOperation).GetMethod(nameof(INumberOperation.Invoke), BindingFlags.Public | BindingFlags.Instance | BindingFlags.DeclaredOnly);
                method = method.MakeGenericMethod(numberType);
            }else{
                method = typeof(IComponentNumberOperation).GetMethod(nameof(IComponentNumberOperation.Invoke), BindingFlags.Public | BindingFlags.Instance | BindingFlags.DeclaredOnly);
                if(componentType == null)
                {
                    componentType = TypeTools.GetComponentType(numberType);
                    if(componentType == null)
                    {
                        throw new ArgumentException("Type does not provide its component type.", nameof(numberType));
                    }
                }
                method = method.MakeGenericMethod(numberType, componentType);
            }
            return (INumber)method.Invoke(func, null);
        }

        public static INumberOperation AsOperation(this Func<AbstractNumber> func)
        {
            if(func == null)
            {
                throw new ArgumentNullException(nameof(func));
            }
            return new FuncAsStandardNumber(func);
        }

        public static AbstractNumber AsNumber(this INumberOperation operation)
        {
            if(operation == null)
            {
                throw new ArgumentNullException(nameof(operation));
            }
            return new AbstractNumber(operation);
        }

        public static UnaryAbstractNumber AsNumber(this IUnaryNumberOperation operation)
        {
            if(operation == null)
            {
                throw new ArgumentNullException(nameof(operation));
            }
            return new UnaryAbstractNumber(operation);
        }

        public static BinaryAbstractNumber AsNumber(this IBinaryNumberOperation operation)
        {
            if(operation == null)
            {
                throw new ArgumentNullException(nameof(operation));
            }
            return new BinaryAbstractNumber(operation);
        }

        public static IUnaryNumberOperation AsUnary(this INumberOperation operation)
        {
            if(operation == null)
            {
                throw new ArgumentNullException(nameof(operation));
            }
            return new NullaryAsUnaryOperation(operation);
        }

        public static IUnaryNumberOperation AsUnary(this IBinaryNumberOperation operation)
        {
            if(operation == null)
            {
                throw new ArgumentNullException(nameof(operation));
            }
            return new BinaryAsUnaryOperation(operation);
        }

        public static IBinaryNumberOperation AsBinary(this IUnaryNumberOperation operation)
        {
            if(operation == null)
            {
                throw new ArgumentNullException(nameof(operation));
            }
            return new UnaryAsBinaryOperation(operation);
        }

        public static IBinaryNumberOperation AsBinary(this INumberOperation operation)
        {
            if(operation == null)
            {
                throw new ArgumentNullException(nameof(operation));
            }
            return new NullaryAsBinaryOperation(operation);
        }

        public static IBinaryNumberOperation Swap(this IBinaryNumberOperation operation)
        {
            if(operation == null)
            {
                throw new ArgumentNullException(nameof(operation));
            }
            return new SwapOperation(operation);
        }

        public static IUnaryNumberOperation Apply(this IUnaryNumberOperation outer, IUnaryNumberOperation inner)
        {
            if(outer == null)
            {
                throw new ArgumentNullException(nameof(outer));
            }
            if(inner == null)
            {
                throw new ArgumentNullException(nameof(inner));
            }
            return new UnaryUnaryOperation(outer, inner);
        }

        public static INumberOperation Apply(this IUnaryNumberOperation outer, INumberOperation inner)
        {
            if(outer == null)
            {
                throw new ArgumentNullException(nameof(outer));
            }
            if(inner == null)
            {
                throw new ArgumentNullException(nameof(inner));
            }
            return new UnaryStandardNumber(outer, inner);
        }

        public static INumberOperation Apply(this IBinaryNumberOperation outer, INumberOperation left, INumberOperation right)
        {
            if(outer == null)
            {
                throw new ArgumentNullException(nameof(outer));
            }
            if(left == null)
            {
                throw new ArgumentNullException(nameof(left));
            }
            if(right == null)
            {
                throw new ArgumentNullException(nameof(right));
            }
            return new BinaryNullaryStandardNumber(outer, left, right);
        }

        public static IUnaryNumberOperation Apply(this IBinaryNumberOperation outer, IUnaryNumberOperation left, INumberOperation right)
        {
            if(outer == null)
            {
                throw new ArgumentNullException(nameof(outer));
            }
            if(right == null)
            {
                throw new ArgumentNullException(nameof(right));
            }
            return new BinaryUnaryStandardNumber(outer, left, right);
        }

        public static IUnaryNumberOperation Apply(this IBinaryNumberOperation outer, INumberOperation left, IUnaryNumberOperation right)
        {
            if(outer == null)
            {
                throw new ArgumentNullException(nameof(outer));
            }
            if(left == null)
            {
                throw new ArgumentNullException(nameof(left));
            }
            return new BinaryNullaryUnaryOperation(outer, left, right);
        }

        public static IUnaryNumberOperation Apply(this IBinaryNumberOperation outer, IUnaryNumberOperation left, IUnaryNumberOperation right)
        {
            if(outer == null)
            {
                throw new ArgumentNullException(nameof(outer));
            }
            return new BinaryUnaryUnaryOperation(outer, left, right);
        }

        public static IBinaryNumberOperation Apply(this IBinaryNumberOperation outer, IBinaryNumberOperation left, IBinaryNumberOperation right)
        {
            if(outer == null)
            {
                throw new ArgumentNullException(nameof(outer));
            }
            if(left == null)
            {
                throw new ArgumentNullException(nameof(left));
            }
            if(right == null)
            {
                throw new ArgumentNullException(nameof(right));
            }
            return new BinaryBinaryBinaryOperation(outer, left, right);
        }

        public static IBinaryNumberOperation Apply(this IUnaryNumberOperation outer, IBinaryNumberOperation inner)
        {
            if(outer == null)
            {
                throw new ArgumentNullException(nameof(outer));
            }
            if(inner == null)
            {
                throw new ArgumentNullException(nameof(inner));
            }
            return new UnaryBinaryOperation(outer, inner);
        }

        private class FuncAsStandardNumber : DynamicNumberOperation<INumberOperation>, INumberOperation
        {
            readonly Func<AbstractNumber> func;

            public FuncAsStandardNumber(Func<AbstractNumber> func)
            {
                this.func = func;
            }

            public TNumber Invoke<TNumber>() where TNumber : struct, INumber<TNumber>
            {
                return func().Invoke<TNumber>();
            }

            public TNumber Invoke<TNumber, TComponent>() where TNumber : struct, INumber<TNumber, TComponent> where TComponent : struct, IEquatable<TComponent>, IComparable<TComponent>
            {
                return func().Invoke<TNumber, TComponent>();
            }

            public override string ToString()
            {
                return func.ToString();
            }
        }

        private class NullaryAsUnaryOperation : DynamicNumberOperation<IUnaryNumberOperation>, IUnaryNumberOperation
        {
            readonly INumberOperation operation;

            public NullaryAsUnaryOperation(INumberOperation operation)
            {
                this.operation = operation;
            }

            public TNumber Invoke<TNumber>(in TNumber numArg) where TNumber : struct, INumber<TNumber>
            {
                return operation.Invoke<TNumber>();
            }

            public TNumber Invoke<TNumber, TComponent>(in TNumber numArg) where TNumber : struct, INumber<TNumber, TComponent> where TComponent : struct, IEquatable<TComponent>, IComparable<TComponent>
            {
                return operation.Invoke<TNumber, TComponent>();
            }

            public override string ToString()
            {
                return operation.ToString();
            }
        }

        private class BinaryAsUnaryOperation : DynamicNumberOperation<IUnaryNumberOperation>, IUnaryNumberOperation
        {
            readonly IBinaryNumberOperation operation;

            public BinaryAsUnaryOperation(IBinaryNumberOperation operation)
            {
                this.operation = operation;
            }

            public TNumber Invoke<TNumber>(in TNumber numArg) where TNumber : struct, INumber<TNumber>
            {
                return operation.Invoke<TNumber>(numArg, numArg);
            }

            public TNumber Invoke<TNumber, TComponent>(in TNumber numArg) where TNumber : struct, INumber<TNumber, TComponent> where TComponent : struct, IEquatable<TComponent>, IComparable<TComponent>
            {
                return operation.Invoke<TNumber, TComponent>(numArg, numArg);
            }

            public override string ToString()
            {
                return operation.ToString();
            }
        }

        private class UnaryAsBinaryOperation : DynamicNumberOperation<IBinaryNumberOperation>, IBinaryNumberOperation
        {
            readonly IUnaryNumberOperation operation;

            public UnaryAsBinaryOperation(IUnaryNumberOperation operation)
            {
                this.operation = operation;
            }

            public TNumber Invoke<TNumber>(in TNumber arg1, in TNumber arg2) where TNumber : struct, INumber<TNumber>
            {
                return operation.Invoke<TNumber>(arg1);
            }

            public TNumber Invoke<TNumber, TComponent>(in TNumber arg1, in TNumber arg2) where TNumber : struct, INumber<TNumber, TComponent> where TComponent : struct, IEquatable<TComponent>, IComparable<TComponent>
            {
                return operation.Invoke<TNumber, TComponent>(arg1);
            }

            public override string ToString()
            {
                return operation.ToString();
            }
        }

        private class NullaryAsBinaryOperation : DynamicNumberOperation<IBinaryNumberOperation>, IBinaryNumberOperation
        {
            readonly INumberOperation operation;

            public NullaryAsBinaryOperation(INumberOperation operation)
            {
                this.operation = operation;
            }

            public TNumber Invoke<TNumber>(in TNumber arg1, in TNumber arg2) where TNumber : struct, INumber<TNumber>
            {
                return operation.Invoke<TNumber>();
            }

            public TNumber Invoke<TNumber, TComponent>(in TNumber arg1, in TNumber arg2) where TNumber : struct, INumber<TNumber, TComponent> where TComponent : struct, IEquatable<TComponent>, IComparable<TComponent>
            {
                return operation.Invoke<TNumber, TComponent>();
            }

            public override string ToString()
            {
                return operation.ToString();
            }
        }

        private class SwapOperation : DynamicNumberOperation<IBinaryNumberOperation>, IBinaryNumberOperation
        {
            readonly IBinaryNumberOperation operation;

            public SwapOperation(IBinaryNumberOperation operation)
            {
                this.operation = operation;
            }

            public TNumber Invoke<TNumber>(in TNumber arg1, in TNumber arg2) where TNumber : struct, INumber<TNumber>
            {
                return operation.Invoke<TNumber>(arg2, arg1);
            }

            public TNumber Invoke<TNumber, TComponent>(in TNumber arg1, in TNumber arg2) where TNumber : struct, INumber<TNumber, TComponent> where TComponent : struct, IEquatable<TComponent>, IComparable<TComponent>
            {
                return operation.Invoke<TNumber, TComponent>(arg2, arg1);
            }

            public override string ToString()
            {
                return "Swap(" + operation.ToString() + ")";
            }
        }

        private class UnaryUnaryOperation : DynamicNumberOperation<IUnaryNumberOperation>, IUnaryNumberOperation
        {
            readonly IUnaryNumberOperation outer;
            readonly IUnaryNumberOperation inner;

            public UnaryUnaryOperation(IUnaryNumberOperation outer, IUnaryNumberOperation inner)
            {
                this.outer = outer;
                this.inner = inner;
            }

            public TNumber Invoke<TNumber>(in TNumber numArg) where TNumber : struct, INumber<TNumber>
            {
                return outer.Invoke<TNumber>(inner.Invoke<TNumber>(numArg));
            }

            public TNumber Invoke<TNumber, TComponent>(in TNumber numArg) where TNumber : struct, INumber<TNumber, TComponent> where TComponent : struct, IEquatable<TComponent>, IComparable<TComponent>
            {
                return outer.Invoke<TNumber, TComponent>(inner.Invoke<TNumber, TComponent>(numArg));
            }

            public override string ToString()
            {
                return outer.ToString() + "(" + inner.ToString() + ")";
            }
        }

        private class UnaryStandardNumber : DynamicNumberOperation<INumberOperation>, INumberOperation
        {
            readonly IUnaryNumberOperation outer;
            readonly INumberOperation inner;

            public UnaryStandardNumber(IUnaryNumberOperation outer, INumberOperation inner)
            {
                this.outer = outer;
                this.inner = inner;
            }

            public TNumber Invoke<TNumber>() where TNumber : struct, INumber<TNumber>
            {
                return outer.Invoke<TNumber>(inner.Invoke<TNumber>());
            }

            public TNumber Invoke<TNumber, TComponent>() where TNumber : struct, INumber<TNumber, TComponent> where TComponent : struct, IEquatable<TComponent>, IComparable<TComponent>
            {
                return outer.Invoke<TNumber, TComponent>(inner.Invoke<TNumber, TComponent>());
            }

            public override string ToString()
            {
                return outer.ToString() + "(" + inner.ToString() + ")";
            }
        }

        private class BinaryNullaryStandardNumber : DynamicNumberOperation<INumberOperation>, INumberOperation
        {
            readonly IBinaryNumberOperation outer;
            readonly INumberOperation left;
            readonly INumberOperation right;

            public BinaryNullaryStandardNumber(IBinaryNumberOperation outer, INumberOperation left, INumberOperation right)
            {
                this.outer = outer;
                this.left = left;
                this.right = right;
            }

            public TNumber Invoke<TNumber>() where TNumber : struct, INumber<TNumber>
            {
                return outer.Invoke<TNumber>(left.Invoke<TNumber>(), right.Invoke<TNumber>());
            }

            public TNumber Invoke<TNumber, TComponent>() where TNumber : struct, INumber<TNumber, TComponent> where TComponent : struct, IEquatable<TComponent>, IComparable<TComponent>
            {
                return outer.Invoke<TNumber, TComponent>(left.Invoke<TNumber, TComponent>(), right.Invoke<TNumber, TComponent>());
            }

            public override string ToString()
            {
                return outer.ToString() + "(" + (left?.ToString() ?? "Id") + ", " + (right?.ToString() ?? "Id") + ")";
            }
        }

        private class BinaryUnaryStandardNumber : DynamicNumberOperation<IUnaryNumberOperation>, IUnaryNumberOperation
        {
            readonly IBinaryNumberOperation outer;
            readonly IUnaryNumberOperation left;
            readonly INumberOperation right;

            public BinaryUnaryStandardNumber(IBinaryNumberOperation outer, IUnaryNumberOperation left, INumberOperation right)
            {
                this.outer = outer;
                this.left = left;
                this.right = right;
            }

            public TNumber Invoke<TNumber>(in TNumber num) where TNumber : struct, INumber<TNumber>
            {
                if(left == null)
                {
                    return outer.Invoke<TNumber>(num, right.Invoke<TNumber>());
                }else{
                    return outer.Invoke<TNumber>(left.Invoke<TNumber>(num), right.Invoke<TNumber>());
                }
            }

            public TNumber Invoke<TNumber, TComponent>(in TNumber num) where TNumber : struct, INumber<TNumber, TComponent> where TComponent : struct, IEquatable<TComponent>, IComparable<TComponent>
            {
                if(left == null)
                {
                    return outer.Invoke<TNumber, TComponent>(num, right.Invoke<TNumber, TComponent>());
                }else{
                    return outer.Invoke<TNumber, TComponent>(left.Invoke<TNumber, TComponent>(num), right.Invoke<TNumber, TComponent>());
                }
            }

            public override string ToString()
            {
                return outer.ToString() + "(" + (left?.ToString() ?? "Id") + ", " + (right?.ToString() ?? "Id") + ")";
            }
        }

        private class BinaryNullaryUnaryOperation : DynamicNumberOperation<IUnaryNumberOperation>, IUnaryNumberOperation
        {
            readonly IBinaryNumberOperation outer;
            readonly INumberOperation left;
            readonly IUnaryNumberOperation right;

            public BinaryNullaryUnaryOperation(IBinaryNumberOperation outer, INumberOperation left, IUnaryNumberOperation right)
            {
                this.outer = outer;
                this.left = left;
                this.right = right;
            }

            public TNumber Invoke<TNumber>(in TNumber num) where TNumber : struct, INumber<TNumber>
            {
                if(right == null)
                {
                    return outer.Invoke<TNumber>(left.Invoke<TNumber>(), num);
                }else{
                    return outer.Invoke<TNumber>(left.Invoke<TNumber>(), right.Invoke<TNumber>(num));
                }
            }

            public TNumber Invoke<TNumber, TComponent>(in TNumber num) where TNumber : struct, INumber<TNumber, TComponent> where TComponent : struct, IEquatable<TComponent>, IComparable<TComponent>
            {
                if(right == null)
                {
                    return outer.Invoke<TNumber, TComponent>(left.Invoke<TNumber, TComponent>(), num);
                }else{
                    return outer.Invoke<TNumber, TComponent>(left.Invoke<TNumber, TComponent>(), right.Invoke<TNumber, TComponent>(num));
                }
            }

            public override string ToString()
            {
                return outer.ToString() + "(" + (left?.ToString() ?? "Id") + ", " + (right?.ToString() ?? "Id") + ")";
            }
        }

        private class BinaryUnaryUnaryOperation : DynamicNumberOperation<IUnaryNumberOperation>, IUnaryNumberOperation
        {
            readonly IBinaryNumberOperation outer;
            readonly IUnaryNumberOperation left;
            readonly IUnaryNumberOperation right;

            public BinaryUnaryUnaryOperation(IBinaryNumberOperation outer, IUnaryNumberOperation left, IUnaryNumberOperation right)
            {
                this.outer = outer;
                this.left = left;
                this.right = right;
            }

            public TNumber Invoke<TNumber>(in TNumber num) where TNumber : struct, INumber<TNumber>
            {
                if(left == null)
                {
                    if(right == null)
                    {
                        return outer.Invoke<TNumber>(num, num);
                    }else{
                        return outer.Invoke<TNumber>(num, right.Invoke<TNumber>(num));
                    }
                }else{
                    if(right == null)
                    {
                        return outer.Invoke<TNumber>(left.Invoke<TNumber>(num), num);
                    }else{
                        return outer.Invoke<TNumber>(left.Invoke<TNumber>(num), right.Invoke<TNumber>(num));
                    }
                }
            }

            public TNumber Invoke<TNumber, TComponent>(in TNumber num) where TNumber : struct, INumber<TNumber, TComponent> where TComponent : struct, IEquatable<TComponent>, IComparable<TComponent>
            {
                if(left == null)
                {
                    if(right == null)
                    {
                        return outer.Invoke<TNumber, TComponent>(num, num);
                    }else{
                        return outer.Invoke<TNumber, TComponent>(num, right.Invoke<TNumber, TComponent>(num));
                    }
                }else{
                    if(right == null)
                    {
                        return outer.Invoke<TNumber, TComponent>(left.Invoke<TNumber, TComponent>(num), num);
                    }else{
                        return outer.Invoke<TNumber, TComponent>(left.Invoke<TNumber, TComponent>(num), right.Invoke<TNumber, TComponent>(num));
                    }
                }
            }

            public override string ToString()
            {
                return outer.ToString() + "(" + (left?.ToString() ?? "Id") + ", " + (right?.ToString() ?? "Id") + ")";
            }
        }

        private class BinaryBinaryBinaryOperation : DynamicNumberOperation<IBinaryNumberOperation>, IBinaryNumberOperation
        {
            readonly IBinaryNumberOperation outer;
            readonly IBinaryNumberOperation left;
            readonly IBinaryNumberOperation right;

            public BinaryBinaryBinaryOperation(IBinaryNumberOperation outer, IBinaryNumberOperation left, IBinaryNumberOperation right)
            {
                this.outer = outer;
                this.left = left;
                this.right = right;
            }

            public TNumber Invoke<TNumber>(in TNumber arg1, in TNumber arg2) where TNumber : struct, INumber<TNumber>
            {
                return outer.Invoke<TNumber>(left.Invoke<TNumber>(arg1, arg2), right.Invoke<TNumber>(arg1, arg2));
            }

            public TNumber Invoke<TNumber, TComponent>(in TNumber arg1, in TNumber arg2) where TNumber : struct, INumber<TNumber, TComponent> where TComponent : struct, IEquatable<TComponent>, IComparable<TComponent>
            {
                return outer.Invoke<TNumber, TComponent>(left.Invoke<TNumber, TComponent>(arg1, arg2), right.Invoke<TNumber, TComponent>(arg1, arg2));
            }

            public override string ToString()
            {
                return outer.ToString() + "(" + (left?.ToString() ?? "Id") + ", " + (right?.ToString() ?? "Id") + ")";
            }
        }

        private class UnaryBinaryOperation : DynamicNumberOperation<IBinaryNumberOperation>, IBinaryNumberOperation
        {
            readonly IUnaryNumberOperation outer;
            readonly IBinaryNumberOperation inner;

            public UnaryBinaryOperation(IUnaryNumberOperation outer, IBinaryNumberOperation inner)
            {
                this.outer = outer;
                this.inner = inner;
            }

            public TNumber Invoke<TNumber>(in TNumber arg1, in TNumber arg2) where TNumber : struct, INumber<TNumber>
            {
                return outer.Invoke<TNumber>(inner.Invoke<TNumber>(arg1, arg2));
            }

            public TNumber Invoke<TNumber, TComponent>(in TNumber arg1, in TNumber arg2) where TNumber : struct, INumber<TNumber, TComponent> where TComponent : struct, IEquatable<TComponent>, IComparable<TComponent>
            {
                return outer.Invoke<TNumber, TComponent>(inner.Invoke<TNumber, TComponent>(arg1, arg2));
            }

            public override string ToString()
            {
                return outer.ToString() + "(" + inner.ToString() + ")";
            }
        }

        public static IComponentNumberOperation AsOperation(this Func<ComponentAbstractNumber> func)
        {
            if(func == null)
            {
                throw new ArgumentNullException(nameof(func));
            }
            return new ComponentFuncAsStandardNumber(func);
        }

        public static ComponentAbstractNumber AsNumber(this IComponentNumberOperation operation)
        {
            if(operation == null)
            {
                throw new ArgumentNullException(nameof(operation));
            }
            return new ComponentAbstractNumber(operation);
        }

        public static ComponentUnaryAbstractNumber AsNumber(this IComponentUnaryNumberOperation operation)
        {
            if(operation == null)
            {
                throw new ArgumentNullException(nameof(operation));
            }
            return new ComponentUnaryAbstractNumber(operation);
        }

        public static ComponentBinaryAbstractNumber AsNumber(this IComponentBinaryNumberOperation operation)
        {
            if(operation == null)
            {
                throw new ArgumentNullException(nameof(operation));
            }
            return new ComponentBinaryAbstractNumber(operation);
        }

        public static IComponentUnaryNumberOperation AsUnary(this IComponentNumberOperation operation)
        {
            if(operation == null)
            {
                throw new ArgumentNullException(nameof(operation));
            }
            return new ComponentNullaryAsUnaryOperation(operation);
        }

        public static IComponentUnaryNumberOperation AsUnary(this IComponentBinaryNumberOperation operation)
        {
            if(operation == null)
            {
                throw new ArgumentNullException(nameof(operation));
            }
            return new ComponentBinaryAsUnaryOperation(operation);
        }

        public static IComponentBinaryNumberOperation AsBinary(this IComponentUnaryNumberOperation operation)
        {
            if(operation == null)
            {
                throw new ArgumentNullException(nameof(operation));
            }
            return new ComponentUnaryAsBinaryOperation(operation);
        }

        public static IComponentBinaryNumberOperation AsBinary(this IComponentNumberOperation operation)
        {
            if(operation == null)
            {
                throw new ArgumentNullException(nameof(operation));
            }
            return new ComponentNullaryAsBinaryOperation(operation);
        }

        public static IComponentBinaryNumberOperation Swap(this IComponentBinaryNumberOperation operation)
        {
            if(operation == null)
            {
                throw new ArgumentNullException(nameof(operation));
            }
            return new ComponentSwapOperation(operation);
        }

        public static IComponentUnaryNumberOperation Apply(this IComponentUnaryNumberOperation outer, IComponentUnaryNumberOperation inner)
        {
            if(outer == null)
            {
                throw new ArgumentNullException(nameof(outer));
            }
            if(inner == null)
            {
                throw new ArgumentNullException(nameof(inner));
            }
            return new ComponentUnaryUnaryOperation(outer, inner);
        }

        public static IComponentNumberOperation Apply(this IComponentUnaryNumberOperation outer, IComponentNumberOperation inner)
        {
            if(outer == null)
            {
                throw new ArgumentNullException(nameof(outer));
            }
            if(inner == null)
            {
                throw new ArgumentNullException(nameof(inner));
            }
            return new ComponentUnaryStandardNumber(outer, inner);
        }

        public static IComponentNumberOperation Apply(this IComponentBinaryNumberOperation outer, IComponentNumberOperation left, IComponentNumberOperation right)
        {
            if(outer == null)
            {
                throw new ArgumentNullException(nameof(outer));
            }
            if(left == null)
            {
                throw new ArgumentNullException(nameof(left));
            }
            if(right == null)
            {
                throw new ArgumentNullException(nameof(right));
            }
            return new ComponentBinaryNullaryStandardNumber(outer, left, right);
        }

        public static IComponentUnaryNumberOperation Apply(this IComponentBinaryNumberOperation outer, IComponentUnaryNumberOperation left, IComponentNumberOperation right)
        {
            if(outer == null)
            {
                throw new ArgumentNullException(nameof(outer));
            }
            if(right == null)
            {
                throw new ArgumentNullException(nameof(right));
            }
            return new ComponentBinaryUnaryStandardNumber(outer, left, right);
        }

        public static IComponentUnaryNumberOperation Apply(this IComponentBinaryNumberOperation outer, IComponentNumberOperation left, IComponentUnaryNumberOperation right)
        {
            if(outer == null)
            {
                throw new ArgumentNullException(nameof(outer));
            }
            if(left == null)
            {
                throw new ArgumentNullException(nameof(left));
            }
            return new ComponentBinaryNullaryUnaryOperation(outer, left, right);
        }

        public static IComponentUnaryNumberOperation Apply(this IComponentBinaryNumberOperation outer, IComponentUnaryNumberOperation left, IComponentUnaryNumberOperation right)
        {
            if(outer == null)
            {
                throw new ArgumentNullException(nameof(outer));
            }
            return new ComponentBinaryUnaryUnaryOperation(outer, left, right);
        }

        public static IComponentBinaryNumberOperation Apply(this IComponentBinaryNumberOperation outer, IComponentBinaryNumberOperation left, IComponentBinaryNumberOperation right)
        {
            if(outer == null)
            {
                throw new ArgumentNullException(nameof(outer));
            }
            if(left == null)
            {
                throw new ArgumentNullException(nameof(left));
            }
            if(right == null)
            {
                throw new ArgumentNullException(nameof(right));
            }
            return new ComponentBinaryBinaryBinaryOperation(outer, left, right);
        }

        public static IComponentBinaryNumberOperation Apply(this IComponentUnaryNumberOperation outer, IComponentBinaryNumberOperation inner)
        {
            if(outer == null)
            {
                throw new ArgumentNullException(nameof(outer));
            }
            if(inner == null)
            {
                throw new ArgumentNullException(nameof(inner));
            }
            return new ComponentUnaryBinaryOperation(outer, inner);
        }

        private class ComponentFuncAsStandardNumber : DynamicNumberOperation<IComponentNumberOperation>, IComponentNumberOperation
        {
            readonly Func<ComponentAbstractNumber> func;

            public ComponentFuncAsStandardNumber(Func<ComponentAbstractNumber> func)
            {
                this.func = func;
            }

            public TNumber Invoke<TNumber, TComponent>() where TNumber : struct, INumber<TNumber, TComponent> where TComponent : struct, IEquatable<TComponent>, IComparable<TComponent>
            {
                return func().Invoke<TNumber, TComponent>();
            }

            public override string ToString()
            {
                return func.ToString();
            }
        }

        private class ComponentNullaryAsUnaryOperation : DynamicNumberOperation<IComponentUnaryNumberOperation>, IComponentUnaryNumberOperation
        {
            readonly IComponentNumberOperation operation;

            public ComponentNullaryAsUnaryOperation(IComponentNumberOperation operation)
            {
                this.operation = operation;
            }

            public TNumber Invoke<TNumber, TComponent>(in TNumber numArg) where TNumber : struct, INumber<TNumber, TComponent> where TComponent : struct, IEquatable<TComponent>, IComparable<TComponent>
            {
                return operation.Invoke<TNumber, TComponent>();
            }

            public override string ToString()
            {
                return operation.ToString();
            }
        }

        private class ComponentBinaryAsUnaryOperation : DynamicNumberOperation<IComponentUnaryNumberOperation>, IComponentUnaryNumberOperation
        {
            readonly IComponentBinaryNumberOperation operation;

            public ComponentBinaryAsUnaryOperation(IComponentBinaryNumberOperation operation)
            {
                this.operation = operation;
            }

            public TNumber Invoke<TNumber, TComponent>(in TNumber numArg) where TNumber : struct, INumber<TNumber, TComponent> where TComponent : struct, IEquatable<TComponent>, IComparable<TComponent>
            {
                return operation.Invoke<TNumber, TComponent>(numArg, numArg);
            }

            public override string ToString()
            {
                return operation.ToString();
            }
        }

        private class ComponentUnaryAsBinaryOperation : DynamicNumberOperation<IBinaryNumberOperation>, IComponentBinaryNumberOperation
        {
            readonly IComponentUnaryNumberOperation operation;

            public ComponentUnaryAsBinaryOperation(IComponentUnaryNumberOperation operation)
            {
                this.operation = operation;
            }

            public TNumber Invoke<TNumber, TComponent>(in TNumber arg1, in TNumber arg2) where TNumber : struct, INumber<TNumber, TComponent> where TComponent : struct, IEquatable<TComponent>, IComparable<TComponent>
            {
                return operation.Invoke<TNumber, TComponent>(arg1);
            }

            public override string ToString()
            {
                return operation.ToString();
            }
        }

        private class ComponentNullaryAsBinaryOperation : DynamicNumberOperation<IComponentBinaryNumberOperation>, IComponentBinaryNumberOperation
        {
            readonly IComponentNumberOperation operation;

            public ComponentNullaryAsBinaryOperation(IComponentNumberOperation operation)
            {
                this.operation = operation;
            }

            public TNumber Invoke<TNumber, TComponent>(in TNumber arg1, in TNumber arg2) where TNumber : struct, INumber<TNumber, TComponent> where TComponent : struct, IEquatable<TComponent>, IComparable<TComponent>
            {
                return operation.Invoke<TNumber, TComponent>();
            }

            public override string ToString()
            {
                return operation.ToString();
            }
        }

        private class ComponentSwapOperation : DynamicNumberOperation<IComponentBinaryNumberOperation>, IComponentBinaryNumberOperation
        {
            readonly IComponentBinaryNumberOperation operation;

            public ComponentSwapOperation(IComponentBinaryNumberOperation operation)
            {
                this.operation = operation;
            }

            public TNumber Invoke<TNumber, TComponent>(in TNumber arg1, in TNumber arg2) where TNumber : struct, INumber<TNumber, TComponent> where TComponent : struct, IEquatable<TComponent>, IComparable<TComponent>
            {
                return operation.Invoke<TNumber, TComponent>(arg2, arg1);
            }

            public override string ToString()
            {
                return "Swap(" + operation.ToString() + ")";
            }
        }

        private class ComponentUnaryUnaryOperation : DynamicNumberOperation<IComponentUnaryNumberOperation>, IComponentUnaryNumberOperation
        {
            readonly IComponentUnaryNumberOperation outer;
            readonly IComponentUnaryNumberOperation inner;

            public ComponentUnaryUnaryOperation(IComponentUnaryNumberOperation outer, IComponentUnaryNumberOperation inner)
            {
                this.outer = outer;
                this.inner = inner;
            }

            public TNumber Invoke<TNumber, TComponent>(in TNumber numArg) where TNumber : struct, INumber<TNumber, TComponent> where TComponent : struct, IEquatable<TComponent>, IComparable<TComponent>
            {
                return outer.Invoke<TNumber, TComponent>(inner.Invoke<TNumber, TComponent>(numArg));
            }

            public override string ToString()
            {
                return outer.ToString() + "(" + inner.ToString() + ")";
            }
        }

        private class ComponentUnaryStandardNumber : DynamicNumberOperation<IComponentNumberOperation>, IComponentNumberOperation
        {
            readonly IComponentUnaryNumberOperation outer;
            readonly IComponentNumberOperation inner;

            public ComponentUnaryStandardNumber(IComponentUnaryNumberOperation outer, IComponentNumberOperation inner)
            {
                this.outer = outer;
                this.inner = inner;
            }

            public TNumber Invoke<TNumber, TComponent>() where TNumber : struct, INumber<TNumber, TComponent> where TComponent : struct, IEquatable<TComponent>, IComparable<TComponent>
            {
                return outer.Invoke<TNumber, TComponent>(inner.Invoke<TNumber, TComponent>());
            }

            public override string ToString()
            {
                return outer.ToString() + "(" + inner.ToString() + ")";
            }
        }

        private class ComponentBinaryNullaryStandardNumber : DynamicNumberOperation<IComponentNumberOperation>, IComponentNumberOperation
        {
            readonly IComponentBinaryNumberOperation outer;
            readonly IComponentNumberOperation left;
            readonly IComponentNumberOperation right;

            public ComponentBinaryNullaryStandardNumber(IComponentBinaryNumberOperation outer, IComponentNumberOperation left, IComponentNumberOperation right)
            {
                this.outer = outer;
                this.left = left;
                this.right = right;
            }
            
            public TNumber Invoke<TNumber, TComponent>() where TNumber : struct, INumber<TNumber, TComponent> where TComponent : struct, IEquatable<TComponent>, IComparable<TComponent>
            {
                return outer.Invoke<TNumber, TComponent>(left.Invoke<TNumber, TComponent>(), right.Invoke<TNumber, TComponent>());
            }

            public override string ToString()
            {
                return outer.ToString() + "(" + (left?.ToString() ?? "Id") + ", " + (right?.ToString() ?? "Id") + ")";
            }
        }

        private class ComponentBinaryUnaryStandardNumber : DynamicNumberOperation<IComponentUnaryNumberOperation>, IComponentUnaryNumberOperation
        {
            readonly IComponentBinaryNumberOperation outer;
            readonly IComponentUnaryNumberOperation left;
            readonly IComponentNumberOperation right;

            public ComponentBinaryUnaryStandardNumber(IComponentBinaryNumberOperation outer, IComponentUnaryNumberOperation left, IComponentNumberOperation right)
            {
                this.outer = outer;
                this.left = left;
                this.right = right;
            }

            public TNumber Invoke<TNumber, TComponent>(in TNumber num) where TNumber : struct, INumber<TNumber, TComponent> where TComponent : struct, IEquatable<TComponent>, IComparable<TComponent>
            {
                if(left == null)
                {
                    return outer.Invoke<TNumber, TComponent>(num, right.Invoke<TNumber, TComponent>());
                }else{
                    return outer.Invoke<TNumber, TComponent>(left.Invoke<TNumber, TComponent>(num), right.Invoke<TNumber, TComponent>());
                }
            }

            public override string ToString()
            {
                return outer.ToString() + "(" + (left?.ToString() ?? "Id") + ", " + (right?.ToString() ?? "Id") + ")";
            }
        }

        private class ComponentBinaryNullaryUnaryOperation : DynamicNumberOperation<IComponentUnaryNumberOperation>, IComponentUnaryNumberOperation
        {
            readonly IComponentBinaryNumberOperation outer;
            readonly IComponentNumberOperation left;
            readonly IComponentUnaryNumberOperation right;

            public ComponentBinaryNullaryUnaryOperation(IComponentBinaryNumberOperation outer, IComponentNumberOperation left, IComponentUnaryNumberOperation right)
            {
                this.outer = outer;
                this.left = left;
                this.right = right;
            }

            public TNumber Invoke<TNumber, TComponent>(in TNumber num) where TNumber : struct, INumber<TNumber, TComponent> where TComponent : struct, IEquatable<TComponent>, IComparable<TComponent>
            {
                if(right == null)
                {
                    return outer.Invoke<TNumber, TComponent>(left.Invoke<TNumber, TComponent>(), num);
                }else{
                    return outer.Invoke<TNumber, TComponent>(left.Invoke<TNumber, TComponent>(), right.Invoke<TNumber, TComponent>(num));
                }
            }

            public override string ToString()
            {
                return outer.ToString() + "(" + (left?.ToString() ?? "Id") + ", " + (right?.ToString() ?? "Id") + ")";
            }
        }

        private class ComponentBinaryUnaryUnaryOperation : DynamicNumberOperation<IComponentUnaryNumberOperation>, IComponentUnaryNumberOperation
        {
            readonly IComponentBinaryNumberOperation outer;
            readonly IComponentUnaryNumberOperation left;
            readonly IComponentUnaryNumberOperation right;

            public ComponentBinaryUnaryUnaryOperation(IComponentBinaryNumberOperation outer, IComponentUnaryNumberOperation left, IComponentUnaryNumberOperation right)
            {
                this.outer = outer;
                this.left = left;
                this.right = right;
            }

            public TNumber Invoke<TNumber, TComponent>(in TNumber num) where TNumber : struct, INumber<TNumber, TComponent> where TComponent : struct, IEquatable<TComponent>, IComparable<TComponent>
            {
                if(left == null)
                {
                    if(right == null)
                    {
                        return outer.Invoke<TNumber, TComponent>(num, num);
                    }else{
                        return outer.Invoke<TNumber, TComponent>(num, right.Invoke<TNumber, TComponent>(num));
                    }
                }else{
                    if(right == null)
                    {
                        return outer.Invoke<TNumber, TComponent>(left.Invoke<TNumber, TComponent>(num), num);
                    }else{
                        return outer.Invoke<TNumber, TComponent>(left.Invoke<TNumber, TComponent>(num), right.Invoke<TNumber, TComponent>(num));
                    }
                }
            }

            public override string ToString()
            {
                return outer.ToString() + "(" + (left?.ToString() ?? "Id") + ", " + (right?.ToString() ?? "Id") + ")";
            }
        }

        private class ComponentBinaryBinaryBinaryOperation : DynamicNumberOperation<IComponentBinaryNumberOperation>, IComponentBinaryNumberOperation
        {
            readonly IComponentBinaryNumberOperation outer;
            readonly IComponentBinaryNumberOperation left;
            readonly IComponentBinaryNumberOperation right;

            public ComponentBinaryBinaryBinaryOperation(IComponentBinaryNumberOperation outer, IComponentBinaryNumberOperation left, IComponentBinaryNumberOperation right)
            {
                this.outer = outer;
                this.left = left;
                this.right = right;
            }

            public TNumber Invoke<TNumber, TComponent>(in TNumber arg1, in TNumber arg2) where TNumber : struct, INumber<TNumber, TComponent> where TComponent : struct, IEquatable<TComponent>, IComparable<TComponent>
            {
                return outer.Invoke<TNumber, TComponent>(left.Invoke<TNumber, TComponent>(arg1, arg2), right.Invoke<TNumber, TComponent>(arg1, arg2));
            }

            public override string ToString()
            {
                return outer.ToString() + "(" + (left?.ToString() ?? "Id") + ", " + (right?.ToString() ?? "Id") + ")";
            }
        }

        private class ComponentUnaryBinaryOperation : DynamicNumberOperation<IComponentBinaryNumberOperation>, IComponentBinaryNumberOperation
        {
            readonly IComponentUnaryNumberOperation outer;
            readonly IComponentBinaryNumberOperation inner;

            public ComponentUnaryBinaryOperation(IComponentUnaryNumberOperation outer, IComponentBinaryNumberOperation inner)
            {
                this.outer = outer;
                this.inner = inner;
            }

            public TNumber Invoke<TNumber, TComponent>(in TNumber arg1, in TNumber arg2) where TNumber : struct, INumber<TNumber, TComponent> where TComponent : struct, IEquatable<TComponent>, IComparable<TComponent>
            {
                return outer.Invoke<TNumber, TComponent>(inner.Invoke<TNumber, TComponent>(arg1, arg2));
            }

            public override string ToString()
            {
                return outer.ToString() + "(" + inner.ToString() + ")";
            }
        }
    }
}
