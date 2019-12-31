using IS4.HyperNumerics.NumberTypes;
using IS4.HyperNumerics.Operations;
using System;

namespace IS4.HyperNumerics
{
    /// <summary>
    /// Provides methods for various mathematical functions for any number type.
    /// </summary>
    public static class HyperMath
    {
        static class Constants<TNumber> where TNumber : struct, INumber<TNumber>
        {
            public static readonly TNumber RealOne = Call<TNumber>(NullaryOperation.RealOne);
            public static readonly TNumber PI = Mul2(Mul2(Atan(RealOne)));
            public static readonly TNumber E = Exp(RealOne);
        }

        /// <summary>
        /// Returns the value corresponding to the π constant, calculated as atan(1)/4.
        /// </summary>
        /// <typeparam name="TNumber"></typeparam>
        /// <returns></returns>
        public static TNumber PI<TNumber>() where TNumber : struct, INumber<TNumber>
        {
            return Constants<TNumber>.PI;
        }

        /// <summary>
        /// Returns the value corresponding to the e constant, calculated as exp(1).
        /// </summary>
        /// <typeparam name="TNumber"></typeparam>
        /// <returns></returns>
        public static TNumber E<TNumber>() where TNumber : struct, INumber<TNumber>
        {
            return Constants<TNumber>.E;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="TNumber"></typeparam>
        /// <typeparam name="TPrimitive"></typeparam>
        /// <param name="num"></param>
        /// <returns></returns>
        public static TPrimitive Abs<TNumber, TPrimitive>(in TNumber num) where TNumber : struct, INumber<TNumber, TPrimitive> where TPrimitive : struct, IEquatable<TPrimitive>, IComparable<TPrimitive>
        {
            return Operations.For<TNumber, TPrimitive>.Instance.Call(PrimitiveUnaryOperation.AbsoluteValue, num);
        }

        public static TPrimitive Std<TNumber, TPrimitive>(in TNumber num) where TNumber : struct, INumber<TNumber, TPrimitive> where TPrimitive : struct, IEquatable<TPrimitive>, IComparable<TPrimitive>
        {
            return Operations.For<TNumber, TPrimitive>.Instance.Call(PrimitiveUnaryOperation.RealValue, num);
        }

        public static TNumber Mul2<TNumber>(in TNumber num) where TNumber : struct, INumber<TNumber>
        {
            return Call(UnaryOperation.Double, num);
        }

        public static TNumber Div2<TNumber>(in TNumber num) where TNumber : struct, INumber<TNumber>
        {
            return Call(UnaryOperation.Half, num);
        }

        public static TNumber Add<TNumber>(in TNumber x, in TNumber y) where TNumber : struct, INumber<TNumber>
        {
            return Call(BinaryOperation.Add, x, in y);
        }

        public static TNumber Sub<TNumber>(in TNumber x, in TNumber y) where TNumber : struct, INumber<TNumber>
        {
            return Call(BinaryOperation.Subtract, x, in y);
        }

        public static TNumber Mul<TNumber>(in TNumber x, in TNumber y) where TNumber : struct, INumber<TNumber>
        {
            return Call(BinaryOperation.Multiply, x, in y);
        }

        public static TNumber Div<TNumber>(in TNumber x, in TNumber y) where TNumber : struct, INumber<TNumber>
        {
            return Call(BinaryOperation.Divide, x, in y);
        }

        public static TNumber Pow<TNumber>(in TNumber x, in TNumber y) where TNumber : struct, INumber<TNumber>
        {
            return Call(BinaryOperation.Power, x, in y);
        }

        internal static TNumber PowDefault<TNumber>(in TNumber x, in TNumber y) where TNumber : struct, INumber<TNumber>
        {
            return Exp(Mul(Log(x), y));
        }

        internal static TNumber PowValDefault<TNumber, TPrimitive>(in TNumber x, TPrimitive y) where TNumber : struct, INumber<TNumber, TPrimitive> where TPrimitive : struct, IEquatable<TPrimitive>, IComparable<TPrimitive>
        {
            return Exp(MulVal(Log(x), y));
        }

        public static TNumber AddVal<TNumber, TPrimitive>(in TNumber x, TPrimitive y) where TNumber : struct, INumber<TNumber, TPrimitive> where TPrimitive : struct, IEquatable<TPrimitive>, IComparable<TPrimitive>
        {
            return CallPrimitive(BinaryOperation.Add, x, y);
        }

        public static TNumber SubVal<TNumber, TPrimitive>(in TNumber x, TPrimitive y) where TNumber : struct, INumber<TNumber, TPrimitive> where TPrimitive : struct, IEquatable<TPrimitive>, IComparable<TPrimitive>
        {
            return CallPrimitive(BinaryOperation.Subtract, x, y);
        }

        public static TNumber MulVal<TNumber, TPrimitive>(in TNumber x, TPrimitive y) where TNumber : struct, INumber<TNumber, TPrimitive> where TPrimitive : struct, IEquatable<TPrimitive>, IComparable<TPrimitive>
        {
            return CallPrimitive(BinaryOperation.Multiply, x, y);
        }

        public static TNumber DivVal<TNumber, TPrimitive>(in TNumber x, TPrimitive y) where TNumber : struct, INumber<TNumber, TPrimitive> where TPrimitive : struct, IEquatable<TPrimitive>, IComparable<TPrimitive>
        {
            return CallPrimitive(BinaryOperation.Divide, x, y);
        }

        public static TNumber PowVal<TNumber, TPrimitive>(in TNumber x, TPrimitive y) where TNumber : struct, INumber<TNumber, TPrimitive> where TPrimitive : struct, IEquatable<TPrimitive>, IComparable<TPrimitive>
        {
            return CallPrimitive(BinaryOperation.Power, x, y);
        }

        public static TNumber Neg<TNumber>(in TNumber num) where TNumber : struct, INumber<TNumber>
        {
            return Call(UnaryOperation.Negate, num);
        }

        public static TNumber Inc<TNumber>(in TNumber num) where TNumber : struct, INumber<TNumber>
        {
            return Call(UnaryOperation.Increment, num);
        }

        public static TNumber Dec<TNumber>(in TNumber num) where TNumber : struct, INumber<TNumber>
        {
            return Call(UnaryOperation.Decrement, num);
        }

        public static TNumber Inv<TNumber>(in TNumber num) where TNumber : struct, INumber<TNumber>
        {
            return Call(UnaryOperation.Inverse, num);
        }

        public static TNumber Con<TNumber>(in TNumber num) where TNumber : struct, INumber<TNumber>
        {
            return Call(UnaryOperation.Conjugate, num);
        }

        public static TNumber Mods<TNumber>(in TNumber num) where TNumber : struct, INumber<TNumber>
        {
            return Call(UnaryOperation.Modulus, num);
        }

        public static bool CanInv<TNumber>(in TNumber num) where TNumber : struct, INumber<TNumber>
        {
            return Operations.For<TNumber>.Instance.IsInvertible(num);
        }

        public static bool IsFin<TNumber>(in TNumber num) where TNumber : struct, INumber<TNumber>
        {
            return Operations.For<TNumber>.Instance.IsFinite(num);
        }

        public static TNumber Pow2<TNumber>(in TNumber num) where TNumber : struct, INumber<TNumber>
        {
            return Call(UnaryOperation.Square, num);
        }

        public static TNumber Sqrt<TNumber>(in TNumber num) where TNumber : struct, INumber<TNumber>
        {
            return Call(UnaryOperation.SquareRoot, num);
        }

        internal static TNumber SqrtDefault<TNumber>(in TNumber num) where TNumber : struct, INumber<TNumber>
        {
            return Exp(Div2(Log(num)));
        }

        public static TNumber Sin<TNumber>(in TNumber num) where TNumber : struct, INumber<TNumber>
        {
            return Call(UnaryOperation.Sine, num);
        }

        public static TNumber Cos<TNumber>(in TNumber num) where TNumber : struct, INumber<TNumber>
        {
            return Call(UnaryOperation.Cosine, num);
        }

        public static TNumber Tan<TNumber>(in TNumber num) where TNumber : struct, INumber<TNumber>
        {
            return Call(UnaryOperation.Tangent, num);
        }

        public static TNumber Sinh<TNumber>(in TNumber num) where TNumber : struct, INumber<TNumber>
        {
            return Call(UnaryOperation.HyperbolicSine, num);
        }

        public static TNumber Cosh<TNumber>(in TNumber num) where TNumber : struct, INumber<TNumber>
        {
            return Call(UnaryOperation.HyperbolicCosine, num);
        }

        public static TNumber Tanh<TNumber>(in TNumber num) where TNumber : struct, INumber<TNumber>
        {
            return Call(UnaryOperation.HyperbolicTangent, num);
        }

        internal static TNumber SinhDefault<TNumber>(in TNumber num) where TNumber : struct, INumber<TNumber>
        {
            return Sub(Div2(Exp(num)), Exp(Neg(num)));
        }

        internal static TNumber CoshDefault<TNumber>(in TNumber num) where TNumber : struct, INumber<TNumber>
        {
            return Add(Div2(Exp(num)), Exp(Neg(num)));
        }

        internal static TNumber TanhDefault<TNumber>(in TNumber num) where TNumber : struct, INumber<TNumber>
        {
            var denom = Inc(Exp(Mul2(num)));
            return Div(Dec(Exp(Mul2(num))), denom);
        }

        public static TNumber Asin<TNumber>(in TNumber num) where TNumber : struct, INumber<TNumber>
        {
            return Call(UnaryOperation.ArcSine, num);
        }

        public static TNumber Acos<TNumber>(in TNumber num) where TNumber : struct, INumber<TNumber>
        {
            return Call(UnaryOperation.ArcCosine, num);
        }

        public static TNumber Atan<TNumber>(in TNumber num) where TNumber : struct, INumber<TNumber>
        {
            return Call(UnaryOperation.ArcTangent, num);
        }

        public static TNumber Atan2<TNumber>(in TNumber y, in TNumber x) where TNumber : struct, INumber<TNumber>
        {
            return Call<TNumber>(BinaryOperation.Atan2, in y, in x);
        }

        internal static TNumber Atan2Default<TNumber>(in TNumber y, in TNumber x) where TNumber : struct, INumber<TNumber>
        {
            if(Operations.For<TNumber>.Instance.IsInvertible(y))
            {
                return Mul2(Atan(Div(Sub(Sqrt(Add(Pow2(x), Pow2(y))), x), y)));
            }
            var value = Atan(Div(y, x));
            if(Operations.For<TNumber>.Instance.IsInvertible(Add(Sqrt(Pow2(x)), x)))
            {
                return value;
            }
            return Add(value, PI<TNumber>());
        }

        public static TNumber Exp<TNumber>(in TNumber num) where TNumber : struct, INumber<TNumber>
        {
            return Call(UnaryOperation.Exponentiate, num);
        }

        public static TNumber Log<TNumber>(in TNumber num) where TNumber : struct, INumber<TNumber>
        {
            return Call(UnaryOperation.Logarithm, num);
        }

        public static TNumber Clone<TNumber>(in TNumber num) where TNumber : struct, INumber<TNumber>
        {
            return Operations.For<TNumber>.Instance.Clone(num);
        }

        public static bool Equals<TNumber>(in TNumber num1, in TNumber num2) where TNumber : struct, INumber<TNumber>
        {
            return Operations.For<TNumber>.Instance.Equals(num1, num2);
        }

        public static int Compare<TNumber>(in TNumber num1, in TNumber num2) where TNumber : struct, INumber<TNumber>
        {
            return Operations.For<TNumber>.Instance.Compare(num1, num2);
        }

        public static TNumber Call<TNumber>(NullaryOperation operation) where TNumber : struct, INumber<TNumber>
        {
            return Operations.For<TNumber>.Instance.Call(operation);
        }

        public static TNumber Call<TNumber>(UnaryOperation operation, in TNumber num) where TNumber : struct, INumber<TNumber>
        {
            return Operations.For<TNumber>.Instance.Call(operation, num);
        }

        public static TNumber Call<TNumber>(BinaryOperation operation, in TNumber num1, in TNumber num2) where TNumber : struct, INumber<TNumber>
        {
            return Operations.For<TNumber>.Instance.Call(operation, num1, num2);
        }

        public static TNumber CallInner<TNumber, TInner>(BinaryOperation operation, in TNumber num1, in TInner num2) where TNumber : struct, IExtendedNumber<TNumber, TInner> where TInner : struct, INumber<TInner>
        {
            return Operations.ForExtended<TNumber, TInner>.Instance.Call(operation, num1, num2);
        }

        public static TNumber CallPrimitive<TNumber, TPrimitive>(BinaryOperation operation, in TNumber num1, TPrimitive num2) where TNumber : struct, INumber<TNumber, TPrimitive> where TPrimitive : struct, IEquatable<TPrimitive>, IComparable<TPrimitive>
        {
            return Operations.For<TNumber, TPrimitive>.Instance.Call(operation, num1, num2);
        }

        public static TPrimitive Call<TNumber, TPrimitive>(PrimitiveUnaryOperation operation, in TNumber num) where TNumber : struct, INumber<TNumber, TPrimitive> where TPrimitive : struct, IEquatable<TPrimitive>, IComparable<TPrimitive>
        {
            return Operations.For<TNumber, TPrimitive>.Instance.Call(operation, num);
        }

        public static TNumber Create<TNumber, TPrimitive>(TPrimitive realUnit = default, TPrimitive otherUnits = default, TPrimitive someUnitsCombined = default, TPrimitive allUnitsCombined = default) where TNumber : struct, INumber<TNumber, TPrimitive> where TPrimitive : struct, IEquatable<TPrimitive>, IComparable<TPrimitive>
        {
            return Operations.For<TNumber, TPrimitive>.Instance.Create(realUnit, otherUnits, someUnitsCombined, allUnitsCombined);
        }

        public static TNumber[] GetDerivative<TNumber>(IUnaryNumberOperation func, in TNumber num, int depth) where TNumber : struct, INumber<TNumber>
        {
            if(depth < 0)
            {
                throw new ArgumentOutOfRangeException(nameof(depth));
            }
            if(depth == 0)
            {
                return new TNumber[]{ func.Invoke(num) };
            }
            var arr = new TNumber[depth + 1];
            arr[0] = GetDerivativeValue(num, func, arr, depth - 1, 1, (in TNumber n) => n);
            return arr;
        }

        delegate TNumber ValueSelector<TInner, TNumber>(in TInner num) where TInner : struct, INumber<TInner> where TNumber : struct, INumber<TNumber>;
        static TInner GetDerivativeValue<TInner, TNumber>(in TInner num, IUnaryNumberOperation func, TNumber[] arr, int depth, int offset, ValueSelector<TInner, TNumber> valueSelector) where TInner : struct, INumber<TInner> where TNumber : struct, INumber<TNumber>
        {
            var value = new HyperDual<TInner>(num, Constants<TInner>.RealOne);
            if(depth == 0)
            {
                value = func.Invoke(value);
            }else{
                value = GetDerivativeValue(value, func, arr, depth - 1, offset + 1, (in HyperDual<TInner> n) => valueSelector(n.Second));
            }
            arr[offset] = valueSelector(value.Second);
            return value.First;
        }

        public class Derivative : IUnaryNumberOperation
        {
            readonly IUnaryNumberOperation func;
            readonly int order;

            public Derivative(IUnaryNumberOperation func, int order)
            {
                if(order < 1)
                {
                    throw new ArgumentOutOfRangeException(nameof(order));
                }
                this.func = func;
                this.order = order;
            }

            public TNumber Invoke<TNumber>(in TNumber arg) where TNumber : struct, INumber<TNumber>
            {
                return GetDerivative(func, arg, order)[order];
            }

            public TNumber Invoke<TNumber, TPrimitive>(in TNumber arg) where TNumber : struct, INumber<TNumber, TPrimitive> where TPrimitive : struct, IEquatable<TPrimitive>, IComparable<TPrimitive>
            {
                return Invoke<TNumber>(arg);
            }
        }

        public static class Operations
        {
            public static class For<TNumber> where TNumber : struct, INumber<TNumber>
            {
                public static readonly INumberOperations<TNumber> Instance = default(TNumber).GetOperations();
            }

            public static class For<TNumber, TPrimitive> where TNumber : struct, INumber<TNumber, TPrimitive> where TPrimitive : struct, IEquatable<TPrimitive>, IComparable<TPrimitive>
            {
                public static readonly INumberOperations<TNumber, TPrimitive> Instance = default(TNumber).GetOperations();
            }

            public static class ForExtended<TNumber, TInner> where TNumber : struct, IExtendedNumber<TNumber, TInner> where TInner : struct, INumber<TInner>
            {
                public static readonly IExtendedNumberOperations<TNumber, TInner> Instance = default(TNumber).GetOperations();
            }

            public static class ForExtended<TNumber, TInner, TPrimitive> where TNumber : struct, IExtendedNumber<TNumber, TInner, TPrimitive> where TInner : struct, INumber<TInner, TPrimitive> where TPrimitive : struct, IEquatable<TPrimitive>, IComparable<TPrimitive>
            {
                public static readonly IExtendedNumberOperations<TNumber, TInner, TPrimitive> Instance = default(TNumber).GetOperations();
            }

            public static class ForHyper<TNumber, TInner> where TNumber : struct, IHyperNumber<TNumber, TInner> where TInner : struct, INumber<TInner>
            {
                public static readonly IHyperNumberOperations<TNumber, TInner> Instance = default(TNumber).GetOperations();
            }

            public static class ForHyper<TNumber, TInner, TPrimitive> where TNumber : struct, IHyperNumber<TNumber, TInner, TPrimitive> where TInner : struct, INumber<TInner, TPrimitive> where TPrimitive : struct, IEquatable<TPrimitive>, IComparable<TPrimitive>
            {
                public static readonly IHyperNumberOperations<TNumber, TInner, TPrimitive> Instance = default(TNumber).GetOperations();
            }

            public static readonly INumberOperation Default = new DefaultNullaryOperation();
            public static readonly INumberOperation Zero = new NumberNullaryOperation(NullaryOperation.Zero);
            public static readonly INumberOperation RealOne = new NumberNullaryOperation(NullaryOperation.RealOne);
            public static readonly INumberOperation SpecialOne = new NumberNullaryOperation(NullaryOperation.SpecialOne);
            public static readonly INumberOperation UnitsOne = new NumberNullaryOperation(NullaryOperation.UnitsOne);
            public static readonly INumberOperation NonRealUnitsOne = new NumberNullaryOperation(NullaryOperation.NonRealUnitsOne);
            public static readonly INumberOperation CombinedOne = new NumberNullaryOperation(NullaryOperation.CombinedOne);
            public static readonly INumberOperation AllOne = new NumberNullaryOperation(NullaryOperation.AllOne);
            public static readonly INumberOperation PI = new PIOperation();
            public static readonly INumberOperation E = new EOperation();
            public static readonly IUnaryNumberOperation Id = new IdOperation();
            public static readonly IBinaryNumberOperation Add = new NumberBinaryOperation(BinaryOperation.Add);
            public static readonly IBinaryNumberOperation Sub = new NumberBinaryOperation(BinaryOperation.Subtract);
            public static readonly IBinaryNumberOperation Mul = new NumberBinaryOperation(BinaryOperation.Multiply);
            public static readonly IBinaryNumberOperation Div = new NumberBinaryOperation(BinaryOperation.Divide);
            public static readonly IUnaryNumberOperation Neg = new NumberUnaryOperation(UnaryOperation.Negate);
            public static readonly IUnaryNumberOperation Inv = new NumberUnaryOperation(UnaryOperation.Inverse);
            public static readonly IUnaryNumberOperation Inc = new NumberUnaryOperation(UnaryOperation.Increment);
            public static readonly IUnaryNumberOperation Dec = new NumberUnaryOperation(UnaryOperation.Decrement);
            public static readonly IUnaryNumberOperation Con = new NumberUnaryOperation(UnaryOperation.Conjugate);
            public static readonly IUnaryNumberOperation Mods = new NumberUnaryOperation(UnaryOperation.Modulus);
            public static readonly IPrimitiveUnaryNumberFunc<ValueType> Abs = new NumberPrimitiveUnaryOperation(PrimitiveUnaryOperation.AbsoluteValue);
            public static readonly IUnaryNumberOperation Mul2 = new NumberUnaryOperation(UnaryOperation.Double);
            public static readonly IUnaryNumberOperation Div2 = new NumberUnaryOperation(UnaryOperation.Half);
            public static readonly IBinaryNumberOperation Pow = new NumberBinaryOperation(BinaryOperation.Power);
            public static readonly IUnaryNumberOperation Pow2 = new NumberUnaryOperation(UnaryOperation.Square);
            public static readonly IUnaryNumberOperation Sqrt = new NumberUnaryOperation(UnaryOperation.SquareRoot);
            public static readonly IUnaryNumberOperation Sin = new NumberUnaryOperation(UnaryOperation.Sine);
            public static readonly IUnaryNumberOperation Cos = new NumberUnaryOperation(UnaryOperation.Cosine);
            public static readonly IUnaryNumberOperation Tan = new NumberUnaryOperation(UnaryOperation.Tangent);
            public static readonly IUnaryNumberOperation Sinh = new NumberUnaryOperation(UnaryOperation.HyperbolicSine);
            public static readonly IUnaryNumberOperation Cosh = new NumberUnaryOperation(UnaryOperation.HyperbolicCosine);
            public static readonly IUnaryNumberOperation Tanh = new NumberUnaryOperation(UnaryOperation.HyperbolicTangent);
            public static readonly IUnaryNumberOperation Asin = new NumberUnaryOperation(UnaryOperation.ArcSine);
            public static readonly IUnaryNumberOperation Acos = new NumberUnaryOperation(UnaryOperation.ArcCosine);
            public static readonly IUnaryNumberOperation Atan = new NumberUnaryOperation(UnaryOperation.ArcTangent);
            public static readonly IBinaryNumberOperation Atan2 = new NumberBinaryOperation(BinaryOperation.Atan2);
            public static readonly IUnaryNumberOperation Exp = new NumberUnaryOperation(UnaryOperation.Exponentiate);
            public static readonly IUnaryNumberOperation Log = new NumberUnaryOperation(UnaryOperation.Logarithm);

            public static INumberOperation GetOperation(NullaryOperation operation)
            {
                switch(operation)
                {
                    case NullaryOperation.Zero:
                        return Zero;
                    case NullaryOperation.RealOne:
                        return RealOne;
                    case NullaryOperation.SpecialOne:
                        return SpecialOne;
                    case NullaryOperation.UnitsOne:
                        return UnitsOne;
                    case NullaryOperation.NonRealUnitsOne:
                        return NonRealUnitsOne;
                    case NullaryOperation.CombinedOne:
                        return CombinedOne;
                    case NullaryOperation.AllOne:
                        return AllOne;
                    default:
                        return new NumberNullaryOperation(operation);
                }
            }

            public static IUnaryNumberOperation GetOperation(UnaryOperation operation)
            {
                switch(operation)
                {
                    case UnaryOperation.Negate:
                        return Neg;
                    case UnaryOperation.Increment:
                        return Inc;
                    case UnaryOperation.Decrement:
                        return Dec;
                    case UnaryOperation.Inverse:
                        return Inv;
                    case UnaryOperation.Conjugate:
                        return Con;
                    case UnaryOperation.Modulus:
                        return Mods;
                    case UnaryOperation.Double:
                        return Mul2;
                    case UnaryOperation.Half:
                        return Div2;
                    case UnaryOperation.Square:
                        return Pow2;
                    case UnaryOperation.SquareRoot:
                        return Sqrt;
                    case UnaryOperation.Exponentiate:
                        return Exp;
                    case UnaryOperation.Logarithm:
                        return Log;
                    case UnaryOperation.Sine:
                        return Sin;
                    case UnaryOperation.Cosine:
                        return Cos;
                    case UnaryOperation.Tangent:
                        return Tan;
                    case UnaryOperation.HyperbolicSine:
                        return Sinh;
                    case UnaryOperation.HyperbolicCosine:
                        return Cosh;
                    case UnaryOperation.HyperbolicTangent:
                        return Tanh;
                    case UnaryOperation.ArcSine:
                        return Asin;
                    case UnaryOperation.ArcCosine:
                        return Acos;
                    case UnaryOperation.ArcTangent:
                        return Atan;
                    default:
                        return new NumberUnaryOperation(operation);
                }
            }

            public static IBinaryNumberOperation GetOperation(BinaryOperation operation)
            {
                switch(operation)
                {
                    case BinaryOperation.Add:
                        return Add;
                    case BinaryOperation.Subtract:
                        return Sub;
                    case BinaryOperation.Multiply:
                        return Mul;
                    case BinaryOperation.Divide:
                        return Div;
                    case BinaryOperation.Power:
                        return Pow;
                    case BinaryOperation.Atan2:
                        return Atan2;
                    default:
                        return new NumberBinaryOperation(operation);
                }
            }

            class PIOperation : DynamicNumberOperation<INumberOperation>, INumberOperation
            {
                public TNumber Invoke<TNumber>() where TNumber : struct, INumber<TNumber>
                {
                    return PI<TNumber>();
                }

                public TNumber Invoke<TNumber, TPrimitive>() where TNumber : struct, INumber<TNumber, TPrimitive> where TPrimitive : struct, IEquatable<TPrimitive>, IComparable<TPrimitive>
                {
                    return PI<TNumber>();
                }

                public override string ToString()
                {
                    return "PI";
                }
            }

            class EOperation : DynamicNumberOperation<INumberOperation>, INumberOperation
            {
                public TNumber Invoke<TNumber>() where TNumber : struct, INumber<TNumber>
                {
                    return E<TNumber>();
                }

                public TNumber Invoke<TNumber, TPrimitive>() where TNumber : struct, INumber<TNumber, TPrimitive> where TPrimitive : struct, IEquatable<TPrimitive>, IComparable<TPrimitive>
                {
                    return E<TNumber>();
                }

                public override string ToString()
                {
                    return "E";
                }
            }

            class IdOperation : DynamicNumberOperation<IUnaryNumberOperation>, IUnaryNumberOperation
            {
                public TNumber Invoke<TNumber>(in TNumber num) where TNumber : struct, INumber<TNumber>
                {
                    return num;
                }

                public TNumber Invoke<TNumber, TPrimitive>(in TNumber num) where TNumber : struct, INumber<TNumber, TPrimitive> where TPrimitive : struct, IEquatable<TPrimitive>, IComparable<TPrimitive>
                {
                    return num;
                }

                public override string ToString()
                {
                    return "Id";
                }
            }

            class DefaultNullaryOperation : DynamicNumberOperation<INumberOperation>, INumberOperation
            {
                public TNumber Invoke<TNumber>() where TNumber : struct, INumber<TNumber>
                {
                    return default;
                }

                public TNumber Invoke<TNumber, TPrimitive>() where TNumber : struct, INumber<TNumber, TPrimitive> where TPrimitive : struct, IEquatable<TPrimitive>, IComparable<TPrimitive>
                {
                    return default;
                }

                public override string ToString()
                {
                    return "default";
                }
            }

            class NumberNullaryOperation : DynamicNumberOperation<INumberOperation>, INumberOperation
            {
                readonly NullaryOperation type;

                public NumberNullaryOperation(NullaryOperation type)
                {
                    this.type = type;
                }

                public TNumber Invoke<TNumber>() where TNumber : struct, INumber<TNumber>
                {
                    return For<TNumber>.Instance.Call(type);
                }

                public TNumber Invoke<TNumber, TPrimitive>() where TNumber : struct, INumber<TNumber, TPrimitive> where TPrimitive : struct, IEquatable<TPrimitive>, IComparable<TPrimitive>
                {
                    return For<TNumber, TPrimitive>.Instance.Call(type);
                }

                public override string ToString()
                {
                    return type.ToString();
                }
            }

            class NumberUnaryOperation : DynamicNumberOperation<IUnaryNumberOperation>, IUnaryNumberOperation
            {
                readonly UnaryOperation type;

                public NumberUnaryOperation(UnaryOperation type)
                {
                    this.type = type;
                }

                public TNumber Invoke<TNumber>(in TNumber num) where TNumber : struct, INumber<TNumber>
                {
                    return For<TNumber>.Instance.Call(type, num);
                }

                public TNumber Invoke<TNumber, TPrimitive>(in TNumber num) where TNumber : struct, INumber<TNumber, TPrimitive> where TPrimitive : struct, IEquatable<TPrimitive>, IComparable<TPrimitive>
                {
                    return For<TNumber, TPrimitive>.Instance.Call(type, num);
                }

                public override string ToString()
                {
                    return type.ToString();
                }
            }

            class NumberBinaryOperation : DynamicNumberOperation<IBinaryNumberOperation>, IBinaryNumberOperation
            {
                readonly BinaryOperation type;

                public NumberBinaryOperation(BinaryOperation type)
                {
                    this.type = type;
                }

                public TNumber Invoke<TNumber>(in TNumber x, in TNumber y) where TNumber : struct, INumber<TNumber>
                {
                    return For<TNumber>.Instance.Call(type, x, y);
                }

                public TNumber Invoke<TNumber, TPrimitive>(in TNumber x, in TNumber y) where TNumber : struct, INumber<TNumber, TPrimitive> where TPrimitive : struct, IEquatable<TPrimitive>, IComparable<TPrimitive>
                {
                    return For<TNumber, TPrimitive>.Instance.Call(type, x, y);
                }

                public override string ToString()
                {
                    return type.ToString();
                }
            }

            class NumberPrimitiveUnaryOperation : DynamicNumberOperation<IPrimitiveUnaryNumberFunc<ValueType>>, IPrimitiveUnaryNumberFunc<ValueType>
            {
                readonly PrimitiveUnaryOperation type;

                public NumberPrimitiveUnaryOperation(PrimitiveUnaryOperation type)
                {
                    this.type = type;
                }

                public ValueType Invoke<TNumber, TPrimitive>(in TNumber num) where TNumber : struct, INumber<TNumber, TPrimitive> where TPrimitive : struct, IEquatable<TPrimitive>, IComparable<TPrimitive>
                {
                    return For<TNumber, TPrimitive>.Instance.Call(type, num);
                }

                public override string ToString()
                {
                    return type.ToString();
                }
            }
        }
    }
}
