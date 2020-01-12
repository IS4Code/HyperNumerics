using IS4.HyperNumerics.Operations;
using System;
using System.Collections;
using System.Collections.Generic;

namespace IS4.HyperNumerics.NumberTypes
{
	partial struct HyperComplex<TInner> : IHyperNumber<HyperComplex<TInner>, TInner> where TInner : struct, INumber<TInner>
	{
        readonly TInner first;
        readonly TInner second;

        public TInner First => first;
        public TInner Second => second;

        TInner IWrapperNumber<TInner>.Value => first;

        int INumber.Dimension => HyperMath.Operations.For<TInner>.Instance.Dimension * 2;

        public HyperComplex(in TInner first)
        {
            this.first = first;
            second = HyperMath.Call<TInner>(NullaryOperation.Zero);
        }

        public HyperComplex(in TInner first, in TInner second)
        {
            this.first = first;
            this.second = second;
        }

        public HyperComplex(in (TInner first, TInner second) tuple)
        {
            first = tuple.first;
            second = tuple.second;
        }

        public void Deconstruct(out TInner first, out TInner second)
        {
            first = this.first;
            second = this.second;
        }

        public HyperComplex<TInner> Clone()
        {
            return new HyperComplex<TInner>(first.Clone(), second.Clone());
        }

        public HyperComplex<TInner> WithFirst(in TInner first)
        {
            return new HyperComplex<TInner>(first, second);
        }

        public HyperComplex<TInner> WithSecond(in TInner second)
        {
            return new HyperComplex<TInner>(first, second);
        }

        public static implicit operator HyperComplex<TInner>((TInner first, TInner second) tuple)
        {
            return new HyperComplex<TInner>(tuple.first, tuple.second);
        }

        public static implicit operator (TInner first, TInner second)(HyperComplex<TInner> value)
        {
            return (value.first, value.second);
        }

        public HyperComplex<TInner> FirstCall(BinaryOperation operation, in TInner other)
        {
            return new HyperComplex<TInner>(HyperMath.Call(operation, first, other), second);
        }

        public HyperComplex<TInner> SecondCall(BinaryOperation operation, in TInner other)
        {
            return new HyperComplex<TInner>(first, HyperMath.Call(operation, second, other));
        }
		
        public HyperComplex<TInner> FirstCall(UnaryOperation operation)
        {
            return new HyperComplex<TInner>(HyperMath.Call(operation, first), second);
        }

        public HyperComplex<TInner> SecondCall(UnaryOperation operation)
        {
            return new HyperComplex<TInner>(first, HyperMath.Call(operation, second));
        }

        public bool Equals(in HyperComplex<TInner> other)
        {
            return HyperMath.Equals(first, other.first) && HyperMath.Equals(second, other.second);
        }

        public int CompareTo(in HyperComplex<TInner> other)
        {
            int value = HyperMath.Compare(first, other.first);
            return value != 0 ? value : HyperMath.Compare(second, other.second);
        }

        public bool Equals(in TInner other)
        {
            return HyperMath.Equals(first, other) && HyperMath.Call<TInner>(NullaryOperation.Zero).Equals(second);
        }

        public int CompareTo(in TInner other)
        {
            int value = HyperMath.Compare(first, other);
            return value != 0 ? value : -HyperMath.Call<TInner>(NullaryOperation.Zero).CompareTo(second);
        }

        public override int GetHashCode()
        {
            return first.GetHashCode() * 17 + second.GetHashCode();
        }

        public override string ToString()
        {
            return "Complex(" + first.ToString() + ", " + second.ToString() + ")";
        }

        public string ToString(string format, IFormatProvider formatProvider)
        {
            return "Complex(" + first.ToString(format, formatProvider) + ", " + second.ToString(format, formatProvider) + ")";
        }

        IHyperNumberOperations<HyperComplex<TInner>, TInner> IHyperNumber<HyperComplex<TInner>, TInner>.GetOperations()
        {
            return Operations.Instance;
        }

		partial class Operations : NumberOperations<HyperComplex<TInner>>, IHyperNumberOperations<HyperComplex<TInner>, TInner>
		{
            public override int Dimension => HyperMath.Operations.For<TInner>.Instance.Dimension * 2;

			public HyperComplex<TInner> Call(NullaryOperation operation)
            {
                switch(operation)
                {
                    case NullaryOperation.Zero:
                    {
                        var zero = HyperMath.Call<TInner>(NullaryOperation.Zero);
                        return new HyperComplex<TInner>(zero, zero);
                    }
                    case NullaryOperation.RealOne:
                        return new HyperComplex<TInner>(HyperMath.Call<TInner>(NullaryOperation.RealOne), HyperMath.Call<TInner>(NullaryOperation.Zero));
                    case NullaryOperation.SpecialOne:
                        return new HyperComplex<TInner>(HyperMath.Call<TInner>(NullaryOperation.Zero), HyperMath.Call<TInner>(NullaryOperation.RealOne));
                    case NullaryOperation.UnitsOne:
                        return new HyperComplex<TInner>(HyperMath.Call<TInner>(NullaryOperation.UnitsOne), HyperMath.Call<TInner>(NullaryOperation.RealOne));
                    case NullaryOperation.NonRealUnitsOne:
                        return new HyperComplex<TInner>(HyperMath.Call<TInner>(NullaryOperation.NonRealUnitsOne), HyperMath.Call<TInner>(NullaryOperation.RealOne));
                    case NullaryOperation.CombinedOne:
                        return new HyperComplex<TInner>(HyperMath.Call<TInner>(NullaryOperation.Zero), HyperMath.Call<TInner>(NullaryOperation.CombinedOne));
                    case NullaryOperation.AllOne:
                        return new HyperComplex<TInner>(HyperMath.Call<TInner>(NullaryOperation.AllOne), HyperMath.Call<TInner>(NullaryOperation.AllOne));
                    default:
                        throw new NotSupportedException();
                }
            }

            public HyperComplex<TInner> Create(in TInner first, in TInner second)
            {
                return new HyperComplex<TInner>(first, second);
            }
		}

		IEnumerator IEnumerable.GetEnumerator()
		{
			foreach(var obj in first)
			{
				yield return obj;
			}
			foreach(var obj in second)
			{
				yield return obj;
			}
        }
	}

	partial struct HyperComplex<TInner, TPrimitive> : IHyperNumber<HyperComplex<TInner, TPrimitive>, TInner, TPrimitive> where TInner : struct, INumber<TInner, TPrimitive> where TPrimitive : struct, IEquatable<TPrimitive>, IComparable<TPrimitive>
	{
        readonly TInner first;
        readonly TInner second;

        public TInner First => first;
        public TInner Second => second;

        TInner IWrapperNumber<TInner>.Value => first;

        int INumber.Dimension => HyperMath.Operations.For<TInner>.Instance.Dimension * 2;

        public HyperComplex(in TInner first)
        {
            this.first = first;
            second = HyperMath.Call<TInner>(NullaryOperation.Zero);
        }

        public HyperComplex(in TInner first, in TInner second)
        {
            this.first = first;
            this.second = second;
        }

        public HyperComplex(in (TInner first, TInner second) tuple)
        {
            first = tuple.first;
            second = tuple.second;
        }

        public void Deconstruct(out TInner first, out TInner second)
        {
            first = this.first;
            second = this.second;
        }

        public HyperComplex<TInner, TPrimitive> Clone()
        {
            return new HyperComplex<TInner, TPrimitive>(first.Clone(), second.Clone());
        }

