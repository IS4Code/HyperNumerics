using IS4.HyperNumerics.Operations;
using System;
using System.Collections;
using System.Collections.Generic;

using static IS4.HyperNumerics.HyperMath;

namespace IS4.HyperNumerics.NumberTypes
{
    /// <summary>
    /// Represents a diagonal number formed from two values of type <typeparamref name="TInner"/>.
    /// </summary>
    /// <typeparam name="TInner">The inner type of the components.</typeparam>
    /// <remarks>
    /// A diagonal number (a, b) can be represented algebraically as a + bk, where k^2 = k.
    /// </remarks>
    [Serializable]
    public readonly partial struct HyperDiagonal<TInner> where TInner : struct, INumber<TInner>
    {
        public bool IsInvertible => CanInv(first) && CanInv(Add(first, second));

        public bool IsFinite => IsFin(first) && IsFin(second);

        public HyperDiagonal<TInner> Call(StandardBinaryOperation operation, in HyperDiagonal<TInner> other)
        {
            switch(operation)
            {
                case StandardBinaryOperation.Add:
                    return new HyperDiagonal<TInner>(Add(first, other.first), Add(second, other.second));
                case StandardBinaryOperation.Subtract:
                    return new HyperDiagonal<TInner>(Sub(first, other.first), Sub(second, other.second));
                case StandardBinaryOperation.Multiply:
                    return new HyperDiagonal<TInner>(Mul(first, other.first), Add(Add(Mul(first, other.second), Mul(second, other.first)), Mul(second, other.second)));
                case StandardBinaryOperation.Divide:
                    var denom = Add(Pow2(other.first), Pow2(other.second));
                    return new HyperDiagonal<TInner>(Div(first, other.first), Div(Sub(second, Div(Mul(first, other.second), other.first)), Add(other.first, other.second)));
                case StandardBinaryOperation.Power:
                    return PowDefault(this, other);
                case StandardBinaryOperation.Atan2:
                    return Atan2Default(this, other);
                default:
                    throw new NotSupportedException();
            }
        }

        public HyperDiagonal<TInner> Call(StandardBinaryOperation operation, in TInner other)
        {
            switch(operation)
            {
                case StandardBinaryOperation.Add:
                    return new HyperDiagonal<TInner>(Add(first, other), second);
                case StandardBinaryOperation.Subtract:
                    return new HyperDiagonal<TInner>(Sub(first, other), second);
                case StandardBinaryOperation.Multiply:
                    return new HyperDiagonal<TInner>(Mul(first, other), Mul(second, other));
                case StandardBinaryOperation.Divide:
                    return new HyperDiagonal<TInner>(Div(first, other), Div(second, other));
                case StandardBinaryOperation.Power:
                    return PowDefault(this, other);
                case StandardBinaryOperation.Atan2:
                    return Atan2Default(this, other);
                default:
                    throw new NotSupportedException();
            }
        }

        public HyperDiagonal<TInner> CallReversed(StandardBinaryOperation operation, in TInner other)
        {
            switch(operation)
            {
                case StandardBinaryOperation.Add:
                    return new HyperDiagonal<TInner>(Add(other, first), second);
                case StandardBinaryOperation.Subtract:
                    return new HyperDiagonal<TInner>(Sub(other, first), Neg(second));
                case StandardBinaryOperation.Multiply:
                    return new HyperDiagonal<TInner>(Mul(other, first), Mul(other, second));
                case StandardBinaryOperation.Divide:
                    var denom = Add(Pow2(first), Pow2(second));
                    return new HyperDiagonal<TInner>(Div(other, first), Div(Neg(Div(Mul(other, second), first)), Add(first, second)));
                case StandardBinaryOperation.Power:
                    return PowDefault(other, this);
                case StandardBinaryOperation.Atan2:
                    return Atan2Default(other, this);
                default:
                    throw new NotSupportedException();
            }
        }

        public HyperDiagonal<TInner> Call(StandardUnaryOperation operation)
        {
            switch(operation)
            {
                case StandardUnaryOperation.Identity:
                    return this;
                case StandardUnaryOperation.Negate:
                    return new HyperDiagonal<TInner>(Neg(this.first), Neg(second));
                case StandardUnaryOperation.Increment:
                    return new HyperDiagonal<TInner>(Inc(this.first), second);
                case StandardUnaryOperation.Decrement:
                    return new HyperDiagonal<TInner>(Dec(this.first), second);
                case StandardUnaryOperation.Inverse:
                    return new HyperDiagonal<TInner>(Inv(this.first), Div(Neg(second), Mul(Add(this.first, second), this.first)));
                case StandardUnaryOperation.Conjugate:
                    return new HyperDiagonal<TInner>(this.first, Neg(second));
                case StandardUnaryOperation.Modulus:
                    return Mul(Add(this.first, second), this.first);
                case StandardUnaryOperation.Double:
                    return new HyperDiagonal<TInner>(Mul2(this.first), Mul2(second));
                case StandardUnaryOperation.Half:
                    return new HyperDiagonal<TInner>(Div2(this.first), Div2(second));
                case StandardUnaryOperation.Square:
                    return new HyperDiagonal<TInner>(Pow2(this.first), Add(Mul2(Mul(this.first, second)), Pow2(second)));
                default:
                    var first = HyperMath.Call(operation, this.first);
                    return new HyperDiagonal<TInner>(first, Sub(HyperMath.Call(operation, Add(this.first, second)), first));
            }
        }

        public TInner CallComponent(StandardUnaryOperation operation)
        {
            throw new NotSupportedException();
        }

        public override bool Equals(object other)
        {
            return other is HyperDiagonal<TInner> value && Equals(in value);
        }
    }

