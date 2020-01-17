using IS4.HyperNumerics.NumberTypes;
using IS4.HyperNumerics.Operations;
using System;
using System.Collections.Generic;

namespace IS4.HyperNumerics
{
    /// <summary>
    /// Provides methods for various mathematical functions for any number type.
    /// </summary>
    public static class HyperMath
    {
        static class Constants<TNumber> where TNumber : struct, INumber<TNumber>
        {
            public static readonly TNumber RealOne = Create<TNumber>(StandardNumber.One);
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
        /// <typeparam name="TComponent"></typeparam>
        /// <param name="num"></param>
        /// <returns></returns>
        public static TComponent Abs<TNumber, TComponent>(in TNumber num) where TNumber : struct, INumber<TNumber, TComponent> where TComponent : struct, IEquatable<TComponent>, IComparable<TComponent>
        {
            return Operations.For<TNumber, TComponent>.Instance.CallComponent(StandardUnaryOperation.Identity, num);
        }

        public static TNumber Mul2<TNumber>(in TNumber num) where TNumber : struct, INumber<TNumber>
        {
            return Call(StandardUnaryOperation.Double, num);
        }

        public static TNumber Div2<TNumber>(in TNumber num) where TNumber : struct, INumber<TNumber>
        {
            return Call(StandardUnaryOperation.Half, num);
        }

        public static TNumber Add<TNumber>(in TNumber x, in TNumber y) where TNumber : struct, INumber<TNumber>
        {
            return Call(StandardBinaryOperation.Add, x, in y);
        }

        public static TNumber Sub<TNumber>(in TNumber x, in TNumber y) where TNumber : struct, INumber<TNumber>
        {
            return Call(StandardBinaryOperation.Subtract, x, in y);
        }

        public static TNumber Mul<TNumber>(in TNumber x, in TNumber y) where TNumber : struct, INumber<TNumber>
        {
            return Call(StandardBinaryOperation.Multiply, x, in y);
        }

        public static TNumber Div<TNumber>(in TNumber x, in TNumber y) where TNumber : struct, INumber<TNumber>
        {
            return Call(StandardBinaryOperation.Divide, x, in y);
        }

        public static TNumber Pow<TNumber>(in TNumber x, in TNumber y) where TNumber : struct, INumber<TNumber>
        {
            return Call(StandardBinaryOperation.Power, x, in y);
        }

        internal static TNumber PowDefault<TNumber>(in TNumber x, in TNumber y) where TNumber : struct, INumber<TNumber>
        {
            return Exp(Mul(Log(x), y));
        }

        internal static TNumber PowValDefault<TNumber, TComponent>(in TNumber x, in TComponent y) where TNumber : struct, INumber<TNumber, TComponent> where TComponent : struct, IEquatable<TComponent>, IComparable<TComponent>
        {
            return Exp(MulVal(Log(x), y));
        }

        public static TNumber AddVal<TNumber, TComponent>(in TNumber x, in TComponent y) where TNumber : struct, INumber<TNumber, TComponent> where TComponent : struct, IEquatable<TComponent>, IComparable<TComponent>
        {
            return CallComponent(StandardBinaryOperation.Add, x, y);
        }

        public static TNumber SubVal<TNumber, TComponent>(in TNumber x, in TComponent y) where TNumber : struct, INumber<TNumber, TComponent> where TComponent : struct, IEquatable<TComponent>, IComparable<TComponent>
        {
            return CallComponent(StandardBinaryOperation.Subtract, x, y);
        }

        public static TNumber MulVal<TNumber, TComponent>(in TNumber x, in TComponent y) where TNumber : struct, INumber<TNumber, TComponent> where TComponent : struct, IEquatable<TComponent>, IComparable<TComponent>
        {
            return CallComponent(StandardBinaryOperation.Multiply, x, y);
        }

        public static TNumber DivVal<TNumber, TComponent>(in TNumber x, in TComponent y) where TNumber : struct, INumber<TNumber, TComponent> where TComponent : struct, IEquatable<TComponent>, IComparable<TComponent>
        {
            return CallComponent(StandardBinaryOperation.Divide, x, y);
        }

        public static TNumber PowVal<TNumber, TComponent>(in TNumber x, in TComponent y) where TNumber : struct, INumber<TNumber, TComponent> where TComponent : struct, IEquatable<TComponent>, IComparable<TComponent>
        {
            return CallComponent(StandardBinaryOperation.Power, x, y);
        }

