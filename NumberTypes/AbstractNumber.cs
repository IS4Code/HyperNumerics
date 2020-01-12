using IS4.HyperNumerics.Operations;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq.Expressions;
using System.Reflection;

namespace IS4.HyperNumerics.NumberTypes
{
    /// <summary>
    /// Represents a number formed by invoking a constructed nullary operation (<see cref="INumberOperation"/>), i.e. the result of an expression.
    /// This type supports dynamic dispatch – a dynamic cast to a valid number type will produce a number
    /// of that type by calling <see cref="INumberOperation.Invoke{TNumber}"/> on the operation.
    /// </summary>
    [Serializable]
    public readonly partial struct AbstractNumber : INumber<AbstractNumber>, INumberOperation, IDynamicMetaObjectProvider
    {
        private readonly INumberOperation operation;

        public INumberOperation Operation => operation ?? HyperMath.Operations.Default;

        public bool IsInvertible => true;

        public bool IsFinite => true;

        int INumber.Dimension => -1;

        public AbstractNumber(INumberOperation operation)
        {
            if(operation == null)
            {
                throw new ArgumentNullException(nameof(operation));
            }
            this.operation = operation;
        }

        public AbstractNumber Clone()
        {
            if(Operation is ICloneable cloneable)
            {
                return new AbstractNumber((INumberOperation)cloneable.Clone());
            }
            return this;
        }

        public TNumber Invoke<TNumber>() where TNumber : struct, INumber<TNumber>
        {
            return Operation.Invoke<TNumber>();
        }

        public TNumber Invoke<TNumber, TPrimitive>() where TNumber : struct, INumber<TNumber, TPrimitive> where TPrimitive : struct, IEquatable<TPrimitive>, IComparable<TPrimitive>
        {
            return Operation.Invoke<TNumber, TPrimitive>();
        }

        public AbstractNumber Call(BinaryOperation operation, in AbstractNumber other)
        {
            return new AbstractNumber(HyperMath.Operations.GetOperation(operation).Apply(Operation, other.Operation));
        }

        public AbstractNumber Call(UnaryOperation operation)
        {
            return new AbstractNumber(HyperMath.Operations.GetOperation(operation).Apply(Operation));
        }

        public override bool Equals(object obj)
        {
            return obj is AbstractNumber value && Equals(in value);
        }

        public bool Equals(in AbstractNumber other)
        {
            return Operation.Equals(other.Operation);
        }

        public int CompareTo(in AbstractNumber other)
        {
            return 0;
        }

        public override int GetHashCode()
        {
            return Operation.GetHashCode();
        }

        public override string ToString()
        {
            return Operation.ToString();
        }

        public string ToString(string format, IFormatProvider formatProvider)
        {
            return Operation.ToString();
        }

        partial class Operations : NumberOperations<AbstractNumber>, INumberOperations<AbstractNumber>
        {
            public override int Dimension => -1;

            public AbstractNumber Call(NullaryOperation operation)
            {
                return new AbstractNumber(HyperMath.Operations.GetOperation(operation));
            }
        }

        DynamicMetaObject IDynamicMetaObjectProvider.GetMetaObject(Expression parameter)
        {
            return new MetaObject(parameter, this);
        }

        class MetaObject : DynamicMetaObject
        {
            private static readonly Type InterfaceType = typeof(INumberOperation);
            private static readonly MethodInfo Invoke = InterfaceType.GetMethod(nameof(INumberOperation.Invoke), BindingFlags.Public | BindingFlags.Instance | BindingFlags.DeclaredOnly);
            private static readonly Type NumberType = typeof(AbstractNumber);

            public MetaObject(Expression expression, INumber<AbstractNumber> value) : base(expression, BindingRestrictions.GetTypeRestriction(expression, NumberType), value)
            {

            }

            public override DynamicMetaObject BindConvert(ConvertBinder binder)
            {
                MethodInfo method;
                try{
                    method = Invoke.MakeGenericMethod(binder.Type);
                }catch(ArgumentException)
                {
                    return base.BindConvert(binder);
                }
                var restrictions = BindingRestrictions.GetTypeRestriction(Expression, LimitType);
                var expression = Expression.Call(Expression.Convert(Expression, InterfaceType), method);
                return new DynamicMetaObject(Expression.Convert(expression, binder.ReturnType), restrictions);
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            yield return this;
        }
    }

    /// <summary>
    /// Represents a number formed by invoking a constructed nullary operation (<see cref="IPrimitiveNumberOperation"/>), i.e. the result of an expression.
    /// This type supports dynamic dispatch – a dynamic cast to a valid number type will produce a number
    /// of that type by calling <see cref="IPrimitiveNumberOperation.Invoke{TNumber, TPrimitive}"/> on the operation.
    /// </summary>
    [Serializable]
    public readonly partial struct PrimitiveAbstractNumber : IWrapperNumber<PrimitiveAbstractNumber, PrimitiveAbstractNumber, PrimitiveAbstractNumber>, IPrimitiveNumberOperation, IDynamicMetaObjectProvider
    {
        private readonly IPrimitiveNumberOperation operation;

        public IPrimitiveNumberOperation Operation => operation ?? HyperMath.Operations.Default;

        public bool IsInvertible => true;

        public bool IsFinite => true;

        int INumber.Dimension => -1;

        public PrimitiveAbstractNumber(IPrimitiveNumberOperation operation)
        {
            if(operation == null)
            {
                throw new ArgumentNullException(nameof(operation));
            }
            this.operation = operation;
        }

        public PrimitiveAbstractNumber Clone()
        {
            if(Operation is ICloneable cloneable)
            {
                return new PrimitiveAbstractNumber((IPrimitiveNumberOperation)cloneable.Clone());
            }
            return this;
        }

        public static implicit operator PrimitiveAbstractNumber(AbstractNumber num)
        {
            return new PrimitiveAbstractNumber(num.Operation);
        }

        public TNumber Invoke<TNumber, TPrimitive>() where TNumber : struct, INumber<TNumber, TPrimitive> where TPrimitive : struct, IEquatable<TPrimitive>, IComparable<TPrimitive>
        {
            return Operation.Invoke<TNumber, TPrimitive>();
        }

        public PrimitiveAbstractNumber Call(BinaryOperation operation, in PrimitiveAbstractNumber other)
        {
            return new PrimitiveAbstractNumber(HyperMath.Operations.GetOperation(operation).Apply(Operation, other.Operation));
        }

        public PrimitiveAbstractNumber Call(UnaryOperation operation)
        {
            return new PrimitiveAbstractNumber(HyperMath.Operations.GetOperation(operation).Apply(Operation));
        }

        public override bool Equals(object obj)
        {
            return obj is PrimitiveAbstractNumber value && Equals(in value);
        }

        public bool Equals(in PrimitiveAbstractNumber other)
        {
            return Operation.Equals(other.Operation);
        }

        public int CompareTo(in PrimitiveAbstractNumber other)
        {
            return 0;
        }

        public override int GetHashCode()
        {
            return Operation.GetHashCode();
        }

        public override string ToString()
        {
            return Operation.ToString();
        }

        public string ToString(string format, IFormatProvider formatProvider)
        {
            return Operation.ToString();
        }

        partial class Operations : NumberOperations<PrimitiveAbstractNumber>, IExtendedNumberOperations<PrimitiveAbstractNumber, PrimitiveAbstractNumber, PrimitiveAbstractNumber>
        {
            public override int Dimension => -1;

            public PrimitiveAbstractNumber Call(NullaryOperation operation)
            {
                return new PrimitiveAbstractNumber(HyperMath.Operations.GetOperation(operation));
            }
        }

        DynamicMetaObject IDynamicMetaObjectProvider.GetMetaObject(Expression parameter)
        {
            return new MetaObject(parameter, this);
        }

        class MetaObject : DynamicMetaObject
        {
            private static readonly Type InterfaceType = typeof(IPrimitiveNumberOperation);
            private static readonly MethodInfo Invoke = InterfaceType.GetMethod(nameof(IPrimitiveNumberOperation.Invoke), BindingFlags.Public | BindingFlags.Instance | BindingFlags.DeclaredOnly);
            private static readonly Type NumberType = typeof(PrimitiveAbstractNumber);

            public MetaObject(Expression expression, INumber<PrimitiveAbstractNumber> value) : base(expression, BindingRestrictions.GetTypeRestriction(expression, NumberType), value)
            {

            }

            public override DynamicMetaObject BindConvert(ConvertBinder binder)
            {
                MethodInfo method;
                try{
                    method = Invoke.MakeGenericMethod(binder.Type, TypeTools.GetPrimitiveType(binder.Type));
                }catch(ArgumentException)
                {
                    return base.BindConvert(binder);
                }
                var restrictions = BindingRestrictions.GetTypeRestriction(Expression, LimitType);
                var expression = Expression.Call(Expression.Convert(Expression, InterfaceType), method);
                return new DynamicMetaObject(Expression.Convert(expression, binder.ReturnType), restrictions);
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            yield return this;
        }
    }

    /// <summary>
    /// Represents a number formed by invoking a constructed unary operation (<see cref="IUnaryNumberOperation"/>), i.e. the result of an expression
    /// with a single variable.
    /// </summary>
    [Serializable]
    public readonly partial struct UnaryAbstractNumber : IWrapperNumber<UnaryAbstractNumber, UnaryAbstractNumber>, IUnaryNumberOperation
    {
        private readonly IUnaryNumberOperation operation;

        public IUnaryNumberOperation Operation => operation ?? HyperMath.Operations.Default.AsUnary();

        public bool IsInvertible => true;

        public bool IsFinite => true;

        int INumber.Dimension => -1;

        public UnaryAbstractNumber(IUnaryNumberOperation operation)
        {
            if(operation == null)
            {
                throw new ArgumentNullException(nameof(operation));
            }
            this.operation = operation;
        }

        public UnaryAbstractNumber Clone()
        {
            if(Operation is ICloneable cloneable)
            {
                return new UnaryAbstractNumber((IUnaryNumberOperation)cloneable.Clone());
            }
            return this;
        }

        public static implicit operator UnaryAbstractNumber(AbstractNumber num)
        {
            return new UnaryAbstractNumber(num.Operation.AsUnary());
        }

        public TNumber Invoke<TNumber>(in TNumber num) where TNumber : struct, INumber<TNumber>
        {
            return Operation.Invoke<TNumber>(num);
        }

        public TNumber Invoke<TNumber, TPrimitive>(in TNumber num) where TNumber : struct, INumber<TNumber, TPrimitive> where TPrimitive : struct, IEquatable<TPrimitive>, IComparable<TPrimitive>
        {
            return Operation.Invoke<TNumber, TPrimitive>(num);
        }

        public UnaryAbstractNumber Call(BinaryOperation operation, in UnaryAbstractNumber other)
        {
            return new UnaryAbstractNumber(HyperMath.Operations.GetOperation(operation).Apply(Operation, other.Operation));
        }

        public UnaryAbstractNumber Call(UnaryOperation operation)
        {
            return new UnaryAbstractNumber(HyperMath.Operations.GetOperation(operation).Apply(Operation));
        }

        public override bool Equals(object obj)
        {
            return obj is UnaryAbstractNumber value && Equals(in value);
        }

        public bool Equals(in UnaryAbstractNumber other)
        {
            return Operation.Equals(other.Operation);
        }

        public int CompareTo(in UnaryAbstractNumber other)
        {
            return 0;
        }

        public override int GetHashCode()
        {
            return Operation.GetHashCode();
        }

        public override string ToString()
        {
            return Operation.ToString();
        }

        public string ToString(string format, IFormatProvider formatProvider)
        {
            return Operation.ToString();
        }

        partial class Operations : NumberOperations<UnaryAbstractNumber>, IExtendedNumberOperations<UnaryAbstractNumber, UnaryAbstractNumber>
        {
            public override int Dimension => -1;

            public UnaryAbstractNumber Call(NullaryOperation operation)
            {
                return new UnaryAbstractNumber(HyperMath.Operations.GetOperation(operation).AsUnary());
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            yield return this;
        }
    }

    /// <summary>
    /// Represents a number formed by invoking a constructed unary operation (<see cref="IPrimitiveUnaryNumberOperation"/>), i.e. the result of an expression
    /// with a single variable.
    /// </summary>
    [Serializable]
    public readonly partial struct PrimitiveUnaryAbstractNumber : IWrapperNumber<PrimitiveUnaryAbstractNumber, PrimitiveUnaryAbstractNumber, PrimitiveUnaryAbstractNumber>, IPrimitiveUnaryNumberOperation
    {
        private readonly IPrimitiveUnaryNumberOperation operation;

        public IPrimitiveUnaryNumberOperation Operation => operation ?? HyperMath.Operations.Default.AsUnary();

        public bool IsInvertible => true;

        public bool IsFinite => true;

        int INumber.Dimension => -1;

        public PrimitiveUnaryAbstractNumber(IPrimitiveUnaryNumberOperation operation)
        {
            if(operation == null)
            {
                throw new ArgumentNullException(nameof(operation));
            }
            this.operation = operation;
        }

        public PrimitiveUnaryAbstractNumber Clone()
        {
            if(Operation is ICloneable cloneable)
            {
                return new PrimitiveUnaryAbstractNumber((IPrimitiveUnaryNumberOperation)cloneable.Clone());
            }
            return this;
        }

        public static implicit operator PrimitiveUnaryAbstractNumber(AbstractNumber num)
        {
            return new PrimitiveUnaryAbstractNumber(num.Operation.AsUnary());
        }

        public static implicit operator PrimitiveUnaryAbstractNumber(UnaryAbstractNumber num)
        {
            return new PrimitiveUnaryAbstractNumber(num.Operation);
        }

        public static implicit operator PrimitiveUnaryAbstractNumber(PrimitiveAbstractNumber num)
        {
            return new PrimitiveUnaryAbstractNumber(num.Operation.AsUnary());
        }

        public TNumber Invoke<TNumber, TPrimitive>(in TNumber num) where TNumber : struct, INumber<TNumber, TPrimitive> where TPrimitive : struct, IEquatable<TPrimitive>, IComparable<TPrimitive>
        {
            return Operation.Invoke<TNumber, TPrimitive>(num);
        }

        public PrimitiveUnaryAbstractNumber Call(BinaryOperation operation, in PrimitiveUnaryAbstractNumber other)
        {
            return new PrimitiveUnaryAbstractNumber(HyperMath.Operations.GetOperation(operation).Apply(Operation, other.Operation));
        }

        public PrimitiveUnaryAbstractNumber Call(UnaryOperation operation)
        {
            return new PrimitiveUnaryAbstractNumber(HyperMath.Operations.GetOperation(operation).Apply(Operation));
        }

        public override bool Equals(object obj)
        {
            return obj is PrimitiveUnaryAbstractNumber value && Equals(in value);
        }

        public bool Equals(in PrimitiveUnaryAbstractNumber other)
        {
            return Operation.Equals(other.Operation);
        }

        public int CompareTo(in PrimitiveUnaryAbstractNumber other)
        {
            return 0;
        }

        public override int GetHashCode()
        {
            return Operation.GetHashCode();
        }

        public override string ToString()
        {
            return Operation.ToString();
        }

        public string ToString(string format, IFormatProvider formatProvider)
        {
            return Operation.ToString();
        }

        partial class Operations : NumberOperations<PrimitiveUnaryAbstractNumber>, IExtendedNumberOperations<PrimitiveUnaryAbstractNumber, PrimitiveUnaryAbstractNumber, PrimitiveUnaryAbstractNumber>
        {
            public override int Dimension => -1;

            public PrimitiveUnaryAbstractNumber Call(NullaryOperation operation)
            {
                return new PrimitiveUnaryAbstractNumber(HyperMath.Operations.GetOperation(operation).AsUnary());
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            yield return this;
        }
    }

    /// <summary>
    /// Represents a number formed by invoking a constructed binary operation (<see cref="IBinaryNumberOperation"/>), i.e. the result of an expression
    /// with two variables.
    /// </summary>
    [Serializable]
    public readonly partial struct BinaryAbstractNumber : IWrapperNumber<BinaryAbstractNumber, BinaryAbstractNumber>, IBinaryNumberOperation
    {
        private readonly IBinaryNumberOperation operation;

        public IBinaryNumberOperation Operation => operation ?? HyperMath.Operations.Default.AsBinary();

        public bool IsInvertible => true;

        public bool IsFinite => true;

        int INumber.Dimension => -1;

        public BinaryAbstractNumber(IBinaryNumberOperation operation)
        {
            if(operation == null)
            {
                throw new ArgumentNullException(nameof(operation));
            }
            this.operation = operation;
        }

        public BinaryAbstractNumber Clone()
        {
            if(Operation is ICloneable cloneable)
            {
                return new BinaryAbstractNumber((IBinaryNumberOperation)cloneable.Clone());
            }
            return this;
        }

        public static implicit operator BinaryAbstractNumber(AbstractNumber num)
        {
            return new BinaryAbstractNumber(num.Operation.AsBinary());
        }

        public static implicit operator BinaryAbstractNumber(UnaryAbstractNumber num)
        {
            return new BinaryAbstractNumber(num.Operation.AsBinary());
        }

        public TNumber Invoke<TNumber>(in TNumber numArg1, in TNumber numArg2) where TNumber : struct, INumber<TNumber>
        {
            return Operation.Invoke<TNumber>(numArg1, numArg2);
        }

        public TNumber Invoke<TNumber, TPrimitive>(in TNumber numArg1, in TNumber numArg2) where TNumber : struct, INumber<TNumber, TPrimitive> where TPrimitive : struct, IEquatable<TPrimitive>, IComparable<TPrimitive>
        {
            return Operation.Invoke<TNumber, TPrimitive>(numArg1, numArg2);
        }

        public BinaryAbstractNumber Call(BinaryOperation operation, in BinaryAbstractNumber other)
        {
            return new BinaryAbstractNumber(HyperMath.Operations.GetOperation(operation).Apply(Operation, other.Operation));
        }

        public BinaryAbstractNumber Call(UnaryOperation operation)
        {
            return new BinaryAbstractNumber(HyperMath.Operations.GetOperation(operation).Apply(Operation));
        }

        public override bool Equals(object obj)
        {
            return obj is BinaryAbstractNumber value && Equals(in value);
        }

        public bool Equals(in BinaryAbstractNumber other)
        {
            return Operation.Equals(other.Operation);
        }

        public int CompareTo(in BinaryAbstractNumber other)
        {
            return 0;
        }

        public override int GetHashCode()
        {
            return Operation.GetHashCode();
        }

        public override string ToString()
        {
            return Operation.ToString();
        }

        public string ToString(string format, IFormatProvider formatProvider)
        {
            return Operation.ToString();
        }

        partial class Operations : NumberOperations<BinaryAbstractNumber>, IExtendedNumberOperations<BinaryAbstractNumber, BinaryAbstractNumber>
        {
            public override int Dimension => -1;

            public BinaryAbstractNumber Call(NullaryOperation operation)
            {
                return new BinaryAbstractNumber(HyperMath.Operations.GetOperation(operation).AsBinary());
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            yield return this;
        }
    }

    /// <summary>
    /// Represents a number formed by invoking a constructed binary operation (<see cref="IPrimitiveBinaryNumberOperation"/>), i.e. the result of an expression
    /// with two variables.
    /// </summary>
    [Serializable]
    public readonly partial struct PrimitiveBinaryAbstractNumber : IWrapperNumber<PrimitiveBinaryAbstractNumber, PrimitiveBinaryAbstractNumber, PrimitiveBinaryAbstractNumber>, IPrimitiveBinaryNumberOperation
    {
        private readonly IPrimitiveBinaryNumberOperation operation;

        public IPrimitiveBinaryNumberOperation Operation => operation ?? HyperMath.Operations.Default.AsBinary();

        public bool IsInvertible => true;

        public bool IsFinite => true;

        int INumber.Dimension => -1;

        public PrimitiveBinaryAbstractNumber(IPrimitiveBinaryNumberOperation operation)
        {
            if(operation == null)
            {
                throw new ArgumentNullException(nameof(operation));
            }
            this.operation = operation;
        }

        public PrimitiveBinaryAbstractNumber Clone()
        {
            if(Operation is ICloneable cloneable)
            {
                return new PrimitiveBinaryAbstractNumber((IPrimitiveBinaryNumberOperation)cloneable.Clone());
            }
            return this;
        }

        public static implicit operator PrimitiveBinaryAbstractNumber(AbstractNumber num)
        {
            return new PrimitiveBinaryAbstractNumber(num.Operation.AsBinary());
        }

        public static implicit operator PrimitiveBinaryAbstractNumber(UnaryAbstractNumber num)
        {
            return new PrimitiveBinaryAbstractNumber(num.Operation.AsBinary());
        }

        public static implicit operator PrimitiveBinaryAbstractNumber(BinaryAbstractNumber num)
        {
            return new PrimitiveBinaryAbstractNumber(num.Operation);
        }

        public static implicit operator PrimitiveBinaryAbstractNumber(PrimitiveUnaryAbstractNumber num)
        {
            return new PrimitiveBinaryAbstractNumber(num.Operation.AsBinary());
        }

        public static implicit operator PrimitiveBinaryAbstractNumber(PrimitiveAbstractNumber num)
        {
            return new PrimitiveBinaryAbstractNumber(num.Operation.AsBinary());
        }

        public TNumber Invoke<TNumber, TPrimitive>(in TNumber numArg1, in TNumber numArg2) where TNumber : struct, INumber<TNumber, TPrimitive> where TPrimitive : struct, IEquatable<TPrimitive>, IComparable<TPrimitive>
        {
            return Operation.Invoke<TNumber, TPrimitive>(numArg1, numArg2);
        }

        public PrimitiveBinaryAbstractNumber Call(BinaryOperation operation, in PrimitiveBinaryAbstractNumber other)
        {
            return new PrimitiveBinaryAbstractNumber(HyperMath.Operations.GetOperation(operation).Apply(Operation, other.Operation));
        }

        public PrimitiveBinaryAbstractNumber Call(UnaryOperation operation)
        {
            return new PrimitiveBinaryAbstractNumber(HyperMath.Operations.GetOperation(operation).Apply(Operation));
        }

        public override bool Equals(object obj)
        {
            return obj is PrimitiveBinaryAbstractNumber value && Equals(in value);
        }

        public bool Equals(in PrimitiveBinaryAbstractNumber other)
        {
            return Operation.Equals(other.Operation);
        }

        public int CompareTo(in PrimitiveBinaryAbstractNumber other)
        {
            return 0;
        }

        public override int GetHashCode()
        {
            return Operation.GetHashCode();
        }

        public override string ToString()
        {
            return Operation.ToString();
        }

        public string ToString(string format, IFormatProvider formatProvider)
        {
            return Operation.ToString();
        }

        partial class Operations : NumberOperations<PrimitiveBinaryAbstractNumber>, IExtendedNumberOperations<PrimitiveBinaryAbstractNumber, PrimitiveBinaryAbstractNumber, PrimitiveBinaryAbstractNumber>
        {
            public override int Dimension => -1;

            public PrimitiveBinaryAbstractNumber Call(NullaryOperation operation)
            {
                return new PrimitiveBinaryAbstractNumber(HyperMath.Operations.GetOperation(operation).AsBinary());
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            yield return this;
        }
    }
}
