using IS4.HyperNumerics.Operations;
using System;

namespace IS4.HyperNumerics.NumberTypes
{
	partial struct AbstractNumber : IWrapperNumber<AbstractNumber, AbstractNumber>
	{
        AbstractNumber IWrapperNumber<AbstractNumber>.Value => this;

		AbstractNumber IExtendedNumber<AbstractNumber, AbstractNumber>.CallReversed(BinaryOperation operation, in AbstractNumber num)
		{
			return num.Call(operation, this);
		}
		
        IExtendedNumberOperations<AbstractNumber, AbstractNumber> IExtendedNumber<AbstractNumber, AbstractNumber>.GetOperations()
        {
            return Operations.Instance;
        }

		partial class Operations : IExtendedNumberOperations<AbstractNumber, AbstractNumber>
		{
            public AbstractNumber Create(in AbstractNumber num)
            {
                return num;
            }
		}
	}

	partial struct PrimitiveAbstractNumber : IWrapperNumber<PrimitiveAbstractNumber, PrimitiveAbstractNumber>
	{
        PrimitiveAbstractNumber IWrapperNumber<PrimitiveAbstractNumber>.Value => this;

		PrimitiveAbstractNumber IExtendedNumber<PrimitiveAbstractNumber, PrimitiveAbstractNumber>.CallReversed(BinaryOperation operation, in PrimitiveAbstractNumber num)
		{
			return num.Call(operation, this);
		}
		
        IExtendedNumberOperations<PrimitiveAbstractNumber, PrimitiveAbstractNumber> IExtendedNumber<PrimitiveAbstractNumber, PrimitiveAbstractNumber>.GetOperations()
        {
            return Operations.Instance;
        }

		partial class Operations : IExtendedNumberOperations<PrimitiveAbstractNumber, PrimitiveAbstractNumber>
		{
            public PrimitiveAbstractNumber Create(in PrimitiveAbstractNumber num)
            {
                return num;
            }
		}
	}

	partial struct UnaryAbstractNumber : IWrapperNumber<UnaryAbstractNumber, UnaryAbstractNumber>
	{
        UnaryAbstractNumber IWrapperNumber<UnaryAbstractNumber>.Value => this;

		UnaryAbstractNumber IExtendedNumber<UnaryAbstractNumber, UnaryAbstractNumber>.CallReversed(BinaryOperation operation, in UnaryAbstractNumber num)
		{
			return num.Call(operation, this);
		}
		
        IExtendedNumberOperations<UnaryAbstractNumber, UnaryAbstractNumber> IExtendedNumber<UnaryAbstractNumber, UnaryAbstractNumber>.GetOperations()
        {
            return Operations.Instance;
        }

		partial class Operations : IExtendedNumberOperations<UnaryAbstractNumber, UnaryAbstractNumber>
		{
            public UnaryAbstractNumber Create(in UnaryAbstractNumber num)
            {
                return num;
            }
		}
	}

	partial struct PrimitiveUnaryAbstractNumber : IWrapperNumber<PrimitiveUnaryAbstractNumber, PrimitiveUnaryAbstractNumber>
	{
        PrimitiveUnaryAbstractNumber IWrapperNumber<PrimitiveUnaryAbstractNumber>.Value => this;

		PrimitiveUnaryAbstractNumber IExtendedNumber<PrimitiveUnaryAbstractNumber, PrimitiveUnaryAbstractNumber>.CallReversed(BinaryOperation operation, in PrimitiveUnaryAbstractNumber num)
		{
			return num.Call(operation, this);
		}
		
        IExtendedNumberOperations<PrimitiveUnaryAbstractNumber, PrimitiveUnaryAbstractNumber> IExtendedNumber<PrimitiveUnaryAbstractNumber, PrimitiveUnaryAbstractNumber>.GetOperations()
        {
            return Operations.Instance;
        }

		partial class Operations : IExtendedNumberOperations<PrimitiveUnaryAbstractNumber, PrimitiveUnaryAbstractNumber>
		{
            public PrimitiveUnaryAbstractNumber Create(in PrimitiveUnaryAbstractNumber num)
            {
                return num;
            }
		}
	}

	partial struct BinaryAbstractNumber : IWrapperNumber<BinaryAbstractNumber, BinaryAbstractNumber>
	{
        BinaryAbstractNumber IWrapperNumber<BinaryAbstractNumber>.Value => this;