        public static TNumber AddValRev<TNumber, TComponent>(in TComponent x, in TNumber y) where TNumber : struct, INumber<TNumber, TComponent> where TComponent : struct, IEquatable<TComponent>, IComparable<TComponent>
        {
            return CallComponentReversed(StandardBinaryOperation.Add, x, y);
        }

        public static TNumber SubValRev<TNumber, TComponent>(in TComponent x, in TNumber y) where TNumber : struct, INumber<TNumber, TComponent> where TComponent : struct, IEquatable<TComponent>, IComparable<TComponent>
        {
            return CallComponentReversed(StandardBinaryOperation.Subtract, x, y);
        }

        public static TNumber MulValRev<TNumber, TComponent>(in TComponent x, in TNumber y) where TNumber : struct, INumber<TNumber, TComponent> where TComponent : struct, IEquatable<TComponent>, IComparable<TComponent>
        {
            return CallComponentReversed(StandardBinaryOperation.Multiply, x, y);
        }

        public static TNumber DivValRev<TNumber, TComponent>(in TComponent x, in TNumber y) where TNumber : struct, INumber<TNumber, TComponent> where TComponent : struct, IEquatable<TComponent>, IComparable<TComponent>
        {
            return CallComponentReversed(StandardBinaryOperation.Divide, x, y);
        }

        public static TNumber PowValRev<TNumber, TComponent>(in TComponent x, in TNumber y) where TNumber : struct, INumber<TNumber, TComponent> where TComponent : struct, IEquatable<TComponent>, IComparable<TComponent>
        {
            return CallComponentReversed(StandardBinaryOperation.Power, x, y);
        }

        public static TNumber Neg<TNumber>(in TNumber num) where TNumber : struct, INumber<TNumber>
        {
            return Call(StandardUnaryOperation.Negate, num);
        }

        public static TNumber Inc<TNumber>(in TNumber num) where TNumber : struct, INumber<TNumber>
        {
            return Call(StandardUnaryOperation.Increment, num);
        }

        public static TNumber Dec<TNumber>(in TNumber num) where TNumber : struct, INumber<TNumber>
        {
            return Call(StandardUnaryOperation.Decrement, num);
        }

        public static TNumber Inv<TNumber>(in TNumber num) where TNumber : struct, INumber<TNumber>
        {
            return Call(StandardUnaryOperation.Inverse, num);
        }

        public static TNumber Con<TNumber>(in TNumber num) where TNumber : struct, INumber<TNumber>
        {
            return Call(StandardUnaryOperation.Conjugate, num);
        }

        public static TNumber Mods<TNumber>(in TNumber num) where TNumber : struct, INumber<TNumber>
        {
            return Call(StandardUnaryOperation.Modulus, num);
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
            return Call(StandardUnaryOperation.Square, num);
        }

        public static TNumber Sqrt<TNumber>(in TNumber num) where TNumber : struct, INumber<TNumber>
        {
            return Call(StandardUnaryOperation.SquareRoot, num);
        }

        internal static TNumber SqrtDefault<TNumber>(in TNumber num) where TNumber : struct, INumber<TNumber>
        {
            return Exp(Div2(Log(num)));
        }

        public static TNumber Sin<TNumber>(in TNumber num) where TNumber : struct, INumber<TNumber>
        {
            return Call(StandardUnaryOperation.Sine, num);
        }

        public static TNumber Cos<TNumber>(in TNumber num) where TNumber : struct, INumber<TNumber>
        {
            return Call(StandardUnaryOperation.Cosine, num);
        }

        public static TNumber Tan<TNumber>(in TNumber num) where TNumber : struct, INumber<TNumber>
        {
            return Call(StandardUnaryOperation.Tangent, num);
        }

        public static TNumber Sinh<TNumber>(in TNumber num) where TNumber : struct, INumber<TNumber>
        {
            return Call(StandardUnaryOperation.HyperbolicSine, num);
        }

        public static TNumber Cosh<TNumber>(in TNumber num) where TNumber : struct, INumber<TNumber>
        {
            return Call(StandardUnaryOperation.HyperbolicCosine, num);
        }

        public static TNumber Tanh<TNumber>(in TNumber num) where TNumber : struct, INumber<TNumber>
        {
            return Call(StandardUnaryOperation.HyperbolicTangent, num);
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
            return Call(StandardUnaryOperation.ArcSine, num);
        }

        public static TNumber Acos<TNumber>(in TNumber num) where TNumber : struct, INumber<TNumber>
        {
            return Call(StandardUnaryOperation.ArcCosine, num);
        }