        public HyperComplex<TInner, TPrimitive> WithFirst(in TInner first)
        {
            return new HyperComplex<TInner, TPrimitive>(first, second);
        }

        public HyperComplex<TInner, TPrimitive> WithSecond(in TInner second)
        {
            return new HyperComplex<TInner, TPrimitive>(first, second);
        }

        public static implicit operator HyperComplex<TInner, TPrimitive>((TInner first, TInner second) tuple)
        {
            return new HyperComplex<TInner, TPrimitive>(tuple.first, tuple.second);
        }

        public static implicit operator (TInner first, TInner second)(HyperComplex<TInner, TPrimitive> value)
        {
            return (value.first, value.second);
        }

        public HyperComplex<TInner, TPrimitive> FirstCall(BinaryOperation operation, in TInner other)
        {
            return new HyperComplex<TInner, TPrimitive>(HyperMath.Call(operation, first, other), second);
        }

        public HyperComplex<TInner, TPrimitive> SecondCall(BinaryOperation operation, in TInner other)
        {
            return new HyperComplex<TInner, TPrimitive>(first, HyperMath.Call(operation, second, other));
        }
				
        public HyperComplex<TInner, TPrimitive> FirstCall(BinaryOperation operation, in TPrimitive other)
        {
            return new HyperComplex<TInner, TPrimitive>(HyperMath.CallPrimitive(operation, first, other), second);
        }

        public HyperComplex<TInner, TPrimitive> SecondCall(BinaryOperation operation, in TPrimitive other)
        {
            return new HyperComplex<TInner, TPrimitive>(first, HyperMath.CallPrimitive(operation, second, other));
        }
		
        public HyperComplex<TInner, TPrimitive> FirstCall(UnaryOperation operation)
        {
            return new HyperComplex<TInner, TPrimitive>(HyperMath.Call(operation, first), second);
        }

        public HyperComplex<TInner, TPrimitive> SecondCall(UnaryOperation operation)
        {
            return new HyperComplex<TInner, TPrimitive>(first, HyperMath.Call(operation, second));
        }

        public bool Equals(in HyperComplex<TInner, TPrimitive> other)
        {
            return HyperMath.Equals(first, other.first) && HyperMath.Equals(second, other.second);
        }

        public int CompareTo(in HyperComplex<TInner, TPrimitive> other)
        {
            int value = HyperMath.Compare(first, other.first);
            return value != 0 ? value : HyperMath.Compare(second, other.second);
        }

        public bool Equals(in TInner other)
        {
            return HyperMath.Equals(first, other) && HyperMath.Call<TInner>(NullaryOperation.Zero).Equals(second);
        }

        public int CompareTo(in TInner other)
        {
            int value = HyperMath.Compare(first, other);
            return value != 0 ? value : -HyperMath.Call<TInner>(NullaryOperation.Zero).CompareTo(second);
        }

        public override int GetHashCode()
        {
            return first.GetHashCode() * 17 + second.GetHashCode();
        }

        public override string ToString()
        {
            return "Complex(" + first.ToString() + ", " + second.ToString() + ")";
        }

        public string ToString(string format, IFormatProvider formatProvider)
        {
            return "Complex(" + first.ToString(format, formatProvider) + ", " + second.ToString(format, formatProvider) + ")";
        }

        IHyperNumberOperations<HyperComplex<TInner, TPrimitive>, TInner> IHyperNumber<HyperComplex<TInner, TPrimitive>, TInner>.GetOperations()
        {
            return Operations.Instance;
        }		

        IHyperNumberOperations<HyperComplex<TInner, TPrimitive>, TInner, TPrimitive> IHyperNumber<HyperComplex<TInner, TPrimitive>, TInner, TPrimitive>.GetOperations()
        {
            return Operations.Instance;
        }

		partial class Operations : NumberOperations<HyperComplex<TInner, TPrimitive>>, IHyperNumberOperations<HyperComplex<TInner, TPrimitive>, TInner, TPrimitive>
		{
            public override int Dimension => HyperMath.Operations.For<TInner>.Instance.Dimension * 2;

			public HyperComplex<TInner, TPrimitive> Call(NullaryOperation operation)
            {
                switch(operation)
                {
                    case NullaryOperation.Zero:
                    {
                        var zero = HyperMath.Call<TInner>(NullaryOperation.Zero);
                        return new HyperComplex<TInner, TPrimitive>(zero, zero);
                    }
                    case NullaryOperation.RealOne:
                        return new HyperComplex<TInner, TPrimitive>(HyperMath.Call<TInner>(NullaryOperation.RealOne), HyperMath.Call<TInner>(NullaryOperation.Zero));
                    case NullaryOperation.SpecialOne:
                        return new HyperComplex<TInner, TPrimitive>(HyperMath.Call<TInner>(NullaryOperation.Zero), HyperMath.Call<TInner>(NullaryOperation.RealOne));
                    case NullaryOperation.UnitsOne:
                        return new HyperComplex<TInner, TPrimitive>(HyperMath.Call<TInner>(NullaryOperation.UnitsOne), HyperMath.Call<TInner>(NullaryOperation.RealOne));
                    case NullaryOperation.NonRealUnitsOne:
                        return new HyperComplex<TInner, TPrimitive>(HyperMath.Call<TInner>(NullaryOperation.NonRealUnitsOne), HyperMath.Call<TInner>(NullaryOperation.RealOne));
                    case NullaryOperation.CombinedOne:
                        return new HyperComplex<TInner, TPrimitive>(HyperMath.Call<TInner>(NullaryOperation.Zero), HyperMath.Call<TInner>(NullaryOperation.CombinedOne));
                    case NullaryOperation.AllOne:
                        return new HyperComplex<TInner, TPrimitive>(HyperMath.Call<TInner>(NullaryOperation.AllOne), HyperMath.Call<TInner>(NullaryOperation.AllOne));
                    default:
                        throw new NotSupportedException();
                }
            }

            public HyperComplex<TInner, TPrimitive> Create(in TInner first, in TInner second)
            {
                return new HyperComplex<TInner, TPrimitive>(first, second);
            }			
			
            public HyperComplex<TInner, TPrimitive> Create(in TPrimitive num)
            {
                return new HyperComplex<TInner, TPrimitive>(HyperMath.Operations.For<TInner, TPrimitive>.Instance.Create(num));
            }

            public HyperComplex<TInner, TPrimitive> Create(in TPrimitive realUnit, in TPrimitive otherUnits, in TPrimitive someUnitsCombined, in TPrimitive allUnitsCombined)
            {
                return new HyperComplex<TInner, TPrimitive>(HyperMath.Create<TInner, TPrimitive>(realUnit, otherUnits, someUnitsCombined, someUnitsCombined), HyperMath.Create<TInner, TPrimitive>(otherUnits, someUnitsCombined, someUnitsCombined, allUnitsCombined));
            }

            public HyperComplex<TInner, TPrimitive> Create(IEnumerable<TPrimitive> units)
            {
                var ienum = units.GetEnumerator();
                ienum.MoveNext();
                return Create(ienum);
            }

            public HyperComplex<TInner, TPrimitive> Create(IEnumerator<TPrimitive> units)
            {
                var first = HyperMath.Operations.For<TInner, TPrimitive>.Instance.Create(units);
                var second = HyperMath.Operations.For<TInner, TPrimitive>.Instance.Create(units);
                return new HyperComplex<TInner, TPrimitive>(first, second);
            }
		}
	}

