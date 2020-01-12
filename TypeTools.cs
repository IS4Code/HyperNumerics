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

        public static Type GetHyperNumberType<TNumber, TComponent>(int numComplexUnits = 0, int numSplitComplexUnits = 0, int numDualUnits = 0, int numDiagonalUnits = 0) where TNumber : struct, INumber<TNumber, TComponent> where TComponent : struct, IEquatable<TComponent>, IComparable<TComponent>
        {
            var complex = Enumerable.Repeat(typeof(HyperComplex<,>), numComplexUnits);
            var splitComplex = Enumerable.Repeat(typeof(HyperSplitComplex<,>), numSplitComplexUnits);
            var dual = Enumerable.Repeat(typeof(HyperDual<,>), numDualUnits);
            var diagonal = Enumerable.Repeat(typeof(HyperDiagonal<,>), numDiagonalUnits);
            return GetHyperNumberType<TNumber, TComponent>(complex.Concat(splitComplex).Concat(dual).Concat(diagonal));
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

        public static Type GetHyperNumberType<TNumber, TComponent>(IEnumerable<Type> hyperNumberTypes) where TNumber : struct, INumber<TNumber, TComponent> where TComponent : struct, IEquatable<TComponent>, IComparable<TComponent>
        {
            var type = typeof(TNumber);
            var primType = typeof(TComponent);
            foreach(var t in hyperNumberTypes)
            {
                type = t.MakeGenericType(type, primType);
            }
            return type;
        }

        public static INumberOperations GetNumberOperations(Type numberType)
        {
            return ((INumber)Activator.CreateInstance(numberType)).GetOperations();
        }

        public static Type GetComponentType(Type numberType)
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
