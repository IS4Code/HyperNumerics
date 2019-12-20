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
            static readonly INumberFactory<TNumber> Factory = default(TNumber).GetFactory();
            public static readonly TNumber Zero = Factory.Zero;
            public static readonly TNumber RealOne = Factory.RealOne;
            public static readonly TNumber SpecialOne = Factory.SpecialOne;
            public static readonly TNumber UnitsOne = Factory.UnitsOne;
            public static readonly TNumber NonRealUnitsOne = Factory.NonRealUnitsOne;
            public static readonly TNumber CombinedOne = Factory.CombinedOne;
            public static readonly TNumber AllOne = Factory.AllOne;
            public static readonly TNumber PI = RealOne.ArcTangent().Double().Double();
            public static readonly TNumber E = RealOne.Exponentiate();
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
            return num.AbsoluteValue();
        }

        public static TNumber Mul2<TNumber>(in TNumber num) where TNumber : struct, INumber<TNumber>
        {
            return num.Double();
        }

        public static TNumber Div2<TNumber>(in TNumber num) where TNumber : struct, INumber<TNumber>
        {
            return num.Half();
        }

        public static TNumber Pow<TNumber>(in TNumber x, in TNumber y) where TNumber : struct, INumber<TNumber>
        {
            return x.Power(y);
        }

        public static TNumber Pow<TNumber, TPrimitive>(in TNumber x, TPrimitive y) where TNumber : struct, INumber<TNumber, TPrimitive> where TPrimitive : struct, IEquatable<TPrimitive>, IComparable<TPrimitive>
        {
            return x.Power(y);
        }

        public static TNumber Pow2<TNumber>(in TNumber num) where TNumber : struct, INumber<TNumber>
        {
            return num.Square();
        }

        public static TNumber Sqrt<TNumber>(in TNumber num) where TNumber : struct, INumber<TNumber>
        {
            return num.SquareRoot();
        }

        public static TNumber Sin<TNumber>(in TNumber num) where TNumber : struct, INumber<TNumber>
        {
            return num.Sine();
        }

        public static TNumber Cos<TNumber>(in TNumber num) where TNumber : struct, INumber<TNumber>
        {
            return num.Cosine();
        }

        public static TNumber Tan<TNumber>(in TNumber num) where TNumber : struct, INumber<TNumber>
        {
            return num.Tangent();
        }

        public static TNumber Sinh<TNumber>(in TNumber num) where TNumber : struct, INumber<TNumber>
        {
            return num.HyperbolicSine();
        }

        public static TNumber Cosh<TNumber>(in TNumber num) where TNumber : struct, INumber<TNumber>
        {
            return num.HyperbolicCosine();
        }

        public static TNumber Tanh<TNumber>(in TNumber num) where TNumber : struct, INumber<TNumber>
        {
            return num.HyperbolicTangent();
        }

        public static TNumber Asin<TNumber>(in TNumber num) where TNumber : struct, INumber<TNumber>
        {
            return num.ArcSine();
        }

        public static TNumber Acos<TNumber>(in TNumber num) where TNumber : struct, INumber<TNumber>
        {
            return num.ArcCosine();
        }

        public static TNumber Atan<TNumber>(in TNumber num) where TNumber : struct, INumber<TNumber>
        {
            return num.ArcTangent();
        }

        public static TNumber Atan2<TNumber>(in TNumber y, in TNumber x) where TNumber : struct, INumber<TNumber>
        {
            if(y.IsInvertible)
            {
                return Atan(x.Square().Add(y.Square()).SquareRoot().Subtract(x).Divide(y)).Double();
            }
            var value = y.Divide(x).ArcTangent();
            if(x.Square().SquareRoot().Add(x).IsInvertible)
            {
                return value;
            }
            return value.Add(PI<TNumber>());
        }

        public static TNumber Exp<TNumber>(in TNumber num) where TNumber : struct, INumber<TNumber>
        {
            return num.Exponentiate();
        }

        public static TNumber Log<TNumber>(in TNumber num) where TNumber : struct, INumber<TNumber>
        {
            return num.Logarithm();
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
            var value = new HyperDual<TInner>(num, default(TInner).GetFactory().RealOne);
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
            public static readonly INumberOperation Zero = new ZeroOperation();
            public static readonly INumberOperation RealOne = new RealOneOperation();
            public static readonly INumberOperation SpecialOne = new SpecialOneOperation();
            public static readonly INumberOperation UnitsOne = new UnitsOneOperation();
            public static readonly INumberOperation NonRealUnitsOne = new NonRealUnitsOneOperation();
            public static readonly INumberOperation CombinedOne = new CombinedOneOperation();
            public static readonly INumberOperation AllOne = new AllOneOperation();
            public static readonly INumberOperation PI = new PIOperation();
            public static readonly INumberOperation E = new EOperation();
            public static readonly IUnaryNumberOperation Id = new IdOperation();
            public static readonly IBinaryNumberOperation Add = new AddOperation();
            public static readonly IBinaryNumberOperation Sub = new SubOperation();
            public static readonly IBinaryNumberOperation Mul = new MulOperation();
            public static readonly IBinaryNumberOperation Div = new DivOperation();
            public static readonly IUnaryNumberOperation Neg = new NegOperation();
            public static readonly IUnaryNumberOperation Inv = new InvOperation();
            public static readonly IUnaryNumberOperation Inc = new IncOperation();
            public static readonly IUnaryNumberOperation Dec = new DecOperation();
            public static readonly IUnaryNumberOperation Con = new ConOperation();
            public static readonly IUnaryNumberOperation Mods = new ModsOperation();
            public static readonly IPrimitiveUnaryNumberFunc<ValueType> Abs = new AbsOperation();
            public static readonly IUnaryNumberOperation Mul2 = new Mul2Operation();
            public static readonly IUnaryNumberOperation Div2 = new Div2Operation();
            public static readonly IBinaryNumberOperation Pow = new PowOperation();
            public static readonly IUnaryNumberOperation Pow2 = new Pow2Operation();
            public static readonly IUnaryNumberOperation Sqrt = new SqrtOperation();
            public static readonly IUnaryNumberOperation Sin = new SinOperation();
            public static readonly IUnaryNumberOperation Cos = new CosOperation();
            public static readonly IUnaryNumberOperation Tan = new TanOperation();
            public static readonly IUnaryNumberOperation Sinh = new SinhOperation();
            public static readonly IUnaryNumberOperation Cosh = new CoshOperation();
            public static readonly IUnaryNumberOperation Tanh = new TanhOperation();
            public static readonly IUnaryNumberOperation Asin = new AsinOperation();
            public static readonly IUnaryNumberOperation Acos = new AcosOperation();
            public static readonly IUnaryNumberOperation Atan = new AtanOperation();
            public static readonly IBinaryNumberOperation Atan2 = new Atan2Operation();
            public static readonly IUnaryNumberOperation Exp = new ExpOperation();
            public static readonly IUnaryNumberOperation Log = new LogOperation();

            class ZeroOperation : DynamicNumberOperation<INumberOperation>, INumberOperation
            {
                public TNumber Invoke<TNumber>() where TNumber : struct, INumber<TNumber>
                {
                    return Constants<TNumber>.Zero;
                }

                public TNumber Invoke<TNumber, TPrimitive>() where TNumber : struct, INumber<TNumber, TPrimitive> where TPrimitive : struct, IEquatable<TPrimitive>, IComparable<TPrimitive>
                {
                    return Constants<TNumber>.Zero;
                }

                public override string ToString()
                {
                    return "Zero";
                }
            }

            class RealOneOperation : DynamicNumberOperation<INumberOperation>, INumberOperation
            {
                public TNumber Invoke<TNumber>() where TNumber : struct, INumber<TNumber>
                {
                    return Constants<TNumber>.RealOne;
                }

                public TNumber Invoke<TNumber, TPrimitive>() where TNumber : struct, INumber<TNumber, TPrimitive> where TPrimitive : struct, IEquatable<TPrimitive>, IComparable<TPrimitive>
                {
                    return Constants<TNumber>.RealOne;
                }

                public override string ToString()
                {
                    return "RealOne";
                }
            }

            class SpecialOneOperation : DynamicNumberOperation<INumberOperation>, INumberOperation
            {
                public TNumber Invoke<TNumber>() where TNumber : struct, INumber<TNumber>
                {
                    return Constants<TNumber>.SpecialOne;
                }

                public TNumber Invoke<TNumber, TPrimitive>() where TNumber : struct, INumber<TNumber, TPrimitive> where TPrimitive : struct, IEquatable<TPrimitive>, IComparable<TPrimitive>
                {
                    return Constants<TNumber>.SpecialOne;
                }

                public override string ToString()
                {
                    return "SpecialOne";
                }
            }

            class UnitsOneOperation : DynamicNumberOperation<INumberOperation>, INumberOperation
            {
                public TNumber Invoke<TNumber>() where TNumber : struct, INumber<TNumber>
                {
                    return Constants<TNumber>.UnitsOne;
                }

                public TNumber Invoke<TNumber, TPrimitive>() where TNumber : struct, INumber<TNumber, TPrimitive> where TPrimitive : struct, IEquatable<TPrimitive>, IComparable<TPrimitive>
                {
                    return Constants<TNumber>.UnitsOne;
                }

                public override string ToString()
                {
                    return "UnitsOne";
                }
            }

            class NonRealUnitsOneOperation : DynamicNumberOperation<INumberOperation>, INumberOperation
            {
                public TNumber Invoke<TNumber>() where TNumber : struct, INumber<TNumber>
                {
                    return Constants<TNumber>.NonRealUnitsOne;
                }

                public TNumber Invoke<TNumber, TPrimitive>() where TNumber : struct, INumber<TNumber, TPrimitive> where TPrimitive : struct, IEquatable<TPrimitive>, IComparable<TPrimitive>
                {
                    return Constants<TNumber>.NonRealUnitsOne;
                }

                public override string ToString()
                {
                    return "NonRealUnitsOne";
                }
            }

            class CombinedOneOperation : DynamicNumberOperation<INumberOperation>, INumberOperation
            {
                public TNumber Invoke<TNumber>() where TNumber : struct, INumber<TNumber>
                {
                    return Constants<TNumber>.CombinedOne;
                }

                public TNumber Invoke<TNumber, TPrimitive>() where TNumber : struct, INumber<TNumber, TPrimitive> where TPrimitive : struct, IEquatable<TPrimitive>, IComparable<TPrimitive>
                {
                    return Constants<TNumber>.CombinedOne;
                }

                public override string ToString()
                {
                    return "CombinedOne";
                }
            }

            class AllOneOperation : DynamicNumberOperation<INumberOperation>, INumberOperation
            {
                public TNumber Invoke<TNumber>() where TNumber : struct, INumber<TNumber>
                {
                    return Constants<TNumber>.AllOne;
                }

                public TNumber Invoke<TNumber, TPrimitive>() where TNumber : struct, INumber<TNumber, TPrimitive> where TPrimitive : struct, IEquatable<TPrimitive>, IComparable<TPrimitive>
                {
                    return Constants<TNumber>.AllOne;
                }

                public override string ToString()
                {
                    return "AllOne";
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

            class AddOperation : DynamicNumberOperation<IBinaryNumberOperation>, IBinaryNumberOperation
            {
                public TNumber Invoke<TNumber>(in TNumber x, in TNumber y) where TNumber : struct, INumber<TNumber>
                {
                    return x.Add(y);
                }

                public TNumber Invoke<TNumber, TPrimitive>(in TNumber x, in TNumber y) where TNumber : struct, INumber<TNumber, TPrimitive> where TPrimitive : struct, IEquatable<TPrimitive>, IComparable<TPrimitive>
                {
                    return x.Add(y);
                }

                public override string ToString()
                {
                    return "Add";
                }
            }

            class SubOperation : DynamicNumberOperation<IBinaryNumberOperation>, IBinaryNumberOperation
            {
                public TNumber Invoke<TNumber>(in TNumber x, in TNumber y) where TNumber : struct, INumber<TNumber>
                {
                    return x.Subtract(y);
                }

                public TNumber Invoke<TNumber, TPrimitive>(in TNumber x, in TNumber y) where TNumber : struct, INumber<TNumber, TPrimitive> where TPrimitive : struct, IEquatable<TPrimitive>, IComparable<TPrimitive>
                {
                    return x.Subtract(y);
                }

                public override string ToString()
                {
                    return "Sub";
                }
            }

            class MulOperation : DynamicNumberOperation<IBinaryNumberOperation>, IBinaryNumberOperation
            {
                public TNumber Invoke<TNumber>(in TNumber x, in TNumber y) where TNumber : struct, INumber<TNumber>
                {
                    return x.Multiply(y);
                }

                public TNumber Invoke<TNumber, TPrimitive>(in TNumber x, in TNumber y) where TNumber : struct, INumber<TNumber, TPrimitive> where TPrimitive : struct, IEquatable<TPrimitive>, IComparable<TPrimitive>
                {
                    return x.Multiply(y);
                }

                public override string ToString()
                {
                    return "Mul";
                }
            }

            class DivOperation : DynamicNumberOperation<IBinaryNumberOperation>, IBinaryNumberOperation
            {
                public TNumber Invoke<TNumber>(in TNumber x, in TNumber y) where TNumber : struct, INumber<TNumber>
                {
                    return x.Divide(y);
                }

                public TNumber Invoke<TNumber, TPrimitive>(in TNumber x, in TNumber y) where TNumber : struct, INumber<TNumber, TPrimitive> where TPrimitive : struct, IEquatable<TPrimitive>, IComparable<TPrimitive>
                {
                    return x.Divide(y);
                }

                public override string ToString()
                {
                    return "Div";
                }
            }

            class NegOperation : DynamicNumberOperation<IUnaryNumberOperation>, IUnaryNumberOperation
            {
                public TNumber Invoke<TNumber>(in TNumber num) where TNumber : struct, INumber<TNumber>
                {
                    return num.Negate();
                }

                public TNumber Invoke<TNumber, TPrimitive>(in TNumber num) where TNumber : struct, INumber<TNumber, TPrimitive> where TPrimitive : struct, IEquatable<TPrimitive>, IComparable<TPrimitive>
                {
                    return num.Negate();
                }

                public override string ToString()
                {
                    return "Neg";
                }
            }

            class InvOperation : DynamicNumberOperation<IUnaryNumberOperation>, IUnaryNumberOperation
            {
                public TNumber Invoke<TNumber>(in TNumber num) where TNumber : struct, INumber<TNumber>
                {
                    return num.Inverse();
                }

                public TNumber Invoke<TNumber, TPrimitive>(in TNumber num) where TNumber : struct, INumber<TNumber, TPrimitive> where TPrimitive : struct, IEquatable<TPrimitive>, IComparable<TPrimitive>
                {
                    return num.Inverse();
                }

                public override string ToString()
                {
                    return "Inv";
                }
            }

            class IncOperation : DynamicNumberOperation<IUnaryNumberOperation>, IUnaryNumberOperation
            {
                public TNumber Invoke<TNumber>(in TNumber num) where TNumber : struct, INumber<TNumber>
                {
                    return num.Increment();
                }

                public TNumber Invoke<TNumber, TPrimitive>(in TNumber num) where TNumber : struct, INumber<TNumber, TPrimitive> where TPrimitive : struct, IEquatable<TPrimitive>, IComparable<TPrimitive>
                {
                    return num.Increment();
                }

                public override string ToString()
                {
                    return "Inc";
                }
            }

            class DecOperation : DynamicNumberOperation<IUnaryNumberOperation>, IUnaryNumberOperation
            {
                public TNumber Invoke<TNumber>(in TNumber num) where TNumber : struct, INumber<TNumber>
                {
                    return num.Decrement();
                }

                public TNumber Invoke<TNumber, TPrimitive>(in TNumber num) where TNumber : struct, INumber<TNumber, TPrimitive> where TPrimitive : struct, IEquatable<TPrimitive>, IComparable<TPrimitive>
                {
                    return num.Decrement();
                }

                public override string ToString()
                {
                    return "Dec";
                }
            }

            class ConOperation : DynamicNumberOperation<IUnaryNumberOperation>, IUnaryNumberOperation
            {
                public TNumber Invoke<TNumber>(in TNumber num) where TNumber : struct, INumber<TNumber>
                {
                    return num.Conjugate();
                }

                public TNumber Invoke<TNumber, TPrimitive>(in TNumber num) where TNumber : struct, INumber<TNumber, TPrimitive> where TPrimitive : struct, IEquatable<TPrimitive>, IComparable<TPrimitive>
                {
                    return num.Conjugate();
                }

                public override string ToString()
                {
                    return "Con";
                }
            }

            class ModsOperation : DynamicNumberOperation<IUnaryNumberOperation>, IUnaryNumberOperation
            {
                public TNumber Invoke<TNumber>(in TNumber num) where TNumber : struct, INumber<TNumber>
                {
                    return num.Modulus();
                }

                public TNumber Invoke<TNumber, TPrimitive>(in TNumber num) where TNumber : struct, INumber<TNumber, TPrimitive> where TPrimitive : struct, IEquatable<TPrimitive>, IComparable<TPrimitive>
                {
                    return num.Modulus();
                }

                public override string ToString()
                {
                    return "Mods";
                }
            }

            class AbsOperation : DynamicNumberOperation<IPrimitiveUnaryNumberFunc<ValueType>>, IPrimitiveUnaryNumberFunc<ValueType>
            {
                public ValueType Invoke<TNumber, TPrimitive>(in TNumber num) where TNumber : struct, INumber<TNumber, TPrimitive> where TPrimitive : struct, IEquatable<TPrimitive>, IComparable<TPrimitive>
                {
                    return num.AbsoluteValue();
                }

                public override string ToString()
                {
                    return "Abs";
                }
            }

            class Mul2Operation : DynamicNumberOperation<IUnaryNumberOperation>, IUnaryNumberOperation
            {
                public TNumber Invoke<TNumber>(in TNumber num) where TNumber : struct, INumber<TNumber>
                {
                    return Mul2(num);
                }

                public TNumber Invoke<TNumber, TPrimitive>(in TNumber num) where TNumber : struct, INumber<TNumber, TPrimitive> where TPrimitive : struct, IEquatable<TPrimitive>, IComparable<TPrimitive>
                {
                    return Mul2(num);
                }

                public override string ToString()
                {
                    return "Mul2";
                }
            }

            class Div2Operation : DynamicNumberOperation<IUnaryNumberOperation>, IUnaryNumberOperation
            {
                public TNumber Invoke<TNumber>(in TNumber num) where TNumber : struct, INumber<TNumber>
                {
                    return Div2(num);
                }

                public TNumber Invoke<TNumber, TPrimitive>(in TNumber num) where TNumber : struct, INumber<TNumber, TPrimitive> where TPrimitive : struct, IEquatable<TPrimitive>, IComparable<TPrimitive>
                {
                    return Div2(num);
                }

                public override string ToString()
                {
                    return "Div2";
                }
            }

            class PowOperation : DynamicNumberOperation<IBinaryNumberOperation>, IBinaryNumberOperation
            {
                public TNumber Invoke<TNumber>(in TNumber x, in TNumber y) where TNumber : struct, INumber<TNumber>
                {
                    return Pow<TNumber>(x, y);
                }

                public TNumber Invoke<TNumber, TPrimitive>(in TNumber x, in TNumber y) where TNumber : struct, INumber<TNumber, TPrimitive> where TPrimitive : struct, IEquatable<TPrimitive>, IComparable<TPrimitive>
                {
                    return Pow<TNumber>(x, y);
                }

                public override string ToString()
                {
                    return "Pow";
                }
            }

            class Pow2Operation : DynamicNumberOperation<IUnaryNumberOperation>, IUnaryNumberOperation
            {
                public TNumber Invoke<TNumber>(in TNumber num) where TNumber : struct, INumber<TNumber>
                {
                    return Pow2(num);
                }

                public TNumber Invoke<TNumber, TPrimitive>(in TNumber num) where TNumber : struct, INumber<TNumber, TPrimitive> where TPrimitive : struct, IEquatable<TPrimitive>, IComparable<TPrimitive>
                {
                    return Pow2(num);
                }

                public override string ToString()
                {
                    return "Pow2";
                }
            }

            class SqrtOperation : DynamicNumberOperation<IUnaryNumberOperation>, IUnaryNumberOperation
            {
                public TNumber Invoke<TNumber>(in TNumber num) where TNumber : struct, INumber<TNumber>
                {
                    return Sqrt(num);
                }

                public TNumber Invoke<TNumber, TPrimitive>(in TNumber num) where TNumber : struct, INumber<TNumber, TPrimitive> where TPrimitive : struct, IEquatable<TPrimitive>, IComparable<TPrimitive>
                {
                    return Sqrt(num);
                }

                public override string ToString()
                {
                    return "Sqrt";
                }
            }

            class SinOperation : DynamicNumberOperation<IUnaryNumberOperation>, IUnaryNumberOperation
            {
                public TNumber Invoke<TNumber>(in TNumber num) where TNumber : struct, INumber<TNumber>
                {
                    return Sin(num);
                }

                public TNumber Invoke<TNumber, TPrimitive>(in TNumber num) where TNumber : struct, INumber<TNumber, TPrimitive> where TPrimitive : struct, IEquatable<TPrimitive>, IComparable<TPrimitive>
                {
                    return Sin(num);
                }

                public override string ToString()
                {
                    return "Sin";
                }
            }

            class CosOperation : DynamicNumberOperation<IUnaryNumberOperation>, IUnaryNumberOperation
            {
                public TNumber Invoke<TNumber>(in TNumber num) where TNumber : struct, INumber<TNumber>
                {
                    return Cos(num);
                }

                public TNumber Invoke<TNumber, TPrimitive>(in TNumber num) where TNumber : struct, INumber<TNumber, TPrimitive> where TPrimitive : struct, IEquatable<TPrimitive>, IComparable<TPrimitive>
                {
                    return Cos(num);
                }

                public override string ToString()
                {
                    return "Cos";
                }
            }

            class TanOperation : DynamicNumberOperation<IUnaryNumberOperation>, IUnaryNumberOperation
            {
                public TNumber Invoke<TNumber>(in TNumber num) where TNumber : struct, INumber<TNumber>
                {
                    return Tan(num);
                }

                public TNumber Invoke<TNumber, TPrimitive>(in TNumber num) where TNumber : struct, INumber<TNumber, TPrimitive> where TPrimitive : struct, IEquatable<TPrimitive>, IComparable<TPrimitive>
                {
                    return Tan(num);
                }

                public override string ToString()
                {
                    return "Tan";
                }
            }

            class SinhOperation : DynamicNumberOperation<IUnaryNumberOperation>, IUnaryNumberOperation
            {
                public TNumber Invoke<TNumber>(in TNumber num) where TNumber : struct, INumber<TNumber>
                {
                    return Sinh(num);
                }

                public TNumber Invoke<TNumber, TPrimitive>(in TNumber num) where TNumber : struct, INumber<TNumber, TPrimitive> where TPrimitive : struct, IEquatable<TPrimitive>, IComparable<TPrimitive>
                {
                    return Sinh(num);
                }

                public override string ToString()
                {
                    return "Sinh";
                }
            }

            class CoshOperation : DynamicNumberOperation<IUnaryNumberOperation>, IUnaryNumberOperation
            {
                public TNumber Invoke<TNumber>(in TNumber num) where TNumber : struct, INumber<TNumber>
                {
                    return Cosh(num);
                }

                public TNumber Invoke<TNumber, TPrimitive>(in TNumber num) where TNumber : struct, INumber<TNumber, TPrimitive> where TPrimitive : struct, IEquatable<TPrimitive>, IComparable<TPrimitive>
                {
                    return Cosh(num);
                }

                public override string ToString()
                {
                    return "Cosh";
                }
            }

            class TanhOperation : DynamicNumberOperation<IUnaryNumberOperation>, IUnaryNumberOperation
            {
                public TNumber Invoke<TNumber>(in TNumber num) where TNumber : struct, INumber<TNumber>
                {
                    return Tanh(num);
                }

                public TNumber Invoke<TNumber, TPrimitive>(in TNumber num) where TNumber : struct, INumber<TNumber, TPrimitive> where TPrimitive : struct, IEquatable<TPrimitive>, IComparable<TPrimitive>
                {
                    return Tanh(num);
                }

                public override string ToString()
                {
                    return "Tanh";
                }
            }

            class AsinOperation : DynamicNumberOperation<IUnaryNumberOperation>, IUnaryNumberOperation
            {
                public TNumber Invoke<TNumber>(in TNumber num) where TNumber : struct, INumber<TNumber>
                {
                    return Asin(num);
                }

                public TNumber Invoke<TNumber, TPrimitive>(in TNumber num) where TNumber : struct, INumber<TNumber, TPrimitive> where TPrimitive : struct, IEquatable<TPrimitive>, IComparable<TPrimitive>
                {
                    return Asin(num);
                }

                public override string ToString()
                {
                    return "Asin";
                }
            }

            class AcosOperation : DynamicNumberOperation<IUnaryNumberOperation>, IUnaryNumberOperation
            {
                public TNumber Invoke<TNumber>(in TNumber num) where TNumber : struct, INumber<TNumber>
                {
                    return Acos(num);
                }

                public TNumber Invoke<TNumber, TPrimitive>(in TNumber num) where TNumber : struct, INumber<TNumber, TPrimitive> where TPrimitive : struct, IEquatable<TPrimitive>, IComparable<TPrimitive>
                {
                    return Acos(num);
                }

                public override string ToString()
                {
                    return "Acos";
                }
            }

            class AtanOperation : DynamicNumberOperation<IUnaryNumberOperation>, IUnaryNumberOperation
            {
                public TNumber Invoke<TNumber>(in TNumber num) where TNumber : struct, INumber<TNumber>
                {
                    return Atan(num);
                }

                public TNumber Invoke<TNumber, TPrimitive>(in TNumber num) where TNumber : struct, INumber<TNumber, TPrimitive> where TPrimitive : struct, IEquatable<TPrimitive>, IComparable<TPrimitive>
                {
                    return Atan(num);
                }

                public override string ToString()
                {
                    return "Atan";
                }
            }

            class Atan2Operation : DynamicNumberOperation<IBinaryNumberOperation>, IBinaryNumberOperation
            {
                public TNumber Invoke<TNumber>(in TNumber y, in TNumber x) where TNumber : struct, INumber<TNumber>
                {
                    return Atan2(y, x);
                }

                public TNumber Invoke<TNumber, TPrimitive>(in TNumber y, in TNumber x) where TNumber : struct, INumber<TNumber, TPrimitive> where TPrimitive : struct, IEquatable<TPrimitive>, IComparable<TPrimitive>
                {
                    return Atan2(y, x);
                }

                public override string ToString()
                {
                    return "Atan2";
                }
            }

            class ExpOperation : DynamicNumberOperation<IUnaryNumberOperation>, IUnaryNumberOperation
            {
                public TNumber Invoke<TNumber>(in TNumber num) where TNumber : struct, INumber<TNumber>
                {
                    return Exp(num);
                }

                public TNumber Invoke<TNumber, TPrimitive>(in TNumber num) where TNumber : struct, INumber<TNumber, TPrimitive> where TPrimitive : struct, IEquatable<TPrimitive>, IComparable<TPrimitive>
                {
                    return Exp(num);
                }

                public override string ToString()
                {
                    return "Exp";
                }
            }

            class LogOperation : DynamicNumberOperation<IUnaryNumberOperation>, IUnaryNumberOperation
            {
                public TNumber Invoke<TNumber>(in TNumber num) where TNumber : struct, INumber<TNumber>
                {
                    return Log(num);
                }

                public TNumber Invoke<TNumber, TPrimitive>(in TNumber num) where TNumber : struct, INumber<TNumber, TPrimitive> where TPrimitive : struct, IEquatable<TPrimitive>, IComparable<TPrimitive>
                {
                    return Log(num);
                }

                public override string ToString()
                {
                    return "Log";
                }
            }
        }
    }
}