	partial struct HyperDiagonal<TInner> : IHyperNumber<HyperDiagonal<TInner>, TInner> where TInner : struct, INumber<TInner>
	{
        readonly TInner first;
        readonly TInner second;

        public TInner First => first;
        public TInner Second => second;

        TInner IWrapperNumber<TInner>.Value => first;

        int INumber.Dimension => HyperMath.Operations.For<TInner>.Instance.Dimension * 2;

        public HyperDiagonal(in TInner first)
        {
            this.first = first;
            second = HyperMath.Call<TInner>(NullaryOperation.Zero);
        }

        public HyperDiagonal(in TInner first, in TInner second)
        {
            this.first = first;
            this.second = second;
        }

        public HyperDiagonal(in (TInner first, TInner second) tuple)
        {
            first = tuple.first;
            second = tuple.second;
        }

        public void Deconstruct(out TInner first, out TInner second)
        {
            first = this.first;
            second = this.second;
        }

        public HyperDiagonal<TInner> Clone()
        {
            return new HyperDiagonal<TInner>(first.Clone(), second.Clone());
        }

        public HyperDiagonal<TInner> WithFirst(in TInner first)
        {
            return new HyperDiagonal<TInner>(first, second);
        }

        public HyperDiagonal<TInner> WithSecond(in TInner second)
        {
            return new HyperDiagonal<TInner>(first, second);
        }

        public static implicit operator HyperDiagonal<TInner>((TInner first, TInner second) tuple)
        {
            return new HyperDiagonal<TInner>(tuple.first, tuple.second);
        }

        public static implicit operator (TInner first, TInner second)(HyperDiagonal<TInner> value)
        {
            return (value.first, value.second);
        }

        public HyperDiagonal<TInner> FirstCall(BinaryOperation operation, in TInner other)
        {
            return new HyperDiagonal<TInner>(HyperMath.Call(operation, first, other), second);
        }

        public HyperDiagonal<TInner> SecondCall(BinaryOperation operation, in TInner other)
        {
            return new HyperDiagonal<TInner>(first, HyperMath.Call(operation, second, other));
        }
		
        public HyperDiagonal<TInner> FirstCall(UnaryOperation operation)
        {
            return new HyperDiagonal<TInner>(HyperMath.Call(operation, first), second);
        }

        public HyperDiagonal<TInner> SecondCall(UnaryOperation operation)
        {
            return new HyperDiagonal<TInner>(first, HyperMath.Call(operation, second));
        }

        public bool Equals(in HyperDiagonal<TInner> other)
        {
            return HyperMath.Equals(first, other.first) && HyperMath.Equals(second, other.second);
        }

        public int CompareTo(in HyperDiagonal<TInner> other)
        {
            int value = HyperMath.Compare(first, other.first);
            return value != 0 ? value : HyperMath.Compare(second, other.second);
        }

        public bool Equals(in TInner other)
        {
            return HyperMath.Equals(first, other) && HyperMath.Call<TInner>(NullaryOperation.Zero).Equals(second);
        }

        public int CompareTo(in TInner other)
        {
            int value = HyperMath.Compare(first, other);
            return value != 0 ? value : -HyperMath.Call<TInner>(NullaryOperation.Zero).CompareTo(second);
        }

        public override int GetHashCode()
        {
            return first.GetHashCode() * 17 + second.GetHashCode();
        }

        public override string ToString()
        {
            return "Diagonal(" + first.ToString() + ", " + second.ToString() + ")";
        }

        public string ToString(string format, IFormatProvider formatProvider)
        {
            return "Diagonal(" + first.ToString(format, formatProvider) + ", " + second.ToString(format, formatProvider) + ")";
        }

        IHyperNumberOperations<HyperDiagonal<TInner>, TInner> IHyperNumber<HyperDiagonal<TInner>, TInner>.GetOperations()
        {
            return Operations.Instance;
        }

		partial class Operations : NumberOperations<HyperDiagonal<TInner>>, IHyperNumberOperations<HyperDiagonal<TInner>, TInner>
		{
            public override int Dimension => HyperMath.Operations.For<TInner>.Instance.Dimension * 2;

			public HyperDiagonal<TInner> Call(NullaryOperation operation)
            {
                switch(operation)
                {
                    case NullaryOperation.Zero:
                    {
                        var zero = HyperMath.Call<TInner>(NullaryOperation.Zero);
                        return new HyperDiagonal<TInner>(zero, zero);
                    }
                    case NullaryOperation.RealOne:
                        return new HyperDiagonal<TInner>(HyperMath.Call<TInner>(NullaryOperation.RealOne), HyperMath.Call<TInner>(NullaryOperation.Zero));
                    case NullaryOperation.SpecialOne:
                        return new HyperDiagonal<TInner>(HyperMath.Call<TInner>(NullaryOperation.Zero), HyperMath.Call<TInner>(NullaryOperation.RealOne));
                    case NullaryOperation.UnitsOne:
                        return new HyperDiagonal<TInner>(HyperMath.Call<TInner>(NullaryOperation.UnitsOne), HyperMath.Call<TInner>(NullaryOperation.RealOne));
                    case NullaryOperation.NonRealUnitsOne:
                        return new HyperDiagonal<TInner>(HyperMath.Call<TInner>(NullaryOperation.NonRealUnitsOne), HyperMath.Call<TInner>(NullaryOperation.RealOne));
                    case NullaryOperation.CombinedOne:
                        return new HyperDiagonal<TInner>(HyperMath.Call<TInner>(NullaryOperation.Zero), HyperMath.Call<TInner>(NullaryOperation.CombinedOne));
                    case NullaryOperation.AllOne:
                        return new HyperDiagonal<TInner>(HyperMath.Call<TInner>(NullaryOperation.AllOne), HyperMath.Call<TInner>(NullaryOperation.AllOne));
                    default:
                        throw new NotSupportedException();
                }
            }

            public HyperDiagonal<TInner> Create(in TInner first, in TInner second)
            {
                return new HyperDiagonal<TInner>(first, second);
            }
		}

		IEnumerator IEnumerable.GetEnumerator()
		{
			foreach(var obj in first)
			{
				yield return obj;
			}
			foreach(var obj in second)
			{
				yield return obj;
			}
        }
	}

	partial struct HyperDiagonal<TInner, TPrimitive> : IHyperNumber<HyperDiagonal<TInner, TPrimitive>, TInner, TPrimitive> where TInner : struct, INumber<TInner, TPrimitive> where TPrimitive : struct, IEquatable<TPrimitive>, IComparable<TPrimitive>
	{
        readonly TInner first;
        readonly TInner second;

        public TInner First => first;
        public TInner Second => second;

        TInner IWrapperNumber<TInner>.Value => first;

        int INumber.Dimension => HyperMath.Operations.For<TInner>.Instance.Dimension * 2;

        public HyperDiagonal(in TInner first)
        {
            this.first = first;
            second = HyperMath.Call<TInner>(NullaryOperation.Zero);
        }

        public HyperDiagonal(in TInner first, in TInner second)
        {
            this.first = first;
            this.second = second;
        }

        public HyperDiagonal(in (TInner first, TInner second) tuple)
        {
            first = tuple.first;
            second = tuple.second;
        }

        public void Deconstruct(out TInner first, out TInner second)
        {
            first = this.first;
            second = this.second;
        }

        public HyperDiagonal<TInner, TPrimitive> Clone()
        {
            return new HyperDiagonal<TInner, TPrimitive>(first.Clone(), second.Clone());
        }