    /// <summary>
    /// Represents a diagonal number formed from two values of type <typeparamref name="TInner"/>.
    /// This version should be used if <typeparamref name="TComponent"/> can be provided.
    /// </summary>
    /// <typeparam name="TInner">The inner type of the components.</typeparam>
    /// <typeparam name="TComponent">The component type the number uses.</typeparam>
    /// <remarks>
    /// A diagonal number (a, b) can be represented algebraically as a + bk, where k^2 = k.
    /// </remarks>
    [Serializable]
    public readonly partial struct HyperDiagonal<TInner, TComponent> where TInner : struct, INumber<TInner, TComponent> where TComponent : struct, IEquatable<TComponent>, IComparable<TComponent>
    {
        public bool IsInvertible => CanInv(first) && CanInv(Add(first, second));

        public bool IsFinite => IsFin(first) && IsFin(second);

        public HyperDiagonal<TInner, TComponent> Call(StandardBinaryOperation operation, in HyperDiagonal<TInner, TComponent> other)
        {
            switch(operation)
            {
                case StandardBinaryOperation.Add:
                    return new HyperDiagonal<TInner, TComponent>(Add(first, other.first), Add(second, other.second));
                case StandardBinaryOperation.Subtract:
                    return new HyperDiagonal<TInner, TComponent>(Sub(first, other.first), Sub(second, other.second));
                case StandardBinaryOperation.Multiply:
                    return new HyperDiagonal<TInner, TComponent>(Mul(first, other.first), Add(Add(Mul(first, other.second), Mul(second, other.first)), Mul(second, other.second)));
                case StandardBinaryOperation.Divide:
                    var denom = Add(Pow2(other.first), Pow2(other.second));
                    return new HyperDiagonal<TInner, TComponent>(Div(first, other.first), Div(Sub(second, Div(Mul(first, other.second), other.first)), Add(other.first, other.second)));
                case StandardBinaryOperation.Power:
                    return PowDefault(this, other);
                case StandardBinaryOperation.Atan2:
                    return Atan2Default(this, other);
                default:
                    throw new NotSupportedException();
            }
        }

        public HyperDiagonal<TInner, TComponent> Call(StandardBinaryOperation operation, in TInner other)
        {
            switch(operation)
            {
                case StandardBinaryOperation.Add:
                    return new HyperDiagonal<TInner, TComponent>(Add(first, other), second);
                case StandardBinaryOperation.Subtract:
                    return new HyperDiagonal<TInner, TComponent>(Sub(first, other), second);
                case StandardBinaryOperation.Multiply:
                    return new HyperDiagonal<TInner, TComponent>(Mul(first, other), Mul(second, other));
                case StandardBinaryOperation.Divide:
                    return new HyperDiagonal<TInner, TComponent>(Div(first, other), Div(second, other));
                case StandardBinaryOperation.Power:
                    return PowDefault(this, other);
                case StandardBinaryOperation.Atan2:
                    return Atan2Default(this, other);
                default:
                    throw new NotSupportedException();
            }
        }

        public HyperDiagonal<TInner, TComponent> CallReversed(StandardBinaryOperation operation, in TInner other)
        {
            switch(operation)
            {
                case StandardBinaryOperation.Add:
                    return new HyperDiagonal<TInner, TComponent>(Add(other, first), second);
                case StandardBinaryOperation.Subtract:
                    return new HyperDiagonal<TInner, TComponent>(Sub(other, first), Neg(second));
                case StandardBinaryOperation.Multiply:
                    return new HyperDiagonal<TInner, TComponent>(Mul(other, first), Mul(other, second));
                case StandardBinaryOperation.Divide:
                    var denom = Add(Pow2(first), Pow2(second));
                    return new HyperDiagonal<TInner, TComponent>(Div(other, first), Div(Neg(Div(Mul(other, second), first)), Add(first, second)));
                case StandardBinaryOperation.Power:
                    return PowDefault(other, this);
                case StandardBinaryOperation.Atan2:
                    return Atan2Default(other, this);
                default:
                    throw new NotSupportedException();
            }
        }

        public HyperDiagonal<TInner, TComponent> Call(StandardBinaryOperation operation, in TComponent other)
        {
            switch(operation)
            {
                case StandardBinaryOperation.Add:
                    return new HyperDiagonal<TInner, TComponent>(AddVal(this.first, other), second);
                case StandardBinaryOperation.Subtract:
                    return new HyperDiagonal<TInner, TComponent>(SubVal(this.first, other), second);
                case StandardBinaryOperation.Multiply:
                    return new HyperDiagonal<TInner, TComponent>(MulVal(this.first, other), MulVal(second, other));
                case StandardBinaryOperation.Divide:
                    return new HyperDiagonal<TInner, TComponent>(DivVal(this.first, other), DivVal(second, other));
                case StandardBinaryOperation.Power:
                    var first = PowVal(this.first, other);
                    return new HyperDiagonal<TInner, TComponent>(first, Sub(PowVal(Add(this.first, second), other), first));
                case StandardBinaryOperation.Atan2:
                    return Atan2Default(this, Operations.Instance.Create(other, default, default, default));
                default:
                    throw new NotSupportedException();
            }
        }

        public HyperDiagonal<TInner, TComponent> CallReversed(StandardBinaryOperation operation, in TComponent other)
        {
            switch(operation)
            {
                case StandardBinaryOperation.Add:
                    return new HyperDiagonal<TInner, TComponent>(AddValRev(other, first), second);
                case StandardBinaryOperation.Subtract:
                    return new HyperDiagonal<TInner, TComponent>(SubValRev(other, first), Neg(second));
                case StandardBinaryOperation.Multiply:
                    return new HyperDiagonal<TInner, TComponent>(MulValRev(other, first), MulValRev(other, second));
                case StandardBinaryOperation.Divide:
                    var denom = Add(Pow2(first), Pow2(second));
                    return new HyperDiagonal<TInner, TComponent>(DivValRev(other, first), Div(Neg(Div(MulValRev(other, second), first)), Add(first, second)));
                case StandardBinaryOperation.Power:
                    return PowDefault(Operations.Instance.Create(other, default, default, default), this);
                case StandardBinaryOperation.Atan2:
                    return Atan2Default(Operations.Instance.Create(other, default, default, default), this);
                default:
                    throw new NotSupportedException();
            }
        }

        public HyperDiagonal<TInner, TComponent> Call(StandardUnaryOperation operation)
        {
            switch(operation)
            {
                case StandardUnaryOperation.Identity:
                    return this;
                case StandardUnaryOperation.Negate:
                    return new HyperDiagonal<TInner, TComponent>(Neg(this.first), Neg(second));
                case StandardUnaryOperation.Increment:
                    return new HyperDiagonal<TInner, TComponent>(Inc(this.first), second);
                case StandardUnaryOperation.Decrement:
                    return new HyperDiagonal<TInner, TComponent>(Dec(this.first), second);
                case StandardUnaryOperation.Inverse:
                    return new HyperDiagonal<TInner, TComponent>(Inv(this.first), Div(Neg(second), Mul(Add(this.first, second), this.first)));
                case StandardUnaryOperation.Conjugate:
                    return new HyperDiagonal<TInner, TComponent>(this.first, Neg(second));
                case StandardUnaryOperation.Modulus:
                    return Mul(Add(this.first, second), this.first);
                case StandardUnaryOperation.Double:
                    return new HyperDiagonal<TInner, TComponent>(Mul2(this.first), Mul2(second));
                case StandardUnaryOperation.Half:
                    return new HyperDiagonal<TInner, TComponent>(Div2(this.first), Div2(second));
                case StandardUnaryOperation.Square:
                    return new HyperDiagonal<TInner, TComponent>(Pow2(this.first), Add(Mul2(Mul(this.first, second)), Pow2(second)));
                default:
                    var first = HyperMath.Call(operation, this.first);
                    return new HyperDiagonal<TInner, TComponent>(first, Sub(HyperMath.Call(operation, Add(this.first, second)), first));
            }
        }

        public TComponent CallComponent(StandardUnaryOperation operation)
        {
            throw new NotSupportedException();
        }

        public override bool Equals(object other)
        {
            return other is HyperDiagonal<TInner, TComponent> value && Equals(in value);
        }
    }
}
