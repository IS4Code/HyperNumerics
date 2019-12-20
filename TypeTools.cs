using IS4.HyperNumerics.NumberTypes;
using System;
using System.Collections.Generic;
using System.Linq;

namespace IS4.HyperNumerics
{
    public static class TypeTools
    {
        public static Type GetHyperNumberType<TNumber>(int numComplexUnits = 0, int numSplitComplexUnits = 0, int numDualUnits = 0, int numDiagonalUnits = 0) where TNumber : struct, INumber<TNumber>
        {
            var complex = Enumerable.Repeat(typeof(HyperComplex<>), numComplexUnits);
            var splitComplex = Enumerable.Repeat(typeof(HyperSplitComplex<>), numSplitComplexUnits);
            var dual = Enumerable.Repeat(typeof(HyperDual<>), numDualUnits);
            var diagonal = Enumerable.Repeat(typeof(HyperDiagonal<>), numDiagonalUnits);
            return GetHyperNumberType<TNumber>(complex.Concat(splitComplex).Concat(dual).Concat(diagonal));
        }

        public static Type GetHyperNumberType<TNumber, TPrimitive>(int numComplexUnits = 0, int numSplitComplexUnits = 0, int numDualUnits = 0, int numDiagonalUnits = 0) where TNumber : struct, INumber<TNumber, TPrimitive> where TPrimitive : struct, IEquatable<TPrimitive>, IComparable<TPrimitive>
        {
            var complex = Enumerable.Repeat(typeof(HyperComplex<,>), numComplexUnits);
            var splitComplex = Enumerable.Repeat(typeof(HyperSplitComplex<,>), numSplitComplexUnits);
            var dual = Enumerable.Repeat(typeof(HyperDual<,>), numDualUnits);
            var diagonal = Enumerable.Repeat(typeof(HyperDiagonal<,>), numDiagonalUnits);
            return GetHyperNumberType<TNumber, TPrimitive>(complex.Concat(splitComplex).Concat(dual).Concat(diagonal));
        }

        public static Type GetHyperNumberType<TNumber>(IEnumerable<Type> hyperNumberTypes) where TNumber : struct, INumber<TNumber>
        {
            var type = typeof(TNumber);
            foreach(var t in hyperNumberTypes)
            {
                type = t.MakeGenericType(type);
            }
            return type;
        }

        public static Type GetHyperNumberType<TNumber, TPrimitive>(IEnumerable<Type> hyperNumberTypes) where TNumber : struct, INumber<TNumber, TPrimitive> where TPrimitive : struct, IEquatable<TPrimitive>, IComparable<TPrimitive>
        {
            var type = typeof(TNumber);
            var primType = typeof(TPrimitive);
            foreach(var t in hyperNumberTypes)
            {
                type = t.MakeGenericType(type, primType);
            }
            return type;
        }

        public static INumberFactory GetNumberFactory(Type numberType)
        {
            return ((INumber)Activator.CreateInstance(numberType)).GetFactory();
        }

        public static Type GetPrimitiveType(Type numberType)
        {
            var tbase = typeof(INumber<,>);
            return numberType.GetInterfaces().Where(
                t => t.IsGenericType && tbase.Equals(t.GetGenericTypeDefinition())
            ).Select(
                t => t.GetGenericArguments()
            ).Where(
                args => args[0].Equals(numberType)
            ).Select(
                args => args[1]
            ).FirstOrDefault();
        }
    }
}
