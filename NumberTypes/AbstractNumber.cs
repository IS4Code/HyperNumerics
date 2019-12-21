using IS4.HyperNumerics.Operations;
using System;
using System.Dynamic;
using System.Linq.Expressions;
using System.Reflection;

namespace IS4.HyperNumerics.NumberTypes
{
    [Serializable]
    public readonly struct AbstractNumber : INumber<AbstractNumber>, INumberOperation, IDynamicMetaObjectProvider
    {
        private readonly INumberOperation operation;

        public INumberOperation Operation => operation ?? HyperMath.Operations.Zero;

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

        object ICloneable.Clone()
        {
            return Clone();
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

        public bool Equals(AbstractNumber other)
        {
            return Equals(in other);
        }

        public bool Equals(in AbstractNumber other)
        {
            return Operation.Equals(other.Operation);
        }

        public int CompareTo(AbstractNumber other)
        {
            return 0;
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

        public static bool operator==(AbstractNumber a, AbstractNumber b)
        {
            return a.Equals(in b);
        }

        public static bool operator!=(AbstractNumber a, AbstractNumber b)
        {
            return !a.Equals(in b);
        }

        public static bool operator>(AbstractNumber a, AbstractNumber b)
        {
            return a.CompareTo(in b) > 0;
        }

        public static bool operator<(AbstractNumber a, AbstractNumber b)
        {
            return a.CompareTo(in b) < 0;
        }

        public static bool operator>=(AbstractNumber a, AbstractNumber b)
        {
            return a.CompareTo(in b) >= 0;
        }

        public static bool operator<=(AbstractNumber a, AbstractNumber b)
        {
            return a.CompareTo(in b) <= 0;
        }

        INumberOperations INumber.GetOperations()
        {
            return Operations.Instance;
        }

        INumberOperations<AbstractNumber> INumber<AbstractNumber>.GetOperations()
        {
            return Operations.Instance;
        }

        class Operations : NumberOperations<AbstractNumber>, INumberOperations<AbstractNumber>
        {
            public static readonly Operations Instance = new Operations();

            public override int Dimension => -1;

            public bool IsInvertible(in AbstractNumber num)
            {
                return num.IsInvertible;
            }

            public bool IsFinite(in AbstractNumber num)
            {
                return num.IsFinite;
            }

            public AbstractNumber Call(NullaryOperation operation)
            {
                return new AbstractNumber(HyperMath.Operations.GetOperation(operation));
            }

            public AbstractNumber Call(UnaryOperation operation, in AbstractNumber num)
            {
                return num.Call(operation);
            }

            public AbstractNumber Call(BinaryOperation operation, in AbstractNumber num1, in AbstractNumber num2)
            {
                return num1.Call(operation, num2);
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
            private static readonly PropertyInfo OperationProperty = NumberType.GetProperty(nameof(Operation));

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
                var expression = Expression.Call(Expression.Property(Expression.Convert(Expression, NumberType), OperationProperty), method);
                return new DynamicMetaObject(Expression.Convert(expression, binder.ReturnType), restrictions);
            }
        }
    }
    
    [Serializable]
    public readonly struct PrimitiveAbstractNumber : INumber<PrimitiveAbstractNumber>, IPrimitiveNumberOperation, IDynamicMetaObjectProvider
    {
        private readonly IPrimitiveNumberOperation operation;

        public IPrimitiveNumberOperation Operation => operation ?? HyperMath.Operations.Zero;

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

        object ICloneable.Clone()
        {
            return Clone();
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

        public bool Equals(PrimitiveAbstractNumber other)
        {
            return Equals(in other);
        }

        public bool Equals(in PrimitiveAbstractNumber other)
        {
            return Operation.Equals(other.Operation);
        }

        public int CompareTo(PrimitiveAbstractNumber other)
        {
            return 0;
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

        public static implicit operator PrimitiveAbstractNumber(AbstractNumber num)
        {
            return new PrimitiveAbstractNumber(num.Operation);
        }

        public static bool operator==(PrimitiveAbstractNumber a, PrimitiveAbstractNumber b)
        {
            return a.Equals(in b);
        }

        public static bool operator!=(PrimitiveAbstractNumber a, PrimitiveAbstractNumber b)
        {
            return !a.Equals(in b);
        }

        public static bool operator>(PrimitiveAbstractNumber a, PrimitiveAbstractNumber b)
        {
            return a.CompareTo(in b) > 0;
        }

        public static bool operator<(PrimitiveAbstractNumber a, PrimitiveAbstractNumber b)
        {
            return a.CompareTo(in b) < 0;
        }

        public static bool operator>=(PrimitiveAbstractNumber a, PrimitiveAbstractNumber b)
        {
            return a.CompareTo(in b) >= 0;
        }

        public static bool operator<=(PrimitiveAbstractNumber a, PrimitiveAbstractNumber b)
        {
            return a.CompareTo(in b) <= 0;
        }

        INumberOperations INumber.GetOperations()
        {
            return Operations.Instance;
        }

        INumberOperations<PrimitiveAbstractNumber> INumber<PrimitiveAbstractNumber>.GetOperations()
        {
            return Operations.Instance;
        }

        class Operations : NumberOperations<PrimitiveAbstractNumber>, INumberOperations<PrimitiveAbstractNumber>
        {
            public static readonly Operations Instance = new Operations();

            public override int Dimension => -1;

            public bool IsInvertible(in PrimitiveAbstractNumber num)
            {
                return num.IsInvertible;
            }

            public bool IsFinite(in PrimitiveAbstractNumber num)
            {
                return num.IsFinite;
            }

            public PrimitiveAbstractNumber Call(NullaryOperation operation)
            {
                return new PrimitiveAbstractNumber(HyperMath.Operations.GetOperation(operation));
            }

            public PrimitiveAbstractNumber Call(UnaryOperation operation, in PrimitiveAbstractNumber num)
            {
                return num.Call(operation);
            }

            public PrimitiveAbstractNumber Call(BinaryOperation operation, in PrimitiveAbstractNumber num1, in PrimitiveAbstractNumber num2)
            {
                return num1.Call(operation, num2);
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
            private static readonly PropertyInfo OperationProperty = NumberType.GetProperty(nameof(Operation));

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
                var expression = Expression.Call(Expression.Property(Expression.Convert(Expression, NumberType), OperationProperty), method);
                return new DynamicMetaObject(Expression.Convert(expression, binder.ReturnType), restrictions);
            }
        }
    }
    
    [Serializable]
    public readonly struct UnaryAbstractNumber : INumber<UnaryAbstractNumber>, IUnaryNumberOperation
    {
        private readonly IUnaryNumberOperation operation;

        public IUnaryNumberOperation Operation => operation ?? HyperMath.Operations.Zero.AsUnary();

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

        object ICloneable.Clone()
        {
            return Clone();
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

        public bool Equals(UnaryAbstractNumber other)
        {
            return Equals(in other);
        }

        public bool Equals(in UnaryAbstractNumber other)
        {
            return Operation.Equals(other.Operation);
        }

        public int CompareTo(UnaryAbstractNumber other)
        {
            return 0;
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

        public static implicit operator UnaryAbstractNumber(AbstractNumber num)
        {
            return new UnaryAbstractNumber(num.Operation.AsUnary());
        }

        public static bool operator==(UnaryAbstractNumber a, UnaryAbstractNumber b)
        {
            return a.Equals(in b);
        }

        public static bool operator!=(UnaryAbstractNumber a, UnaryAbstractNumber b)
        {
            return !a.Equals(in b);
        }

        public static bool operator>(UnaryAbstractNumber a, UnaryAbstractNumber b)
        {
            return a.CompareTo(in b) > 0;
        }

        public static bool operator<(UnaryAbstractNumber a, UnaryAbstractNumber b)
        {
            return a.CompareTo(in b) < 0;
        }

        public static bool operator>=(UnaryAbstractNumber a, UnaryAbstractNumber b)
        {
            return a.CompareTo(in b) >= 0;
        }

        public static bool operator<=(UnaryAbstractNumber a, UnaryAbstractNumber b)
        {
            return a.CompareTo(in b) <= 0;
        }

        INumberOperations INumber.GetOperations()
        {
            return Operations.Instance;
        }

        INumberOperations<UnaryAbstractNumber> INumber<UnaryAbstractNumber>.GetOperations()
        {
            return Operations.Instance;
        }

        class Operations : NumberOperations<UnaryAbstractNumber>, INumberOperations<UnaryAbstractNumber>
        {
            public static readonly Operations Instance = new Operations();

            public override int Dimension => -1;

            public bool IsInvertible(in UnaryAbstractNumber num)
            {
                return num.IsInvertible;
            }

            public bool IsFinite(in UnaryAbstractNumber num)
            {
                return num.IsFinite;
            }

            public UnaryAbstractNumber Call(NullaryOperation operation)
            {
                return new UnaryAbstractNumber(HyperMath.Operations.GetOperation(operation).AsUnary());
            }

            public UnaryAbstractNumber Call(UnaryOperation operation, in UnaryAbstractNumber num)
            {
                return num.Call(operation);
            }

            public UnaryAbstractNumber Call(BinaryOperation operation, in UnaryAbstractNumber num1, in UnaryAbstractNumber num2)
            {
                return num1.Call(operation, num2);
            }
        }
    }
    
    [Serializable]
    public readonly struct PrimitiveUnaryAbstractNumber : INumber<PrimitiveUnaryAbstractNumber>, IPrimitiveUnaryNumberOperation
    {
        private readonly IPrimitiveUnaryNumberOperation operation;

        public IPrimitiveUnaryNumberOperation Operation => operation ?? HyperMath.Operations.Zero.AsUnary();

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

        object ICloneable.Clone()
        {
            return Clone();
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

        public bool Equals(PrimitiveUnaryAbstractNumber other)
        {
            return Equals(in other);
        }

        public bool Equals(in PrimitiveUnaryAbstractNumber other)
        {
            return Operation.Equals(other.Operation);
        }

        public int CompareTo(PrimitiveUnaryAbstractNumber other)
        {
            return 0;
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

        public static bool operator==(PrimitiveUnaryAbstractNumber a, PrimitiveUnaryAbstractNumber b)
        {
            return a.Equals(in b);
        }

        public static bool operator!=(PrimitiveUnaryAbstractNumber a, PrimitiveUnaryAbstractNumber b)
        {
            return !a.Equals(in b);
        }

        public static bool operator>(PrimitiveUnaryAbstractNumber a, PrimitiveUnaryAbstractNumber b)
        {
            return a.CompareTo(in b) > 0;
        }

        public static bool operator<(PrimitiveUnaryAbstractNumber a, PrimitiveUnaryAbstractNumber b)
        {
            return a.CompareTo(in b) < 0;
        }

        public static bool operator>=(PrimitiveUnaryAbstractNumber a, PrimitiveUnaryAbstractNumber b)
        {
            return a.CompareTo(in b) >= 0;
        }

        public static bool operator<=(PrimitiveUnaryAbstractNumber a, PrimitiveUnaryAbstractNumber b)
        {
            return a.CompareTo(in b) <= 0;
        }

        INumberOperations INumber.GetOperations()
        {
            return Operations.Instance;
        }

        INumberOperations<PrimitiveUnaryAbstractNumber> INumber<PrimitiveUnaryAbstractNumber>.GetOperations()
        {
            return Operations.Instance;
        }

        class Operations : NumberOperations<PrimitiveUnaryAbstractNumber>, INumberOperations<PrimitiveUnaryAbstractNumber>
        {
            public static readonly Operations Instance = new Operations();

            public override int Dimension => -1;

            public bool IsInvertible(in PrimitiveUnaryAbstractNumber num)
            {
                return num.IsInvertible;
            }

            public bool IsFinite(in PrimitiveUnaryAbstractNumber num)
            {
                return num.IsFinite;
            }

            public PrimitiveUnaryAbstractNumber Call(NullaryOperation operation)
            {
                return new PrimitiveUnaryAbstractNumber(HyperMath.Operations.GetOperation(operation).AsUnary());
            }

            public PrimitiveUnaryAbstractNumber Call(UnaryOperation operation, in PrimitiveUnaryAbstractNumber num)
            {
                return num.Call(operation);
            }

            public PrimitiveUnaryAbstractNumber Call(BinaryOperation operation, in PrimitiveUnaryAbstractNumber num1, in PrimitiveUnaryAbstractNumber num2)
            {
                return num1.Call(operation, num2);
            }
        }
    }
    
    [Serializable]
    public readonly struct BinaryAbstractNumber : INumber<BinaryAbstractNumber>, IBinaryNumberOperation
    {
        private readonly IBinaryNumberOperation operation;

        public IBinaryNumberOperation Operation => operation ?? HyperMath.Operations.Zero.AsBinary();

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

        object ICloneable.Clone()
        {
            return Clone();
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

        public bool Equals(BinaryAbstractNumber other)
        {
            return Equals(in other);
        }

        public bool Equals(in BinaryAbstractNumber other)
        {
            return Operation.Equals(other.Operation);
        }

        public int CompareTo(BinaryAbstractNumber other)
        {
            return 0;
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

        public static implicit operator BinaryAbstractNumber(AbstractNumber num)
        {
            return new BinaryAbstractNumber(num.Operation.AsBinary());
        }

        public static bool operator==(BinaryAbstractNumber a, BinaryAbstractNumber b)
        {
            return a.Equals(in b);
        }

        public static bool operator!=(BinaryAbstractNumber a, BinaryAbstractNumber b)
        {
            return !a.Equals(in b);
        }

        public static bool operator>(BinaryAbstractNumber a, BinaryAbstractNumber b)
        {
            return a.CompareTo(in b) > 0;
        }

        public static bool operator<(BinaryAbstractNumber a, BinaryAbstractNumber b)
        {
            return a.CompareTo(in b) < 0;
        }

        public static bool operator>=(BinaryAbstractNumber a, BinaryAbstractNumber b)
        {
            return a.CompareTo(in b) >= 0;
        }

        public static bool operator<=(BinaryAbstractNumber a, BinaryAbstractNumber b)
        {
            return a.CompareTo(in b) <= 0;
        }

        INumberOperations INumber.GetOperations()
        {
            return Operations.Instance;
        }

        INumberOperations<BinaryAbstractNumber> INumber<BinaryAbstractNumber>.GetOperations()
        {
            return Operations.Instance;
        }

        class Operations : NumberOperations<BinaryAbstractNumber>, INumberOperations<BinaryAbstractNumber>
        {
            public static readonly Operations Instance = new Operations();

            public override int Dimension => -1;

            public bool IsInvertible(in BinaryAbstractNumber num)
            {
                return num.IsInvertible;
            }

            public bool IsFinite(in BinaryAbstractNumber num)
            {
                return num.IsFinite;
            }

            public BinaryAbstractNumber Call(NullaryOperation operation)
            {
                return new BinaryAbstractNumber(HyperMath.Operations.GetOperation(operation).AsBinary());
            }

            public BinaryAbstractNumber Call(UnaryOperation operation, in BinaryAbstractNumber num)
            {
                return num.Call(operation);
            }

            public BinaryAbstractNumber Call(BinaryOperation operation, in BinaryAbstractNumber num1, in BinaryAbstractNumber num2)
            {
                return num1.Call(operation, num2);
            }
        }
    }
    
    [Serializable]
    public readonly struct PrimitiveBinaryAbstractNumber : INumber<PrimitiveBinaryAbstractNumber>, IPrimitiveBinaryNumberOperation
    {
        private readonly IPrimitiveBinaryNumberOperation operation;

        public IPrimitiveBinaryNumberOperation Operation => operation ?? HyperMath.Operations.Zero.AsBinary();

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

        object ICloneable.Clone()
        {
            return Clone();
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

        public bool Equals(PrimitiveBinaryAbstractNumber other)
        {
            return Equals(in other);
        }

        public bool Equals(in PrimitiveBinaryAbstractNumber other)
        {
            return Operation.Equals(other.Operation);
        }

        public int CompareTo(PrimitiveBinaryAbstractNumber other)
        {
            return 0;
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

        public static implicit operator PrimitiveBinaryAbstractNumber(AbstractNumber num)
        {
            return new PrimitiveBinaryAbstractNumber(num.Operation.AsBinary());
        }

        public static implicit operator PrimitiveBinaryAbstractNumber(BinaryAbstractNumber num)
        {
            return new PrimitiveBinaryAbstractNumber(num.Operation);
        }

        public static implicit operator PrimitiveBinaryAbstractNumber(PrimitiveAbstractNumber num)
        {
            return new PrimitiveBinaryAbstractNumber(num.Operation.AsBinary());
        }

        public static bool operator==(PrimitiveBinaryAbstractNumber a, PrimitiveBinaryAbstractNumber b)
        {
            return a.Equals(in b);
        }

        public static bool operator!=(PrimitiveBinaryAbstractNumber a, PrimitiveBinaryAbstractNumber b)
        {
            return !a.Equals(in b);
        }

        public static bool operator>(PrimitiveBinaryAbstractNumber a, PrimitiveBinaryAbstractNumber b)
        {
            return a.CompareTo(in b) > 0;
        }

        public static bool operator<(PrimitiveBinaryAbstractNumber a, PrimitiveBinaryAbstractNumber b)
        {
            return a.CompareTo(in b) < 0;
        }

        public static bool operator>=(PrimitiveBinaryAbstractNumber a, PrimitiveBinaryAbstractNumber b)
        {
            return a.CompareTo(in b) >= 0;
        }

        public static bool operator<=(PrimitiveBinaryAbstractNumber a, PrimitiveBinaryAbstractNumber b)
        {
            return a.CompareTo(in b) <= 0;
        }

        INumberOperations INumber.GetOperations()
        {
            return Operations.Instance;
        }

        INumberOperations<PrimitiveBinaryAbstractNumber> INumber<PrimitiveBinaryAbstractNumber>.GetOperations()
        {
            return Operations.Instance;
        }

        class Operations : NumberOperations<PrimitiveBinaryAbstractNumber>, INumberOperations<PrimitiveBinaryAbstractNumber>
        {
            public static readonly Operations Instance = new Operations();

            public override int Dimension => -1;

            public bool IsInvertible(in PrimitiveBinaryAbstractNumber num)
            {
                return num.IsInvertible;
            }

            public bool IsFinite(in PrimitiveBinaryAbstractNumber num)
            {
                return num.IsFinite;
            }

            public PrimitiveBinaryAbstractNumber Call(NullaryOperation operation)
            {
                return new PrimitiveBinaryAbstractNumber(HyperMath.Operations.GetOperation(operation).AsBinary());
            }

            public PrimitiveBinaryAbstractNumber Call(UnaryOperation operation, in PrimitiveBinaryAbstractNumber num)
            {
                return num.Call(operation);
            }

            public PrimitiveBinaryAbstractNumber Call(BinaryOperation operation, in PrimitiveBinaryAbstractNumber num1, in PrimitiveBinaryAbstractNumber num2)
            {
                return num1.Call(operation, num2);
            }
        }
    }
}