        public HyperDiagonal<TInner, TPrimitive> WithFirst(in TInner first)
        {
            return new HyperDiagonal<TInner, TPrimitive>(first, second);
        }

        public HyperDiagonal<TInner, TPrimitive> WithSecond(in TInner second)
        {
            return new HyperDiagonal<TInner, TPrimitive>(first, second);
        }

        public static implicit operator HyperDiagonal<TInner, TPrimitive>((TInner first, TInner second) tuple)
        {
            return new HyperDiagonal<TInner, TPrimitive>(tuple.first, tuple.second);
        }

        public static implicit operator (TInner first, TInner second)(HyperDiagonal<TInner, TPrimitive> value)
        {
            return (value.first, value.second);
        }

        public HyperDiagonal<TInner, TPrimitive> FirstCall(BinaryOperation operation, in TInner other)
        {
            return new HyperDiagonal<TInner, TPrimitive>(HyperMath.Call(operation, first, other), second);
        }

        public HyperDiagonal<TInner, TPrimitive> SecondCall(BinaryOperation operation, in TInner other)
        {
            return new HyperDiagonal<TInner, TPrimitive>(first, HyperMath.Call(operation, second, other));
        }
				
        public HyperDiagonal<TInner, TPrimitive> FirstCall(BinaryOperation operation, in TPrimitive other)
        {
            return new HyperDiagonal<TInner, TPrimitive>(HyperMath.CallPrimitive(operation, first, other), second);
        }

        public HyperDiagonal<TInner, TPrimitive> SecondCall(BinaryOperation operation, in TPrimitive other)
        {
            return new HyperDiagonal<TInner, TPrimitive>(first, HyperMath.CallPrimitive(operation, second, other));
        }
		
        public HyperDiagonal<TInner, TPrimitive> FirstCall(UnaryOperation operation)
        {
            return new HyperDiagonal<TInner, TPrimitive>(HyperMath.Call(operation, first), second);
        }

        public HyperDiagonal<TInner, TPrimitive> SecondCall(UnaryOperation operation)
        {
            return new HyperDiagonal<TInner, TPrimitive>(first, HyperMath.Call(operation, second));
        }

        public bool Equals(in HyperDiagonal<TInner, TPrimitive> other)
        {
            return HyperMath.Equals(first, other.first) && HyperMath.Equals(second, other.second);
        }

        public int CompareTo(in HyperDiagonal<TInner, TPrimitive> other)
        {
            int value = HyperMath.Compare(first, other.first);
            return value != 0 ? value : HyperMath.Compare(second, other.second);
        }

        public bool Equals(in TInner other)
        {
            return HyperMath.Equals(first, other) && HyperMath.Call<TInner>(NullaryOperation.Zero).Equals(second);
        }

        public int CompareTo(in TInner other)
        {
            int value = HyperMath.Compare(first, other);
            return value != 0 ? value : -HyperMath.Call<TInner>(NullaryOperation.Zero).CompareTo(second);
        }

        public override int GetHashCode()
        {
            return first.GetHashCode() * 17 + second.GetHashCode();
        }

        public override string ToString()
        {
            return "Diagonal(" + first.ToString() + ", " + second.ToString() + ")";
        }

        public string ToString(string format, IFormatProvider formatProvider)
        {
            return "Diagonal(" + first.ToString(format, formatProvider) + ", " + second.ToString(format, formatProvider) + ")";
        }

        IHyperNumberOperations<HyperDiagonal<TInner, TPrimitive>, TInner> IHyperNumber<HyperDiagonal<TInner, TPrimitive>, TInner>.GetOperations()
        {
            return Operations.Instance;
        }		

        IHyperNumberOperations<HyperDiagonal<TInner, TPrimitive>, TInner, TPrimitive> IHyperNumber<HyperDiagonal<TInner, TPrimitive>, TInner, TPrimitive>.GetOperations()
        {
            return Operations.Instance;
        }

		partial class Operations : NumberOperations<HyperDiagonal<TInner, TPrimitive>>, IHyperNumberOperations<HyperDiagonal<TInner, TPrimitive>, TInner, TPrimitive>
		{
            public override int Dimension => HyperMath.Operations.For<TInner>.Instance.Dimension * 2;

			public HyperDiagonal<TInner, TPrimitive> Call(NullaryOperation operation)
            {
                switch(operation)
                {
                    case NullaryOperation.Zero:
                    {
                        var zero = HyperMath.Call<TInner>(NullaryOperation.Zero);
                        return new HyperDiagonal<TInner, TPrimitive>(zero, zero);
                    }
                    case NullaryOperation.RealOne:
                        return new HyperDiagonal<TInner, TPrimitive>(HyperMath.Call<TInner>(NullaryOperation.RealOne), HyperMath.Call<TInner>(NullaryOperation.Zero));
                    case NullaryOperation.SpecialOne:
                        return new HyperDiagonal<TInner, TPrimitive>(HyperMath.Call<TInner>(NullaryOperation.Zero), HyperMath.Call<TInner>(NullaryOperation.RealOne));
                    case NullaryOperation.UnitsOne:
                        return new HyperDiagonal<TInner, TPrimitive>(HyperMath.Call<TInner>(NullaryOperation.UnitsOne), HyperMath.Call<TInner>(NullaryOperation.RealOne));
                    case NullaryOperation.NonRealUnitsOne:
                        return new HyperDiagonal<TInner, TPrimitive>(HyperMath.Call<TInner>(NullaryOperation.NonRealUnitsOne), HyperMath.Call<TInner>(NullaryOperation.RealOne));
                    case NullaryOperation.CombinedOne:
                        return new HyperDiagonal<TInner, TPrimitive>(HyperMath.Call<TInner>(NullaryOperation.Zero), HyperMath.Call<TInner>(NullaryOperation.CombinedOne));
                    case NullaryOperation.AllOne:
                        return new HyperDiagonal<TInner, TPrimitive>(HyperMath.Call<TInner>(NullaryOperation.AllOne), HyperMath.Call<TInner>(NullaryOperation.AllOne));
                    default:
                        throw new NotSupportedException();
                }
            }

            public HyperDiagonal<TInner, TPrimitive> Create(in TInner first, in TInner second)
            {
                return new HyperDiagonal<TInner, TPrimitive>(first, second);
            }			
			
            public HyperDiagonal<TInner, TPrimitive> Create(in TPrimitive num)
            {
                return new HyperDiagonal<TInner, TPrimitive>(HyperMath.Operations.For<TInner, TPrimitive>.Instance.Create(num));
            }

            public HyperDiagonal<TInner, TPrimitive> Create(in TPrimitive realUnit, in TPrimitive otherUnits, in TPrimitive someUnitsCombined, in TPrimitive allUnitsCombined)
            {
                return new HyperDiagonal<TInner, TPrimitive>(HyperMath.Create<TInner, TPrimitive>(realUnit, otherUnits, someUnitsCombined, someUnitsCombined), HyperMath.Create<TInner, TPrimitive>(otherUnits, someUnitsCombined, someUnitsCombined, allUnitsCombined));
            }

            public HyperDiagonal<TInner, TPrimitive> Create(IEnumerable<TPrimitive> units)
            {
                var ienum = units.GetEnumerator();
                ienum.MoveNext();
                return Create(ienum);
            }

            public HyperDiagonal<TInner, TPrimitive> Create(IEnumerator<TPrimitive> units)
            {
                var first = HyperMath.Operations.For<TInner, TPrimitive>.Instance.Create(units);
                var second = HyperMath.Operations.For<TInner, TPrimitive>.Instance.Create(units);
                return new HyperDiagonal<TInner, TPrimitive>(first, second);
            }
		}
	}

