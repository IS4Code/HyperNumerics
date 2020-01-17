using IS4.HyperNumerics.Operations;
using System;

namespace IS4.HyperNumerics
{
    internal abstract class NumberOperations<TNumber> : INumberOperations where TNumber : struct, INumber<TNumber>
    {
        public abstract int Dimension { get; }

        readonly INumberOperations<TNumber> thisOperations;

        public NumberOperations()
        {
            thisOperations = this as INumberOperations<TNumber>;
            if(thisOperations == null)
            {
                throw new TypeLoadException("The type must implement " + typeof(INumberOperations<TNumber>));
            }
        }

        INumber INumberOperations.Create(StandardNumber num)
        {
            return thisOperations.Create(num);
        }

        INumber INumberOperations.Call(StandardUnaryOperation operation, INumber num)
        {
            if(!(num is INumber<TNumber> tnum))
            {
                throw new ArgumentException("The type of the argument must implement " + typeof(INumber<TNumber>), nameof(num));
            }
            return tnum.Call(operation);
        }

        INumber INumberOperations.Call(StandardBinaryOperation operation, INumber num1, INumber num2)
        {
            if(!(num1 is INumber<TNumber> tnum1))
            {
                throw new ArgumentException("The type of the argument must implement " + typeof(INumber<TNumber>), nameof(num1));
            }
            if(!(num2 is TNumber tnum2))
            {
                throw new ArgumentException("The type of the argument must be " + typeof(TNumber), nameof(num2));
            }
            return tnum1.Call(operation, tnum2);
        }
    }
}
