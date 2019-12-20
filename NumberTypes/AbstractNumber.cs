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
        public static AbstractNumber Zero => default;
        public static AbstractNumber RealOne => new AbstractNumber(HyperMath.Operations.RealOne);
        public static AbstractNumber SpecialOne => new AbstractNumber(HyperMath.Operations.SpecialOne);
        public static AbstractNumber UnitsOne => new AbstractNumber(HyperMath.Operations.UnitsOne);
        public static AbstractNumber NonRealUnitsOne => new AbstractNumber(HyperMath.Operations.NonRealUnitsOne);
        public static AbstractNumber CombinedOne => new AbstractNumber(HyperMath.Operations.CombinedOne);
        public static AbstractNumber AllOne => new AbstractNumber(HyperMath.Operations.AllOne);

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

        public AbstractNumber Add(in AbstractNumber other)
        {
            return new AbstractNumber(HyperMath.Operations.Add.Apply(Operation, other.Operation));
        }

        public AbstractNumber Subtract(in AbstractNumber other)
        {
            return new AbstractNumber(HyperMath.Operations.Sub.Apply(Operation, other.Operation));
        }

        public AbstractNumber Multiply(in AbstractNumber other)
        {
            return new AbstractNumber(HyperMath.Operations.Mul.Apply(Operation, other.Operation));
        }

        public AbstractNumber Divide(in AbstractNumber other)
        {
            return new AbstractNumber(HyperMath.Operations.Div.Apply(Operation, other.Operation));
        }

        public AbstractNumber Power(in AbstractNumber other)
        {
            return new AbstractNumber(HyperMath.Operations.Pow.Apply(Operation, other.Operation));
        }

        public AbstractNumber Negate()
        {
            return new AbstractNumber(HyperMath.Operations.Neg.Apply(Operation));
        }

        public AbstractNumber Increment()
        {
            return new AbstractNumber(HyperMath.Operations.Inc.Apply(Operation));
        }

        public AbstractNumber Decrement()
        {
            return new AbstractNumber(HyperMath.Operations.Dec.Apply(Operation));
        }

        public AbstractNumber Inverse()
        {
            return new AbstractNumber(HyperMath.Operations.Inv.Apply(Operation));
        }

        public AbstractNumber Conjugate()
        {
            return new AbstractNumber(HyperMath.Operations.Con.Apply(Operation));
        }

        public AbstractNumber Modulus()
        {
            return new AbstractNumber(HyperMath.Operations.Mods.Apply(Operation));
        }

        AbstractNumber INumber<AbstractNumber>.Half()
        {
            return new AbstractNumber(HyperMath.Operations.Div2.Apply(Operation));
        }

        AbstractNumber INumber<AbstractNumber>.Double()
        {
            return new AbstractNumber(HyperMath.Operations.Mul2.Apply(Operation));
        }

        AbstractNumber INumber<AbstractNumber>.Square()
        {
            return new AbstractNumber(HyperMath.Operations.Pow2.Apply(Operation));
        }

        AbstractNumber INumber<AbstractNumber>.SquareRoot()
        {
            return new AbstractNumber(HyperMath.Operations.Sqrt.Apply(Operation));
        }

        AbstractNumber INumber<AbstractNumber>.Exponentiate()
        {
            return new AbstractNumber(HyperMath.Operations.Exp.Apply(Operation));
        }

        AbstractNumber INumber<AbstractNumber>.Logarithm()
        {
            return new AbstractNumber(HyperMath.Operations.Log.Apply(Operation));
        }

        AbstractNumber INumber<AbstractNumber>.Sine()
        {
            return new AbstractNumber(HyperMath.Operations.Sin.Apply(Operation));
        }

        AbstractNumber INumber<AbstractNumber>.Cosine()
        {
            return new AbstractNumber(HyperMath.Operations.Cos.Apply(Operation));
        }

        AbstractNumber INumber<AbstractNumber>.Tangent()
        {
            return new AbstractNumber(HyperMath.Operations.Tan.Apply(Operation));
        }

        AbstractNumber INumber<AbstractNumber>.HyperbolicSine()
        {
            return new AbstractNumber(HyperMath.Operations.Sinh.Apply(Operation));
        }

        AbstractNumber INumber<AbstractNumber>.HyperbolicCosine()
        {
            return new AbstractNumber(HyperMath.Operations.Cosh.Apply(Operation));
        }

        AbstractNumber INumber<AbstractNumber>.HyperbolicTangent()
        {
            return new AbstractNumber(HyperMath.Operations.Tanh.Apply(Operation));
        }

        AbstractNumber INumber<AbstractNumber>.ArcSine()
        {
            return new AbstractNumber(HyperMath.Operations.Asin.Apply(Operation));
        }

        AbstractNumber INumber<AbstractNumber>.ArcCosine()
        {
            return new AbstractNumber(HyperMath.Operations.Acos.Apply(Operation));
        }

        AbstractNumber INumber<AbstractNumber>.ArcTangent()
        {
            return new AbstractNumber(HyperMath.Operations.Atan.Apply(Operation));
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

        public static AbstractNumber operator+(AbstractNumber a, AbstractNumber b)
        {
            return a.Add(b);
        }

        public static AbstractNumber operator-(AbstractNumber a, AbstractNumber b)
        {
            return a.Subtract(b);
        }

        public static AbstractNumber operator*(AbstractNumber a, AbstractNumber b)
        {
            return a.Multiply(b);
        }

        public static AbstractNumber operator/(AbstractNumber a, AbstractNumber b)
        {
            return a.Divide(b);
        }

        public static AbstractNumber operator^(AbstractNumber a, AbstractNumber b)
        {
            return a.Power(b);
        }

        public static AbstractNumber operator-(AbstractNumber a)
        {
            return a.Negate();
        }

        public static AbstractNumber operator++(AbstractNumber a)
        {
            return a.Increment();
        }

        public static AbstractNumber operator--(AbstractNumber a)
        {
            return a.Decrement();
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

        INumberFactory INumber.GetFactory()
        {
            return Factory.Instance;
        }

        INumberFactory<AbstractNumber> INumber<AbstractNumber>.GetFactory()
        {
            return Factory.Instance;
        }

        class Factory : INumberFactory<AbstractNumber>
        {
            public static readonly Factory Instance = new Factory();
            public AbstractNumber Zero => AbstractNumber.Zero;
            public AbstractNumber RealOne => AbstractNumber.RealOne;
            public AbstractNumber SpecialOne => AbstractNumber.SpecialOne;
            public AbstractNumber UnitsOne => AbstractNumber.UnitsOne;
            public AbstractNumber NonRealUnitsOne => AbstractNumber.NonRealUnitsOne;
            public AbstractNumber CombinedOne => AbstractNumber.CombinedOne;
            public AbstractNumber AllOne => AbstractNumber.AllOne;
            INumber INumberFactory.Zero => AbstractNumber.Zero;
            INumber INumberFactory.RealOne => AbstractNumber.RealOne;
            INumber INumberFactory.SpecialOne => AbstractNumber.SpecialOne;
            INumber INumberFactory.UnitsOne => AbstractNumber.UnitsOne;
            INumber INumberFactory.NonRealUnitsOne => AbstractNumber.NonRealUnitsOne;
            INumber INumberFactory.CombinedOne => AbstractNumber.CombinedOne;
            INumber INumberFactory.AllOne => AbstractNumber.AllOne;
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
        public static PrimitiveAbstractNumber Zero => default;
        public static PrimitiveAbstractNumber RealOne => new PrimitiveAbstractNumber(HyperMath.Operations.RealOne);
        public static PrimitiveAbstractNumber SpecialOne => new PrimitiveAbstractNumber(HyperMath.Operations.SpecialOne);
        public static PrimitiveAbstractNumber UnitsOne => new PrimitiveAbstractNumber(HyperMath.Operations.UnitsOne);
        public static PrimitiveAbstractNumber NonRealUnitsOne => new PrimitiveAbstractNumber(HyperMath.Operations.NonRealUnitsOne);
        public static PrimitiveAbstractNumber CombinedOne => new PrimitiveAbstractNumber(HyperMath.Operations.CombinedOne);
        public static PrimitiveAbstractNumber AllOne => new PrimitiveAbstractNumber(HyperMath.Operations.AllOne);

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

        public PrimitiveAbstractNumber Add(in PrimitiveAbstractNumber other)
        {
            return new PrimitiveAbstractNumber(HyperMath.Operations.Add.Apply(Operation, other.Operation));
        }

        public PrimitiveAbstractNumber Subtract(in PrimitiveAbstractNumber other)
        {
            return new PrimitiveAbstractNumber(HyperMath.Operations.Sub.Apply(Operation, other.Operation));
        }

        public PrimitiveAbstractNumber Multiply(in PrimitiveAbstractNumber other)
        {
            return new PrimitiveAbstractNumber(HyperMath.Operations.Mul.Apply(Operation, other.Operation));
        }

        public PrimitiveAbstractNumber Divide(in PrimitiveAbstractNumber other)
        {
            return new PrimitiveAbstractNumber(HyperMath.Operations.Div.Apply(Operation, other.Operation));
        }

        public PrimitiveAbstractNumber Power(in PrimitiveAbstractNumber other)
        {
            return new PrimitiveAbstractNumber(HyperMath.Operations.Pow.Apply(Operation, other.Operation));
        }

        public PrimitiveAbstractNumber Negate()
        {
            return new PrimitiveAbstractNumber(HyperMath.Operations.Neg.Apply(Operation));
        }

        public PrimitiveAbstractNumber Increment()
        {
            return new PrimitiveAbstractNumber(HyperMath.Operations.Inc.Apply(Operation));
        }

        public PrimitiveAbstractNumber Decrement()
        {
            return new PrimitiveAbstractNumber(HyperMath.Operations.Dec.Apply(Operation));
        }

        public PrimitiveAbstractNumber Inverse()
        {
            return new PrimitiveAbstractNumber(HyperMath.Operations.Inv.Apply(Operation));
        }

        public PrimitiveAbstractNumber Conjugate()
        {
            return new PrimitiveAbstractNumber(HyperMath.Operations.Con.Apply(Operation));
        }

        public PrimitiveAbstractNumber Modulus()
        {
            return new PrimitiveAbstractNumber(HyperMath.Operations.Mods.Apply(Operation));
        }

        PrimitiveAbstractNumber INumber<PrimitiveAbstractNumber>.Half()
        {
            return new PrimitiveAbstractNumber(HyperMath.Operations.Div2.Apply(Operation));
        }

        PrimitiveAbstractNumber INumber<PrimitiveAbstractNumber>.Double()
        {
            return new PrimitiveAbstractNumber(HyperMath.Operations.Mul2.Apply(Operation));
        }

        PrimitiveAbstractNumber INumber<PrimitiveAbstractNumber>.Square()
        {
            return new PrimitiveAbstractNumber(HyperMath.Operations.Pow2.Apply(Operation));
        }

        PrimitiveAbstractNumber INumber<PrimitiveAbstractNumber>.SquareRoot()
        {
            return new PrimitiveAbstractNumber(HyperMath.Operations.Sqrt.Apply(Operation));
        }

        PrimitiveAbstractNumber INumber<PrimitiveAbstractNumber>.Exponentiate()
        {
            return new PrimitiveAbstractNumber(HyperMath.Operations.Exp.Apply(Operation));
        }

        PrimitiveAbstractNumber INumber<PrimitiveAbstractNumber>.Logarithm()
        {
            return new PrimitiveAbstractNumber(HyperMath.Operations.Log.Apply(Operation));
        }

        PrimitiveAbstractNumber INumber<PrimitiveAbstractNumber>.Sine()
        {
            return new PrimitiveAbstractNumber(HyperMath.Operations.Sin.Apply(Operation));
        }

        PrimitiveAbstractNumber INumber<PrimitiveAbstractNumber>.Cosine()
        {
            return new PrimitiveAbstractNumber(HyperMath.Operations.Cos.Apply(Operation));
        }

        PrimitiveAbstractNumber INumber<PrimitiveAbstractNumber>.Tangent()
        {
            return new PrimitiveAbstractNumber(HyperMath.Operations.Tan.Apply(Operation));
        }

        PrimitiveAbstractNumber INumber<PrimitiveAbstractNumber>.HyperbolicSine()
        {
            return new PrimitiveAbstractNumber(HyperMath.Operations.Sinh.Apply(Operation));
        }

        PrimitiveAbstractNumber INumber<PrimitiveAbstractNumber>.HyperbolicCosine()
        {
            return new PrimitiveAbstractNumber(HyperMath.Operations.Cosh.Apply(Operation));
        }

        PrimitiveAbstractNumber INumber<PrimitiveAbstractNumber>.HyperbolicTangent()
        {
            return new PrimitiveAbstractNumber(HyperMath.Operations.Tanh.Apply(Operation));
        }

        PrimitiveAbstractNumber INumber<PrimitiveAbstractNumber>.ArcSine()
        {
            return new PrimitiveAbstractNumber(HyperMath.Operations.Asin.Apply(Operation));
        }

        PrimitiveAbstractNumber INumber<PrimitiveAbstractNumber>.ArcCosine()
        {
            return new PrimitiveAbstractNumber(HyperMath.Operations.Acos.Apply(Operation));
        }

        PrimitiveAbstractNumber INumber<PrimitiveAbstractNumber>.ArcTangent()
        {
            return new PrimitiveAbstractNumber(HyperMath.Operations.Atan.Apply(Operation));
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

        public static PrimitiveAbstractNumber operator+(PrimitiveAbstractNumber a, PrimitiveAbstractNumber b)
        {
            return a.Add(b);
        }

        public static PrimitiveAbstractNumber operator-(PrimitiveAbstractNumber a, PrimitiveAbstractNumber b)
        {
            return a.Subtract(b);
        }

        public static PrimitiveAbstractNumber operator*(PrimitiveAbstractNumber a, PrimitiveAbstractNumber b)
        {
            return a.Multiply(b);
        }

        public static PrimitiveAbstractNumber operator/(PrimitiveAbstractNumber a, PrimitiveAbstractNumber b)
        {
            return a.Divide(b);
        }

        public static PrimitiveAbstractNumber operator^(PrimitiveAbstractNumber a, PrimitiveAbstractNumber b)
        {
            return a.Power(b);
        }

        public static PrimitiveAbstractNumber operator-(PrimitiveAbstractNumber a)
        {
            return a.Negate();
        }

        public static PrimitiveAbstractNumber operator++(PrimitiveAbstractNumber a)
        {
            return a.Increment();
        }

        public static PrimitiveAbstractNumber operator--(PrimitiveAbstractNumber a)
        {
            return a.Decrement();
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

        INumberFactory INumber.GetFactory()
        {
            return Factory.Instance;
        }

        INumberFactory<PrimitiveAbstractNumber> INumber<PrimitiveAbstractNumber>.GetFactory()
        {
            return Factory.Instance;
        }

        class Factory : INumberFactory<PrimitiveAbstractNumber>
        {
            public static readonly Factory Instance = new Factory();
            public PrimitiveAbstractNumber Zero => PrimitiveAbstractNumber.Zero;
            public PrimitiveAbstractNumber RealOne => PrimitiveAbstractNumber.RealOne;
            public PrimitiveAbstractNumber SpecialOne => PrimitiveAbstractNumber.SpecialOne;
            public PrimitiveAbstractNumber UnitsOne => PrimitiveAbstractNumber.UnitsOne;
            public PrimitiveAbstractNumber NonRealUnitsOne => PrimitiveAbstractNumber.NonRealUnitsOne;
            public PrimitiveAbstractNumber CombinedOne => PrimitiveAbstractNumber.CombinedOne;
            public PrimitiveAbstractNumber AllOne => PrimitiveAbstractNumber.AllOne;
            INumber INumberFactory.Zero => PrimitiveAbstractNumber.Zero;
            INumber INumberFactory.RealOne => PrimitiveAbstractNumber.RealOne;
            INumber INumberFactory.SpecialOne => PrimitiveAbstractNumber.SpecialOne;
            INumber INumberFactory.UnitsOne => PrimitiveAbstractNumber.UnitsOne;
            INumber INumberFactory.NonRealUnitsOne => PrimitiveAbstractNumber.NonRealUnitsOne;
            INumber INumberFactory.CombinedOne => PrimitiveAbstractNumber.CombinedOne;
            INumber INumberFactory.AllOne => PrimitiveAbstractNumber.AllOne;
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
        public static UnaryAbstractNumber Zero => default;
        public static UnaryAbstractNumber RealOne => new UnaryAbstractNumber(HyperMath.Operations.RealOne.AsUnary());
        public static UnaryAbstractNumber SpecialOne => new UnaryAbstractNumber(HyperMath.Operations.SpecialOne.AsUnary());
        public static UnaryAbstractNumber UnitsOne => new UnaryAbstractNumber(HyperMath.Operations.UnitsOne.AsUnary());
        public static UnaryAbstractNumber NonRealUnitsOne => new UnaryAbstractNumber(HyperMath.Operations.NonRealUnitsOne.AsUnary());
        public static UnaryAbstractNumber CombinedOne => new UnaryAbstractNumber(HyperMath.Operations.CombinedOne.AsUnary());
        public static UnaryAbstractNumber AllOne => new UnaryAbstractNumber(HyperMath.Operations.AllOne.AsUnary());

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

        public UnaryAbstractNumber Add(in UnaryAbstractNumber other)
        {
            return new UnaryAbstractNumber(HyperMath.Operations.Add.Apply(Operation, other.Operation));
        }

        public UnaryAbstractNumber Subtract(in UnaryAbstractNumber other)
        {
            return new UnaryAbstractNumber(HyperMath.Operations.Sub.Apply(Operation, other.Operation));
        }

        public UnaryAbstractNumber Multiply(in UnaryAbstractNumber other)
        {
            return new UnaryAbstractNumber(HyperMath.Operations.Mul.Apply(Operation, other.Operation));
        }

        public UnaryAbstractNumber Divide(in UnaryAbstractNumber other)
        {
            return new UnaryAbstractNumber(HyperMath.Operations.Div.Apply(Operation, other.Operation));
        }

        public UnaryAbstractNumber Power(in UnaryAbstractNumber other)
        {
            return new UnaryAbstractNumber(HyperMath.Operations.Pow.Apply(Operation, other.Operation));
        }

        public UnaryAbstractNumber Negate()
        {
            return new UnaryAbstractNumber(HyperMath.Operations.Neg.Apply(Operation));
        }

        public UnaryAbstractNumber Increment()
        {
            return new UnaryAbstractNumber(HyperMath.Operations.Inc.Apply(Operation));
        }

        public UnaryAbstractNumber Decrement()
        {
            return new UnaryAbstractNumber(HyperMath.Operations.Dec.Apply(Operation));
        }

        public UnaryAbstractNumber Inverse()
        {
            return new UnaryAbstractNumber(HyperMath.Operations.Inv.Apply(Operation));
        }

        public UnaryAbstractNumber Conjugate()
        {
            return new UnaryAbstractNumber(HyperMath.Operations.Con.Apply(Operation));
        }

        public UnaryAbstractNumber Modulus()
        {
            return new UnaryAbstractNumber(HyperMath.Operations.Mods.Apply(Operation));
        }

        UnaryAbstractNumber INumber<UnaryAbstractNumber>.Half()
        {
            return new UnaryAbstractNumber(HyperMath.Operations.Div2.Apply(Operation));
        }

        UnaryAbstractNumber INumber<UnaryAbstractNumber>.Double()
        {
            return new UnaryAbstractNumber(HyperMath.Operations.Mul2.Apply(Operation));
        }

        UnaryAbstractNumber INumber<UnaryAbstractNumber>.Square()
        {
            return new UnaryAbstractNumber(HyperMath.Operations.Pow2.Apply(Operation));
        }

        UnaryAbstractNumber INumber<UnaryAbstractNumber>.SquareRoot()
        {
            return new UnaryAbstractNumber(HyperMath.Operations.Sqrt.Apply(Operation));
        }

        UnaryAbstractNumber INumber<UnaryAbstractNumber>.Exponentiate()
        {
            return new UnaryAbstractNumber(HyperMath.Operations.Exp.Apply(Operation));
        }

        UnaryAbstractNumber INumber<UnaryAbstractNumber>.Logarithm()
        {
            return new UnaryAbstractNumber(HyperMath.Operations.Log.Apply(Operation));
        }

        UnaryAbstractNumber INumber<UnaryAbstractNumber>.Sine()
        {
            return new UnaryAbstractNumber(HyperMath.Operations.Sin.Apply(Operation));
        }

        UnaryAbstractNumber INumber<UnaryAbstractNumber>.Cosine()
        {
            return new UnaryAbstractNumber(HyperMath.Operations.Cos.Apply(Operation));
        }

        UnaryAbstractNumber INumber<UnaryAbstractNumber>.Tangent()
        {
            return new UnaryAbstractNumber(HyperMath.Operations.Tan.Apply(Operation));
        }

        UnaryAbstractNumber INumber<UnaryAbstractNumber>.HyperbolicSine()
        {
            return new UnaryAbstractNumber(HyperMath.Operations.Sinh.Apply(Operation));
        }

        UnaryAbstractNumber INumber<UnaryAbstractNumber>.HyperbolicCosine()
        {
            return new UnaryAbstractNumber(HyperMath.Operations.Cosh.Apply(Operation));
        }

        UnaryAbstractNumber INumber<UnaryAbstractNumber>.HyperbolicTangent()
        {
            return new UnaryAbstractNumber(HyperMath.Operations.Tanh.Apply(Operation));
        }

        UnaryAbstractNumber INumber<UnaryAbstractNumber>.ArcSine()
        {
            return new UnaryAbstractNumber(HyperMath.Operations.Asin.Apply(Operation));
        }

        UnaryAbstractNumber INumber<UnaryAbstractNumber>.ArcCosine()
        {
            return new UnaryAbstractNumber(HyperMath.Operations.Acos.Apply(Operation));
        }

        UnaryAbstractNumber INumber<UnaryAbstractNumber>.ArcTangent()
        {
            return new UnaryAbstractNumber(HyperMath.Operations.Atan.Apply(Operation));
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

        public static UnaryAbstractNumber operator+(UnaryAbstractNumber a, UnaryAbstractNumber b)
        {
            return a.Add(b);
        }

        public static UnaryAbstractNumber operator-(UnaryAbstractNumber a, UnaryAbstractNumber b)
        {
            return a.Subtract(b);
        }

        public static UnaryAbstractNumber operator*(UnaryAbstractNumber a, UnaryAbstractNumber b)
        {
            return a.Multiply(b);
        }

        public static UnaryAbstractNumber operator/(UnaryAbstractNumber a, UnaryAbstractNumber b)
        {
            return a.Divide(b);
        }

        public static UnaryAbstractNumber operator^(UnaryAbstractNumber a, UnaryAbstractNumber b)
        {
            return a.Power(b);
        }

        public static UnaryAbstractNumber operator-(UnaryAbstractNumber a)
        {
            return a.Negate();
        }

        public static UnaryAbstractNumber operator++(UnaryAbstractNumber a)
        {
            return a.Increment();
        }

        public static UnaryAbstractNumber operator--(UnaryAbstractNumber a)
        {
            return a.Decrement();
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

        INumberFactory INumber.GetFactory()
        {
            return Factory.Instance;
        }

        INumberFactory<UnaryAbstractNumber> INumber<UnaryAbstractNumber>.GetFactory()
        {
            return Factory.Instance;
        }

        class Factory : INumberFactory<UnaryAbstractNumber>
        {
            public static readonly Factory Instance = new Factory();
            public UnaryAbstractNumber Zero => UnaryAbstractNumber.Zero;
            public UnaryAbstractNumber RealOne => UnaryAbstractNumber.RealOne;
            public UnaryAbstractNumber SpecialOne => UnaryAbstractNumber.SpecialOne;
            public UnaryAbstractNumber UnitsOne => UnaryAbstractNumber.UnitsOne;
            public UnaryAbstractNumber NonRealUnitsOne => UnaryAbstractNumber.NonRealUnitsOne;
            public UnaryAbstractNumber CombinedOne => UnaryAbstractNumber.CombinedOne;
            public UnaryAbstractNumber AllOne => UnaryAbstractNumber.AllOne;
            INumber INumberFactory.Zero => UnaryAbstractNumber.Zero;
            INumber INumberFactory.RealOne => UnaryAbstractNumber.RealOne;
            INumber INumberFactory.SpecialOne => UnaryAbstractNumber.SpecialOne;
            INumber INumberFactory.UnitsOne => UnaryAbstractNumber.UnitsOne;
            INumber INumberFactory.NonRealUnitsOne => UnaryAbstractNumber.NonRealUnitsOne;
            INumber INumberFactory.CombinedOne => UnaryAbstractNumber.CombinedOne;
            INumber INumberFactory.AllOne => UnaryAbstractNumber.AllOne;
        }
    }
    
    [Serializable]
    public readonly struct PrimitiveUnaryAbstractNumber : INumber<PrimitiveUnaryAbstractNumber>, IPrimitiveUnaryNumberOperation
    {
        public static PrimitiveUnaryAbstractNumber Zero => default;
        public static PrimitiveUnaryAbstractNumber RealOne => new PrimitiveUnaryAbstractNumber(HyperMath.Operations.RealOne.AsUnary());
        public static PrimitiveUnaryAbstractNumber SpecialOne => new PrimitiveUnaryAbstractNumber(HyperMath.Operations.SpecialOne.AsUnary());
        public static PrimitiveUnaryAbstractNumber UnitsOne => new PrimitiveUnaryAbstractNumber(HyperMath.Operations.UnitsOne.AsUnary());
        public static PrimitiveUnaryAbstractNumber NonRealUnitsOne => new PrimitiveUnaryAbstractNumber(HyperMath.Operations.NonRealUnitsOne.AsUnary());
        public static PrimitiveUnaryAbstractNumber CombinedOne => new PrimitiveUnaryAbstractNumber(HyperMath.Operations.CombinedOne.AsUnary());
        public static PrimitiveUnaryAbstractNumber AllOne => new PrimitiveUnaryAbstractNumber(HyperMath.Operations.AllOne.AsUnary());

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

        public PrimitiveUnaryAbstractNumber Add(in PrimitiveUnaryAbstractNumber other)
        {
            return new PrimitiveUnaryAbstractNumber(HyperMath.Operations.Add.Apply(Operation, other.Operation));
        }

        public PrimitiveUnaryAbstractNumber Subtract(in PrimitiveUnaryAbstractNumber other)
        {
            return new PrimitiveUnaryAbstractNumber(HyperMath.Operations.Sub.Apply(Operation, other.Operation));
        }

        public PrimitiveUnaryAbstractNumber Multiply(in PrimitiveUnaryAbstractNumber other)
        {
            return new PrimitiveUnaryAbstractNumber(HyperMath.Operations.Mul.Apply(Operation, other.Operation));
        }

        public PrimitiveUnaryAbstractNumber Divide(in PrimitiveUnaryAbstractNumber other)
        {
            return new PrimitiveUnaryAbstractNumber(HyperMath.Operations.Div.Apply(Operation, other.Operation));
        }

        public PrimitiveUnaryAbstractNumber Power(in PrimitiveUnaryAbstractNumber other)
        {
            return new PrimitiveUnaryAbstractNumber(HyperMath.Operations.Pow.Apply(Operation, other.Operation));
        }

        public PrimitiveUnaryAbstractNumber Negate()
        {
            return new PrimitiveUnaryAbstractNumber(HyperMath.Operations.Neg.Apply(Operation));
        }

        public PrimitiveUnaryAbstractNumber Increment()
        {
            return new PrimitiveUnaryAbstractNumber(HyperMath.Operations.Inc.Apply(Operation));
        }

        public PrimitiveUnaryAbstractNumber Decrement()
        {
            return new PrimitiveUnaryAbstractNumber(HyperMath.Operations.Dec.Apply(Operation));
        }

        public PrimitiveUnaryAbstractNumber Inverse()
        {
            return new PrimitiveUnaryAbstractNumber(HyperMath.Operations.Inv.Apply(Operation));
        }

        public PrimitiveUnaryAbstractNumber Conjugate()
        {
            return new PrimitiveUnaryAbstractNumber(HyperMath.Operations.Con.Apply(Operation));
        }

        public PrimitiveUnaryAbstractNumber Modulus()
        {
            return new PrimitiveUnaryAbstractNumber(HyperMath.Operations.Mods.Apply(Operation));
        }

        PrimitiveUnaryAbstractNumber INumber<PrimitiveUnaryAbstractNumber>.Half()
        {
            return new PrimitiveUnaryAbstractNumber(HyperMath.Operations.Div2.Apply(Operation));
        }

        PrimitiveUnaryAbstractNumber INumber<PrimitiveUnaryAbstractNumber>.Double()
        {
            return new PrimitiveUnaryAbstractNumber(HyperMath.Operations.Mul2.Apply(Operation));
        }

        PrimitiveUnaryAbstractNumber INumber<PrimitiveUnaryAbstractNumber>.Square()
        {
            return new PrimitiveUnaryAbstractNumber(HyperMath.Operations.Pow2.Apply(Operation));
        }

        PrimitiveUnaryAbstractNumber INumber<PrimitiveUnaryAbstractNumber>.SquareRoot()
        {
            return new PrimitiveUnaryAbstractNumber(HyperMath.Operations.Sqrt.Apply(Operation));
        }

        PrimitiveUnaryAbstractNumber INumber<PrimitiveUnaryAbstractNumber>.Exponentiate()
        {
            return new PrimitiveUnaryAbstractNumber(HyperMath.Operations.Exp.Apply(Operation));
        }

        PrimitiveUnaryAbstractNumber INumber<PrimitiveUnaryAbstractNumber>.Logarithm()
        {
            return new PrimitiveUnaryAbstractNumber(HyperMath.Operations.Log.Apply(Operation));
        }

        PrimitiveUnaryAbstractNumber INumber<PrimitiveUnaryAbstractNumber>.Sine()
        {
            return new PrimitiveUnaryAbstractNumber(HyperMath.Operations.Sin.Apply(Operation));
        }

        PrimitiveUnaryAbstractNumber INumber<PrimitiveUnaryAbstractNumber>.Cosine()
        {
            return new PrimitiveUnaryAbstractNumber(HyperMath.Operations.Cos.Apply(Operation));
        }

        PrimitiveUnaryAbstractNumber INumber<PrimitiveUnaryAbstractNumber>.Tangent()
        {
            return new PrimitiveUnaryAbstractNumber(HyperMath.Operations.Tan.Apply(Operation));
        }

        PrimitiveUnaryAbstractNumber INumber<PrimitiveUnaryAbstractNumber>.HyperbolicSine()
        {
            return new PrimitiveUnaryAbstractNumber(HyperMath.Operations.Sinh.Apply(Operation));
        }

        PrimitiveUnaryAbstractNumber INumber<PrimitiveUnaryAbstractNumber>.HyperbolicCosine()
        {
            return new PrimitiveUnaryAbstractNumber(HyperMath.Operations.Cosh.Apply(Operation));
        }

        PrimitiveUnaryAbstractNumber INumber<PrimitiveUnaryAbstractNumber>.HyperbolicTangent()
        {
            return new PrimitiveUnaryAbstractNumber(HyperMath.Operations.Tanh.Apply(Operation));
        }

        PrimitiveUnaryAbstractNumber INumber<PrimitiveUnaryAbstractNumber>.ArcSine()
        {
            return new PrimitiveUnaryAbstractNumber(HyperMath.Operations.Asin.Apply(Operation));
        }

        PrimitiveUnaryAbstractNumber INumber<PrimitiveUnaryAbstractNumber>.ArcCosine()
        {
            return new PrimitiveUnaryAbstractNumber(HyperMath.Operations.Acos.Apply(Operation));
        }

        PrimitiveUnaryAbstractNumber INumber<PrimitiveUnaryAbstractNumber>.ArcTangent()
        {
            return new PrimitiveUnaryAbstractNumber(HyperMath.Operations.Atan.Apply(Operation));
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

        public static PrimitiveUnaryAbstractNumber operator+(PrimitiveUnaryAbstractNumber a, PrimitiveUnaryAbstractNumber b)
        {
            return a.Add(b);
        }

        public static PrimitiveUnaryAbstractNumber operator-(PrimitiveUnaryAbstractNumber a, PrimitiveUnaryAbstractNumber b)
        {
            return a.Subtract(b);
        }

        public static PrimitiveUnaryAbstractNumber operator*(PrimitiveUnaryAbstractNumber a, PrimitiveUnaryAbstractNumber b)
        {
            return a.Multiply(b);
        }

        public static PrimitiveUnaryAbstractNumber operator/(PrimitiveUnaryAbstractNumber a, PrimitiveUnaryAbstractNumber b)
        {
            return a.Divide(b);
        }

        public static PrimitiveUnaryAbstractNumber operator^(PrimitiveUnaryAbstractNumber a, PrimitiveUnaryAbstractNumber b)
        {
            return a.Power(b);
        }

        public static PrimitiveUnaryAbstractNumber operator-(PrimitiveUnaryAbstractNumber a)
        {
            return a.Negate();
        }

        public static PrimitiveUnaryAbstractNumber operator++(PrimitiveUnaryAbstractNumber a)
        {
            return a.Increment();
        }

        public static PrimitiveUnaryAbstractNumber operator--(PrimitiveUnaryAbstractNumber a)
        {
            return a.Decrement();
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

        INumberFactory INumber.GetFactory()
        {
            return Factory.Instance;
        }

        INumberFactory<PrimitiveUnaryAbstractNumber> INumber<PrimitiveUnaryAbstractNumber>.GetFactory()
        {
            return Factory.Instance;
        }

        class Factory : INumberFactory<PrimitiveUnaryAbstractNumber>
        {
            public static readonly Factory Instance = new Factory();
            public PrimitiveUnaryAbstractNumber Zero => PrimitiveUnaryAbstractNumber.Zero;
            public PrimitiveUnaryAbstractNumber RealOne => PrimitiveUnaryAbstractNumber.RealOne;
            public PrimitiveUnaryAbstractNumber SpecialOne => PrimitiveUnaryAbstractNumber.SpecialOne;
            public PrimitiveUnaryAbstractNumber UnitsOne => PrimitiveUnaryAbstractNumber.UnitsOne;
            public PrimitiveUnaryAbstractNumber NonRealUnitsOne => PrimitiveUnaryAbstractNumber.NonRealUnitsOne;
            public PrimitiveUnaryAbstractNumber CombinedOne => PrimitiveUnaryAbstractNumber.CombinedOne;
            public PrimitiveUnaryAbstractNumber AllOne => PrimitiveUnaryAbstractNumber.AllOne;
            INumber INumberFactory.Zero => PrimitiveUnaryAbstractNumber.Zero;
            INumber INumberFactory.RealOne => PrimitiveUnaryAbstractNumber.RealOne;
            INumber INumberFactory.SpecialOne => PrimitiveUnaryAbstractNumber.SpecialOne;
            INumber INumberFactory.UnitsOne => PrimitiveUnaryAbstractNumber.UnitsOne;
            INumber INumberFactory.NonRealUnitsOne => PrimitiveUnaryAbstractNumber.NonRealUnitsOne;
            INumber INumberFactory.CombinedOne => PrimitiveUnaryAbstractNumber.CombinedOne;
            INumber INumberFactory.AllOne => PrimitiveUnaryAbstractNumber.AllOne;
        }
    }
    
    [Serializable]
    public readonly struct BinaryAbstractNumber : INumber<BinaryAbstractNumber>, IBinaryNumberOperation
    {
        public static BinaryAbstractNumber Zero => default;
        public static BinaryAbstractNumber RealOne => new BinaryAbstractNumber(HyperMath.Operations.RealOne.AsBinary());
        public static BinaryAbstractNumber SpecialOne => new BinaryAbstractNumber(HyperMath.Operations.SpecialOne.AsBinary());
        public static BinaryAbstractNumber UnitsOne => new BinaryAbstractNumber(HyperMath.Operations.UnitsOne.AsBinary());
        public static BinaryAbstractNumber NonRealUnitsOne => new BinaryAbstractNumber(HyperMath.Operations.NonRealUnitsOne.AsBinary());
        public static BinaryAbstractNumber CombinedOne => new BinaryAbstractNumber(HyperMath.Operations.CombinedOne.AsBinary());
        public static BinaryAbstractNumber AllOne => new BinaryAbstractNumber(HyperMath.Operations.AllOne.AsBinary());

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

        public BinaryAbstractNumber Add(in BinaryAbstractNumber other)
        {
            return new BinaryAbstractNumber(HyperMath.Operations.Add.Apply(Operation, other.Operation));
        }

        public BinaryAbstractNumber Subtract(in BinaryAbstractNumber other)
        {
            return new BinaryAbstractNumber(HyperMath.Operations.Sub.Apply(Operation, other.Operation));
        }

        public BinaryAbstractNumber Multiply(in BinaryAbstractNumber other)
        {
            return new BinaryAbstractNumber(HyperMath.Operations.Mul.Apply(Operation, other.Operation));
        }

        public BinaryAbstractNumber Divide(in BinaryAbstractNumber other)
        {
            return new BinaryAbstractNumber(HyperMath.Operations.Div.Apply(Operation, other.Operation));
        }

        public BinaryAbstractNumber Power(in BinaryAbstractNumber other)
        {
            return new BinaryAbstractNumber(HyperMath.Operations.Pow.Apply(Operation, other.Operation));
        }

        public BinaryAbstractNumber Negate()
        {
            return new BinaryAbstractNumber(HyperMath.Operations.Neg.Apply(Operation));
        }

        public BinaryAbstractNumber Increment()
        {
            return new BinaryAbstractNumber(HyperMath.Operations.Inc.Apply(Operation));
        }

        public BinaryAbstractNumber Decrement()
        {
            return new BinaryAbstractNumber(HyperMath.Operations.Dec.Apply(Operation));
        }

        public BinaryAbstractNumber Inverse()
        {
            return new BinaryAbstractNumber(HyperMath.Operations.Inv.Apply(Operation));
        }

        public BinaryAbstractNumber Conjugate()
        {
            return new BinaryAbstractNumber(HyperMath.Operations.Con.Apply(Operation));
        }

        public BinaryAbstractNumber Modulus()
        {
            return new BinaryAbstractNumber(HyperMath.Operations.Mods.Apply(Operation));
        }

        BinaryAbstractNumber INumber<BinaryAbstractNumber>.Half()
        {
            return new BinaryAbstractNumber(HyperMath.Operations.Div2.Apply(Operation));
        }

        BinaryAbstractNumber INumber<BinaryAbstractNumber>.Double()
        {
            return new BinaryAbstractNumber(HyperMath.Operations.Mul2.Apply(Operation));
        }

        BinaryAbstractNumber INumber<BinaryAbstractNumber>.Square()
        {
            return new BinaryAbstractNumber(HyperMath.Operations.Pow2.Apply(Operation));
        }

        BinaryAbstractNumber INumber<BinaryAbstractNumber>.SquareRoot()
        {
            return new BinaryAbstractNumber(HyperMath.Operations.Sqrt.Apply(Operation));
        }

        BinaryAbstractNumber INumber<BinaryAbstractNumber>.Exponentiate()
        {
            return new BinaryAbstractNumber(HyperMath.Operations.Exp.Apply(Operation));
        }

        BinaryAbstractNumber INumber<BinaryAbstractNumber>.Logarithm()
        {
            return new BinaryAbstractNumber(HyperMath.Operations.Log.Apply(Operation));
        }

        BinaryAbstractNumber INumber<BinaryAbstractNumber>.Sine()
        {
            return new BinaryAbstractNumber(HyperMath.Operations.Sin.Apply(Operation));
        }

        BinaryAbstractNumber INumber<BinaryAbstractNumber>.Cosine()
        {
            return new BinaryAbstractNumber(HyperMath.Operations.Cos.Apply(Operation));
        }

        BinaryAbstractNumber INumber<BinaryAbstractNumber>.Tangent()
        {
            return new BinaryAbstractNumber(HyperMath.Operations.Tan.Apply(Operation));
        }

        BinaryAbstractNumber INumber<BinaryAbstractNumber>.HyperbolicSine()
        {
            return new BinaryAbstractNumber(HyperMath.Operations.Sinh.Apply(Operation));
        }

        BinaryAbstractNumber INumber<BinaryAbstractNumber>.HyperbolicCosine()
        {
            return new BinaryAbstractNumber(HyperMath.Operations.Cosh.Apply(Operation));
        }

        BinaryAbstractNumber INumber<BinaryAbstractNumber>.HyperbolicTangent()
        {
            return new BinaryAbstractNumber(HyperMath.Operations.Tanh.Apply(Operation));
        }

        BinaryAbstractNumber INumber<BinaryAbstractNumber>.ArcSine()
        {
            return new BinaryAbstractNumber(HyperMath.Operations.Asin.Apply(Operation));
        }

        BinaryAbstractNumber INumber<BinaryAbstractNumber>.ArcCosine()
        {
            return new BinaryAbstractNumber(HyperMath.Operations.Acos.Apply(Operation));
        }

        BinaryAbstractNumber INumber<BinaryAbstractNumber>.ArcTangent()
        {
            return new BinaryAbstractNumber(HyperMath.Operations.Atan.Apply(Operation));
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

        public static BinaryAbstractNumber operator+(BinaryAbstractNumber a, BinaryAbstractNumber b)
        {
            return a.Add(b);
        }

        public static BinaryAbstractNumber operator-(BinaryAbstractNumber a, BinaryAbstractNumber b)
        {
            return a.Subtract(b);
        }

        public static BinaryAbstractNumber operator*(BinaryAbstractNumber a, BinaryAbstractNumber b)
        {
            return a.Multiply(b);
        }

        public static BinaryAbstractNumber operator/(BinaryAbstractNumber a, BinaryAbstractNumber b)
        {
            return a.Divide(b);
        }

        public static BinaryAbstractNumber operator^(BinaryAbstractNumber a, BinaryAbstractNumber b)
        {
            return a.Power(b);
        }

        public static BinaryAbstractNumber operator-(BinaryAbstractNumber a)
        {
            return a.Negate();
        }

        public static BinaryAbstractNumber operator++(BinaryAbstractNumber a)
        {
            return a.Increment();
        }

        public static BinaryAbstractNumber operator--(BinaryAbstractNumber a)
        {
            return a.Decrement();
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

        INumberFactory INumber.GetFactory()
        {
            return Factory.Instance;
        }

        INumberFactory<BinaryAbstractNumber> INumber<BinaryAbstractNumber>.GetFactory()
        {
            return Factory.Instance;
        }

        class Factory : INumberFactory<BinaryAbstractNumber>
        {
            public static readonly Factory Instance = new Factory();
            public BinaryAbstractNumber Zero => BinaryAbstractNumber.Zero;
            public BinaryAbstractNumber RealOne => BinaryAbstractNumber.RealOne;
            public BinaryAbstractNumber SpecialOne => BinaryAbstractNumber.SpecialOne;
            public BinaryAbstractNumber UnitsOne => BinaryAbstractNumber.UnitsOne;
            public BinaryAbstractNumber NonRealUnitsOne => BinaryAbstractNumber.NonRealUnitsOne;
            public BinaryAbstractNumber CombinedOne => BinaryAbstractNumber.CombinedOne;
            public BinaryAbstractNumber AllOne => BinaryAbstractNumber.AllOne;
            INumber INumberFactory.Zero => BinaryAbstractNumber.Zero;
            INumber INumberFactory.RealOne => BinaryAbstractNumber.RealOne;
            INumber INumberFactory.SpecialOne => BinaryAbstractNumber.SpecialOne;
            INumber INumberFactory.UnitsOne => BinaryAbstractNumber.UnitsOne;
            INumber INumberFactory.NonRealUnitsOne => BinaryAbstractNumber.NonRealUnitsOne;
            INumber INumberFactory.CombinedOne => BinaryAbstractNumber.CombinedOne;
            INumber INumberFactory.AllOne => BinaryAbstractNumber.AllOne;
        }
    }
    
    [Serializable]
    public readonly struct PrimitiveBinaryAbstractNumber : INumber<PrimitiveBinaryAbstractNumber>, IPrimitiveBinaryNumberOperation
    {
        public static PrimitiveBinaryAbstractNumber Zero => default;
        public static PrimitiveBinaryAbstractNumber RealOne => new PrimitiveBinaryAbstractNumber(HyperMath.Operations.RealOne.AsBinary());
        public static PrimitiveBinaryAbstractNumber SpecialOne => new PrimitiveBinaryAbstractNumber(HyperMath.Operations.SpecialOne.AsBinary());
        public static PrimitiveBinaryAbstractNumber UnitsOne => new PrimitiveBinaryAbstractNumber(HyperMath.Operations.UnitsOne.AsBinary());
        public static PrimitiveBinaryAbstractNumber NonRealUnitsOne => new PrimitiveBinaryAbstractNumber(HyperMath.Operations.NonRealUnitsOne.AsBinary());
        public static PrimitiveBinaryAbstractNumber CombinedOne => new PrimitiveBinaryAbstractNumber(HyperMath.Operations.CombinedOne.AsBinary());
        public static PrimitiveBinaryAbstractNumber AllOne => new PrimitiveBinaryAbstractNumber(HyperMath.Operations.AllOne.AsBinary());

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

        public PrimitiveBinaryAbstractNumber Add(in PrimitiveBinaryAbstractNumber other)
        {
            return new PrimitiveBinaryAbstractNumber(HyperMath.Operations.Add.Apply(Operation, other.Operation));
        }

        public PrimitiveBinaryAbstractNumber Subtract(in PrimitiveBinaryAbstractNumber other)
        {
            return new PrimitiveBinaryAbstractNumber(HyperMath.Operations.Sub.Apply(Operation, other.Operation));
        }

        public PrimitiveBinaryAbstractNumber Multiply(in PrimitiveBinaryAbstractNumber other)
        {
            return new PrimitiveBinaryAbstractNumber(HyperMath.Operations.Mul.Apply(Operation, other.Operation));
        }

        public PrimitiveBinaryAbstractNumber Divide(in PrimitiveBinaryAbstractNumber other)
        {
            return new PrimitiveBinaryAbstractNumber(HyperMath.Operations.Div.Apply(Operation, other.Operation));
        }

        public PrimitiveBinaryAbstractNumber Power(in PrimitiveBinaryAbstractNumber other)
        {
            return new PrimitiveBinaryAbstractNumber(HyperMath.Operations.Pow.Apply(Operation, other.Operation));
        }

        public PrimitiveBinaryAbstractNumber Negate()
        {
            return new PrimitiveBinaryAbstractNumber(HyperMath.Operations.Neg.Apply(Operation));
        }

        public PrimitiveBinaryAbstractNumber Increment()
        {
            return new PrimitiveBinaryAbstractNumber(HyperMath.Operations.Inc.Apply(Operation));
        }

        public PrimitiveBinaryAbstractNumber Decrement()
        {
            return new PrimitiveBinaryAbstractNumber(HyperMath.Operations.Dec.Apply(Operation));
        }

        public PrimitiveBinaryAbstractNumber Inverse()
        {
            return new PrimitiveBinaryAbstractNumber(HyperMath.Operations.Inv.Apply(Operation));
        }

        public PrimitiveBinaryAbstractNumber Conjugate()
        {
            return new PrimitiveBinaryAbstractNumber(HyperMath.Operations.Con.Apply(Operation));
        }

        public PrimitiveBinaryAbstractNumber Modulus()
        {
            return new PrimitiveBinaryAbstractNumber(HyperMath.Operations.Mods.Apply(Operation));
        }

        PrimitiveBinaryAbstractNumber INumber<PrimitiveBinaryAbstractNumber>.Half()
        {
            return new PrimitiveBinaryAbstractNumber(HyperMath.Operations.Div2.Apply(Operation));
        }

        PrimitiveBinaryAbstractNumber INumber<PrimitiveBinaryAbstractNumber>.Double()
        {
            return new PrimitiveBinaryAbstractNumber(HyperMath.Operations.Mul2.Apply(Operation));
        }

        PrimitiveBinaryAbstractNumber INumber<PrimitiveBinaryAbstractNumber>.Square()
        {
            return new PrimitiveBinaryAbstractNumber(HyperMath.Operations.Pow2.Apply(Operation));
        }

        PrimitiveBinaryAbstractNumber INumber<PrimitiveBinaryAbstractNumber>.SquareRoot()
        {
            return new PrimitiveBinaryAbstractNumber(HyperMath.Operations.Sqrt.Apply(Operation));
        }

        PrimitiveBinaryAbstractNumber INumber<PrimitiveBinaryAbstractNumber>.Exponentiate()
        {
            return new PrimitiveBinaryAbstractNumber(HyperMath.Operations.Exp.Apply(Operation));
        }

        PrimitiveBinaryAbstractNumber INumber<PrimitiveBinaryAbstractNumber>.Logarithm()
        {
            return new PrimitiveBinaryAbstractNumber(HyperMath.Operations.Log.Apply(Operation));
        }

        PrimitiveBinaryAbstractNumber INumber<PrimitiveBinaryAbstractNumber>.Sine()
        {
            return new PrimitiveBinaryAbstractNumber(HyperMath.Operations.Sin.Apply(Operation));
        }

        PrimitiveBinaryAbstractNumber INumber<PrimitiveBinaryAbstractNumber>.Cosine()
        {
            return new PrimitiveBinaryAbstractNumber(HyperMath.Operations.Cos.Apply(Operation));
        }

        PrimitiveBinaryAbstractNumber INumber<PrimitiveBinaryAbstractNumber>.Tangent()
        {
            return new PrimitiveBinaryAbstractNumber(HyperMath.Operations.Tan.Apply(Operation));
        }

        PrimitiveBinaryAbstractNumber INumber<PrimitiveBinaryAbstractNumber>.HyperbolicSine()
        {
            return new PrimitiveBinaryAbstractNumber(HyperMath.Operations.Sinh.Apply(Operation));
        }

        PrimitiveBinaryAbstractNumber INumber<PrimitiveBinaryAbstractNumber>.HyperbolicCosine()
        {
            return new PrimitiveBinaryAbstractNumber(HyperMath.Operations.Cosh.Apply(Operation));
        }

        PrimitiveBinaryAbstractNumber INumber<PrimitiveBinaryAbstractNumber>.HyperbolicTangent()
        {
            return new PrimitiveBinaryAbstractNumber(HyperMath.Operations.Tanh.Apply(Operation));
        }

        PrimitiveBinaryAbstractNumber INumber<PrimitiveBinaryAbstractNumber>.ArcSine()
        {
            return new PrimitiveBinaryAbstractNumber(HyperMath.Operations.Asin.Apply(Operation));
        }

        PrimitiveBinaryAbstractNumber INumber<PrimitiveBinaryAbstractNumber>.ArcCosine()
        {
            return new PrimitiveBinaryAbstractNumber(HyperMath.Operations.Acos.Apply(Operation));
        }

        PrimitiveBinaryAbstractNumber INumber<PrimitiveBinaryAbstractNumber>.ArcTangent()
        {
            return new PrimitiveBinaryAbstractNumber(HyperMath.Operations.Atan.Apply(Operation));
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

        public static PrimitiveBinaryAbstractNumber operator+(PrimitiveBinaryAbstractNumber a, PrimitiveBinaryAbstractNumber b)
        {
            return a.Add(b);
        }

        public static PrimitiveBinaryAbstractNumber operator-(PrimitiveBinaryAbstractNumber a, PrimitiveBinaryAbstractNumber b)
        {
            return a.Subtract(b);
        }

        public static PrimitiveBinaryAbstractNumber operator*(PrimitiveBinaryAbstractNumber a, PrimitiveBinaryAbstractNumber b)
        {
            return a.Multiply(b);
        }

        public static PrimitiveBinaryAbstractNumber operator/(PrimitiveBinaryAbstractNumber a, PrimitiveBinaryAbstractNumber b)
        {
            return a.Divide(b);
        }

        public static PrimitiveBinaryAbstractNumber operator^(PrimitiveBinaryAbstractNumber a, PrimitiveBinaryAbstractNumber b)
        {
            return a.Power(b);
        }

        public static PrimitiveBinaryAbstractNumber operator-(PrimitiveBinaryAbstractNumber a)
        {
            return a.Negate();
        }

        public static PrimitiveBinaryAbstractNumber operator++(PrimitiveBinaryAbstractNumber a)
        {
            return a.Increment();
        }

        public static PrimitiveBinaryAbstractNumber operator--(PrimitiveBinaryAbstractNumber a)
        {
            return a.Decrement();
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

        INumberFactory INumber.GetFactory()
        {
            return Factory.Instance;
        }

        INumberFactory<PrimitiveBinaryAbstractNumber> INumber<PrimitiveBinaryAbstractNumber>.GetFactory()
        {
            return Factory.Instance;
        }

        class Factory : INumberFactory<PrimitiveBinaryAbstractNumber>
        {
            public static readonly Factory Instance = new Factory();
            public PrimitiveBinaryAbstractNumber Zero => PrimitiveBinaryAbstractNumber.Zero;
            public PrimitiveBinaryAbstractNumber RealOne => PrimitiveBinaryAbstractNumber.RealOne;
            public PrimitiveBinaryAbstractNumber SpecialOne => PrimitiveBinaryAbstractNumber.SpecialOne;
            public PrimitiveBinaryAbstractNumber UnitsOne => PrimitiveBinaryAbstractNumber.UnitsOne;
            public PrimitiveBinaryAbstractNumber NonRealUnitsOne => PrimitiveBinaryAbstractNumber.NonRealUnitsOne;
            public PrimitiveBinaryAbstractNumber CombinedOne => PrimitiveBinaryAbstractNumber.CombinedOne;
            public PrimitiveBinaryAbstractNumber AllOne => PrimitiveBinaryAbstractNumber.AllOne;
            INumber INumberFactory.Zero => PrimitiveBinaryAbstractNumber.Zero;
            INumber INumberFactory.RealOne => PrimitiveBinaryAbstractNumber.RealOne;
            INumber INumberFactory.SpecialOne => PrimitiveBinaryAbstractNumber.SpecialOne;
            INumber INumberFactory.UnitsOne => PrimitiveBinaryAbstractNumber.UnitsOne;
            INumber INumberFactory.NonRealUnitsOne => PrimitiveBinaryAbstractNumber.NonRealUnitsOne;
            INumber INumberFactory.CombinedOne => PrimitiveBinaryAbstractNumber.CombinedOne;
            INumber INumberFactory.AllOne => PrimitiveBinaryAbstractNumber.AllOne;
        }
    }
}