	partial struct HyperDual<TInner> : IHyperNumber<HyperDual<TInner>, TInner> where TInner : struct, INumber<TInner>
	{
        readonly TInner first;
        readonly TInner second;

        public TInner First => first;
        public TInner Second => second;

        TInner IWrapperNumber<TInner>.Value => first;

        int INumber.Dimension => HyperMath.Operations.For<TInner>.Instance.Dimension * 2;

        public HyperDual(in TInner first)
        {
            this.first = first;
            second = HyperMath.Call<TInner>(NullaryOperation.Zero);
        }

        public HyperDual(in TInner first, in TInner second)
        {
            this.first = first;
            this.second = second;
        }

        public HyperDual(in (TInner first, TInner second) tuple)
        {
            first = tuple.first;
            second = tuple.second;
        }

        public void Deconstruct(out TInner first, out TInner second)
        {
            first = this.first;
            second = this.second;
        }

        public HyperDual<TInner> Clone()
        {
            return new HyperDual<TInner>(first.Clone(), second.Clone());
        }

        public HyperDual<TInner> WithFirst(in TInner first)
        {
            return new HyperDual<TInner>(first, second);
        }

        public HyperDual<TInner> WithSecond(in TInner second)
        {
            return new HyperDual<TInner>(first, second);
        }

        public static implicit operator HyperDual<TInner>((TInner first, TInner second) tuple)
        {
            return new HyperDual<TInner>(tuple.first, tuple.second);
        }

        public static implicit operator (TInner first, TInner second)(HyperDual<TInner> value)
        {
            return (value.first, value.second);
        }

        public HyperDual<TInner> FirstCall(BinaryOperation operation, in TInner other)
        {
            return new HyperDual<TInner>(HyperMath.Call(operation, first, other), second);
        }

        public HyperDual<TInner> SecondCall(BinaryOperation operation, in TInner other)
        {
            return new HyperDual<TInner>(first, HyperMath.Call(operation, second, other));
        }
		
        public HyperDual<TInner> FirstCall(UnaryOperation operation)
        {
            return new HyperDual<TInner>(HyperMath.Call(operation, first), second);
        }

        public HyperDual<TInner> SecondCall(UnaryOperation operation)
        {
            return new HyperDual<TInner>(first, HyperMath.Call(operation, second));
        }

        public bool Equals(in HyperDual<TInner> other)
        {
            return HyperMath.Equals(first, other.first) && HyperMath.Equals(second, other.second);
        }

        public int CompareTo(in HyperDual<TInner> other)
        {
            int value = HyperMath.Compare(first, other.first);
            return value != 0 ? value : HyperMath.Compare(second, other.second);
        }

        public bool Equals(in TInner other)
        {
            return HyperMath.Equals(first, other) && HyperMath.Call<TInner>(NullaryOperation.Zero).Equals(second);
        }

        public int CompareTo(in TInner other)
        {
            int value = HyperMath.Compare(first, other);
            return value != 0 ? value : -HyperMath.Call<TInner>(NullaryOperation.Zero).CompareTo(second);
        }

        public override int GetHashCode()
        {
            return first.GetHashCode() * 17 + second.GetHashCode();
        }

        public override string ToString()
        {
            return "Dual(" + first.ToString() + ", " + second.ToString() + ")";
        }

        public string ToString(string format, IFormatProvider formatProvider)
        {
            return "Dual(" + first.ToString(format, formatProvider) + ", " + second.ToString(format, formatProvider) + ")";
        }

        IHyperNumberOperations<HyperDual<TInner>, TInner> IHyperNumber<HyperDual<TInner>, TInner>.GetOperations()
        {
            return Operations.Instance;
        }

		partial class Operations : NumberOperations<HyperDual<TInner>>, IHyperNumberOperations<HyperDual<TInner>, TInner>
		{
            public override int Dimension => HyperMath.Operations.For<TInner>.Instance.Dimension * 2;

			public HyperDual<TInner> Call(NullaryOperation operation)
            {
                switch(operation)
                {
                    case NullaryOperation.Zero:
                    {
                        var zero = HyperMath.Call<TInner>(NullaryOperation.Zero);
                        return new HyperDual<TInner>(zero, zero);
                    }
                    case NullaryOperation.RealOne:
                        return new HyperDual<TInner>(HyperMath.Call<TInner>(NullaryOperation.RealOne), HyperMath.Call<TInner>(NullaryOperation.Zero));
                    case NullaryOperation.SpecialOne:
                        return new HyperDual<TInner>(HyperMath.Call<TInner>(NullaryOperation.Zero), HyperMath.Call<TInner>(NullaryOperation.RealOne));
                    case NullaryOperation.UnitsOne:
                        return new HyperDual<TInner>(HyperMath.Call<TInner>(NullaryOperation.UnitsOne), HyperMath.Call<TInner>(NullaryOperation.RealOne));
                    case NullaryOperation.NonRealUnitsOne:
                        return new HyperDual<TInner>(HyperMath.Call<TInner>(NullaryOperation.NonRealUnitsOne), HyperMath.Call<TInner>(NullaryOperation.RealOne));
                    case NullaryOperation.CombinedOne:
                        return new HyperDual<TInner>(HyperMath.Call<TInner>(NullaryOperation.Zero), HyperMath.Call<TInner>(NullaryOperation.CombinedOne));
                    case NullaryOperation.AllOne:
                        return new HyperDual<TInner>(HyperMath.Call<TInner>(NullaryOperation.AllOne), HyperMath.Call<TInner>(NullaryOperation.AllOne));
                    default:
                        throw new NotSupportedException();
                }
            }

            public HyperDual<TInner> Create(in TInner first, in TInner second)
            {
                return new HyperDual<TInner>(first, second);
            }
		}

		IEnumerator IEnumerable.GetEnumerator()
		{
			foreach(var obj in first)
			{
				yield return obj;
			}
			foreach(var obj in second)
			{
				yield return obj;
			}
        }
	}

	partial struct HyperDual<TInner, TPrimitive> : IHyperNumber<HyperDual<TInner, TPrimitive>, TInner, TPrimitive> where TInner : struct, INumber<TInner, TPrimitive> where TPrimitive : struct, IEquatable<TPrimitive>, IComparable<TPrimitive>
	{
        readonly TInner first;
        readonly TInner second;

        public TInner First => first;
        public TInner Second => second;

        TInner IWrapperNumber<TInner>.Value => first;

        int INumber.Dimension => HyperMath.Operations.For<TInner>.Instance.Dimension * 2;

        public HyperDual(in TInner first)
        {
            this.first = first;
            second = HyperMath.Call<TInner>(NullaryOperation.Zero);
        }

        public HyperDual(in TInner first, in TInner second)
        {
            this.first = first;
            this.second = second;
        }

        public HyperDual(in (TInner first, TInner second) tuple)
        {
            first = tuple.first;
            second = tuple.second;
        }

        public void Deconstruct(out TInner first, out TInner second)
        {
            first = this.first;
            second = this.second;
        }

        public HyperDual<TInner, TPrimitive> Clone()
        {
            return new HyperDual<TInner, TPrimitive>(first.Clone(), second.Clone());
        }

        public HyperDual<TInner, TPrimitive> WithFirst(in TInner first)
        {
            return new HyperDual<TInner, TPrimitive>(first, second);
        }

        public HyperDual<TInner, TPrimitive> WithSecond(in TInner second)
        {
            return new HyperDual<TInner, TPrimitive>(first, second);
        }