		BinaryAbstractNumber IExtendedNumber<BinaryAbstractNumber, BinaryAbstractNumber>.CallReversed(BinaryOperation operation, in BinaryAbstractNumber num)
		{
			return num.Call(operation, this);
		}
		
        IExtendedNumberOperations<BinaryAbstractNumber, BinaryAbstractNumber> IExtendedNumber<BinaryAbstractNumber, BinaryAbstractNumber>.GetOperations()
        {
            return Operations.Instance;
        }

		partial class Operations : IExtendedNumberOperations<BinaryAbstractNumber, BinaryAbstractNumber>
		{
            public BinaryAbstractNumber Create(in BinaryAbstractNumber num)
            {
                return num;
            }
		}
	}

	partial struct PrimitiveBinaryAbstractNumber : IWrapperNumber<PrimitiveBinaryAbstractNumber, PrimitiveBinaryAbstractNumber>
	{
        PrimitiveBinaryAbstractNumber IWrapperNumber<PrimitiveBinaryAbstractNumber>.Value => this;

		PrimitiveBinaryAbstractNumber IExtendedNumber<PrimitiveBinaryAbstractNumber, PrimitiveBinaryAbstractNumber>.CallReversed(BinaryOperation operation, in PrimitiveBinaryAbstractNumber num)
		{
			return num.Call(operation, this);
		}
		
        IExtendedNumberOperations<PrimitiveBinaryAbstractNumber, PrimitiveBinaryAbstractNumber> IExtendedNumber<PrimitiveBinaryAbstractNumber, PrimitiveBinaryAbstractNumber>.GetOperations()
        {
            return Operations.Instance;
        }

		partial class Operations : IExtendedNumberOperations<PrimitiveBinaryAbstractNumber, PrimitiveBinaryAbstractNumber>
		{
            public PrimitiveBinaryAbstractNumber Create(in PrimitiveBinaryAbstractNumber num)
            {
                return num;
            }
		}
	}

	partial struct BoxedNumber<TInner> : IWrapperNumber<BoxedNumber<TInner>, BoxedNumber<TInner>> where TInner : struct, INumber<TInner>
	{
        BoxedNumber<TInner> IWrapperNumber<BoxedNumber<TInner>>.Value => this;

		BoxedNumber<TInner> IExtendedNumber<BoxedNumber<TInner>, BoxedNumber<TInner>>.CallReversed(BinaryOperation operation, in BoxedNumber<TInner> num)
		{
			return num.Call(operation, this);
		}
		
        IExtendedNumberOperations<BoxedNumber<TInner>, BoxedNumber<TInner>> IExtendedNumber<BoxedNumber<TInner>, BoxedNumber<TInner>>.GetOperations()
        {
            return Operations.Instance;
        }

		partial class Operations : IExtendedNumberOperations<BoxedNumber<TInner>, BoxedNumber<TInner>>
		{
            public BoxedNumber<TInner> Create(in BoxedNumber<TInner> num)
            {
                return num;
            }
		}
	}

	partial struct BoxedNumber<TInner, TPrimitive> : IWrapperNumber<BoxedNumber<TInner, TPrimitive>, BoxedNumber<TInner, TPrimitive>, TPrimitive> where TInner : struct, INumber<TInner, TPrimitive> where TPrimitive : struct, IEquatable<TPrimitive>, IComparable<TPrimitive>
	{
        BoxedNumber<TInner, TPrimitive> IWrapperNumber<BoxedNumber<TInner, TPrimitive>>.Value => this;

		BoxedNumber<TInner, TPrimitive> IExtendedNumber<BoxedNumber<TInner, TPrimitive>, BoxedNumber<TInner, TPrimitive>>.CallReversed(BinaryOperation operation, in BoxedNumber<TInner, TPrimitive> num)
		{
			return num.Call(operation, this);
		}
		
        IExtendedNumberOperations<BoxedNumber<TInner, TPrimitive>, BoxedNumber<TInner, TPrimitive>> IExtendedNumber<BoxedNumber<TInner, TPrimitive>, BoxedNumber<TInner, TPrimitive>>.GetOperations()
        {
            return Operations.Instance;
        }

		IExtendedNumberOperations<BoxedNumber<TInner, TPrimitive>, BoxedNumber<TInner, TPrimitive>, TPrimitive> IExtendedNumber<BoxedNumber<TInner, TPrimitive>, BoxedNumber<TInner, TPrimitive>, TPrimitive>.GetOperations()
        {
            return Operations.Instance;
        }

