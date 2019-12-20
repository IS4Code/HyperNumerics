using IS4.HyperNumerics.NumberTypes;
using System;
using System.Reflection;

namespace IS4.HyperNumerics.Operations
{
    public static class FunctionalExtensions
    {
        public static TResult DynamicInvoke<TResult, TPrimitive>(this IPrimitiveNumberFunc<TResult> func, Type numberType, Type primitiveType = null) where TPrimitive : struct, IEquatable<TPrimitive>, IComparable<TPrimitive>
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
            if(primitiveType == null && func is INumberFunc<TResult>)
            {
                method = typeof(INumberFunc<TResult>).GetMethod(nameof(INumberFunc<TResult>.Invoke), BindingFlags.Public | BindingFlags.Instance | BindingFlags.DeclaredOnly);
                method = method.MakeGenericMethod(numberType);
            }else{
                method = typeof(IPrimitiveNumberFunc<TResult>).GetMethod(nameof(IPrimitiveNumberFunc<TResult>.Invoke), BindingFlags.Public | BindingFlags.Instance | BindingFlags.DeclaredOnly);
                if(primitiveType == null)
                {
                    primitiveType = TypeTools.GetPrimitiveType(numberType);
                    if(primitiveType == null)
                    {
                        throw new ArgumentException("Type does not provide its primitive type.", nameof(numberType));
                    }
                }
                method = method.MakeGenericMethod(numberType, primitiveType);
            }
            return (TResult)method.Invoke(func, null);
        }

