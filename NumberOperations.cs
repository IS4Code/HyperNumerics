using IS4.HyperNumerics.Operations;
using System;
using System.Collections.Generic;
using System.Text;

namespace IS4.HyperNumerics
{
    internal abstract class NumberOperations<TNumber> : INumberOperations where TNumber : struct, INumber<TNumber>
    {
        public abstract int Dimension { get; }

        public NumberOperations()
        {
            if(!(this is INumberOperations<TNumber>))
            {
                throw new TypeLoadException("The type must implement INumberOperations<TNumber>");
            }
        }

        INumber INumberOperations.Call(NullaryOperation operation)
        {
            return ((INumberOperations<TNumber>)(object)this).Call(operation);
        }
    }
}