		partial class Operations : IExtendedNumberOperations<BoxedNumber<TInner, TPrimitive>, BoxedNumber<TInner, TPrimitive>, TPrimitive>
		{
            public BoxedNumber<TInner, TPrimitive> Create(in BoxedNumber<TInner, TPrimitive> num)
            {
                return num;
            }
		}
	}

	partial struct CustomDefaultNumber<TInner, TTraits> : IWrapperNumber<CustomDefaultNumber<TInner, TTraits>, CustomDefaultNumber<TInner, TTraits>> where TInner : struct, INumber<TInner> where TTraits : struct, CustomDefaultNumber<TInner, TTraits>.ITraits
	{
        CustomDefaultNumber<TInner, TTraits> IWrapperNumber<CustomDefaultNumber<TInner, TTraits>>.Value => this;

		CustomDefaultNumber<TInner, TTraits> IExtendedNumber<CustomDefaultNumber<TInner, TTraits>, CustomDefaultNumber<TInner, TTraits>>.CallReversed(BinaryOperation operation, in CustomDefaultNumber<TInner, TTraits> num)
		{
			return num.Call(operation, this);
		}
		
        IExtendedNumberOperations<CustomDefaultNumber<TInner, TTraits>, CustomDefaultNumber<TInner, TTraits>> IExtendedNumber<CustomDefaultNumber<TInner, TTraits>, CustomDefaultNumber<TInner, TTraits>>.GetOperations()
        {
            return Operations.Instance;
        }

		partial class Operations : IExtendedNumberOperations<CustomDefaultNumber<TInner, TTraits>, CustomDefaultNumber<TInner, TTraits>>
		{
            public CustomDefaultNumber<TInner, TTraits> Create(in CustomDefaultNumber<TInner, TTraits> num)
            {
                return num;
            }
		}
	}

	partial struct CustomDefaultNumber<TInner, TPrimitive, TTraits> : IWrapperNumber<CustomDefaultNumber<TInner, TPrimitive, TTraits>, CustomDefaultNumber<TInner, TPrimitive, TTraits>, TPrimitive> where TInner : struct, INumber<TInner, TPrimitive> where TPrimitive : struct, IEquatable<TPrimitive>, IComparable<TPrimitive> where TTraits : struct, CustomDefaultNumber<TInner, TPrimitive, TTraits>.ITraits
	{
        CustomDefaultNumber<TInner, TPrimitive, TTraits> IWrapperNumber<CustomDefaultNumber<TInner, TPrimitive, TTraits>>.Value => this;

		CustomDefaultNumber<TInner, TPrimitive, TTraits> IExtendedNumber<CustomDefaultNumber<TInner, TPrimitive, TTraits>, CustomDefaultNumber<TInner, TPrimitive, TTraits>>.CallReversed(BinaryOperation operation, in CustomDefaultNumber<TInner, TPrimitive, TTraits> num)
		{
			return num.Call(operation, this);
		}
		
        IExtendedNumberOperations<CustomDefaultNumber<TInner, TPrimitive, TTraits>, CustomDefaultNumber<TInner, TPrimitive, TTraits>> IExtendedNumber<CustomDefaultNumber<TInner, TPrimitive, TTraits>, CustomDefaultNumber<TInner, TPrimitive, TTraits>>.GetOperations()
        {
            return Operations.Instance;
        }

		IExtendedNumberOperations<CustomDefaultNumber<TInner, TPrimitive, TTraits>, CustomDefaultNumber<TInner, TPrimitive, TTraits>, TPrimitive> IExtendedNumber<CustomDefaultNumber<TInner, TPrimitive, TTraits>, CustomDefaultNumber<TInner, TPrimitive, TTraits>, TPrimitive>.GetOperations()
        {
            return Operations.Instance;
        }

		partial class Operations : IExtendedNumberOperations<CustomDefaultNumber<TInner, TPrimitive, TTraits>, CustomDefaultNumber<TInner, TPrimitive, TTraits>, TPrimitive>
		{
            public CustomDefaultNumber<TInner, TPrimitive, TTraits> Create(in CustomDefaultNumber<TInner, TPrimitive, TTraits> num)
            {
                return num;
            }
		}
	}

	partial struct GeneratedNumber<TInner> : IWrapperNumber<GeneratedNumber<TInner>, GeneratedNumber<TInner>> where TInner : struct, INumber<TInner>
	{
        GeneratedNumber<TInner> IWrapperNumber<GeneratedNumber<TInner>>.Value => this;