        public static INumber DynamicInvoke(this IPrimitiveNumberOperation func, Type numberType, Type primitiveType = null)
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
            if(primitiveType == null && func is INumberOperation)
            {
                method = typeof(INumberOperation).GetMethod(nameof(INumberOperation.Invoke), BindingFlags.Public | BindingFlags.Instance | BindingFlags.DeclaredOnly);
                method = method.MakeGenericMethod(numberType);
            }else{
                method = typeof(IPrimitiveNumberOperation).GetMethod(nameof(IPrimitiveNumberOperation.Invoke), BindingFlags.Public | BindingFlags.Instance | BindingFlags.DeclaredOnly);
                if(primitiveType == null)
                {
                    primitiveType = TypeTools.GetPrimitiveType(numberType);
                    if(primitiveType == null)
                    {
                        throw new ArgumentException("Type does not provide its primitive type.", nameof(numberType));
                    }
                }
                method = method.MakeGenericMethod(numberType, primitiveType);
            }
            return (INumber)method.Invoke(func, null);
        }

        public static INumberOperation AsOperation(this Func<AbstractNumber> func)
        {
            if(func == null)
            {
                throw new ArgumentNullException(nameof(func));
            }
            return new FuncAsNullaryOperation(func);
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
            return new UnaryNullaryOperation(outer, inner);
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
            return new BinaryNullaryNullaryOperation(outer, left, right);
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
            return new BinaryUnaryNullaryOperation(outer, left, right);
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

        private class FuncAsNullaryOperation : DynamicNumberOperation<INumberOperation>, INumberOperation
        {
            readonly Func<AbstractNumber> func;

            public FuncAsNullaryOperation(Func<AbstractNumber> func)
            {
                this.func = func;
            }

            public TNumber Invoke<TNumber>() where TNumber : struct, INumber<TNumber>
            {
                return func().Invoke<TNumber>();
            }

            public TNumber Invoke<TNumber, TPrimitive>() where TNumber : struct, INumber<TNumber, TPrimitive> where TPrimitive : struct, IEquatable<TPrimitive>, IComparable<TPrimitive>
            {
                return func().Invoke<TNumber, TPrimitive>();
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

            public TNumber Invoke<TNumber, TPrimitive>(in TNumber numArg) where TNumber : struct, INumber<TNumber, TPrimitive> where TPrimitive : struct, IEquatable<TPrimitive>, IComparable<TPrimitive>
            {
                return operation.Invoke<TNumber, TPrimitive>();
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

            public TNumber Invoke<TNumber, TPrimitive>(in TNumber numArg) where TNumber : struct, INumber<TNumber, TPrimitive> where TPrimitive : struct, IEquatable<TPrimitive>, IComparable<TPrimitive>
            {
                return operation.Invoke<TNumber, TPrimitive>(numArg, numArg);
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

            public TNumber Invoke<TNumber, TPrimitive>(in TNumber arg1, in TNumber arg2) where TNumber : struct, INumber<TNumber, TPrimitive> where TPrimitive : struct, IEquatable<TPrimitive>, IComparable<TPrimitive>
            {
                return operation.Invoke<TNumber, TPrimitive>(arg1);
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

            public TNumber Invoke<TNumber, TPrimitive>(in TNumber arg1, in TNumber arg2) where TNumber : struct, INumber<TNumber, TPrimitive> where TPrimitive : struct, IEquatable<TPrimitive>, IComparable<TPrimitive>
            {
                return operation.Invoke<TNumber, TPrimitive>();
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

            public TNumber Invoke<TNumber, TPrimitive>(in TNumber arg1, in TNumber arg2) where TNumber : struct, INumber<TNumber, TPrimitive> where TPrimitive : struct, IEquatable<TPrimitive>, IComparable<TPrimitive>
            {
                return operation.Invoke<TNumber, TPrimitive>(arg2, arg1);
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

            public TNumber Invoke<TNumber, TPrimitive>(in TNumber numArg) where TNumber : struct, INumber<TNumber, TPrimitive> where TPrimitive : struct, IEquatable<TPrimitive>, IComparable<TPrimitive>
            {
                return outer.Invoke<TNumber, TPrimitive>(inner.Invoke<TNumber, TPrimitive>(numArg));
            }

            public override string ToString()
            {
                return outer.ToString() + "(" + inner.ToString() + ")";
            }
        }

        private class UnaryNullaryOperation : DynamicNumberOperation<INumberOperation>, INumberOperation
        {
            readonly IUnaryNumberOperation outer;
            readonly INumberOperation inner;

            public UnaryNullaryOperation(IUnaryNumberOperation outer, INumberOperation inner)
            {
                this.outer = outer;
                this.inner = inner;
            }

            public TNumber Invoke<TNumber>() where TNumber : struct, INumber<TNumber>
            {
                return outer.Invoke<TNumber>(inner.Invoke<TNumber>());
            }

            public TNumber Invoke<TNumber, TPrimitive>() where TNumber : struct, INumber<TNumber, TPrimitive> where TPrimitive : struct, IEquatable<TPrimitive>, IComparable<TPrimitive>
            {
                return outer.Invoke<TNumber, TPrimitive>(inner.Invoke<TNumber, TPrimitive>());
            }

            public override string ToString()
            {
                return outer.ToString() + "(" + inner.ToString() + ")";
            }
        }

        private class BinaryNullaryNullaryOperation : DynamicNumberOperation<INumberOperation>, INumberOperation
        {
            readonly IBinaryNumberOperation outer;
            readonly INumberOperation left;
            readonly INumberOperation right;

            public BinaryNullaryNullaryOperation(IBinaryNumberOperation outer, INumberOperation left, INumberOperation right)
            {
                this.outer = outer;
                this.left = left;
                this.right = right;
            }

            public TNumber Invoke<TNumber>() where TNumber : struct, INumber<TNumber>
            {
                return outer.Invoke<TNumber>(left.Invoke<TNumber>(), right.Invoke<TNumber>());
            }

            public TNumber Invoke<TNumber, TPrimitive>() where TNumber : struct, INumber<TNumber, TPrimitive> where TPrimitive : struct, IEquatable<TPrimitive>, IComparable<TPrimitive>
            {
                return outer.Invoke<TNumber, TPrimitive>(left.Invoke<TNumber, TPrimitive>(), right.Invoke<TNumber, TPrimitive>());
            }

            public override string ToString()
            {
                return outer.ToString() + "(" + (left?.ToString() ?? "Id") + ", " + (right?.ToString() ?? "Id") + ")";
            }
        }

        private class BinaryUnaryNullaryOperation : DynamicNumberOperation<IUnaryNumberOperation>, IUnaryNumberOperation
        {
            readonly IBinaryNumberOperation outer;
            readonly IUnaryNumberOperation left;
            readonly INumberOperation right;

            public BinaryUnaryNullaryOperation(IBinaryNumberOperation outer, IUnaryNumberOperation left, INumberOperation right)
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

            public TNumber Invoke<TNumber, TPrimitive>(in TNumber num) where TNumber : struct, INumber<TNumber, TPrimitive> where TPrimitive : struct, IEquatable<TPrimitive>, IComparable<TPrimitive>
            {
                if(left == null)
                {
                    return outer.Invoke<TNumber, TPrimitive>(num, right.Invoke<TNumber, TPrimitive>());
                }else{
                    return outer.Invoke<TNumber, TPrimitive>(left.Invoke<TNumber, TPrimitive>(num), right.Invoke<TNumber, TPrimitive>());
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

            public TNumber Invoke<TNumber, TPrimitive>(in TNumber num) where TNumber : struct, INumber<TNumber, TPrimitive> where TPrimitive : struct, IEquatable<TPrimitive>, IComparable<TPrimitive>
            {
                if(right == null)
                {
                    return outer.Invoke<TNumber, TPrimitive>(left.Invoke<TNumber, TPrimitive>(), num);
                }else{
                    return outer.Invoke<TNumber, TPrimitive>(left.Invoke<TNumber, TPrimitive>(), right.Invoke<TNumber, TPrimitive>(num));
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

            public TNumber Invoke<TNumber, TPrimitive>(in TNumber num) where TNumber : struct, INumber<TNumber, TPrimitive> where TPrimitive : struct, IEquatable<TPrimitive>, IComparable<TPrimitive>
            {
                if(left == null)
                {
                    if(right == null)
                    {
                        return outer.Invoke<TNumber, TPrimitive>(num, num);
                    }else{
                        return outer.Invoke<TNumber, TPrimitive>(num, right.Invoke<TNumber, TPrimitive>(num));
                    }
                }else{
                    if(right == null)
                    {
                        return outer.Invoke<TNumber, TPrimitive>(left.Invoke<TNumber, TPrimitive>(num), num);
                    }else{
                        return outer.Invoke<TNumber, TPrimitive>(left.Invoke<TNumber, TPrimitive>(num), right.Invoke<TNumber, TPrimitive>(num));
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

            public TNumber Invoke<TNumber, TPrimitive>(in TNumber arg1, in TNumber arg2) where TNumber : struct, INumber<TNumber, TPrimitive> where TPrimitive : struct, IEquatable<TPrimitive>, IComparable<TPrimitive>
            {
                return outer.Invoke<TNumber, TPrimitive>(left.Invoke<TNumber, TPrimitive>(arg1, arg2), right.Invoke<TNumber, TPrimitive>(arg1, arg2));
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

            public TNumber Invoke<TNumber, TPrimitive>(in TNumber arg1, in TNumber arg2) where TNumber : struct, INumber<TNumber, TPrimitive> where TPrimitive : struct, IEquatable<TPrimitive>, IComparable<TPrimitive>
            {
                return outer.Invoke<TNumber, TPrimitive>(inner.Invoke<TNumber, TPrimitive>(arg1, arg2));
            }

            public override string ToString()
            {
                return outer.ToString() + "(" + inner.ToString() + ")";
            }
        }

        public static IPrimitiveNumberOperation AsOperation(this Func<PrimitiveAbstractNumber> func)
        {
            if(func == null)
            {
                throw new ArgumentNullException(nameof(func));
            }
            return new PrimitiveFuncAsNullaryOperation(func);
        }

        public static PrimitiveAbstractNumber AsNumber(this IPrimitiveNumberOperation operation)
        {
            if(operation == null)
            {
                throw new ArgumentNullException(nameof(operation));
            }
            return new PrimitiveAbstractNumber(operation);
        }

        public static PrimitiveUnaryAbstractNumber AsNumber(this IPrimitiveUnaryNumberOperation operation)
        {
            if(operation == null)
            {
                throw new ArgumentNullException(nameof(operation));
            }
            return new PrimitiveUnaryAbstractNumber(operation);
        }

        public static PrimitiveBinaryAbstractNumber AsNumber(this IPrimitiveBinaryNumberOperation operation)
        {
            if(operation == null)
            {
                throw new ArgumentNullException(nameof(operation));
            }
            return new PrimitiveBinaryAbstractNumber(operation);
        }

        public static IPrimitiveUnaryNumberOperation AsUnary(this IPrimitiveNumberOperation operation)
        {
            if(operation == null)
            {
                throw new ArgumentNullException(nameof(operation));
            }
            return new PrimitiveNullaryAsUnaryOperation(operation);
        }

        public static IPrimitiveUnaryNumberOperation AsUnary(this IPrimitiveBinaryNumberOperation operation)
        {
            if(operation == null)
            {
                throw new ArgumentNullException(nameof(operation));
            }
            return new PrimitiveBinaryAsUnaryOperation(operation);
        }

        public static IPrimitiveBinaryNumberOperation AsBinary(this IPrimitiveUnaryNumberOperation operation)
        {
            if(operation == null)
            {
                throw new ArgumentNullException(nameof(operation));
            }
            return new PrimitiveUnaryAsBinaryOperation(operation);
        }

        public static IPrimitiveBinaryNumberOperation AsBinary(this IPrimitiveNumberOperation operation)
        {
            if(operation == null)
            {
                throw new ArgumentNullException(nameof(operation));
            }
            return new PrimitiveNullaryAsBinaryOperation(operation);
        }

        public static IPrimitiveBinaryNumberOperation Swap(this IPrimitiveBinaryNumberOperation operation)
        {
            if(operation == null)
            {
                throw new ArgumentNullException(nameof(operation));
            }
            return new PrimitiveSwapOperation(operation);
        }

        public static IPrimitiveUnaryNumberOperation Apply(this IPrimitiveUnaryNumberOperation outer, IPrimitiveUnaryNumberOperation inner)
        {
            if(outer == null)
            {
                throw new ArgumentNullException(nameof(outer));
            }
            if(inner == null)
            {
                throw new ArgumentNullException(nameof(inner));
            }
            return new PrimitiveUnaryUnaryOperation(outer, inner);
        }

        public static IPrimitiveNumberOperation Apply(this IPrimitiveUnaryNumberOperation outer, IPrimitiveNumberOperation inner)
        {
            if(outer == null)
            {
                throw new ArgumentNullException(nameof(outer));
            }
            if(inner == null)
            {
                throw new ArgumentNullException(nameof(inner));
            }
            return new PrimitiveUnaryNullaryOperation(outer, inner);
        }

        public static IPrimitiveNumberOperation Apply(this IPrimitiveBinaryNumberOperation outer, IPrimitiveNumberOperation left, IPrimitiveNumberOperation right)
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
            return new PrimitiveBinaryNullaryNullaryOperation(outer, left, right);
        }

        public static IPrimitiveUnaryNumberOperation Apply(this IPrimitiveBinaryNumberOperation outer, IPrimitiveUnaryNumberOperation left, IPrimitiveNumberOperation right)
        {
            if(outer == null)
            {
                throw new ArgumentNullException(nameof(outer));
            }
            if(right == null)
            {
                throw new ArgumentNullException(nameof(right));
            }
            return new PrimitiveBinaryUnaryNullaryOperation(outer, left, right);
        }

        public static IPrimitiveUnaryNumberOperation Apply(this IPrimitiveBinaryNumberOperation outer, IPrimitiveNumberOperation left, IPrimitiveUnaryNumberOperation right)
        {
            if(outer == null)
            {
                throw new ArgumentNullException(nameof(outer));
            }
            if(left == null)
            {
                throw new ArgumentNullException(nameof(left));
            }
            return new PrimitiveBinaryNullaryUnaryOperation(outer, left, right);
        }

        public static IPrimitiveUnaryNumberOperation Apply(this IPrimitiveBinaryNumberOperation outer, IPrimitiveUnaryNumberOperation left, IPrimitiveUnaryNumberOperation right)
        {
            if(outer == null)
            {
                throw new ArgumentNullException(nameof(outer));
            }
            return new PrimitiveBinaryUnaryUnaryOperation(outer, left, right);
        }

        public static IPrimitiveBinaryNumberOperation Apply(this IPrimitiveBinaryNumberOperation outer, IPrimitiveBinaryNumberOperation left, IPrimitiveBinaryNumberOperation right)
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
            return new PrimitiveBinaryBinaryBinaryOperation(outer, left, right);
        }

        public static IPrimitiveBinaryNumberOperation Apply(this IPrimitiveUnaryNumberOperation outer, IPrimitiveBinaryNumberOperation inner)
        {
            if(outer == null)
            {
                throw new ArgumentNullException(nameof(outer));
            }
            if(inner == null)
            {
                throw new ArgumentNullException(nameof(inner));
            }
            return new PrimitiveUnaryBinaryOperation(outer, inner);
        }

        private class PrimitiveFuncAsNullaryOperation : DynamicNumberOperation<IPrimitiveNumberOperation>, IPrimitiveNumberOperation
        {
            readonly Func<PrimitiveAbstractNumber> func;

            public PrimitiveFuncAsNullaryOperation(Func<PrimitiveAbstractNumber> func)
            {
                this.func = func;
            }

            public TNumber Invoke<TNumber, TPrimitive>() where TNumber : struct, INumber<TNumber, TPrimitive> where TPrimitive : struct, IEquatable<TPrimitive>, IComparable<TPrimitive>
            {
                return func().Invoke<TNumber, TPrimitive>();
            }

            public override string ToString()
            {
                return func.ToString();
            }
        }

        private class PrimitiveNullaryAsUnaryOperation : DynamicNumberOperation<IPrimitiveUnaryNumberOperation>, IPrimitiveUnaryNumberOperation
        {
            readonly IPrimitiveNumberOperation operation;

            public PrimitiveNullaryAsUnaryOperation(IPrimitiveNumberOperation operation)
            {
                this.operation = operation;
            }

            public TNumber Invoke<TNumber, TPrimitive>(in TNumber numArg) where TNumber : struct, INumber<TNumber, TPrimitive> where TPrimitive : struct, IEquatable<TPrimitive>, IComparable<TPrimitive>
            {
                return operation.Invoke<TNumber, TPrimitive>();
            }

            public override string ToString()
            {
                return operation.ToString();
            }
        }

        private class PrimitiveBinaryAsUnaryOperation : DynamicNumberOperation<IPrimitiveUnaryNumberOperation>, IPrimitiveUnaryNumberOperation
        {
            readonly IPrimitiveBinaryNumberOperation operation;

            public PrimitiveBinaryAsUnaryOperation(IPrimitiveBinaryNumberOperation operation)
            {
                this.operation = operation;
            }

            public TNumber Invoke<TNumber, TPrimitive>(in TNumber numArg) where TNumber : struct, INumber<TNumber, TPrimitive> where TPrimitive : struct, IEquatable<TPrimitive>, IComparable<TPrimitive>
            {
                return operation.Invoke<TNumber, TPrimitive>(numArg, numArg);
            }

            public override string ToString()
            {
                return operation.ToString();
            }
        }

        private class PrimitiveUnaryAsBinaryOperation : DynamicNumberOperation<IBinaryNumberOperation>, IPrimitiveBinaryNumberOperation
        {
            readonly IPrimitiveUnaryNumberOperation operation;

            public PrimitiveUnaryAsBinaryOperation(IPrimitiveUnaryNumberOperation operation)
            {
                this.operation = operation;
            }

            public TNumber Invoke<TNumber, TPrimitive>(in TNumber arg1, in TNumber arg2) where TNumber : struct, INumber<TNumber, TPrimitive> where TPrimitive : struct, IEquatable<TPrimitive>, IComparable<TPrimitive>
            {
                return operation.Invoke<TNumber, TPrimitive>(arg1);
            }

            public override string ToString()
            {
                return operation.ToString();
            }
        }

        private class PrimitiveNullaryAsBinaryOperation : DynamicNumberOperation<IPrimitiveBinaryNumberOperation>, IPrimitiveBinaryNumberOperation
        {
            readonly IPrimitiveNumberOperation operation;

            public PrimitiveNullaryAsBinaryOperation(IPrimitiveNumberOperation operation)
            {
                this.operation = operation;
            }

            public TNumber Invoke<TNumber, TPrimitive>(in TNumber arg1, in TNumber arg2) where TNumber : struct, INumber<TNumber, TPrimitive> where TPrimitive : struct, IEquatable<TPrimitive>, IComparable<TPrimitive>
            {
                return operation.Invoke<TNumber, TPrimitive>();
            }

            public override string ToString()
            {
                return operation.ToString();
            }
        }

        private class PrimitiveSwapOperation : DynamicNumberOperation<IPrimitiveBinaryNumberOperation>, IPrimitiveBinaryNumberOperation
        {
            readonly IPrimitiveBinaryNumberOperation operation;

            public PrimitiveSwapOperation(IPrimitiveBinaryNumberOperation operation)
            {
                this.operation = operation;
            }

            public TNumber Invoke<TNumber, TPrimitive>(in TNumber arg1, in TNumber arg2) where TNumber : struct, INumber<TNumber, TPrimitive> where TPrimitive : struct, IEquatable<TPrimitive>, IComparable<TPrimitive>
            {
                return operation.Invoke<TNumber, TPrimitive>(arg2, arg1);
            }

            public override string ToString()
            {
                return "Swap(" + operation.ToString() + ")";
            }
        }

        private class PrimitiveUnaryUnaryOperation : DynamicNumberOperation<IPrimitiveUnaryNumberOperation>, IPrimitiveUnaryNumberOperation
        {
            readonly IPrimitiveUnaryNumberOperation outer;
            readonly IPrimitiveUnaryNumberOperation inner;

            public PrimitiveUnaryUnaryOperation(IPrimitiveUnaryNumberOperation outer, IPrimitiveUnaryNumberOperation inner)
            {
                this.outer = outer;
                this.inner = inner;
            }

            public TNumber Invoke<TNumber, TPrimitive>(in TNumber numArg) where TNumber : struct, INumber<TNumber, TPrimitive> where TPrimitive : struct, IEquatable<TPrimitive>, IComparable<TPrimitive>
            {
                return outer.Invoke<TNumber, TPrimitive>(inner.Invoke<TNumber, TPrimitive>(numArg));
            }

            public override string ToString()
            {
                return outer.ToString() + "(" + inner.ToString() + ")";
            }
        }

        private class PrimitiveUnaryNullaryOperation : DynamicNumberOperation<IPrimitiveNumberOperation>, IPrimitiveNumberOperation
        {
            readonly IPrimitiveUnaryNumberOperation outer;
            readonly IPrimitiveNumberOperation inner;

            public PrimitiveUnaryNullaryOperation(IPrimitiveUnaryNumberOperation outer, IPrimitiveNumberOperation inner)
            {
                this.outer = outer;
                this.inner = inner;
            }

            public TNumber Invoke<TNumber, TPrimitive>() where TNumber : struct, INumber<TNumber, TPrimitive> where TPrimitive : struct, IEquatable<TPrimitive>, IComparable<TPrimitive>
            {
                return outer.Invoke<TNumber, TPrimitive>(inner.Invoke<TNumber, TPrimitive>());
            }

            public override string ToString()
            {
                return outer.ToString() + "(" + inner.ToString() + ")";
            }
        }

        private class PrimitiveBinaryNullaryNullaryOperation : DynamicNumberOperation<IPrimitiveNumberOperation>, IPrimitiveNumberOperation
        {
            readonly IPrimitiveBinaryNumberOperation outer;
            readonly IPrimitiveNumberOperation left;
            readonly IPrimitiveNumberOperation right;

            public PrimitiveBinaryNullaryNullaryOperation(IPrimitiveBinaryNumberOperation outer, IPrimitiveNumberOperation left, IPrimitiveNumberOperation right)
            {
                this.outer = outer;
                this.left = left;
                this.right = right;
            }
            
            public TNumber Invoke<TNumber, TPrimitive>() where TNumber : struct, INumber<TNumber, TPrimitive> where TPrimitive : struct, IEquatable<TPrimitive>, IComparable<TPrimitive>
            {
                return outer.Invoke<TNumber, TPrimitive>(left.Invoke<TNumber, TPrimitive>(), right.Invoke<TNumber, TPrimitive>());
            }

            public override string ToString()
            {
                return outer.ToString() + "(" + (left?.ToString() ?? "Id") + ", " + (right?.ToString() ?? "Id") + ")";
            }
        }

        private class PrimitiveBinaryUnaryNullaryOperation : DynamicNumberOperation<IPrimitiveUnaryNumberOperation>, IPrimitiveUnaryNumberOperation
        {
            readonly IPrimitiveBinaryNumberOperation outer;
            readonly IPrimitiveUnaryNumberOperation left;
            readonly IPrimitiveNumberOperation right;

            public PrimitiveBinaryUnaryNullaryOperation(IPrimitiveBinaryNumberOperation outer, IPrimitiveUnaryNumberOperation left, IPrimitiveNumberOperation right)
            {
                this.outer = outer;
                this.left = left;
                this.right = right;
            }

            public TNumber Invoke<TNumber, TPrimitive>(in TNumber num) where TNumber : struct, INumber<TNumber, TPrimitive> where TPrimitive : struct, IEquatable<TPrimitive>, IComparable<TPrimitive>
            {
                if(left == null)
                {
                    return outer.Invoke<TNumber, TPrimitive>(num, right.Invoke<TNumber, TPrimitive>());
                }else{
                    return outer.Invoke<TNumber, TPrimitive>(left.Invoke<TNumber, TPrimitive>(num), right.Invoke<TNumber, TPrimitive>());
                }
            }

            public override string ToString()
            {
                return outer.ToString() + "(" + (left?.ToString() ?? "Id") + ", " + (right?.ToString() ?? "Id") + ")";
            }
        }

        private class PrimitiveBinaryNullaryUnaryOperation : DynamicNumberOperation<IPrimitiveUnaryNumberOperation>, IPrimitiveUnaryNumberOperation
        {
            readonly IPrimitiveBinaryNumberOperation outer;
            readonly IPrimitiveNumberOperation left;
            readonly IPrimitiveUnaryNumberOperation right;

            public PrimitiveBinaryNullaryUnaryOperation(IPrimitiveBinaryNumberOperation outer, IPrimitiveNumberOperation left, IPrimitiveUnaryNumberOperation right)
            {
                this.outer = outer;
                this.left = left;
                this.right = right;
            }

            public TNumber Invoke<TNumber, TPrimitive>(in TNumber num) where TNumber : struct, INumber<TNumber, TPrimitive> where TPrimitive : struct, IEquatable<TPrimitive>, IComparable<TPrimitive>
            {
                if(right == null)
                {
                    return outer.Invoke<TNumber, TPrimitive>(left.Invoke<TNumber, TPrimitive>(), num);
                }else{
                    return outer.Invoke<TNumber, TPrimitive>(left.Invoke<TNumber, TPrimitive>(), right.Invoke<TNumber, TPrimitive>(num));
                }
            }

            public override string ToString()
            {
                return outer.ToString() + "(" + (left?.ToString() ?? "Id") + ", " + (right?.ToString() ?? "Id") + ")";
            }
        }

        private class PrimitiveBinaryUnaryUnaryOperation : DynamicNumberOperation<IPrimitiveUnaryNumberOperation>, IPrimitiveUnaryNumberOperation
        {
            readonly IPrimitiveBinaryNumberOperation outer;
            readonly IPrimitiveUnaryNumberOperation left;
            readonly IPrimitiveUnaryNumberOperation right;

            public PrimitiveBinaryUnaryUnaryOperation(IPrimitiveBinaryNumberOperation outer, IPrimitiveUnaryNumberOperation left, IPrimitiveUnaryNumberOperation right)
            {
                this.outer = outer;
                this.left = left;
                this.right = right;
            }

            public TNumber Invoke<TNumber, TPrimitive>(in TNumber num) where TNumber : struct, INumber<TNumber, TPrimitive> where TPrimitive : struct, IEquatable<TPrimitive>, IComparable<TPrimitive>
            {
                if(left == null)
                {
                    if(right == null)
                    {
                        return outer.Invoke<TNumber, TPrimitive>(num, num);
                    }else{
                        return outer.Invoke<TNumber, TPrimitive>(num, right.Invoke<TNumber, TPrimitive>(num));
                    }
                }else{
                    if(right == null)
                    {
                        return outer.Invoke<TNumber, TPrimitive>(left.Invoke<TNumber, TPrimitive>(num), num);
                    }else{
                        return outer.Invoke<TNumber, TPrimitive>(left.Invoke<TNumber, TPrimitive>(num), right.Invoke<TNumber, TPrimitive>(num));
                    }
                }
            }

            public override string ToString()
            {
                return outer.ToString() + "(" + (left?.ToString() ?? "Id") + ", " + (right?.ToString() ?? "Id") + ")";
            }
        }

        private class PrimitiveBinaryBinaryBinaryOperation : DynamicNumberOperation<IPrimitiveBinaryNumberOperation>, IPrimitiveBinaryNumberOperation
        {
            readonly IPrimitiveBinaryNumberOperation outer;
            readonly IPrimitiveBinaryNumberOperation left;
            readonly IPrimitiveBinaryNumberOperation right;

            public PrimitiveBinaryBinaryBinaryOperation(IPrimitiveBinaryNumberOperation outer, IPrimitiveBinaryNumberOperation left, IPrimitiveBinaryNumberOperation right)
            {
                this.outer = outer;
                this.left = left;
                this.right = right;
            }

            public TNumber Invoke<TNumber, TPrimitive>(in TNumber arg1, in TNumber arg2) where TNumber : struct, INumber<TNumber, TPrimitive> where TPrimitive : struct, IEquatable<TPrimitive>, IComparable<TPrimitive>
            {
                return outer.Invoke<TNumber, TPrimitive>(left.Invoke<TNumber, TPrimitive>(arg1, arg2), right.Invoke<TNumber, TPrimitive>(arg1, arg2));
            }

            public override string ToString()
            {
                return outer.ToString() + "(" + (left?.ToString() ?? "Id") + ", " + (right?.ToString() ?? "Id") + ")";
            }
        }

        private class PrimitiveUnaryBinaryOperation : DynamicNumberOperation<IPrimitiveBinaryNumberOperation>, IPrimitiveBinaryNumberOperation
        {
            readonly IPrimitiveUnaryNumberOperation outer;
            readonly IPrimitiveBinaryNumberOperation inner;

            public PrimitiveUnaryBinaryOperation(IPrimitiveUnaryNumberOperation outer, IPrimitiveBinaryNumberOperation inner)
            {
                this.outer = outer;
                this.inner = inner;
            }

            public TNumber Invoke<TNumber, TPrimitive>(in TNumber arg1, in TNumber arg2) where TNumber : struct, INumber<TNumber, TPrimitive> where TPrimitive : struct, IEquatable<TPrimitive>, IComparable<TPrimitive>
            {
                return outer.Invoke<TNumber, TPrimitive>(inner.Invoke<TNumber, TPrimitive>(arg1, arg2));
            }

            public override string ToString()
            {
                return outer.ToString() + "(" + inner.ToString() + ")";
            }
        }
    }
}