        public static implicit operator HyperDual<TInner, TPrimitive>((TInner first, TInner second) tuple)
        {
            return new HyperDual<TInner, TPrimitive>(tuple.first, tuple.second);
        }

        public static implicit operator (TInner first, TInner second)(HyperDual<TInner, TPrimitive> value)
        {
            return (value.first, value.second);
        }

        public HyperDual<TInner, TPrimitive> FirstCall(BinaryOperation operation, in TInner other)
        {
            return new HyperDual<TInner, TPrimitive>(HyperMath.Call(operation, first, other), second);
        }

        public HyperDual<TInner, TPrimitive> SecondCall(BinaryOperation operation, in TInner other)
        {
            return new HyperDual<TInner, TPrimitive>(first, HyperMath.Call(operation, second, other));
        }
				
        public HyperDual<TInner, TPrimitive> FirstCall(BinaryOperation operation, in TPrimitive other)
        {
            return new HyperDual<TInner, TPrimitive>(HyperMath.CallPrimitive(operation, first, other), second);
        }

        public HyperDual<TInner, TPrimitive> SecondCall(BinaryOperation operation, in TPrimitive other)
        {
            return new HyperDual<TInner, TPrimitive>(first, HyperMath.CallPrimitive(operation, second, other));
        }
		
        public HyperDual<TInner, TPrimitive> FirstCall(UnaryOperation operation)
        {
            return new HyperDual<TInner, TPrimitive>(HyperMath.Call(operation, first), second);
        }

        public HyperDual<TInner, TPrimitive> SecondCall(UnaryOperation operation)
        {
            return new HyperDual<TInner, TPrimitive>(first, HyperMath.Call(operation, second));
        }

        public bool Equals(in HyperDual<TInner, TPrimitive> other)
        {
            return HyperMath.Equals(first, other.first) && HyperMath.Equals(second, other.second);
        }

        public int CompareTo(in HyperDual<TInner, TPrimitive> other)
        {
            int value = HyperMath.Compare(first, other.first);
            return value != 0 ? value : HyperMath.Compare(second, other.second);
        }

        public bool Equals(in TInner other)
        {
            return HyperMath.Equals(first, other) && HyperMath.Call<TInner>(NullaryOperation.Zero).Equals(second);
        }

        public int CompareTo(in TInner other)
        {
            int value = HyperMath.Compare(first, other);
            return value != 0 ? value : -HyperMath.Call<TInner>(NullaryOperation.Zero).CompareTo(second);
        }

        public override int GetHashCode()
        {
            return first.GetHashCode() * 17 + second.GetHashCode();
        }

        public override string ToString()
        {
            return "Dual(" + first.ToString() + ", " + second.ToString() + ")";
        }

        public string ToString(string format, IFormatProvider formatProvider)
        {
            return "Dual(" + first.ToString(format, formatProvider) + ", " + second.ToString(format, formatProvider) + ")";
        }

        IHyperNumberOperations<HyperDual<TInner, TPrimitive>, TInner> IHyperNumber<HyperDual<TInner, TPrimitive>, TInner>.GetOperations()
        {
            return Operations.Instance;
        }		

        IHyperNumberOperations<HyperDual<TInner, TPrimitive>, TInner, TPrimitive> IHyperNumber<HyperDual<TInner, TPrimitive>, TInner, TPrimitive>.GetOperations()
        {
            return Operations.Instance;
        }

		partial class Operations : NumberOperations<HyperDual<TInner, TPrimitive>>, IHyperNumberOperations<HyperDual<TInner, TPrimitive>, TInner, TPrimitive>
		{
            public override int Dimension => HyperMath.Operations.For<TInner>.Instance.Dimension * 2;

			public HyperDual<TInner, TPrimitive> Call(NullaryOperation operation)
            {
                switch(operation)
                {
                    case NullaryOperation.Zero:
                    {
                        var zero = HyperMath.Call<TInner>(NullaryOperation.Zero);
                        return new HyperDual<TInner, TPrimitive>(zero, zero);
                    }
                    case NullaryOperation.RealOne:
                        return new HyperDual<TInner, TPrimitive>(HyperMath.Call<TInner>(NullaryOperation.RealOne), HyperMath.Call<TInner>(NullaryOperation.Zero));
                    case NullaryOperation.SpecialOne:
                        return new HyperDual<TInner, TPrimitive>(HyperMath.Call<TInner>(NullaryOperation.Zero), HyperMath.Call<TInner>(NullaryOperation.RealOne));
                    case NullaryOperation.UnitsOne:
                        return new HyperDual<TInner, TPrimitive>(HyperMath.Call<TInner>(NullaryOperation.UnitsOne), HyperMath.Call<TInner>(NullaryOperation.RealOne));
                    case NullaryOperation.NonRealUnitsOne:
                        return new HyperDual<TInner, TPrimitive>(HyperMath.Call<TInner>(NullaryOperation.NonRealUnitsOne), HyperMath.Call<TInner>(NullaryOperation.RealOne));
                    case NullaryOperation.CombinedOne:
                        return new HyperDual<TInner, TPrimitive>(HyperMath.Call<TInner>(NullaryOperation.Zero), HyperMath.Call<TInner>(NullaryOperation.CombinedOne));
                    case NullaryOperation.AllOne:
                        return new HyperDual<TInner, TPrimitive>(HyperMath.Call<TInner>(NullaryOperation.AllOne), HyperMath.Call<TInner>(NullaryOperation.AllOne));
                    default:
                        throw new NotSupportedException();
                }
            }

            public HyperDual<TInner, TPrimitive> Create(in TInner first, in TInner second)
            {
                return new HyperDual<TInner, TPrimitive>(first, second);
            }			
			
            public HyperDual<TInner, TPrimitive> Create(in TPrimitive num)
            {
                return new HyperDual<TInner, TPrimitive>(HyperMath.Operations.For<TInner, TPrimitive>.Instance.Create(num));
            }

            public HyperDual<TInner, TPrimitive> Create(in TPrimitive realUnit, in TPrimitive otherUnits, in TPrimitive someUnitsCombined, in TPrimitive allUnitsCombined)
            {
                return new HyperDual<TInner, TPrimitive>(HyperMath.Create<TInner, TPrimitive>(realUnit, otherUnits, someUnitsCombined, someUnitsCombined), HyperMath.Create<TInner, TPrimitive>(otherUnits, someUnitsCombined, someUnitsCombined, allUnitsCombined));
            }

            public HyperDual<TInner, TPrimitive> Create(IEnumerable<TPrimitive> units)
            {
                var ienum = units.GetEnumerator();
                ienum.MoveNext();
                return Create(ienum);
            }

            public HyperDual<TInner, TPrimitive> Create(IEnumerator<TPrimitive> units)
            {
                var first = HyperMath.Operations.For<TInner, TPrimitive>.Instance.Create(units);
                var second = HyperMath.Operations.For<TInner, TPrimitive>.Instance.Create(units);
                return new HyperDual<TInner, TPrimitive>(first, second);
            }
		}
	}

	partial struct HyperSplitComplex<TInner> : IHyperNumber<HyperSplitComplex<TInner>, TInner> where TInner : struct, INumber<TInner>
	{
        readonly TInner first;
        readonly TInner second;

        public TInner First => first;
        public TInner Second => second;

        TInner IWrapperNumber<TInner>.Value => first;

        int INumber.Dimension => HyperMath.Operations.For<TInner>.Instance.Dimension * 2;