		GeneratedNumber<TInner> IExtendedNumber<GeneratedNumber<TInner>, GeneratedNumber<TInner>>.CallReversed(BinaryOperation operation, in GeneratedNumber<TInner> num)
		{
			return num.Call(operation, this);
		}
		
        IExtendedNumberOperations<GeneratedNumber<TInner>, GeneratedNumber<TInner>> IExtendedNumber<GeneratedNumber<TInner>, GeneratedNumber<TInner>>.GetOperations()
        {
            return Operations.Instance;
        }

		partial class Operations : IExtendedNumberOperations<GeneratedNumber<TInner>, GeneratedNumber<TInner>>
		{
            public GeneratedNumber<TInner> Create(in GeneratedNumber<TInner> num)
            {
                return num;
            }
		}
	}

	partial struct GeneratedNumber<TInner, TPrimitive> : IWrapperNumber<GeneratedNumber<TInner, TPrimitive>, GeneratedNumber<TInner, TPrimitive>, TPrimitive> where TInner : struct, INumber<TInner, TPrimitive> where TPrimitive : struct, IEquatable<TPrimitive>, IComparable<TPrimitive>
	{
        GeneratedNumber<TInner, TPrimitive> IWrapperNumber<GeneratedNumber<TInner, TPrimitive>>.Value => this;

		GeneratedNumber<TInner, TPrimitive> IExtendedNumber<GeneratedNumber<TInner, TPrimitive>, GeneratedNumber<TInner, TPrimitive>>.CallReversed(BinaryOperation operation, in GeneratedNumber<TInner, TPrimitive> num)
		{
			return num.Call(operation, this);
		}
		
        IExtendedNumberOperations<GeneratedNumber<TInner, TPrimitive>, GeneratedNumber<TInner, TPrimitive>> IExtendedNumber<GeneratedNumber<TInner, TPrimitive>, GeneratedNumber<TInner, TPrimitive>>.GetOperations()
        {
            return Operations.Instance;
        }

		IExtendedNumberOperations<GeneratedNumber<TInner, TPrimitive>, GeneratedNumber<TInner, TPrimitive>, TPrimitive> IExtendedNumber<GeneratedNumber<TInner, TPrimitive>, GeneratedNumber<TInner, TPrimitive>, TPrimitive>.GetOperations()
        {
            return Operations.Instance;
        }

		partial class Operations : IExtendedNumberOperations<GeneratedNumber<TInner, TPrimitive>, GeneratedNumber<TInner, TPrimitive>, TPrimitive>
		{
            public GeneratedNumber<TInner, TPrimitive> Create(in GeneratedNumber<TInner, TPrimitive> num)
            {
                return num;
            }
		}
	}

	partial struct HyperComplex<TInner> : IWrapperNumber<HyperComplex<TInner>, HyperComplex<TInner>> where TInner : struct, INumber<TInner>
	{
        HyperComplex<TInner> IWrapperNumber<HyperComplex<TInner>>.Value => this;

		HyperComplex<TInner> IExtendedNumber<HyperComplex<TInner>, HyperComplex<TInner>>.CallReversed(BinaryOperation operation, in HyperComplex<TInner> num)
		{
			return num.Call(operation, this);
		}
		
        IExtendedNumberOperations<HyperComplex<TInner>, HyperComplex<TInner>> IExtendedNumber<HyperComplex<TInner>, HyperComplex<TInner>>.GetOperations()
        {
            return Operations.Instance;
        }

		partial class Operations : IExtendedNumberOperations<HyperComplex<TInner>, HyperComplex<TInner>>
		{
            public HyperComplex<TInner> Create(in HyperComplex<TInner> num)
            {
                return num;
            }
		}
	}

	partial struct HyperComplex<TInner, TPrimitive> : IWrapperNumber<HyperComplex<TInner, TPrimitive>, HyperComplex<TInner, TPrimitive>, TPrimitive> where TInner : struct, INumber<TInner, TPrimitive> where TPrimitive : struct, IEquatable<TPrimitive>, IComparable<TPrimitive>
	{
        HyperComplex<TInner, TPrimitive> IWrapperNumber<HyperComplex<TInner, TPrimitive>>.Value => this;

		HyperComplex<TInner, TPrimitive> IExtendedNumber<HyperComplex<TInner, TPrimitive>, HyperComplex<TInner, TPrimitive>>.CallReversed(BinaryOperation operation, in HyperComplex<TInner, TPrimitive> num)
		{
			return num.Call(operation, this);
		}
		
