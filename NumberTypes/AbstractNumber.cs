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

        public TNumber Invoke<TNumber, TComponent>() where TNumber : struct, INumber<TNumber, TComponent> where TComponent : struct, IEquatable<TComponent>, IComparable<TComponent>
        {
            return Operation.Invoke<TNumber, TComponent>();
        }

        public AbstractNumber Call(StandardBinaryOperation operation, in AbstractNumber other)
        {
            return new AbstractNumber(HyperMath.Operations.GetOperation(operation).Apply(Operation, other.Operation));
        }

        public AbstractNumber Call(StandardUnaryOperation operation)
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

            public AbstractNumber Create(StandardNumber num)
            {
                return new AbstractNumber(HyperMath.Operations.GetOperation(num));
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
    /// Represents a number formed by invoking a constructed nullary operation (<see cref="IComponentNumberOperation"/>), i.e. the result of an expression.
    /// This type supports dynamic dispatch – a dynamic cast to a valid number type will produce a number
    /// of that type by calling <see cref="IComponentNumberOperation.Invoke{TNumber, TComponent}"/> on the operation.
    /// </summary>
    [Serializable]
    public readonly partial struct ComponentAbstractNumber : IWrapperNumber<ComponentAbstractNumber, ComponentAbstractNumber, ComponentAbstractNumber>, IComponentNumberOperation, IDynamicMetaObjectProvider
    {
        private readonly IComponentNumberOperation operation;

        public IComponentNumberOperation Operation => operation ?? HyperMath.Operations.Default;

        public bool IsInvertible => true;

        public bool IsFinite => true;

        int INumber.Dimension => -1;

        public ComponentAbstractNumber(IComponentNumberOperation operation)
        {
            if(operation == null)
            {
                throw new ArgumentNullException(nameof(operation));
            }
            this.operation = operation;
        }

        public ComponentAbstractNumber Clone()
        {
            if(Operation is ICloneable cloneable)
            {
                return new ComponentAbstractNumber((IComponentNumberOperation)cloneable.Clone());
            }
            return this;
        }

        public static implicit operator ComponentAbstractNumber(AbstractNumber num)
        {
            return new ComponentAbstractNumber(num.Operation);
        }

        public TNumber Invoke<TNumber, TComponent>() where TNumber : struct, INumber<TNumber, TComponent> where TComponent : struct, IEquatable<TComponent>, IComparable<TComponent>
        {
            return Operation.Invoke<TNumber, TComponent>();
        }

        public ComponentAbstractNumber Call(StandardBinaryOperation operation, in ComponentAbstractNumber other)
        {
            return new ComponentAbstractNumber(HyperMath.Operations.GetOperation(operation).Apply(Operation, other.Operation));
        }

        public ComponentAbstractNumber Call(StandardUnaryOperation operation)
        {
            return new ComponentAbstractNumber(HyperMath.Operations.GetOperation(operation).Apply(Operation));
        }

        public override bool Equals(object obj)
        {
            return obj is ComponentAbstractNumber value && Equals(in value);
        }

        public bool Equals(in ComponentAbstractNumber other)
        {
            return Operation.Equals(other.Operation);
        }

        public int CompareTo(in ComponentAbstractNumber other)
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

        partial class Operations : NumberOperations<ComponentAbstractNumber>, IExtendedNumberOperations<ComponentAbstractNumber, ComponentAbstractNumber, ComponentAbstractNumber>
        {
            public override int Dimension => -1;

            public ComponentAbstractNumber Create(StandardNumber num)
            {
                return new ComponentAbstractNumber(HyperMath.Operations.GetOperation(num));
            }
        }

        DynamicMetaObject IDynamicMetaObjectProvider.GetMetaObject(Expression parameter)
        {
            return new MetaObject(parameter, this);
        }

        class MetaObject : DynamicMetaObject
        {
            private static readonly Type InterfaceType = typeof(IComponentNumberOperation);
            private static readonly MethodInfo Invoke = InterfaceType.GetMethod(nameof(IComponentNumberOperation.Invoke), BindingFlags.Public | BindingFlags.Instance | BindingFlags.DeclaredOnly);
            private static readonly Type NumberType = typeof(ComponentAbstractNumber);

            public MetaObject(Expression expression, INumber<ComponentAbstractNumber> value) : base(expression, BindingRestrictions.GetTypeRestriction(expression, NumberType), value)
            {

            }

            public override DynamicMetaObject BindConvert(ConvertBinder binder)
            {
                MethodInfo method;
                try{
                    method = Invoke.MakeGenericMethod(binder.Type, TypeTools.GetComponentType(binder.Type));
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

        public TNumber Invoke<TNumber, TComponent>(in TNumber num) where TNumber : struct, INumber<TNumber, TComponent> where TComponent : struct, IEquatable<TComponent>, IComparable<TComponent>
        {
            return Operation.Invoke<TNumber, TComponent>(num);
        }

        public UnaryAbstractNumber Call(StandardBinaryOperation operation, in UnaryAbstractNumber other)
        {
            return new UnaryAbstractNumber(HyperMath.Operations.GetOperation(operation).Apply(Operation, other.Operation));
        }

        public UnaryAbstractNumber Call(StandardUnaryOperation operation)
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

            public UnaryAbstractNumber Create(StandardNumber num)
            {
                return new UnaryAbstractNumber(HyperMath.Operations.GetOperation(num).AsUnary());
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            yield return this;
        }
    }

    /// <summary>
    /// Represents a number formed by invoking a constructed unary operation (<see cref="IComponentUnaryNumberOperation"/>), i.e. the result of an expression
    /// with a single variable.
    /// </summary>
    [Serializable]
    public readonly partial struct ComponentUnaryAbstractNumber : IWrapperNumber<ComponentUnaryAbstractNumber, ComponentUnaryAbstractNumber, ComponentUnaryAbstractNumber>, IComponentUnaryNumberOperation
    {
        private readonly IComponentUnaryNumberOperation operation;

        public IComponentUnaryNumberOperation Operation => operation ?? HyperMath.Operations.Default.AsUnary();

        public bool IsInvertible => true;

        public bool IsFinite => true;

        int INumber.Dimension => -1;

        public ComponentUnaryAbstractNumber(IComponentUnaryNumberOperation operation)
        {
            if(operation == null)
            {
                throw new ArgumentNullException(nameof(operation));
            }
            this.operation = operation;
        }

        public ComponentUnaryAbstractNumber Clone()
        {
            if(Operation is ICloneable cloneable)
            {
                return new ComponentUnaryAbstractNumber((IComponentUnaryNumberOperation)cloneable.Clone());
            }
            return this;
        }

        public static implicit operator ComponentUnaryAbstractNumber(AbstractNumber num)
        {
            return new ComponentUnaryAbstractNumber(num.Operation.AsUnary());
        }

        public static implicit operator ComponentUnaryAbstractNumber(UnaryAbstractNumber num)
        {
            return new ComponentUnaryAbstractNumber(num.Operation);
        }

        public static implicit operator ComponentUnaryAbstractNumber(ComponentAbstractNumber num)
        {
            return new ComponentUnaryAbstractNumber(num.Operation.AsUnary());
        }

        public TNumber Invoke<TNumber, TComponent>(in TNumber num) where TNumber : struct, INumber<TNumber, TComponent> where TComponent : struct, IEquatable<TComponent>, IComparable<TComponent>
        {
            return Operation.Invoke<TNumber, TComponent>(num);
        }

        public ComponentUnaryAbstractNumber Call(StandardBinaryOperation operation, in ComponentUnaryAbstractNumber other)
        {
            return new ComponentUnaryAbstractNumber(HyperMath.Operations.GetOperation(operation).Apply(Operation, other.Operation));
        }

        public ComponentUnaryAbstractNumber Call(StandardUnaryOperation operation)
        {
            return new ComponentUnaryAbstractNumber(HyperMath.Operations.GetOperation(operation).Apply(Operation));
        }

        public override bool Equals(object obj)
        {
            return obj is ComponentUnaryAbstractNumber value && Equals(in value);
        }

        public bool Equals(in ComponentUnaryAbstractNumber other)
        {
            return Operation.Equals(other.Operation);
        }

        public int CompareTo(in ComponentUnaryAbstractNumber other)
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

        partial class Operations : NumberOperations<ComponentUnaryAbstractNumber>, IExtendedNumberOperations<ComponentUnaryAbstractNumber, ComponentUnaryAbstractNumber, ComponentUnaryAbstractNumber>
        {
            public override int Dimension => -1;

            public ComponentUnaryAbstractNumber Create(StandardNumber num)
            {
                return new ComponentUnaryAbstractNumber(HyperMath.Operations.GetOperation(num).AsUnary());
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

        public TNumber Invoke<TNumber, TComponent>(in TNumber numArg1, in TNumber numArg2) where TNumber : struct, INumber<TNumber, TComponent> where TComponent : struct, IEquatable<TComponent>, IComparable<TComponent>
        {
            return Operation.Invoke<TNumber, TComponent>(numArg1, numArg2);
        }

        public BinaryAbstractNumber Call(StandardBinaryOperation operation, in BinaryAbstractNumber other)
        {
            return new BinaryAbstractNumber(HyperMath.Operations.GetOperation(operation).Apply(Operation, other.Operation));
        }

        public BinaryAbstractNumber Call(StandardUnaryOperation operation)
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

            public BinaryAbstractNumber Create(StandardNumber num)
            {
                return new BinaryAbstractNumber(HyperMath.Operations.GetOperation(num).AsBinary());
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            yield return this;
        }
    }

    /// <summary>
    /// Represents a number formed by invoking a constructed binary operation (<see cref="IComponentBinaryNumberOperation"/>), i.e. the result of an expression
    /// with two variables.
    /// </summary>
    [Serializable]
    public readonly partial struct ComponentBinaryAbstractNumber : IWrapperNumber<ComponentBinaryAbstractNumber, ComponentBinaryAbstractNumber, ComponentBinaryAbstractNumber>, IComponentBinaryNumberOperation
    {
        private readonly IComponentBinaryNumberOperation operation;

        public IComponentBinaryNumberOperation Operation => operation ?? HyperMath.Operations.Default.AsBinary();

        public bool IsInvertible => true;

        public bool IsFinite => true;

        int INumber.Dimension => -1;

        public ComponentBinaryAbstractNumber(IComponentBinaryNumberOperation operation)
        {
            if(operation == null)
            {
                throw new ArgumentNullException(nameof(operation));
            }
            this.operation = operation;
        }

        public ComponentBinaryAbstractNumber Clone()
        {
            if(Operation is ICloneable cloneable)
            {
                return new ComponentBinaryAbstractNumber((IComponentBinaryNumberOperation)cloneable.Clone());
            }
            return this;
        }

        public static implicit operator ComponentBinaryAbstractNumber(AbstractNumber num)
        {
            return new ComponentBinaryAbstractNumber(num.Operation.AsBinary());
        }

        public static implicit operator ComponentBinaryAbstractNumber(UnaryAbstractNumber num)
        {
            return new ComponentBinaryAbstractNumber(num.Operation.AsBinary());
        }

        public static implicit operator ComponentBinaryAbstractNumber(BinaryAbstractNumber num)
        {
            return new ComponentBinaryAbstractNumber(num.Operation);
        }

        public static implicit operator ComponentBinaryAbstractNumber(ComponentUnaryAbstractNumber num)
        {
            return new ComponentBinaryAbstractNumber(num.Operation.AsBinary());
        }

        public static implicit operator ComponentBinaryAbstractNumber(ComponentAbstractNumber num)
        {
            return new ComponentBinaryAbstractNumber(num.Operation.AsBinary());
        }

        public TNumber Invoke<TNumber, TComponent>(in TNumber numArg1, in TNumber numArg2) where TNumber : struct, INumber<TNumber, TComponent> where TComponent : struct, IEquatable<TComponent>, IComparable<TComponent>
        {
            return Operation.Invoke<TNumber, TComponent>(numArg1, numArg2);
        }

        public ComponentBinaryAbstractNumber Call(StandardBinaryOperation operation, in ComponentBinaryAbstractNumber other)
        {
            return new ComponentBinaryAbstractNumber(HyperMath.Operations.GetOperation(operation).Apply(Operation, other.Operation));
        }

        public ComponentBinaryAbstractNumber Call(StandardUnaryOperation operation)
        {
            return new ComponentBinaryAbstractNumber(HyperMath.Operations.GetOperation(operation).Apply(Operation));
        }

        public override bool Equals(object obj)
        {
            return obj is ComponentBinaryAbstractNumber value && Equals(in value);
        }

        public bool Equals(in ComponentBinaryAbstractNumber other)
        {
            return Operation.Equals(other.Operation);
        }

        public int CompareTo(in ComponentBinaryAbstractNumber other)
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

        partial class Operations : NumberOperations<ComponentBinaryAbstractNumber>, IExtendedNumberOperations<ComponentBinaryAbstractNumber, ComponentBinaryAbstractNumber, ComponentBinaryAbstractNumber>
        {
            public override int Dimension => -1;

            public ComponentBinaryAbstractNumber Create(StandardNumber num)
            {
                return new ComponentBinaryAbstractNumber(HyperMath.Operations.GetOperation(num).AsBinary());
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            yield return this;
        }
    }
}