        public HyperSplitComplex(in TInner first)
        {
            this.first = first;
            second = HyperMath.Call<TInner>(NullaryOperation.Zero);
        }

        public HyperSplitComplex(in TInner first, in TInner second)
        {
            this.first = first;
            this.second = second;
        }

        public HyperSplitComplex(in (TInner first, TInner second) tuple)
        {
            first = tuple.first;
            second = tuple.second;
        }

        public void Deconstruct(out TInner first, out TInner second)
        {
            first = this.first;
            second = this.second;
        }

        public HyperSplitComplex<TInner> Clone()
        {
            return new HyperSplitComplex<TInner>(first.Clone(), second.Clone());
        }

        public HyperSplitComplex<TInner> WithFirst(in TInner first)
        {
            return new HyperSplitComplex<TInner>(first, second);
        }

        public HyperSplitComplex<TInner> WithSecond(in TInner second)
        {
            return new HyperSplitComplex<TInner>(first, second);
        }

        public static implicit operator HyperSplitComplex<TInner>((TInner first, TInner second) tuple)
        {
            return new HyperSplitComplex<TInner>(tuple.first, tuple.second);
        }

        public static implicit operator (TInner first, TInner second)(HyperSplitComplex<TInner> value)
        {
            return (value.first, value.second);
        }

        public HyperSplitComplex<TInner> FirstCall(BinaryOperation operation, in TInner other)
        {
            return new HyperSplitComplex<TInner>(HyperMath.Call(operation, first, other), second);
        }

        public HyperSplitComplex<TInner> SecondCall(BinaryOperation operation, in TInner other)
        {
            return new HyperSplitComplex<TInner>(first, HyperMath.Call(operation, second, other));
        }
		
        public HyperSplitComplex<TInner> FirstCall(UnaryOperation operation)
        {
            return new HyperSplitComplex<TInner>(HyperMath.Call(operation, first), second);
        }

        public HyperSplitComplex<TInner> SecondCall(UnaryOperation operation)
        {
            return new HyperSplitComplex<TInner>(first, HyperMath.Call(operation, second));
        }

        public bool Equals(in HyperSplitComplex<TInner> other)
        {
            return HyperMath.Equals(first, other.first) && HyperMath.Equals(second, other.second);
        }

        public int CompareTo(in HyperSplitComplex<TInner> other)
        {
            int value = HyperMath.Compare(first, other.first);
            return value != 0 ? value : HyperMath.Compare(second, other.second);
        }

        public bool Equals(in TInner other)
        {
            return HyperMath.Equals(first, other) && HyperMath.Call<TInner>(NullaryOperation.Zero).Equals(second);
        }

        public int CompareTo(in TInner other)
        {
            int value = HyperMath.Compare(first, other);
            return value != 0 ? value : -HyperMath.Call<TInner>(NullaryOperation.Zero).CompareTo(second);
        }

        public override int GetHashCode()
        {
            return first.GetHashCode() * 17 + second.GetHashCode();
        }

        public override string ToString()
        {
            return "SplitComplex(" + first.ToString() + ", " + second.ToString() + ")";
        }

        public string ToString(string format, IFormatProvider formatProvider)
        {
            return "SplitComplex(" + first.ToString(format, formatProvider) + ", " + second.ToString(format, formatProvider) + ")";
        }

        IHyperNumberOperations<HyperSplitComplex<TInner>, TInner> IHyperNumber<HyperSplitComplex<TInner>, TInner>.GetOperations()
        {
            return Operations.Instance;
        }

		partial class Operations : NumberOperations<HyperSplitComplex<TInner>>, IHyperNumberOperations<HyperSplitComplex<TInner>, TInner>
		{
            public override int Dimension => HyperMath.Operations.For<TInner>.Instance.Dimension * 2;

			public HyperSplitComplex<TInner> Call(NullaryOperation operation)
            {
                switch(operation)
                {
                    case NullaryOperation.Zero:
                    {
                        var zero = HyperMath.Call<TInner>(NullaryOperation.Zero);
                        return new HyperSplitComplex<TInner>(zero, zero);
                    }
                    case NullaryOperation.RealOne:
                        return new HyperSplitComplex<TInner>(HyperMath.Call<TInner>(NullaryOperation.RealOne), HyperMath.Call<TInner>(NullaryOperation.Zero));
                    case NullaryOperation.SpecialOne:
                        return new HyperSplitComplex<TInner>(HyperMath.Call<TInner>(NullaryOperation.Zero), HyperMath.Call<TInner>(NullaryOperation.RealOne));
                    case NullaryOperation.UnitsOne:
                        return new HyperSplitComplex<TInner>(HyperMath.Call<TInner>(NullaryOperation.UnitsOne), HyperMath.Call<TInner>(NullaryOperation.RealOne));
                    case NullaryOperation.NonRealUnitsOne:
                        return new HyperSplitComplex<TInner>(HyperMath.Call<TInner>(NullaryOperation.NonRealUnitsOne), HyperMath.Call<TInner>(NullaryOperation.RealOne));
                    case NullaryOperation.CombinedOne:
                        return new HyperSplitComplex<TInner>(HyperMath.Call<TInner>(NullaryOperation.Zero), HyperMath.Call<TInner>(NullaryOperation.CombinedOne));
                    case NullaryOperation.AllOne:
                        return new HyperSplitComplex<TInner>(HyperMath.Call<TInner>(NullaryOperation.AllOne), HyperMath.Call<TInner>(NullaryOperation.AllOne));
                    default:
                        throw new NotSupportedException();
                }
            }

            public HyperSplitComplex<TInner> Create(in TInner first, in TInner second)
            {
                return new HyperSplitComplex<TInner>(first, second);
            }
		}

		IEnumerator IEnumerable.GetEnumerator()
		{
			foreach(var obj in first)
			{
				yield return obj;
			}
			foreach(var obj in second)
			{
				yield return obj;
			}
        }
	}

	partial struct HyperSplitComplex<TInner, TPrimitive> : IHyperNumber<HyperSplitComplex<TInner, TPrimitive>, TInner, TPrimitive> where TInner : struct, INumber<TInner, TPrimitive> where TPrimitive : struct, IEquatable<TPrimitive>, IComparable<TPrimitive>
	{
        readonly TInner first;
        readonly TInner second;

        public TInner First => first;
        public TInner Second => second;

        TInner IWrapperNumber<TInner>.Value => first;

        int INumber.Dimension => HyperMath.Operations.For<TInner>.Instance.Dimension * 2;

        public HyperSplitComplex(in TInner first)
        {
            this.first = first;
            second = HyperMath.Call<TInner>(NullaryOperation.Zero);
        }

        public HyperSplitComplex(in TInner first, in TInner second)
        {
            this.first = first;
            this.second = second;
        }

        public HyperSplitComplex(in (TInner first, TInner second) tuple)
        {
            first = tuple.first;
            second = tuple.second;
        }

        public void Deconstruct(out TInner first, out TInner second)
        {
            first = this.first;
            second = this.second;
        }

        public HyperSplitComplex<TInner, TPrimitive> Clone()
        {
            return new HyperSplitComplex<TInner, TPrimitive>(first.Clone(), second.Clone());
        }

        public HyperSplitComplex<TInner, TPrimitive> WithFirst(in TInner first)
        {
            return new HyperSplitComplex<TInner, TPrimitive>(first, second);
        }

        public HyperSplitComplex<TInner, TPrimitive> WithSecond(in TInner second)
        {
            return new HyperSplitComplex<TInner, TPrimitive>(first, second);
        }