        IExtendedNumberOperations<HyperComplex<TInner, TPrimitive>, HyperComplex<TInner, TPrimitive>> IExtendedNumber<HyperComplex<TInner, TPrimitive>, HyperComplex<TInner, TPrimitive>>.GetOperations()
        {
            return Operations.Instance;
        }

		IExtendedNumberOperations<HyperComplex<TInner, TPrimitive>, HyperComplex<TInner, TPrimitive>, TPrimitive> IExtendedNumber<HyperComplex<TInner, TPrimitive>, HyperComplex<TInner, TPrimitive>, TPrimitive>.GetOperations()
        {
            return Operations.Instance;
        }

		partial class Operations : IExtendedNumberOperations<HyperComplex<TInner, TPrimitive>, HyperComplex<TInner, TPrimitive>, TPrimitive>
		{
            public HyperComplex<TInner, TPrimitive> Create(in HyperComplex<TInner, TPrimitive> num)
            {
                return num;
            }
		}
	}

	partial struct HyperDiagonal<TInner> : IWrapperNumber<HyperDiagonal<TInner>, HyperDiagonal<TInner>> where TInner : struct, INumber<TInner>
	{
        HyperDiagonal<TInner> IWrapperNumber<HyperDiagonal<TInner>>.Value => this;

		HyperDiagonal<TInner> IExtendedNumber<HyperDiagonal<TInner>, HyperDiagonal<TInner>>.CallReversed(BinaryOperation operation, in HyperDiagonal<TInner> num)
		{
			return num.Call(operation, this);
		}
		
        IExtendedNumberOperations<HyperDiagonal<TInner>, HyperDiagonal<TInner>> IExtendedNumber<HyperDiagonal<TInner>, HyperDiagonal<TInner>>.GetOperations()
        {
            return Operations.Instance;
        }

		partial class Operations : IExtendedNumberOperations<HyperDiagonal<TInner>, HyperDiagonal<TInner>>
		{
            public HyperDiagonal<TInner> Create(in HyperDiagonal<TInner> num)
            {
                return num;
            }
		}
	}

	partial struct HyperDiagonal<TInner, TPrimitive> : IWrapperNumber<HyperDiagonal<TInner, TPrimitive>, HyperDiagonal<TInner, TPrimitive>, TPrimitive> where TInner : struct, INumber<TInner, TPrimitive> where TPrimitive : struct, IEquatable<TPrimitive>, IComparable<TPrimitive>
	{
        HyperDiagonal<TInner, TPrimitive> IWrapperNumber<HyperDiagonal<TInner, TPrimitive>>.Value => this;

		HyperDiagonal<TInner, TPrimitive> IExtendedNumber<HyperDiagonal<TInner, TPrimitive>, HyperDiagonal<TInner, TPrimitive>>.CallReversed(BinaryOperation operation, in HyperDiagonal<TInner, TPrimitive> num)
		{
			return num.Call(operation, this);
		}
		
        IExtendedNumberOperations<HyperDiagonal<TInner, TPrimitive>, HyperDiagonal<TInner, TPrimitive>> IExtendedNumber<HyperDiagonal<TInner, TPrimitive>, HyperDiagonal<TInner, TPrimitive>>.GetOperations()
        {
            return Operations.Instance;
        }

		IExtendedNumberOperations<HyperDiagonal<TInner, TPrimitive>, HyperDiagonal<TInner, TPrimitive>, TPrimitive> IExtendedNumber<HyperDiagonal<TInner, TPrimitive>, HyperDiagonal<TInner, TPrimitive>, TPrimitive>.GetOperations()
        {
            return Operations.Instance;
        }

		partial class Operations : IExtendedNumberOperations<HyperDiagonal<TInner, TPrimitive>, HyperDiagonal<TInner, TPrimitive>, TPrimitive>
		{
            public HyperDiagonal<TInner, TPrimitive> Create(in HyperDiagonal<TInner, TPrimitive> num)
            {
                return num;
            }
		}
	}

	partial struct HyperDual<TInner> : IWrapperNumber<HyperDual<TInner>, HyperDual<TInner>> where TInner : struct, INumber<TInner>
	{
        HyperDual<TInner> IWrapperNumber<HyperDual<TInner>>.Value => this;

		HyperDual<TInner> IExtendedNumber<HyperDual<TInner>, HyperDual<TInner>>.CallReversed(BinaryOperation operation, in HyperDual<TInner> num)
		{
			return num.Call(operation, this);
		}
		
