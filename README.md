HyperNumerics
==========

_HyperNumerics_ is a library in C# (targeting .NET Standard 2.0) containing a variety of numbers types, as well as a multitude of several numeric interfaces and operations.

All new non-real concrete number types are represented using generic types, allowing for efficient substitution of underlying types. For example, a simple complex number is represented as `HyperComplex<Real>` (where `HyperComplex` is a wrapper type and `Real` is the final type), but the same construction can be used to any level. As an example, `HyperComplex<HyperDual<Real>>` can be used to represent a 4-dimensional "number" a+bi+cε+diε with one imaginary unit and one infinitesimal unit. This construction can be used to easily represent complex mathematical operations, like performing automatic differentiation in any degree.

Standard computations are performed with `double`, but if greater accuracy is desired, it is possible to define a new type similar to `Real` but using a different component numeric type.

## Usage
To start hypercalculating, choose a type from the `NumberTypes` namespace. There are two major kinds of types: final types (`Real`, `ExtendedReal`, and `AbstractNumber`), and composite types (`HyperComplex`, `HyperDual`, `ProjectiveNumber` etc.). Composite types can be instantiated from another number type, extending its functionality in some way. Aside of mathematically significant composite types, there are also utility types which can change certain operations or representation of other types (like `BoxedNumber`, `CustomDefaultNumber` etc.).

Composite types usually have two versions to choose from: one without `TComponent` parameter and one with it. The latter version allows several additional operations with `TComponent` (which is usually set to `double`) like obtaining the absolute value or using `TComponent` in other operations. If you can write operations conceptually without using a specific component type, you don't need to use the second version, but using it is usually simpler (even though the types become longer).

For example, the standard complex number is `HyperComplex<Real, double>`, as `Real` uses `double` as its component type. However, you can also use `HyperComplex<Real, float>` if you use `float`, but note that the internal storage `Real` uses is always `double`, and you have to define your own type if you want to change it (but `Real` can simulate `float`). 

The available final number types are `Real`, `ExtendedReal`, and `AbstractNumber`. Standard `Real` throws an exception when it is initialized with a non-real value (infinity, NaN), but `ExtendedReal` doesn't have that restriction, and both are mutually compatible to some degree. `AbstractNumber` on the other hand stores an expression instead of a value, and every additional operation extends the expression. If you only want to represent numbers conceptually and preserve the formulas that build them, you can use that, but you will lose the ability to compare them.

You can also create a type-agnostic application if you use generics, and parametrize the code with a specific type selected at runtime (with `TypeTools.GetHyperNumberType` and `FunctionalExtensions.DynamicInvoke`). There are many generic interfaces to choose from if you require certain sets of operations.

The analogue of `System.Math` is the `HyperMath` class. It is used to perform standard operations on hypernumbers, like addition, multiplication, but also the square root and other common functions. The implementation of these operations depends on the actual number types, and not all of them have to be implemented.

## Contributions
If you want to contribute with a fix, a specific formula, a new useful number type, or algorithm, feel free to submit a pull request.

## Plans
The library as it is now is very competent when it comes to the use of hypernumbers in analysis, but the introduced concepts should be usable in other areas as well. Some of the plans for the future include a representation of algebraic numbers, hyperreal numbers, but also vectors and matrices. 