        public static implicit operator HyperSplitComplex<TInner, TPrimitive>((TInner first, TInner second) tuple)
        {
            return new HyperSplitComplex<TInner, TPrimitive>(tuple.first, tuple.second);
        }

        public static implicit operator (TInner first, TInner second)(HyperSplitComplex<TInner, TPrimitive> value)
        {
            return (value.first, value.second);
        }

        public HyperSplitComplex<TInner, TPrimitive> FirstCall(BinaryOperation operation, in TInner other)
        {
            return new HyperSplitComplex<TInner, TPrimitive>(HyperMath.Call(operation, first, other), second);
        }

        public HyperSplitComplex<TInner, TPrimitive> SecondCall(BinaryOperation operation, in TInner other)
        {
            return new HyperSplitComplex<TInner, TPrimitive>(first, HyperMath.Call(operation, second, other));
        }
				
        public HyperSplitComplex<TInner, TPrimitive> FirstCall(BinaryOperation operation, in TPrimitive other)
        {
            return new HyperSplitComplex<TInner, TPrimitive>(HyperMath.CallPrimitive(operation, first, other), second);
        }

        public HyperSplitComplex<TInner, TPrimitive> SecondCall(BinaryOperation operation, in TPrimitive other)
        {
            return new HyperSplitComplex<TInner, TPrimitive>(first, HyperMath.CallPrimitive(operation, second, other));
        }
		
        public HyperSplitComplex<TInner, TPrimitive> FirstCall(UnaryOperation operation)
        {
            return new HyperSplitComplex<TInner, TPrimitive>(HyperMath.Call(operation, first), second);
        }

        public HyperSplitComplex<TInner, TPrimitive> SecondCall(UnaryOperation operation)
        {
            return new HyperSplitComplex<TInner, TPrimitive>(first, HyperMath.Call(operation, second));
        }

        public bool Equals(in HyperSplitComplex<TInner, TPrimitive> other)
        {
            return HyperMath.Equals(first, other.first) && HyperMath.Equals(second, other.second);
        }

        public int CompareTo(in HyperSplitComplex<TInner, TPrimitive> other)
        {
            int value = HyperMath.Compare(first, other.first);
            return value != 0 ? value : HyperMath.Compare(second, other.second);
        }

        public bool Equals(in TInner other)
        {
            return HyperMath.Equals(first, other) && HyperMath.Call<TInner>(NullaryOperation.Zero).Equals(second);
        }

        public int CompareTo(in TInner other)
        {
            int value = HyperMath.Compare(first, other);
            return value != 0 ? value : -HyperMath.Call<TInner>(NullaryOperation.Zero).CompareTo(second);
        }

        public override int GetHashCode()
        {
            return first.GetHashCode() * 17 + second.GetHashCode();
        }

        public override string ToString()
        {
            return "SplitComplex(" + first.ToString() + ", " + second.ToString() + ")";
        }

        public string ToString(string format, IFormatProvider formatProvider)
        {
            return "SplitComplex(" + first.ToString(format, formatProvider) + ", " + second.ToString(format, formatProvider) + ")";
        }

        IHyperNumberOperations<HyperSplitComplex<TInner, TPrimitive>, TInner> IHyperNumber<HyperSplitComplex<TInner, TPrimitive>, TInner>.GetOperations()
        {
            return Operations.Instance;
        }		

        IHyperNumberOperations<HyperSplitComplex<TInner, TPrimitive>, TInner, TPrimitive> IHyperNumber<HyperSplitComplex<TInner, TPrimitive>, TInner, TPrimitive>.GetOperations()
        {
            return Operations.Instance;
        }

		partial class Operations : NumberOperations<HyperSplitComplex<TInner, TPrimitive>>, IHyperNumberOperations<HyperSplitComplex<TInner, TPrimitive>, TInner, TPrimitive>
		{
            public override int Dimension => HyperMath.Operations.For<TInner>.Instance.Dimension * 2;

			public HyperSplitComplex<TInner, TPrimitive> Call(NullaryOperation operation)
            {
                switch(operation)
                {
                    case NullaryOperation.Zero:
                    {
                        var zero = HyperMath.Call<TInner>(NullaryOperation.Zero);
                        return new HyperSplitComplex<TInner, TPrimitive>(zero, zero);
                    }
                    case NullaryOperation.RealOne:
                        return new HyperSplitComplex<TInner, TPrimitive>(HyperMath.Call<TInner>(NullaryOperation.RealOne), HyperMath.Call<TInner>(NullaryOperation.Zero));
                    case NullaryOperation.SpecialOne:
                        return new HyperSplitComplex<TInner, TPrimitive>(HyperMath.Call<TInner>(NullaryOperation.Zero), HyperMath.Call<TInner>(NullaryOperation.RealOne));
                    case NullaryOperation.UnitsOne:
                        return new HyperSplitComplex<TInner, TPrimitive>(HyperMath.Call<TInner>(NullaryOperation.UnitsOne), HyperMath.Call<TInner>(NullaryOperation.RealOne));
                    case NullaryOperation.NonRealUnitsOne:
                        return new HyperSplitComplex<TInner, TPrimitive>(HyperMath.Call<TInner>(NullaryOperation.NonRealUnitsOne), HyperMath.Call<TInner>(NullaryOperation.RealOne));
                    case NullaryOperation.CombinedOne:
                        return new HyperSplitComplex<TInner, TPrimitive>(HyperMath.Call<TInner>(NullaryOperation.Zero), HyperMath.Call<TInner>(NullaryOperation.CombinedOne));
                    case NullaryOperation.AllOne:
                        return new HyperSplitComplex<TInner, TPrimitive>(HyperMath.Call<TInner>(NullaryOperation.AllOne), HyperMath.Call<TInner>(NullaryOperation.AllOne));
                    default:
                        throw new NotSupportedException();
                }
            }

            public HyperSplitComplex<TInner, TPrimitive> Create(in TInner first, in TInner second)
            {
                return new HyperSplitComplex<TInner, TPrimitive>(first, second);
            }			
			
            public HyperSplitComplex<TInner, TPrimitive> Create(in TPrimitive num)
            {
                return new HyperSplitComplex<TInner, TPrimitive>(HyperMath.Operations.For<TInner, TPrimitive>.Instance.Create(num));
            }

            public HyperSplitComplex<TInner, TPrimitive> Create(in TPrimitive realUnit, in TPrimitive otherUnits, in TPrimitive someUnitsCombined, in TPrimitive allUnitsCombined)
            {
                return new HyperSplitComplex<TInner, TPrimitive>(HyperMath.Create<TInner, TPrimitive>(realUnit, otherUnits, someUnitsCombined, someUnitsCombined), HyperMath.Create<TInner, TPrimitive>(otherUnits, someUnitsCombined, someUnitsCombined, allUnitsCombined));
            }

            public HyperSplitComplex<TInner, TPrimitive> Create(IEnumerable<TPrimitive> units)
            {
                var ienum = units.GetEnumerator();
                ienum.MoveNext();
                return Create(ienum);
            }

            public HyperSplitComplex<TInner, TPrimitive> Create(IEnumerator<TPrimitive> units)
            {
                var first = HyperMath.Operations.For<TInner, TPrimitive>.Instance.Create(units);
                var second = HyperMath.Operations.For<TInner, TPrimitive>.Instance.Create(units);
                return new HyperSplitComplex<TInner, TPrimitive>(first, second);
            }
		}
	}

}