        IExtendedNumberOperations<HyperDual<TInner>, HyperDual<TInner>> IExtendedNumber<HyperDual<TInner>, HyperDual<TInner>>.GetOperations()
        {
            return Operations.Instance;
        }

		partial class Operations : IExtendedNumberOperations<HyperDual<TInner>, HyperDual<TInner>>
		{
            public HyperDual<TInner> Create(in HyperDual<TInner> num)
            {
                return num;
            }
		}
	}

	partial struct HyperDual<TInner, TPrimitive> : IWrapperNumber<HyperDual<TInner, TPrimitive>, HyperDual<TInner, TPrimitive>, TPrimitive> where TInner : struct, INumber<TInner, TPrimitive> where TPrimitive : struct, IEquatable<TPrimitive>, IComparable<TPrimitive>
	{
        HyperDual<TInner, TPrimitive> IWrapperNumber<HyperDual<TInner, TPrimitive>>.Value => this;

		HyperDual<TInner, TPrimitive> IExtendedNumber<HyperDual<TInner, TPrimitive>, HyperDual<TInner, TPrimitive>>.CallReversed(BinaryOperation operation, in HyperDual<TInner, TPrimitive> num)
		{
			return num.Call(operation, this);
		}
		
        IExtendedNumberOperations<HyperDual<TInner, TPrimitive>, HyperDual<TInner, TPrimitive>> IExtendedNumber<HyperDual<TInner, TPrimitive>, HyperDual<TInner, TPrimitive>>.GetOperations()
        {
            return Operations.Instance;
        }

		IExtendedNumberOperations<HyperDual<TInner, TPrimitive>, HyperDual<TInner, TPrimitive>, TPrimitive> IExtendedNumber<HyperDual<TInner, TPrimitive>, HyperDual<TInner, TPrimitive>, TPrimitive>.GetOperations()
        {
            return Operations.Instance;
        }

		partial class Operations : IExtendedNumberOperations<HyperDual<TInner, TPrimitive>, HyperDual<TInner, TPrimitive>, TPrimitive>
		{
            public HyperDual<TInner, TPrimitive> Create(in HyperDual<TInner, TPrimitive> num)
            {
                return num;
            }
		}
	}

	partial struct HyperSplitComplex<TInner> : IWrapperNumber<HyperSplitComplex<TInner>, HyperSplitComplex<TInner>> where TInner : struct, INumber<TInner>
	{
        HyperSplitComplex<TInner> IWrapperNumber<HyperSplitComplex<TInner>>.Value => this;

		HyperSplitComplex<TInner> IExtendedNumber<HyperSplitComplex<TInner>, HyperSplitComplex<TInner>>.CallReversed(BinaryOperation operation, in HyperSplitComplex<TInner> num)
		{
			return num.Call(operation, this);
		}
		
        IExtendedNumberOperations<HyperSplitComplex<TInner>, HyperSplitComplex<TInner>> IExtendedNumber<HyperSplitComplex<TInner>, HyperSplitComplex<TInner>>.GetOperations()
        {
            return Operations.Instance;
        }

		partial class Operations : IExtendedNumberOperations<HyperSplitComplex<TInner>, HyperSplitComplex<TInner>>
		{
            public HyperSplitComplex<TInner> Create(in HyperSplitComplex<TInner> num)
            {
                return num;
            }
		}
	}

	partial struct HyperSplitComplex<TInner, TPrimitive> : IWrapperNumber<HyperSplitComplex<TInner, TPrimitive>, HyperSplitComplex<TInner, TPrimitive>, TPrimitive> where TInner : struct, INumber<TInner, TPrimitive> where TPrimitive : struct, IEquatable<TPrimitive>, IComparable<TPrimitive>
	{
        HyperSplitComplex<TInner, TPrimitive> IWrapperNumber<HyperSplitComplex<TInner, TPrimitive>>.Value => this;

		HyperSplitComplex<TInner, TPrimitive> IExtendedNumber<HyperSplitComplex<TInner, TPrimitive>, HyperSplitComplex<TInner, TPrimitive>>.CallReversed(BinaryOperation operation, in HyperSplitComplex<TInner, TPrimitive> num)
		{
			return num.Call(operation, this);
		}
		
        IExtendedNumberOperations<HyperSplitComplex<TInner, TPrimitive>, HyperSplitComplex<TInner, TPrimitive>> IExtendedNumber<HyperSplitComplex<TInner, TPrimitive>, HyperSplitComplex<TInner, TPrimitive>>.GetOperations()
        {
            return Operations.Instance;
        }