        public static TNumber Atan<TNumber>(in TNumber num) where TNumber : struct, INumber<TNumber>
        {
            return Call(StandardUnaryOperation.ArcTangent, num);
        }

        public static TNumber Atan2<TNumber>(in TNumber y, in TNumber x) where TNumber : struct, INumber<TNumber>
        {
            return Call<TNumber>(StandardBinaryOperation.Atan2, in y, in x);
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
            return Call(StandardUnaryOperation.Exponentiate, num);
        }

        public static TNumber Log<TNumber>(in TNumber num) where TNumber : struct, INumber<TNumber>
        {
            return Call(StandardUnaryOperation.Logarithm, num);
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

        public static TNumber Create<TNumber>(StandardNumber num) where TNumber : struct, INumber<TNumber>
        {
            return Operations.For<TNumber>.Instance.Create(num);
        }

        public static TNumber Call<TNumber>(StandardUnaryOperation operation, in TNumber num) where TNumber : struct, INumber<TNumber>
        {
            return Operations.For<TNumber>.Instance.Call(operation, num);
        }

        public static TNumber Call<TNumber>(StandardBinaryOperation operation, in TNumber num1, in TNumber num2) where TNumber : struct, INumber<TNumber>
        {
            return Operations.For<TNumber>.Instance.Call(operation, num1, num2);
        }

        public static TNumber CallInner<TNumber, TInner>(StandardBinaryOperation operation, in TNumber num1, in TInner num2) where TNumber : struct, IExtendedNumber<TNumber, TInner> where TInner : struct, INumber<TInner>
        {
            return Operations.ForExtended<TNumber, TInner>.Instance.Call(operation, num1, num2);
        }

        public static TNumber CallComponent<TNumber, TComponent>(StandardBinaryOperation operation, in TNumber num1, in TComponent num2) where TNumber : struct, INumber<TNumber, TComponent> where TComponent : struct, IEquatable<TComponent>, IComparable<TComponent>
        {
            return Operations.For<TNumber, TComponent>.Instance.Call(operation, num1, num2);
        }

        public static TNumber CallComponentReversed<TNumber, TComponent>(StandardBinaryOperation operation, in TComponent num1, in TNumber num2) where TNumber : struct, INumber<TNumber, TComponent> where TComponent : struct, IEquatable<TComponent>, IComparable<TComponent>
        {
            return Operations.For<TNumber, TComponent>.Instance.Call(operation, num1, num2);
        }

        public static TComponent CallComponent<TNumber, TComponent>(StandardUnaryOperation operation, in TNumber num) where TNumber : struct, INumber<TNumber, TComponent> where TComponent : struct, IEquatable<TComponent>, IComparable<TComponent>
        {
            return Operations.For<TNumber, TComponent>.Instance.CallComponent(operation, num);
        }

        public static TNumber Create<TNumber, TComponent>(in TComponent realUnit = default, in TComponent otherUnits = default, TComponent someUnitsCombined = default, TComponent allUnitsCombined = default) where TNumber : struct, INumber<TNumber, TComponent> where TComponent : struct, IEquatable<TComponent>, IComparable<TComponent>
        {
            return Operations.For<TNumber, TComponent>.Instance.Create(realUnit, otherUnits, someUnitsCombined, allUnitsCombined);
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

            public TNumber Invoke<TNumber, TComponent>(in TNumber arg) where TNumber : struct, INumber<TNumber, TComponent> where TComponent : struct, IEquatable<TComponent>, IComparable<TComponent>
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

            public static class For<TNumber, TComponent> where TNumber : struct, INumber<TNumber, TComponent> where TComponent : struct, IEquatable<TComponent>, IComparable<TComponent>
            {
                public static readonly INumberOperations<TNumber, TComponent> Instance = default(TNumber).GetOperations();
            }

            public static class ForExtended<TNumber, TInner> where TNumber : struct, IExtendedNumber<TNumber, TInner> where TInner : struct, INumber<TInner>
            {
                public static readonly IExtendedNumberOperations<TNumber, TInner> Instance = default(TNumber).GetOperations();
            }

            public static class ForExtended<TNumber, TInner, TComponent> where TNumber : struct, IExtendedNumber<TNumber, TInner, TComponent> where TInner : struct, INumber<TInner, TComponent> where TComponent : struct, IEquatable<TComponent>, IComparable<TComponent>
            {
                public static readonly IExtendedNumberOperations<TNumber, TInner, TComponent> Instance = default(TNumber).GetOperations();
            }

            public static class ForHyper<TNumber, TInner> where TNumber : struct, IHyperNumber<TNumber, TInner> where TInner : struct, INumber<TInner>
            {
                public static readonly IHyperNumberOperations<TNumber, TInner> Instance = default(TNumber).GetOperations();
            }

            public static class ForHyper<TNumber, TInner, TComponent> where TNumber : struct, IHyperNumber<TNumber, TInner, TComponent> where TInner : struct, INumber<TInner, TComponent> where TComponent : struct, IEquatable<TComponent>, IComparable<TComponent>
            {
                public static readonly IHyperNumberOperations<TNumber, TInner, TComponent> Instance = default(TNumber).GetOperations();
            }

            public static readonly INumberOperation Default = new DefaultStandardNumber();
            public static readonly INumberOperation Zero = new StandardNumberOperation(StandardNumber.Zero);
            public static readonly INumberOperation RealOne = new StandardNumberOperation(StandardNumber.One);
            public static readonly INumberOperation SpecialOne = new StandardNumberOperation(StandardNumber.SpecialOne);
            public static readonly INumberOperation UnitsOne = new StandardNumberOperation(StandardNumber.UnitsOne);
            public static readonly INumberOperation NonRealUnitsOne = new StandardNumberOperation(StandardNumber.NonRealUnitsOne);
            public static readonly INumberOperation CombinedOne = new StandardNumberOperation(StandardNumber.CombinedOne);
            public static readonly INumberOperation AllOne = new StandardNumberOperation(StandardNumber.AllOne);
            public static readonly INumberOperation PI = new PIOperation();
            public static readonly INumberOperation E = new EOperation();
            public static readonly IUnaryNumberOperation Id = new IdOperation();
            public static readonly IBinaryNumberOperation Add = new NumberBinaryOperation(StandardBinaryOperation.Add);
            public static readonly IBinaryNumberOperation Sub = new NumberBinaryOperation(StandardBinaryOperation.Subtract);
            public static readonly IBinaryNumberOperation Mul = new NumberBinaryOperation(StandardBinaryOperation.Multiply);
            public static readonly IBinaryNumberOperation Div = new NumberBinaryOperation(StandardBinaryOperation.Divide);
            public static readonly IUnaryNumberOperation Neg = new NumberUnaryOperation(StandardUnaryOperation.Negate);
            public static readonly IUnaryNumberOperation Inv = new NumberUnaryOperation(StandardUnaryOperation.Inverse);
            public static readonly IUnaryNumberOperation Inc = new NumberUnaryOperation(StandardUnaryOperation.Increment);
            public static readonly IUnaryNumberOperation Dec = new NumberUnaryOperation(StandardUnaryOperation.Decrement);
            public static readonly IUnaryNumberOperation Con = new NumberUnaryOperation(StandardUnaryOperation.Conjugate);
            public static readonly IUnaryNumberOperation Mods = new NumberUnaryOperation(StandardUnaryOperation.Modulus);
            public static readonly IComponentUnaryNumberOperation Abs = new ComponentNumberUnaryOperation(StandardUnaryOperation.Identity);
            public static readonly IUnaryNumberOperation Mul2 = new NumberUnaryOperation(StandardUnaryOperation.Double);
            public static readonly IUnaryNumberOperation Div2 = new NumberUnaryOperation(StandardUnaryOperation.Half);
            public static readonly IBinaryNumberOperation Pow = new NumberBinaryOperation(StandardBinaryOperation.Power);
            public static readonly IUnaryNumberOperation Pow2 = new NumberUnaryOperation(StandardUnaryOperation.Square);
            public static readonly IUnaryNumberOperation Sqrt = new NumberUnaryOperation(StandardUnaryOperation.SquareRoot);
            public static readonly IUnaryNumberOperation Sin = new NumberUnaryOperation(StandardUnaryOperation.Sine);
            public static readonly IUnaryNumberOperation Cos = new NumberUnaryOperation(StandardUnaryOperation.Cosine);
            public static readonly IUnaryNumberOperation Tan = new NumberUnaryOperation(StandardUnaryOperation.Tangent);
            public static readonly IUnaryNumberOperation Sinh = new NumberUnaryOperation(StandardUnaryOperation.HyperbolicSine);
            public static readonly IUnaryNumberOperation Cosh = new NumberUnaryOperation(StandardUnaryOperation.HyperbolicCosine);
            public static readonly IUnaryNumberOperation Tanh = new NumberUnaryOperation(StandardUnaryOperation.HyperbolicTangent);
            public static readonly IUnaryNumberOperation Asin = new NumberUnaryOperation(StandardUnaryOperation.ArcSine);
            public static readonly IUnaryNumberOperation Acos = new NumberUnaryOperation(StandardUnaryOperation.ArcCosine);
            public static readonly IUnaryNumberOperation Atan = new NumberUnaryOperation(StandardUnaryOperation.ArcTangent);
            public static readonly IBinaryNumberOperation Atan2 = new NumberBinaryOperation(StandardBinaryOperation.Atan2);
            public static readonly IUnaryNumberOperation Exp = new NumberUnaryOperation(StandardUnaryOperation.Exponentiate);
            public static readonly IUnaryNumberOperation Log = new NumberUnaryOperation(StandardUnaryOperation.Logarithm);

            public static INumberOperation GetOperation(StandardNumber num)
            {
                switch(num)
                {
                    case StandardNumber.Zero:
                        return Zero;
                    case StandardNumber.One:
                        return RealOne;
                    case StandardNumber.SpecialOne:
                        return SpecialOne;
                    case StandardNumber.UnitsOne:
                        return UnitsOne;
                    case StandardNumber.NonRealUnitsOne:
                        return NonRealUnitsOne;
                    case StandardNumber.CombinedOne:
                        return CombinedOne;
                    case StandardNumber.AllOne:
                        return AllOne;
                    default:
                        return new StandardNumberOperation(num);
                }
            }

            public static IUnaryNumberOperation GetOperation(StandardUnaryOperation operation)
            {
                switch(operation)
                {
                    case StandardUnaryOperation.Identity:
                        return Id;
                    case StandardUnaryOperation.Negate:
                        return Neg;
                    case StandardUnaryOperation.Increment:
                        return Inc;
                    case StandardUnaryOperation.Decrement:
                        return Dec;
                    case StandardUnaryOperation.Inverse:
                        return Inv;
                    case StandardUnaryOperation.Conjugate:
                        return Con;
                    case StandardUnaryOperation.Modulus:
                        return Mods;
                    case StandardUnaryOperation.Double:
                        return Mul2;
                    case StandardUnaryOperation.Half:
                        return Div2;
                    case StandardUnaryOperation.Square:
                        return Pow2;
                    case StandardUnaryOperation.SquareRoot:
                        return Sqrt;
                    case StandardUnaryOperation.Exponentiate:
                        return Exp;
                    case StandardUnaryOperation.Logarithm:
                        return Log;
                    case StandardUnaryOperation.Sine:
                        return Sin;
                    case StandardUnaryOperation.Cosine:
                        return Cos;
                    case StandardUnaryOperation.Tangent:
                        return Tan;
                    case StandardUnaryOperation.HyperbolicSine:
                        return Sinh;
                    case StandardUnaryOperation.HyperbolicCosine:
                        return Cosh;
                    case StandardUnaryOperation.HyperbolicTangent:
                        return Tanh;
                    case StandardUnaryOperation.ArcSine:
                        return Asin;
                    case StandardUnaryOperation.ArcCosine:
                        return Acos;
                    case StandardUnaryOperation.ArcTangent:
                        return Atan;
                    default:
                        return new NumberUnaryOperation(operation);
                }
            }

            public static IBinaryNumberOperation GetOperation(StandardBinaryOperation operation)
            {
                switch(operation)
                {
                    case StandardBinaryOperation.Add:
                        return Add;
                    case StandardBinaryOperation.Subtract:
                        return Sub;
                    case StandardBinaryOperation.Multiply:
                        return Mul;
                    case StandardBinaryOperation.Divide:
                        return Div;
                    case StandardBinaryOperation.Power:
                        return Pow;
                    case StandardBinaryOperation.Atan2:
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

                public TNumber Invoke<TNumber, TComponent>() where TNumber : struct, INumber<TNumber, TComponent> where TComponent : struct, IEquatable<TComponent>, IComparable<TComponent>
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

                public TNumber Invoke<TNumber, TComponent>() where TNumber : struct, INumber<TNumber, TComponent> where TComponent : struct, IEquatable<TComponent>, IComparable<TComponent>
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

                public TNumber Invoke<TNumber, TComponent>(in TNumber num) where TNumber : struct, INumber<TNumber, TComponent> where TComponent : struct, IEquatable<TComponent>, IComparable<TComponent>
                {
                    return num;
                }

                public override string ToString()
                {
                    return "Id";
                }
            }

            class DefaultStandardNumber : DynamicNumberOperation<INumberOperation>, INumberOperation
            {
                public TNumber Invoke<TNumber>() where TNumber : struct, INumber<TNumber>
                {
                    return default;
                }

                public TNumber Invoke<TNumber, TComponent>() where TNumber : struct, INumber<TNumber, TComponent> where TComponent : struct, IEquatable<TComponent>, IComparable<TComponent>
                {
                    return default;
                }

                public override string ToString()
                {
                    return "default";
                }
            }

            class StandardNumberOperation : DynamicNumberOperation<INumberOperation>, INumberOperation
            {
                readonly StandardNumber type;

                public StandardNumberOperation(StandardNumber type)
                {
                    this.type = type;
                }

                public TNumber Invoke<TNumber>() where TNumber : struct, INumber<TNumber>
                {
                    return For<TNumber>.Instance.Create(type);
                }

                public TNumber Invoke<TNumber, TComponent>() where TNumber : struct, INumber<TNumber, TComponent> where TComponent : struct, IEquatable<TComponent>, IComparable<TComponent>
                {
                    return For<TNumber, TComponent>.Instance.Create(type);
                }

                public override string ToString()
                {
                    return type.ToString();
                }
            }

            class NumberUnaryOperation : DynamicNumberOperation<IUnaryNumberOperation>, IUnaryNumberOperation
            {
                readonly StandardUnaryOperation type;

                public NumberUnaryOperation(StandardUnaryOperation type)
                {
                    this.type = type;
                }

                public TNumber Invoke<TNumber>(in TNumber num) where TNumber : struct, INumber<TNumber>
                {
                    return For<TNumber>.Instance.Call(type, num);
                }

                public TNumber Invoke<TNumber, TComponent>(in TNumber num) where TNumber : struct, INumber<TNumber, TComponent> where TComponent : struct, IEquatable<TComponent>, IComparable<TComponent>
                {
                    return For<TNumber, TComponent>.Instance.Call(type, num);
                }

                public override string ToString()
                {
                    return type.ToString();
                }
            }

            class NumberBinaryOperation : DynamicNumberOperation<IBinaryNumberOperation>, IBinaryNumberOperation
            {
                readonly StandardBinaryOperation type;

                public NumberBinaryOperation(StandardBinaryOperation type)
                {
                    this.type = type;
                }

                public TNumber Invoke<TNumber>(in TNumber x, in TNumber y) where TNumber : struct, INumber<TNumber>
                {
                    return For<TNumber>.Instance.Call(type, x, y);
                }

                public TNumber Invoke<TNumber, TComponent>(in TNumber x, in TNumber y) where TNumber : struct, INumber<TNumber, TComponent> where TComponent : struct, IEquatable<TComponent>, IComparable<TComponent>
                {
                    return For<TNumber, TComponent>.Instance.Call(type, x, y);
                }

                public override string ToString()
                {
                    return type.ToString();
                }
            }

            class NumberUnaryComponentOperation : DynamicNumberOperation<IComponentUnaryNumberFunc<ValueType>>, IComponentUnaryNumberFunc<ValueType>
            {
                readonly StandardUnaryOperation type;

                public NumberUnaryComponentOperation(StandardUnaryOperation type)
                {
                    this.type = type;
                }

                public ValueType Invoke<TNumber, TComponent>(in TNumber num) where TNumber : struct, INumber<TNumber, TComponent> where TComponent : struct, IEquatable<TComponent>, IComparable<TComponent>
                {
                    return For<TNumber, TComponent>.Instance.CallComponent(type, num);
                }

                public override string ToString()
                {
                    return type.ToString();
                }
            }

            class ComponentNumberUnaryOperation : DynamicNumberOperation<IComponentUnaryNumberOperation>, IComponentUnaryNumberOperation
            {
                readonly StandardUnaryOperation type;

                public ComponentNumberUnaryOperation(StandardUnaryOperation type)
                {
                    this.type = type;
                }

                public TNumber Invoke<TNumber, TComponent>(in TNumber num) where TNumber : struct, INumber<TNumber, TComponent> where TComponent : struct, IEquatable<TComponent>, IComparable<TComponent>
                {
                    var result = For<TNumber, TComponent>.Instance.CallComponent(type, num);
                    return For<TNumber, TComponent>.Instance.Create(result);
                }

                public override string ToString()
                {
                    return type.ToString();
                }
            }
        }
    }
}