		IExtendedNumberOperations<HyperSplitComplex<TInner, TPrimitive>, HyperSplitComplex<TInner, TPrimitive>, TPrimitive> IExtendedNumber<HyperSplitComplex<TInner, TPrimitive>, HyperSplitComplex<TInner, TPrimitive>, TPrimitive>.GetOperations()
        {
            return Operations.Instance;
        }

		partial class Operations : IExtendedNumberOperations<HyperSplitComplex<TInner, TPrimitive>, HyperSplitComplex<TInner, TPrimitive>, TPrimitive>
		{
            public HyperSplitComplex<TInner, TPrimitive> Create(in HyperSplitComplex<TInner, TPrimitive> num)
            {
                return num;
            }
		}
	}

	partial struct NullableNumber<TInner> : IWrapperNumber<NullableNumber<TInner>, NullableNumber<TInner>> where TInner : struct, INumber<TInner>
	{
        NullableNumber<TInner> IWrapperNumber<NullableNumber<TInner>>.Value => this;

		NullableNumber<TInner> IExtendedNumber<NullableNumber<TInner>, NullableNumber<TInner>>.CallReversed(BinaryOperation operation, in NullableNumber<TInner> num)
		{
			return num.Call(operation, this);
		}
		
        IExtendedNumberOperations<NullableNumber<TInner>, NullableNumber<TInner>> IExtendedNumber<NullableNumber<TInner>, NullableNumber<TInner>>.GetOperations()
        {
            return Operations.Instance;
        }

		partial class Operations : IExtendedNumberOperations<NullableNumber<TInner>, NullableNumber<TInner>>
		{
            public NullableNumber<TInner> Create(in NullableNumber<TInner> num)
            {
                return num;
            }
		}
	}

	partial struct NullableNumber<TInner, TPrimitive> : IWrapperNumber<NullableNumber<TInner, TPrimitive>, NullableNumber<TInner, TPrimitive>, TPrimitive> where TInner : struct, INumber<TInner, TPrimitive> where TPrimitive : struct, IEquatable<TPrimitive>, IComparable<TPrimitive>
	{
        NullableNumber<TInner, TPrimitive> IWrapperNumber<NullableNumber<TInner, TPrimitive>>.Value => this;

		NullableNumber<TInner, TPrimitive> IExtendedNumber<NullableNumber<TInner, TPrimitive>, NullableNumber<TInner, TPrimitive>>.CallReversed(BinaryOperation operation, in NullableNumber<TInner, TPrimitive> num)
		{
			return num.Call(operation, this);
		}
		
        IExtendedNumberOperations<NullableNumber<TInner, TPrimitive>, NullableNumber<TInner, TPrimitive>> IExtendedNumber<NullableNumber<TInner, TPrimitive>, NullableNumber<TInner, TPrimitive>>.GetOperations()
        {
            return Operations.Instance;
        }

		IExtendedNumberOperations<NullableNumber<TInner, TPrimitive>, NullableNumber<TInner, TPrimitive>, TPrimitive> IExtendedNumber<NullableNumber<TInner, TPrimitive>, NullableNumber<TInner, TPrimitive>, TPrimitive>.GetOperations()
        {
            return Operations.Instance;
        }

		partial class Operations : IExtendedNumberOperations<NullableNumber<TInner, TPrimitive>, NullableNumber<TInner, TPrimitive>, TPrimitive>
		{
            public NullableNumber<TInner, TPrimitive> Create(in NullableNumber<TInner, TPrimitive> num)
            {
                return num;
            }
		}
	}

	partial struct NullNumber : IWrapperNumber<NullNumber, NullNumber>
	{
        NullNumber IWrapperNumber<NullNumber>.Value => this;

		NullNumber IExtendedNumber<NullNumber, NullNumber>.CallReversed(BinaryOperation operation, in NullNumber num)
		{
			return num.Call(operation, this);
		}
		
        IExtendedNumberOperations<NullNumber, NullNumber> IExtendedNumber<NullNumber, NullNumber>.GetOperations()
        {
            return Operations.Instance;
        }

		partial class Operations : IExtendedNumberOperations<NullNumber, NullNumber>
		{
            public NullNumber Create(in NullNumber num)
            {
                return num;
            }
		}
	}

	partial struct NullNumber<TPrimitive> : IWrapperNumber<NullNumber<TPrimitive>, NullNumber<TPrimitive>, TPrimitive> where TPrimitive : struct, IEquatable<TPrimitive>, IComparable<TPrimitive>
	{
        NullNumber<TPrimitive> IWrapperNumber<NullNumber<TPrimitive>>.Value => this;

		NullNumber<TPrimitive> IExtendedNumber<NullNumber<TPrimitive>, NullNumber<TPrimitive>>.CallReversed(BinaryOperation operation, in NullNumber<TPrimitive> num)
		{
			return num.Call(operation, this);
		}
		
        IExtendedNumberOperations<NullNumber<TPrimitive>, NullNumber<TPrimitive>> IExtendedNumber<NullNumber<TPrimitive>, NullNumber<TPrimitive>>.GetOperations()
        {
            return Operations.Instance;
        }

		IExtendedNumberOperations<NullNumber<TPrimitive>, NullNumber<TPrimitive>, TPrimitive> IExtendedNumber<NullNumber<TPrimitive>, NullNumber<TPrimitive>, TPrimitive>.GetOperations()
        {
            return Operations.Instance;
        }

		partial class Operations : IExtendedNumberOperations<NullNumber<TPrimitive>, NullNumber<TPrimitive>, TPrimitive>
		{
            public NullNumber<TPrimitive> Create(in NullNumber<TPrimitive> num)
            {
                return num;
            }
		}
	}

	partial struct ProjectiveNumber<TInner> : IWrapperNumber<ProjectiveNumber<TInner>, ProjectiveNumber<TInner>> where TInner : struct, INumber<TInner>
	{
        ProjectiveNumber<TInner> IWrapperNumber<ProjectiveNumber<TInner>>.Value => this;

		ProjectiveNumber<TInner> IExtendedNumber<ProjectiveNumber<TInner>, ProjectiveNumber<TInner>>.CallReversed(BinaryOperation operation, in ProjectiveNumber<TInner> num)
		{
			return num.Call(operation, this);
		}
		
        IExtendedNumberOperations<ProjectiveNumber<TInner>, ProjectiveNumber<TInner>> IExtendedNumber<ProjectiveNumber<TInner>, ProjectiveNumber<TInner>>.GetOperations()
        {
            return Operations.Instance;
        }

		partial class Operations : IExtendedNumberOperations<ProjectiveNumber<TInner>, ProjectiveNumber<TInner>>
		{
            public ProjectiveNumber<TInner> Create(in ProjectiveNumber<TInner> num)
            {
                return num;
            }
		}
	}

	partial struct ProjectiveNumber<TInner, TPrimitive> : IWrapperNumber<ProjectiveNumber<TInner, TPrimitive>, ProjectiveNumber<TInner, TPrimitive>, TPrimitive> where TInner : struct, INumber<TInner, TPrimitive> where TPrimitive : struct, IEquatable<TPrimitive>, IComparable<TPrimitive>
	{
        ProjectiveNumber<TInner, TPrimitive> IWrapperNumber<ProjectiveNumber<TInner, TPrimitive>>.Value => this;

		ProjectiveNumber<TInner, TPrimitive> IExtendedNumber<ProjectiveNumber<TInner, TPrimitive>, ProjectiveNumber<TInner, TPrimitive>>.CallReversed(BinaryOperation operation, in ProjectiveNumber<TInner, TPrimitive> num)
		{
			return num.Call(operation, this);
		}
		
        IExtendedNumberOperations<ProjectiveNumber<TInner, TPrimitive>, ProjectiveNumber<TInner, TPrimitive>> IExtendedNumber<ProjectiveNumber<TInner, TPrimitive>, ProjectiveNumber<TInner, TPrimitive>>.GetOperations()
        {
            return Operations.Instance;
        }

		IExtendedNumberOperations<ProjectiveNumber<TInner, TPrimitive>, ProjectiveNumber<TInner, TPrimitive>, TPrimitive> IExtendedNumber<ProjectiveNumber<TInner, TPrimitive>, ProjectiveNumber<TInner, TPrimitive>, TPrimitive>.GetOperations()
        {
            return Operations.Instance;
        }

		partial class Operations : IExtendedNumberOperations<ProjectiveNumber<TInner, TPrimitive>, ProjectiveNumber<TInner, TPrimitive>, TPrimitive>
		{
            public ProjectiveNumber<TInner, TPrimitive> Create(in ProjectiveNumber<TInner, TPrimitive> num)
            {
                return num;
            }
		}
	}

}