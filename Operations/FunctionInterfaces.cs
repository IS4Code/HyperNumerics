using System;

namespace IS4.HyperNumerics.Operations
{
    public interface INumberFunc<out TResult> : IComponentNumberFunc<TResult>
    {
        TResult Invoke<TNumber>() where TNumber : struct, INumber<TNumber>;
    }

    public interface INumberFunc<in T1, out TResult> : IComponentNumberFunc<T1, TResult>
    {
        TResult Invoke<TNumber>(T1 arg) where TNumber : struct, INumber<TNumber>;
    }

    public interface INumberFunc<in T1, in T2, out TResult> : IComponentNumberFunc<T1, T2, TResult>
    {
        TResult Invoke<TNumber>(T1 arg1, T2 arg2) where TNumber : struct, INumber<TNumber>;
    }

    public interface INumberFunc<in T1, in T2, in T3, out TResult> : IComponentNumberFunc<T1, T2, T3, TResult>
    {
        TResult Invoke<TNumber>(T1 arg1, T2 arg2, T3 arg3) where TNumber : struct, INumber<TNumber>;
    }

    public interface INumberFunc<in T1, in T2, in T3, in T4, out TResult> : IComponentNumberFunc<T1, T2, T3, T4, TResult>
    {
        TResult Invoke<TNumber>(T1 arg1, T2 arg2, T3 arg3, T4 arg4) where TNumber : struct, INumber<TNumber>;
    }

    public interface INumberFunc<in T1, in T2, in T3, in T4, in T5, out TResult> : IComponentNumberFunc<T1, T2, T3, T4, T5, TResult>
    {
        TResult Invoke<TNumber>(T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5) where TNumber : struct, INumber<TNumber>;
    }

    public interface INumberFunc<in T1, in T2, in T3, in T4, in T5, in T6, out TResult> : IComponentNumberFunc<T1, T2, T3, T4, T5, T6, TResult>
    {
        TResult Invoke<TNumber>(T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6) where TNumber : struct, INumber<TNumber>;
    }

    public interface INumberFunc<in T1, in T2, in T3, in T4, in T5, in T6, in T7, out TResult> : IComponentNumberFunc<T1, T2, T3, T4, T5, T6, T7, TResult>
    {
        TResult Invoke<TNumber>(T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7) where TNumber : struct, INumber<TNumber>;
    }

    public interface INumberFunc<in T1, in T2, in T3, in T4, in T5, in T6, in T7, in T8, out TResult> : IComponentNumberFunc<T1, T2, T3, T4, T5, T6, T7, T8, TResult>
    {
        TResult Invoke<TNumber>(T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7, T8 arg8) where TNumber : struct, INumber<TNumber>;
    }

    public interface IUnaryNumberFunc<out TResult> : IComponentUnaryNumberFunc<TResult>
    {
        TResult Invoke<TNumber>(in TNumber numArg) where TNumber : struct, INumber<TNumber>;
    }

    public interface IUnaryNumberFunc<in T1, out TResult> : IComponentUnaryNumberFunc<T1, TResult>
    {
        TResult Invoke<TNumber>(in TNumber numArg, T1 arg) where TNumber : struct, INumber<TNumber>;
    }

    public interface IUnaryNumberFunc<in T1, in T2, out TResult> : IComponentUnaryNumberFunc<T1, T2, TResult>
    {
        TResult Invoke<TNumber>(in TNumber numArg, T1 arg1, T2 arg2) where TNumber : struct, INumber<TNumber>;
    }

    public interface IUnaryNumberFunc<in T1, in T2, in T3, out TResult> : IComponentUnaryNumberFunc<T1, T2, T3, TResult>
    {
        TResult Invoke<TNumber>(in TNumber numArg, T1 arg1, T2 arg2, T3 arg3) where TNumber : struct, INumber<TNumber>;
    }

    public interface IUnaryNumberFunc<in T1, in T2, in T3, in T4, out TResult> : IComponentUnaryNumberFunc<T1, T2, T3, T4, TResult>
    {
        TResult Invoke<TNumber>(in TNumber numArg, T1 arg1, T2 arg2, T3 arg3, T4 arg4) where TNumber : struct, INumber<TNumber>;
    }

    public interface IUnaryNumberFunc<in T1, in T2, in T3, in T4, in T5, out TResult> : IComponentUnaryNumberFunc<T1, T2, T3, T4, T5, TResult>
    {
        TResult Invoke<TNumber>(in TNumber numArg, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5) where TNumber : struct, INumber<TNumber>;
    }

    public interface IUnaryNumberFunc<in T1, in T2, in T3, in T4, in T5, in T6, out TResult> : IComponentUnaryNumberFunc<T1, T2, T3, T4, T5, T6, TResult>
    {
        TResult Invoke<TNumber>(in TNumber numArg, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6) where TNumber : struct, INumber<TNumber>;
    }

    public interface IUnaryNumberFunc<in T1, in T2, in T3, in T4, in T5, in T6, in T7, out TResult> : IComponentUnaryNumberFunc<T1, T2, T3, T4, T5, T6, T7, TResult>
    {
        TResult Invoke<TNumber>(in TNumber numArg, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7) where TNumber : struct, INumber<TNumber>;
    }

    public interface IUnaryNumberFunc<in T1, in T2, in T3, in T4, in T5, in T6, in T7, in T8, out TResult> : IComponentUnaryNumberFunc<T1, T2, T3, T4, T5, T6, T7, T8, TResult>
    {
        TResult Invoke<TNumber>(in TNumber numArg, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7, T8 arg8) where TNumber : struct, INumber<TNumber>;
    }

    public interface IBinaryNumberFunc<out TResult> : IComponentBinaryNumberFunc<TResult>
    {
        TResult Invoke<TNumber>(in TNumber numArg1, in TNumber numArg2) where TNumber : struct, INumber<TNumber>;
    }

    public interface IBinaryNumberFunc<in T1, out TResult> : IComponentBinaryNumberFunc<T1, TResult>
    {
        TResult Invoke<TNumber>(in TNumber numArg1, in TNumber numArg2, T1 arg) where TNumber : struct, INumber<TNumber>;
    }

    public interface IBinaryNumberFunc<in T1, in T2, out TResult> : IComponentBinaryNumberFunc<T1, T2, TResult>
    {
        TResult Invoke<TNumber>(in TNumber numArg1, in TNumber numArg2, T1 arg1, T2 arg2) where TNumber : struct, INumber<TNumber>;
    }

    public interface IBinaryNumberFunc<in T1, in T2, in T3, out TResult> : IComponentBinaryNumberFunc<T1, T2, T3, TResult>
    {
        TResult Invoke<TNumber>(in TNumber numArg1, in TNumber numArg2, T1 arg1, T2 arg2, T3 arg3) where TNumber : struct, INumber<TNumber>;
    }

    public interface IBinaryNumberFunc<in T1, in T2, in T3, in T4, out TResult> : IComponentBinaryNumberFunc<T1, T2, T3, T4, TResult>
    {
        TResult Invoke<TNumber>(in TNumber numArg1, in TNumber numArg2, T1 arg1, T2 arg2, T3 arg3, T4 arg4) where TNumber : struct, INumber<TNumber>;
    }

    public interface IBinaryNumberFunc<in T1, in T2, in T3, in T4, in T5, out TResult> : IComponentBinaryNumberFunc<T1, T2, T3, T4, T5, TResult>
    {
        TResult Invoke<TNumber>(in TNumber numArg1, in TNumber numArg2, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5) where TNumber : struct, INumber<TNumber>;
    }

    public interface IBinaryNumberFunc<in T1, in T2, in T3, in T4, in T5, in T6, out TResult> : IComponentBinaryNumberFunc<T1, T2, T3, T4, T5, T6, TResult>
    {
        TResult Invoke<TNumber>(in TNumber numArg1, in TNumber numArg2, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6) where TNumber : struct, INumber<TNumber>;
    }

    public interface IBinaryNumberFunc<in T1, in T2, in T3, in T4, in T5, in T6, in T7, out TResult> : IComponentBinaryNumberFunc<T1, T2, T3, T4, T5, T6, T7, TResult>
    {
        TResult Invoke<TNumber>(in TNumber numArg1, in TNumber numArg2, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7) where TNumber : struct, INumber<TNumber>;
    }

    public interface IBinaryNumberFunc<in T1, in T2, in T3, in T4, in T5, in T6, in T7, in T8, out TResult> : IComponentBinaryNumberFunc<T1, T2, T3, T4, T5, T6, T7, T8, TResult>
    {
        TResult Invoke<TNumber>(in TNumber numArg1, in TNumber numArg2, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7, T8 arg8) where TNumber : struct, INumber<TNumber>;
    }

    public interface ITernaryNumberFunc<out TResult> : IComponentTernaryNumberFunc<TResult>
    {
        TResult Invoke<TNumber>(in TNumber numArg1, in TNumber numArg2, in TNumber numArg3) where TNumber : struct, INumber<TNumber>;
    }

    public interface ITernaryNumberFunc<in T1, out TResult> : IComponentTernaryNumberFunc<T1, TResult>
    {
        TResult Invoke<TNumber>(in TNumber numArg1, in TNumber numArg2, in TNumber numArg3, T1 arg) where TNumber : struct, INumber<TNumber>;
    }

    public interface ITernaryNumberFunc<in T1, in T2, out TResult> : IComponentTernaryNumberFunc<T1, T2, TResult>
    {
        TResult Invoke<TNumber>(in TNumber numArg1, in TNumber numArg2, in TNumber numArg3, T1 arg1, T2 arg2) where TNumber : struct, INumber<TNumber>;
    }

    public interface ITernaryNumberFunc<in T1, in T2, in T3, out TResult> : IComponentTernaryNumberFunc<T1, T2, T3, TResult>
    {
        TResult Invoke<TNumber>(in TNumber numArg1, in TNumber numArg2, in TNumber numArg3, T1 arg1, T2 arg2, T3 arg3) where TNumber : struct, INumber<TNumber>;
    }

    public interface ITernaryNumberFunc<in T1, in T2, in T3, in T4, out TResult> : IComponentTernaryNumberFunc<T1, T2, T3, T4, TResult>
    {
        TResult Invoke<TNumber>(in TNumber numArg1, in TNumber numArg2, in TNumber numArg3, T1 arg1, T2 arg2, T3 arg3, T4 arg4) where TNumber : struct, INumber<TNumber>;
    }

    public interface ITernaryNumberFunc<in T1, in T2, in T3, in T4, in T5, out TResult> : IComponentTernaryNumberFunc<T1, T2, T3, T4, T5, TResult>
    {
        TResult Invoke<TNumber>(in TNumber numArg1, in TNumber numArg2, in TNumber numArg3, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5) where TNumber : struct, INumber<TNumber>;
    }

    public interface ITernaryNumberFunc<in T1, in T2, in T3, in T4, in T5, in T6, out TResult> : IComponentTernaryNumberFunc<T1, T2, T3, T4, T5, T6, TResult>
    {
        TResult Invoke<TNumber>(in TNumber numArg1, in TNumber numArg2, in TNumber numArg3, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6) where TNumber : struct, INumber<TNumber>;
    }

    public interface ITernaryNumberFunc<in T1, in T2, in T3, in T4, in T5, in T6, in T7, out TResult> : IComponentTernaryNumberFunc<T1, T2, T3, T4, T5, T6, T7, TResult>
    {
        TResult Invoke<TNumber>(in TNumber numArg1, in TNumber numArg2, in TNumber numArg3, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7) where TNumber : struct, INumber<TNumber>;
    }

    public interface ITernaryNumberFunc<in T1, in T2, in T3, in T4, in T5, in T6, in T7, in T8, out TResult> : IComponentTernaryNumberFunc<T1, T2, T3, T4, T5, T6, T7, T8, TResult>
    {
        TResult Invoke<TNumber>(in TNumber numArg1, in TNumber numArg2, in TNumber numArg3, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7, T8 arg8) where TNumber : struct, INumber<TNumber>;
    }

    public interface INumberAction : IComponentNumberAction
    {
        void Invoke<TNumber>() where TNumber : struct, INumber<TNumber>;
    }

    public interface INumberAction<in T1> : IComponentNumberAction<T1>
    {
        void Invoke<TNumber>(T1 arg) where TNumber : struct, INumber<TNumber>;
    }

    public interface INumberAction<in T1, in T2> : IComponentNumberAction<T1, T2>
    {
        void Invoke<TNumber>(T1 arg1, T2 arg2) where TNumber : struct, INumber<TNumber>;
    }

    public interface INumberAction<in T1, in T2, in T3> : IComponentNumberAction<T1, T2, T3>
    {
        void Invoke<TNumber>(T1 arg1, T2 arg2, T3 arg3) where TNumber : struct, INumber<TNumber>;
    }

    public interface INumberAction<in T1, in T2, in T3, in T4> : IComponentNumberAction<T1, T2, T3, T4>
    {
        void Invoke<TNumber>(T1 arg1, T2 arg2, T3 arg3, T4 arg4) where TNumber : struct, INumber<TNumber>;
    }

    public interface INumberAction<in T1, in T2, in T3, in T4, in T5> : IComponentNumberAction<T1, T2, T3, T4, T5>
    {
        void Invoke<TNumber>(T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5) where TNumber : struct, INumber<TNumber>;
    }

    public interface INumberAction<in T1, in T2, in T3, in T4, in T5, in T6> : IComponentNumberAction<T1, T2, T3, T4, T5, T6>
    {
        void Invoke<TNumber>(T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6) where TNumber : struct, INumber<TNumber>;
    }

    public interface INumberAction<in T1, in T2, in T3, in T4, in T5, in T6, in T7> : IComponentNumberAction<T1, T2, T3, T4, T5, T6, T7>
    {
        void Invoke<TNumber>(T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7) where TNumber : struct, INumber<TNumber>;
    }

    public interface INumberAction<in T1, in T2, in T3, in T4, in T5, in T6, in T7, in T8> : IComponentNumberAction<T1, T2, T3, T4, T5, T6, T7, T8>
    {
        void Invoke<TNumber>(T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7, T8 arg8) where TNumber : struct, INumber<TNumber>;
    }

    public interface IUnaryNumberAction : IComponentUnaryNumberAction
    {
        void Invoke<TNumber>(in TNumber numArg) where TNumber : struct, INumber<TNumber>;
    }

    public interface IUnaryNumberAction<in T1> : IComponentUnaryNumberAction<T1>
    {
        void Invoke<TNumber>(in TNumber numArg, T1 arg) where TNumber : struct, INumber<TNumber>;
    }

    public interface IUnaryNumberAction<in T1, in T2> : IComponentUnaryNumberAction<T1, T2>
    {
        void Invoke<TNumber>(in TNumber numArg, T1 arg1, T2 arg2) where TNumber : struct, INumber<TNumber>;
    }

    public interface IUnaryNumberAction<in T1, in T2, in T3> : IComponentUnaryNumberAction<T1, T2, T3>
    {
        void Invoke<TNumber>(in TNumber numArg, T1 arg1, T2 arg2, T3 arg3) where TNumber : struct, INumber<TNumber>;
    }

    public interface IUnaryNumberAction<in T1, in T2, in T3, in T4> : IComponentUnaryNumberAction<T1, T2, T3, T4>
    {
        void Invoke<TNumber>(in TNumber numArg, T1 arg1, T2 arg2, T3 arg3, T4 arg4) where TNumber : struct, INumber<TNumber>;
    }

    public interface IUnaryNumberAction<in T1, in T2, in T3, in T4, in T5> : IComponentUnaryNumberAction<T1, T2, T3, T4, T5>
    {
        void Invoke<TNumber>(in TNumber numArg, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5) where TNumber : struct, INumber<TNumber>;
    }

    public interface IUnaryNumberAction<in T1, in T2, in T3, in T4, in T5, in T6> : IComponentUnaryNumberAction<T1, T2, T3, T4, T5, T6>
    {
        void Invoke<TNumber>(in TNumber numArg, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6) where TNumber : struct, INumber<TNumber>;
    }

    public interface IUnaryNumberAction<in T1, in T2, in T3, in T4, in T5, in T6, in T7> : IComponentUnaryNumberAction<T1, T2, T3, T4, T5, T6, T7>
    {
        void Invoke<TNumber>(in TNumber numArg, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7) where TNumber : struct, INumber<TNumber>;
    }

    public interface IUnaryNumberAction<in T1, in T2, in T3, in T4, in T5, in T6, in T7, in T8> : IComponentUnaryNumberAction<T1, T2, T3, T4, T5, T6, T7, T8>
    {
        void Invoke<TNumber>(in TNumber numArg, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7, T8 arg8) where TNumber : struct, INumber<TNumber>;
    }

    public interface IBinaryNumberAction : IComponentBinaryNumberAction
    {
        void Invoke<TNumber>(in TNumber numArg1, in TNumber numArg2) where TNumber : struct, INumber<TNumber>;
    }

    public interface IBinaryNumberAction<in T1> : IComponentBinaryNumberAction<T1>
    {
        void Invoke<TNumber>(in TNumber numArg1, in TNumber numArg2, T1 arg) where TNumber : struct, INumber<TNumber>;
    }

    public interface IBinaryNumberAction<in T1, in T2> : IComponentBinaryNumberAction<T1, T2>
    {
        void Invoke<TNumber>(in TNumber numArg1, in TNumber numArg2, T1 arg1, T2 arg2) where TNumber : struct, INumber<TNumber>;
    }

    public interface IBinaryNumberAction<in T1, in T2, in T3> : IComponentBinaryNumberAction<T1, T2, T3>
    {
        void Invoke<TNumber>(in TNumber numArg1, in TNumber numArg2, T1 arg1, T2 arg2, T3 arg3) where TNumber : struct, INumber<TNumber>;
    }

    public interface IBinaryNumberAction<in T1, in T2, in T3, in T4> : IComponentBinaryNumberAction<T1, T2, T3, T4>
    {
        void Invoke<TNumber>(in TNumber numArg1, in TNumber numArg2, T1 arg1, T2 arg2, T3 arg3, T4 arg4) where TNumber : struct, INumber<TNumber>;
    }

    public interface IBinaryNumberAction<in T1, in T2, in T3, in T4, in T5> : IComponentBinaryNumberAction<T1, T2, T3, T4, T5>
    {
        void Invoke<TNumber>(in TNumber numArg1, in TNumber numArg2, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5) where TNumber : struct, INumber<TNumber>;
    }

    public interface IBinaryNumberAction<in T1, in T2, in T3, in T4, in T5, in T6> : IComponentBinaryNumberAction<T1, T2, T3, T4, T5, T6>
    {
        void Invoke<TNumber>(in TNumber numArg1, in TNumber numArg2, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6) where TNumber : struct, INumber<TNumber>;
    }

    public interface IBinaryNumberAction<in T1, in T2, in T3, in T4, in T5, in T6, in T7> : IComponentBinaryNumberAction<T1, T2, T3, T4, T5, T6, T7>
    {
        void Invoke<TNumber>(in TNumber numArg1, in TNumber numArg2, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7) where TNumber : struct, INumber<TNumber>;
    }

    public interface IBinaryNumberAction<in T1, in T2, in T3, in T4, in T5, in T6, in T7, in T8> : IComponentBinaryNumberAction<T1, T2, T3, T4, T5, T6, T7, T8>
    {
        void Invoke<TNumber>(in TNumber numArg1, in TNumber numArg2, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7, T8 arg8) where TNumber : struct, INumber<TNumber>;
    }

    public interface ITernaryNumberAction : IComponentTernaryNumberAction
    {
        void Invoke<TNumber>(in TNumber numArg1, in TNumber numArg2) where TNumber : struct, INumber<TNumber>;
    }

    public interface ITernaryNumberAction<in T1> : IComponentTernaryNumberAction<T1>
    {
        void Invoke<TNumber>(in TNumber numArg1, in TNumber numArg2, in TNumber numArg3, T1 arg) where TNumber : struct, INumber<TNumber>;
    }

    public interface ITernaryNumberAction<in T1, in T2> : IComponentTernaryNumberAction<T1, T2>
    {
        void Invoke<TNumber>(in TNumber numArg1, in TNumber numArg2, in TNumber numArg3, T1 arg1, T2 arg2) where TNumber : struct, INumber<TNumber>;
    }

    public interface ITernaryNumberAction<in T1, in T2, in T3> : IComponentTernaryNumberAction<T1, T2, T3>
    {
        void Invoke<TNumber>(in TNumber numArg1, in TNumber numArg2, in TNumber numArg3, T1 arg1, T2 arg2, T3 arg3) where TNumber : struct, INumber<TNumber>;
    }

    public interface ITernaryNumberAction<in T1, in T2, in T3, in T4> : IComponentTernaryNumberAction<T1, T2, T3, T4>
    {
        void Invoke<TNumber>(in TNumber numArg1, in TNumber numArg2, in TNumber numArg3, T1 arg1, T2 arg2, T3 arg3, T4 arg4) where TNumber : struct, INumber<TNumber>;
    }

    public interface ITernaryNumberAction<in T1, in T2, in T3, in T4, in T5> : IComponentTernaryNumberAction<T1, T2, T3, T4, T5>
    {
        void Invoke<TNumber>(in TNumber numArg1, in TNumber numArg2, in TNumber numArg3, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5) where TNumber : struct, INumber<TNumber>;
    }

    public interface ITernaryNumberAction<in T1, in T2, in T3, in T4, in T5, in T6> : IComponentTernaryNumberAction<T1, T2, T3, T4, T5, T6>
    {
        void Invoke<TNumber>(in TNumber numArg1, in TNumber numArg2, in TNumber numArg3, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6) where TNumber : struct, INumber<TNumber>;
    }

    public interface ITernaryNumberAction<in T1, in T2, in T3, in T4, in T5, in T6, in T7> : IComponentTernaryNumberAction<T1, T2, T3, T4, T5, T6, T7>
    {
        void Invoke<TNumber>(in TNumber numArg1, in TNumber numArg2, in TNumber numArg3, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7) where TNumber : struct, INumber<TNumber>;
    }

    public interface ITernaryNumberAction<in T1, in T2, in T3, in T4, in T5, in T6, in T7, in T8> : IComponentTernaryNumberAction<T1, T2, T3, T4, T5, T6, T7, T8>
    {
        void Invoke<TNumber>(in TNumber numArg1, in TNumber numArg2, in TNumber numArg3, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7, T8 arg8) where TNumber : struct, INumber<TNumber>;
    }

    public interface INumberOperation : IComponentNumberOperation
    {
        TNumber Invoke<TNumber>() where TNumber : struct, INumber<TNumber>;
    }

    public interface INumberOperation<in T1> : IComponentNumberOperation<T1>
    {
        TNumber Invoke<TNumber>(T1 arg) where TNumber : struct, INumber<TNumber>;
    }

    public interface INumberOperation<in T1, in T2> : IComponentNumberOperation<T1, T2>
    {
        TNumber Invoke<TNumber>(T1 arg1, T2 arg2) where TNumber : struct, INumber<TNumber>;
    }

    public interface INumberOperation<in T1, in T2, in T3> : IComponentNumberOperation<T1, T2, T3>
    {
        TNumber Invoke<TNumber>(T1 arg1, T2 arg2, T3 arg3) where TNumber : struct, INumber<TNumber>;
    }

    public interface INumberOperation<in T1, in T2, in T3, in T4> : IComponentNumberOperation<T1, T2, T3, T4>
    {
        TNumber Invoke<TNumber>(T1 arg1, T2 arg2, T3 arg3, T4 arg4) where TNumber : struct, INumber<TNumber>;
    }

    public interface INumberOperation<in T1, in T2, in T3, in T4, in T5> : IComponentNumberOperation<T1, T2, T3, T4, T5>
    {
        TNumber Invoke<TNumber>(T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5) where TNumber : struct, INumber<TNumber>;
    }

    public interface INumberOperation<in T1, in T2, in T3, in T4, in T5, in T6> : IComponentNumberOperation<T1, T2, T3, T4, T5, T6>
    {
        TNumber Invoke<TNumber>(T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6) where TNumber : struct, INumber<TNumber>;
    }

    public interface INumberOperation<in T1, in T2, in T3, in T4, in T5, in T6, in T7> : IComponentNumberOperation<T1, T2, T3, T4, T5, T6, T7>
    {
        TNumber Invoke<TNumber>(T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7) where TNumber : struct, INumber<TNumber>;
    }

    public interface INumberOperation<in T1, in T2, in T3, in T4, in T5, in T6, in T7, in T8> : IComponentNumberOperation<T1, T2, T3, T4, T5, T6, T7, T8>
    {
        TNumber Invoke<TNumber>(T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7, T8 arg8) where TNumber : struct, INumber<TNumber>;
    }

    public interface IUnaryNumberOperation : IComponentUnaryNumberOperation
    {
        TNumber Invoke<TNumber>(in TNumber numArg) where TNumber : struct, INumber<TNumber>;
    }

    public interface IUnaryNumberOperation<in T1> : IComponentUnaryNumberOperation<T1>
    {
        TNumber Invoke<TNumber>(in TNumber numArg, T1 arg) where TNumber : struct, INumber<TNumber>;
    }

    public interface IUnaryNumberOperation<in T1, in T2> : IComponentUnaryNumberOperation<T1, T2>
    {
        TNumber Invoke<TNumber>(in TNumber numArg, T1 arg1, T2 arg2) where TNumber : struct, INumber<TNumber>;
    }

    public interface IUnaryNumberOperation<in T1, in T2, in T3> : IComponentUnaryNumberOperation<T1, T2, T3>
    {
        TNumber Invoke<TNumber>(in TNumber numArg, T1 arg1, T2 arg2, T3 arg3) where TNumber : struct, INumber<TNumber>;
    }

    public interface IUnaryNumberOperation<in T1, in T2, in T3, in T4> : IComponentUnaryNumberOperation<T1, T2, T3, T4>
    {
        TNumber Invoke<TNumber>(in TNumber numArg, T1 arg1, T2 arg2, T3 arg3, T4 arg4) where TNumber : struct, INumber<TNumber>;
    }

    public interface IUnaryNumberOperation<in T1, in T2, in T3, in T4, in T5> : IComponentUnaryNumberOperation<T1, T2, T3, T4, T5>
    {
        TNumber Invoke<TNumber>(in TNumber numArg, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5) where TNumber : struct, INumber<TNumber>;
    }

    public interface IUnaryNumberOperation<in T1, in T2, in T3, in T4, in T5, in T6> : IComponentUnaryNumberOperation<T1, T2, T3, T4, T5, T6>
    {
        TNumber Invoke<TNumber>(in TNumber numArg, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6) where TNumber : struct, INumber<TNumber>;
    }

    public interface IUnaryNumberOperation<in T1, in T2, in T3, in T4, in T5, in T6, in T7> : IComponentUnaryNumberOperation<T1, T2, T3, T4, T5, T6, T7>
    {
        TNumber Invoke<TNumber>(in TNumber numArg, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7) where TNumber : struct, INumber<TNumber>;
    }

    public interface IUnaryNumberOperation<in T1, in T2, in T3, in T4, in T5, in T6, in T7, in T8> : IComponentUnaryNumberOperation<T1, T2, T3, T4, T5, T6, T7, T8>
    {
        TNumber Invoke<TNumber>(in TNumber numArg, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7, T8 arg8) where TNumber : struct, INumber<TNumber>;
    }

    public interface IBinaryNumberOperation : IComponentBinaryNumberOperation
    {
        TNumber Invoke<TNumber>(in TNumber numArg1, in TNumber numArg2) where TNumber : struct, INumber<TNumber>;
    }

    public interface IBinaryNumberOperation<in T1> : IComponentBinaryNumberOperation<T1>
    {
        TNumber Invoke<TNumber>(in TNumber numArg1, in TNumber numArg2, T1 arg) where TNumber : struct, INumber<TNumber>;
    }

    public interface IBinaryNumberOperation<in T1, in T2> : IComponentBinaryNumberOperation<T1, T2>
    {
        TNumber Invoke<TNumber>(in TNumber numArg1, in TNumber numArg2, T1 arg1, T2 arg2) where TNumber : struct, INumber<TNumber>;
    }

    public interface IBinaryNumberOperation<in T1, in T2, in T3> : IComponentBinaryNumberOperation<T1, T2, T3>
    {
        TNumber Invoke<TNumber>(in TNumber numArg1, in TNumber numArg2, T1 arg1, T2 arg2, T3 arg3) where TNumber : struct, INumber<TNumber>;
    }

    public interface IBinaryNumberOperation<in T1, in T2, in T3, in T4> : IComponentBinaryNumberOperation<T1, T2, T3, T4>
    {
        TNumber Invoke<TNumber>(in TNumber numArg1, in TNumber numArg2, T1 arg1, T2 arg2, T3 arg3, T4 arg4) where TNumber : struct, INumber<TNumber>;
    }

    public interface IBinaryNumberOperation<in T1, in T2, in T3, in T4, in T5> : IComponentBinaryNumberOperation<T1, T2, T3, T4, T5>
    {
        TNumber Invoke<TNumber>(in TNumber numArg1, in TNumber numArg2, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5) where TNumber : struct, INumber<TNumber>;
    }

    public interface IBinaryNumberOperation<in T1, in T2, in T3, in T4, in T5, in T6> : IComponentBinaryNumberOperation<T1, T2, T3, T4, T5, T6>
    {
        TNumber Invoke<TNumber>(in TNumber numArg1, in TNumber numArg2, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6) where TNumber : struct, INumber<TNumber>;
    }

    public interface IBinaryNumberOperation<in T1, in T2, in T3, in T4, in T5, in T6, in T7> : IComponentBinaryNumberOperation<T1, T2, T3, T4, T5, T6, T7>
    {
        TNumber Invoke<TNumber>(in TNumber numArg1, in TNumber numArg2, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7) where TNumber : struct, INumber<TNumber>;
    }

    public interface IBinaryNumberOperation<in T1, in T2, in T3, in T4, in T5, in T6, in T7, in T8> : IComponentBinaryNumberOperation<T1, T2, T3, T4, T5, T6, T7, T8>
    {
        TNumber Invoke<TNumber>(in TNumber numArg1, in TNumber numArg2, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7, T8 arg8) where TNumber : struct, INumber<TNumber>;
    }

    public interface ITernaryNumberOperation : IComponentTernaryNumberOperation
    {
        TNumber Invoke<TNumber>(in TNumber numArg1, in TNumber numArg2, in TNumber numArg3) where TNumber : struct, INumber<TNumber>;
    }

    public interface ITernaryNumberOperation<in T1> : IComponentTernaryNumberOperation<T1>
    {
        TNumber Invoke<TNumber>(in TNumber numArg1, in TNumber numArg2, in TNumber numArg3, T1 arg) where TNumber : struct, INumber<TNumber>;
    }

    public interface ITernaryNumberOperation<in T1, in T2> : IComponentTernaryNumberOperation<T1, T2>
    {
        TNumber Invoke<TNumber>(in TNumber numArg1, in TNumber numArg2, in TNumber numArg3, T1 arg1, T2 arg2) where TNumber : struct, INumber<TNumber>;
    }

    public interface ITernaryNumberOperation<in T1, in T2, in T3> : IComponentTernaryNumberOperation<T1, T2, T3>
    {
        TNumber Invoke<TNumber>(in TNumber numArg1, in TNumber numArg2, in TNumber numArg3, T1 arg1, T2 arg2, T3 arg3) where TNumber : struct, INumber<TNumber>;
    }

    public interface ITernaryNumberOperation<in T1, in T2, in T3, in T4> : IComponentTernaryNumberOperation<T1, T2, T3, T4>
    {
        TNumber Invoke<TNumber>(in TNumber numArg1, in TNumber numArg2, in TNumber numArg3, T1 arg1, T2 arg2, T3 arg3, T4 arg4) where TNumber : struct, INumber<TNumber>;
    }

    public interface ITernaryNumberOperation<in T1, in T2, in T3, in T4, in T5> : IComponentTernaryNumberOperation<T1, T2, T3, T4, T5>
    {
        TNumber Invoke<TNumber>(in TNumber numArg1, in TNumber numArg2, in TNumber numArg3, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5) where TNumber : struct, INumber<TNumber>;
    }

    public interface ITernaryNumberOperation<in T1, in T2, in T3, in T4, in T5, in T6> : IComponentTernaryNumberOperation<T1, T2, T3, T4, T5, T6>
    {
        TNumber Invoke<TNumber>(in TNumber numArg1, in TNumber numArg2, in TNumber numArg3, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6) where TNumber : struct, INumber<TNumber>;
    }

    public interface ITernaryNumberOperation<in T1, in T2, in T3, in T4, in T5, in T6, in T7> : IComponentTernaryNumberOperation<T1, T2, T3, T4, T5, T6, T7>
    {
        TNumber Invoke<TNumber>(in TNumber numArg1, in TNumber numArg2, in TNumber numArg3, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7) where TNumber : struct, INumber<TNumber>;
    }

    public interface ITernaryNumberOperation<in T1, in T2, in T3, in T4, in T5, in T6, in T7, in T8> : IComponentTernaryNumberOperation<T1, T2, T3, T4, T5, T6, T7, T8>
    {
        TNumber Invoke<TNumber>(in TNumber numArg1, in TNumber numArg2, in TNumber numArg3, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7, T8 arg8) where TNumber : struct, INumber<TNumber>;
    }

    public interface IComponentNumberFunc<out TResult>
    {
        TResult Invoke<TNumber, TComponent>() where TNumber : struct, INumber<TNumber, TComponent> where TComponent : struct, IEquatable<TComponent>, IComparable<TComponent>;
    }

    public interface IComponentNumberFunc<in T1, out TResult>
    {
        TResult Invoke<TNumber, TComponent>(T1 arg) where TNumber : struct, INumber<TNumber, TComponent> where TComponent : struct, IEquatable<TComponent>, IComparable<TComponent>;
    }

    public interface IComponentNumberFunc<in T1, in T2, out TResult>
    {
        TResult Invoke<TNumber, TComponent>(T1 arg1, T2 arg2) where TNumber : struct, INumber<TNumber, TComponent> where TComponent : struct, IEquatable<TComponent>, IComparable<TComponent>;
    }

    public interface IComponentNumberFunc<in T1, in T2, in T3, out TResult>
    {
        TResult Invoke<TNumber, TComponent>(T1 arg1, T2 arg2, T3 arg3) where TNumber : struct, INumber<TNumber, TComponent> where TComponent : struct, IEquatable<TComponent>, IComparable<TComponent>;
    }

    public interface IComponentNumberFunc<in T1, in T2, in T3, in T4, out TResult>
    {
        TResult Invoke<TNumber, TComponent>(T1 arg1, T2 arg2, T3 arg3, T4 arg4) where TNumber : struct, INumber<TNumber, TComponent> where TComponent : struct, IEquatable<TComponent>, IComparable<TComponent>;
    }

    public interface IComponentNumberFunc<in T1, in T2, in T3, in T4, in T5, out TResult>
    {
        TResult Invoke<TNumber, TComponent>(T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5) where TNumber : struct, INumber<TNumber, TComponent> where TComponent : struct, IEquatable<TComponent>, IComparable<TComponent>;
    }

    public interface IComponentNumberFunc<in T1, in T2, in T3, in T4, in T5, in T6, out TResult>
    {
        TResult Invoke<TNumber, TComponent>(T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6) where TNumber : struct, INumber<TNumber, TComponent> where TComponent : struct, IEquatable<TComponent>, IComparable<TComponent>;
    }

    public interface IComponentNumberFunc<in T1, in T2, in T3, in T4, in T5, in T6, in T7, out TResult>
    {
        TResult Invoke<TNumber, TComponent>(T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7) where TNumber : struct, INumber<TNumber, TComponent> where TComponent : struct, IEquatable<TComponent>, IComparable<TComponent>;
    }

    public interface IComponentNumberFunc<in T1, in T2, in T3, in T4, in T5, in T6, in T7, in T8, out TResult>
    {
        TResult Invoke<TNumber, TComponent>(T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7, T8 arg8) where TNumber : struct, INumber<TNumber, TComponent> where TComponent : struct, IEquatable<TComponent>, IComparable<TComponent>;
    }

    public interface IComponentUnaryNumberFunc<out TResult>
    {
        TResult Invoke<TNumber, TComponent>(in TNumber numArg) where TNumber : struct, INumber<TNumber, TComponent> where TComponent : struct, IEquatable<TComponent>, IComparable<TComponent>;
    }

    public interface IComponentUnaryNumberFunc<in T1, out TResult>
    {
        TResult Invoke<TNumber, TComponent>(in TNumber numArg, T1 arg) where TNumber : struct, INumber<TNumber, TComponent> where TComponent : struct, IEquatable<TComponent>, IComparable<TComponent>;
    }

    public interface IComponentUnaryNumberFunc<in T1, in T2, out TResult>
    {
        TResult Invoke<TNumber, TComponent>(in TNumber numArg, T1 arg1, T2 arg2) where TNumber : struct, INumber<TNumber, TComponent> where TComponent : struct, IEquatable<TComponent>, IComparable<TComponent>;
    }

    public interface IComponentUnaryNumberFunc<in T1, in T2, in T3, out TResult>
    {
        TResult Invoke<TNumber, TComponent>(in TNumber numArg, T1 arg1, T2 arg2, T3 arg3) where TNumber : struct, INumber<TNumber, TComponent> where TComponent : struct, IEquatable<TComponent>, IComparable<TComponent>;
    }

    public interface IComponentUnaryNumberFunc<in T1, in T2, in T3, in T4, out TResult>
    {
        TResult Invoke<TNumber, TComponent>(in TNumber numArg, T1 arg1, T2 arg2, T3 arg3, T4 arg4) where TNumber : struct, INumber<TNumber, TComponent> where TComponent : struct, IEquatable<TComponent>, IComparable<TComponent>;
    }

    public interface IComponentUnaryNumberFunc<in T1, in T2, in T3, in T4, in T5, out TResult>
    {
        TResult Invoke<TNumber, TComponent>(in TNumber numArg, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5) where TNumber : struct, INumber<TNumber, TComponent> where TComponent : struct, IEquatable<TComponent>, IComparable<TComponent>;
    }

    public interface IComponentUnaryNumberFunc<in T1, in T2, in T3, in T4, in T5, in T6, out TResult>
    {
        TResult Invoke<TNumber, TComponent>(in TNumber numArg, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6) where TNumber : struct, INumber<TNumber, TComponent> where TComponent : struct, IEquatable<TComponent>, IComparable<TComponent>;
    }

    public interface IComponentUnaryNumberFunc<in T1, in T2, in T3, in T4, in T5, in T6, in T7, out TResult>
    {
        TResult Invoke<TNumber, TComponent>(in TNumber numArg, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7) where TNumber : struct, INumber<TNumber, TComponent> where TComponent : struct, IEquatable<TComponent>, IComparable<TComponent>;
    }

    public interface IComponentUnaryNumberFunc<in T1, in T2, in T3, in T4, in T5, in T6, in T7, in T8, out TResult>
    {
        TResult Invoke<TNumber, TComponent>(in TNumber numArg, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7, T8 arg8) where TNumber : struct, INumber<TNumber, TComponent> where TComponent : struct, IEquatable<TComponent>, IComparable<TComponent>;
    }

    public interface IComponentBinaryNumberFunc<out TResult>
    {
        TResult Invoke<TNumber, TComponent>(in TNumber numArg1, in TNumber numArg2) where TNumber : struct, INumber<TNumber, TComponent> where TComponent : struct, IEquatable<TComponent>, IComparable<TComponent>;
    }

    public interface IComponentBinaryNumberFunc<in T1, out TResult>
    {
        TResult Invoke<TNumber, TComponent>(in TNumber numArg1, in TNumber numArg2, T1 arg) where TNumber : struct, INumber<TNumber, TComponent> where TComponent : struct, IEquatable<TComponent>, IComparable<TComponent>;
    }

    public interface IComponentBinaryNumberFunc<in T1, in T2, out TResult>
    {
        TResult Invoke<TNumber, TComponent>(in TNumber numArg1, in TNumber numArg2, T1 arg1, T2 arg2) where TNumber : struct, INumber<TNumber, TComponent> where TComponent : struct, IEquatable<TComponent>, IComparable<TComponent>;
    }

    public interface IComponentBinaryNumberFunc<in T1, in T2, in T3, out TResult>
    {
        TResult Invoke<TNumber, TComponent>(in TNumber numArg1, in TNumber numArg2, T1 arg1, T2 arg2, T3 arg3) where TNumber : struct, INumber<TNumber, TComponent> where TComponent : struct, IEquatable<TComponent>, IComparable<TComponent>;
    }

    public interface IComponentBinaryNumberFunc<in T1, in T2, in T3, in T4, out TResult>
    {
        TResult Invoke<TNumber, TComponent>(in TNumber numArg1, in TNumber numArg2, T1 arg1, T2 arg2, T3 arg3, T4 arg4) where TNumber : struct, INumber<TNumber, TComponent> where TComponent : struct, IEquatable<TComponent>, IComparable<TComponent>;
    }

    public interface IComponentBinaryNumberFunc<in T1, in T2, in T3, in T4, in T5, out TResult>
    {
        TResult Invoke<TNumber, TComponent>(in TNumber numArg1, in TNumber numArg2, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5) where TNumber : struct, INumber<TNumber, TComponent> where TComponent : struct, IEquatable<TComponent>, IComparable<TComponent>;
    }

    public interface IComponentBinaryNumberFunc<in T1, in T2, in T3, in T4, in T5, in T6, out TResult>
    {
        TResult Invoke<TNumber, TComponent>(in TNumber numArg1, in TNumber numArg2, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6) where TNumber : struct, INumber<TNumber, TComponent> where TComponent : struct, IEquatable<TComponent>, IComparable<TComponent>;
    }

    public interface IComponentBinaryNumberFunc<in T1, in T2, in T3, in T4, in T5, in T6, in T7, out TResult>
    {
        TResult Invoke<TNumber, TComponent>(in TNumber numArg1, in TNumber numArg2, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7) where TNumber : struct, INumber<TNumber, TComponent> where TComponent : struct, IEquatable<TComponent>, IComparable<TComponent>;
    }

    public interface IComponentBinaryNumberFunc<in T1, in T2, in T3, in T4, in T5, in T6, in T7, in T8, out TResult>
    {
        TResult Invoke<TNumber, TComponent>(in TNumber numArg1, in TNumber numArg2, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7, T8 arg8) where TNumber : struct, INumber<TNumber, TComponent> where TComponent : struct, IEquatable<TComponent>, IComparable<TComponent>;
    }

    public interface IComponentTernaryNumberFunc<out TResult>
    {
        TResult Invoke<TNumber, TComponent>(in TNumber numArg1, in TNumber numArg2, in TNumber numArg3) where TNumber : struct, INumber<TNumber, TComponent> where TComponent : struct, IEquatable<TComponent>, IComparable<TComponent>;
    }

    public interface IComponentTernaryNumberFunc<in T1, out TResult>
    {
        TResult Invoke<TNumber, TComponent>(in TNumber numArg1, in TNumber numArg2, in TNumber numArg3, T1 arg) where TNumber : struct, INumber<TNumber, TComponent> where TComponent : struct, IEquatable<TComponent>, IComparable<TComponent>;
    }

    public interface IComponentTernaryNumberFunc<in T1, in T2, out TResult>
    {
        TResult Invoke<TNumber, TComponent>(in TNumber numArg1, in TNumber numArg2, in TNumber numArg3, T1 arg1, T2 arg2) where TNumber : struct, INumber<TNumber, TComponent> where TComponent : struct, IEquatable<TComponent>, IComparable<TComponent>;
    }

    public interface IComponentTernaryNumberFunc<in T1, in T2, in T3, out TResult>
    {
        TResult Invoke<TNumber, TComponent>(in TNumber numArg1, in TNumber numArg2, in TNumber numArg3, T1 arg1, T2 arg2, T3 arg3) where TNumber : struct, INumber<TNumber, TComponent> where TComponent : struct, IEquatable<TComponent>, IComparable<TComponent>;
    }

    public interface IComponentTernaryNumberFunc<in T1, in T2, in T3, in T4, out TResult>
    {
        TResult Invoke<TNumber, TComponent>(in TNumber numArg1, in TNumber numArg2, in TNumber numArg3, T1 arg1, T2 arg2, T3 arg3, T4 arg4) where TNumber : struct, INumber<TNumber, TComponent> where TComponent : struct, IEquatable<TComponent>, IComparable<TComponent>;
    }

    public interface IComponentTernaryNumberFunc<in T1, in T2, in T3, in T4, in T5, out TResult>
    {
        TResult Invoke<TNumber, TComponent>(in TNumber numArg1, in TNumber numArg2, in TNumber numArg3, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5) where TNumber : struct, INumber<TNumber, TComponent> where TComponent : struct, IEquatable<TComponent>, IComparable<TComponent>;
    }

    public interface IComponentTernaryNumberFunc<in T1, in T2, in T3, in T4, in T5, in T6, out TResult>
    {
        TResult Invoke<TNumber, TComponent>(in TNumber numArg1, in TNumber numArg2, in TNumber numArg3, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6) where TNumber : struct, INumber<TNumber, TComponent> where TComponent : struct, IEquatable<TComponent>, IComparable<TComponent>;
    }

    public interface IComponentTernaryNumberFunc<in T1, in T2, in T3, in T4, in T5, in T6, in T7, out TResult>
    {
        TResult Invoke<TNumber, TComponent>(in TNumber numArg1, in TNumber numArg2, in TNumber numArg3, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7) where TNumber : struct, INumber<TNumber, TComponent> where TComponent : struct, IEquatable<TComponent>, IComparable<TComponent>;
    }

    public interface IComponentTernaryNumberFunc<in T1, in T2, in T3, in T4, in T5, in T6, in T7, in T8, out TResult>
    {
        TResult Invoke<TNumber, TComponent>(in TNumber numArg1, in TNumber numArg2, in TNumber numArg3, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7, T8 arg8) where TNumber : struct, INumber<TNumber, TComponent> where TComponent : struct, IEquatable<TComponent>, IComparable<TComponent>;
    }

    public interface IComponentNumberAction
    {
        void Invoke<TNumber, TComponent>() where TNumber : struct, INumber<TNumber, TComponent> where TComponent : struct, IEquatable<TComponent>, IComparable<TComponent>;
    }

    public interface IComponentNumberAction<in T1>
    {
        void Invoke<TNumber, TComponent>(T1 arg) where TNumber : struct, INumber<TNumber, TComponent> where TComponent : struct, IEquatable<TComponent>, IComparable<TComponent>;
    }

    public interface IComponentNumberAction<in T1, in T2>
    {
        void Invoke<TNumber, TComponent>(T1 arg1, T2 arg2) where TNumber : struct, INumber<TNumber, TComponent> where TComponent : struct, IEquatable<TComponent>, IComparable<TComponent>;
    }

    public interface IComponentNumberAction<in T1, in T2, in T3>
    {
        void Invoke<TNumber, TComponent>(T1 arg1, T2 arg2, T3 arg3) where TNumber : struct, INumber<TNumber, TComponent> where TComponent : struct, IEquatable<TComponent>, IComparable<TComponent>;
    }

    public interface IComponentNumberAction<in T1, in T2, in T3, in T4>
    {
        void Invoke<TNumber, TComponent>(T1 arg1, T2 arg2, T3 arg3, T4 arg4) where TNumber : struct, INumber<TNumber, TComponent> where TComponent : struct, IEquatable<TComponent>, IComparable<TComponent>;
    }

    public interface IComponentNumberAction<in T1, in T2, in T3, in T4, in T5>
    {
        void Invoke<TNumber, TComponent>(T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5) where TNumber : struct, INumber<TNumber, TComponent> where TComponent : struct, IEquatable<TComponent>, IComparable<TComponent>;
    }

    public interface IComponentNumberAction<in T1, in T2, in T3, in T4, in T5, in T6>
    {
        void Invoke<TNumber, TComponent>(T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6) where TNumber : struct, INumber<TNumber, TComponent> where TComponent : struct, IEquatable<TComponent>, IComparable<TComponent>;
    }

    public interface IComponentNumberAction<in T1, in T2, in T3, in T4, in T5, in T6, in T7>
    {
        void Invoke<TNumber, TComponent>(T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7) where TNumber : struct, INumber<TNumber, TComponent> where TComponent : struct, IEquatable<TComponent>, IComparable<TComponent>;
    }

    public interface IComponentNumberAction<in T1, in T2, in T3, in T4, in T5, in T6, in T7, in T8>
    {
        void Invoke<TNumber, TComponent>(T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7, T8 arg8) where TNumber : struct, INumber<TNumber, TComponent> where TComponent : struct, IEquatable<TComponent>, IComparable<TComponent>;
    }

    public interface IComponentUnaryNumberAction
    {
        void Invoke<TNumber, TComponent>(in TNumber numArg) where TNumber : struct, INumber<TNumber, TComponent> where TComponent : struct, IEquatable<TComponent>, IComparable<TComponent>;
    }

    public interface IComponentUnaryNumberAction<in T1>
    {
        void Invoke<TNumber, TComponent>(in TNumber numArg, T1 arg) where TNumber : struct, INumber<TNumber, TComponent> where TComponent : struct, IEquatable<TComponent>, IComparable<TComponent>;
    }

    public interface IComponentUnaryNumberAction<in T1, in T2>
    {
        void Invoke<TNumber, TComponent>(in TNumber numArg, T1 arg1, T2 arg2) where TNumber : struct, INumber<TNumber, TComponent> where TComponent : struct, IEquatable<TComponent>, IComparable<TComponent>;
    }

    public interface IComponentUnaryNumberAction<in T1, in T2, in T3>
    {
        void Invoke<TNumber, TComponent>(in TNumber numArg, T1 arg1, T2 arg2, T3 arg3) where TNumber : struct, INumber<TNumber, TComponent> where TComponent : struct, IEquatable<TComponent>, IComparable<TComponent>;
    }

    public interface IComponentUnaryNumberAction<in T1, in T2, in T3, in T4>
    {
        void Invoke<TNumber, TComponent>(in TNumber numArg, T1 arg1, T2 arg2, T3 arg3, T4 arg4) where TNumber : struct, INumber<TNumber, TComponent> where TComponent : struct, IEquatable<TComponent>, IComparable<TComponent>;
    }

    public interface IComponentUnaryNumberAction<in T1, in T2, in T3, in T4, in T5>
    {
        void Invoke<TNumber, TComponent>(in TNumber numArg, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5) where TNumber : struct, INumber<TNumber, TComponent> where TComponent : struct, IEquatable<TComponent>, IComparable<TComponent>;
    }

    public interface IComponentUnaryNumberAction<in T1, in T2, in T3, in T4, in T5, in T6>
    {
        void Invoke<TNumber, TComponent>(in TNumber numArg, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6) where TNumber : struct, INumber<TNumber, TComponent> where TComponent : struct, IEquatable<TComponent>, IComparable<TComponent>;
    }

    public interface IComponentUnaryNumberAction<in T1, in T2, in T3, in T4, in T5, in T6, in T7>
    {
        void Invoke<TNumber, TComponent>(in TNumber numArg, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7) where TNumber : struct, INumber<TNumber, TComponent> where TComponent : struct, IEquatable<TComponent>, IComparable<TComponent>;
    }

    public interface IComponentUnaryNumberAction<in T1, in T2, in T3, in T4, in T5, in T6, in T7, in T8>
    {
        void Invoke<TNumber, TComponent>(in TNumber numArg, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7, T8 arg8) where TNumber : struct, INumber<TNumber, TComponent> where TComponent : struct, IEquatable<TComponent>, IComparable<TComponent>;
    }

    public interface IComponentBinaryNumberAction
    {
        void Invoke<TNumber, TComponent>(in TNumber numArg1, in TNumber numArg2) where TNumber : struct, INumber<TNumber, TComponent> where TComponent : struct, IEquatable<TComponent>, IComparable<TComponent>;
    }

    public interface IComponentBinaryNumberAction<in T1>
    {
        void Invoke<TNumber, TComponent>(in TNumber numArg1, in TNumber numArg2, T1 arg) where TNumber : struct, INumber<TNumber, TComponent> where TComponent : struct, IEquatable<TComponent>, IComparable<TComponent>;
    }

    public interface IComponentBinaryNumberAction<in T1, in T2>
    {
        void Invoke<TNumber, TComponent>(in TNumber numArg1, in TNumber numArg2, T1 arg1, T2 arg2) where TNumber : struct, INumber<TNumber, TComponent> where TComponent : struct, IEquatable<TComponent>, IComparable<TComponent>;
    }

    public interface IComponentBinaryNumberAction<in T1, in T2, in T3>
    {
        void Invoke<TNumber, TComponent>(in TNumber numArg1, in TNumber numArg2, T1 arg1, T2 arg2, T3 arg3) where TNumber : struct, INumber<TNumber, TComponent> where TComponent : struct, IEquatable<TComponent>, IComparable<TComponent>;
    }

    public interface IComponentBinaryNumberAction<in T1, in T2, in T3, in T4>
    {
        void Invoke<TNumber, TComponent>(in TNumber numArg1, in TNumber numArg2, T1 arg1, T2 arg2, T3 arg3, T4 arg4) where TNumber : struct, INumber<TNumber, TComponent> where TComponent : struct, IEquatable<TComponent>, IComparable<TComponent>;
    }

    public interface IComponentBinaryNumberAction<in T1, in T2, in T3, in T4, in T5>
    {
        void Invoke<TNumber, TComponent>(in TNumber numArg1, in TNumber numArg2, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5) where TNumber : struct, INumber<TNumber, TComponent> where TComponent : struct, IEquatable<TComponent>, IComparable<TComponent>;
    }

    public interface IComponentBinaryNumberAction<in T1, in T2, in T3, in T4, in T5, in T6>
    {
        void Invoke<TNumber, TComponent>(in TNumber numArg1, in TNumber numArg2, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6) where TNumber : struct, INumber<TNumber, TComponent> where TComponent : struct, IEquatable<TComponent>, IComparable<TComponent>;
    }

    public interface IComponentBinaryNumberAction<in T1, in T2, in T3, in T4, in T5, in T6, in T7>
    {
        void Invoke<TNumber, TComponent>(in TNumber numArg1, in TNumber numArg2, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7) where TNumber : struct, INumber<TNumber, TComponent> where TComponent : struct, IEquatable<TComponent>, IComparable<TComponent>;
    }

    public interface IComponentBinaryNumberAction<in T1, in T2, in T3, in T4, in T5, in T6, in T7, in T8>
    {
        void Invoke<TNumber, TComponent>(in TNumber numArg1, in TNumber numArg2, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7, T8 arg8) where TNumber : struct, INumber<TNumber, TComponent> where TComponent : struct, IEquatable<TComponent>, IComparable<TComponent>;
    }

    public interface IComponentTernaryNumberAction
    {
        void Invoke<TNumber, TComponent>(in TNumber numArg1, in TNumber numArg2) where TNumber : struct, INumber<TNumber, TComponent> where TComponent : struct, IEquatable<TComponent>, IComparable<TComponent>;
    }

    public interface IComponentTernaryNumberAction<in T1>
    {
        void Invoke<TNumber, TComponent>(in TNumber numArg1, in TNumber numArg2, in TNumber numArg3, T1 arg) where TNumber : struct, INumber<TNumber, TComponent> where TComponent : struct, IEquatable<TComponent>, IComparable<TComponent>;
    }

    public interface IComponentTernaryNumberAction<in T1, in T2>
    {
        void Invoke<TNumber, TComponent>(in TNumber numArg1, in TNumber numArg2, in TNumber numArg3, T1 arg1, T2 arg2) where TNumber : struct, INumber<TNumber, TComponent> where TComponent : struct, IEquatable<TComponent>, IComparable<TComponent>;
    }

    public interface IComponentTernaryNumberAction<in T1, in T2, in T3>
    {
        void Invoke<TNumber, TComponent>(in TNumber numArg1, in TNumber numArg2, in TNumber numArg3, T1 arg1, T2 arg2, T3 arg3) where TNumber : struct, INumber<TNumber, TComponent> where TComponent : struct, IEquatable<TComponent>, IComparable<TComponent>;
    }

    public interface IComponentTernaryNumberAction<in T1, in T2, in T3, in T4>
    {
        void Invoke<TNumber, TComponent>(in TNumber numArg1, in TNumber numArg2, in TNumber numArg3, T1 arg1, T2 arg2, T3 arg3, T4 arg4) where TNumber : struct, INumber<TNumber, TComponent> where TComponent : struct, IEquatable<TComponent>, IComparable<TComponent>;
    }

    public interface IComponentTernaryNumberAction<in T1, in T2, in T3, in T4, in T5>
    {
        void Invoke<TNumber, TComponent>(in TNumber numArg1, in TNumber numArg2, in TNumber numArg3, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5) where TNumber : struct, INumber<TNumber, TComponent> where TComponent : struct, IEquatable<TComponent>, IComparable<TComponent>;
    }

    public interface IComponentTernaryNumberAction<in T1, in T2, in T3, in T4, in T5, in T6>
    {
        void Invoke<TNumber, TComponent>(in TNumber numArg1, in TNumber numArg2, in TNumber numArg3, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6) where TNumber : struct, INumber<TNumber, TComponent> where TComponent : struct, IEquatable<TComponent>, IComparable<TComponent>;
    }

    public interface IComponentTernaryNumberAction<in T1, in T2, in T3, in T4, in T5, in T6, in T7>
    {
        void Invoke<TNumber, TComponent>(in TNumber numArg1, in TNumber numArg2, in TNumber numArg3, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7) where TNumber : struct, INumber<TNumber, TComponent> where TComponent : struct, IEquatable<TComponent>, IComparable<TComponent>;
    }

    public interface IComponentTernaryNumberAction<in T1, in T2, in T3, in T4, in T5, in T6, in T7, in T8>
    {
        void Invoke<TNumber, TComponent>(in TNumber numArg1, in TNumber numArg2, in TNumber numArg3, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7, T8 arg8) where TNumber : struct, INumber<TNumber, TComponent> where TComponent : struct, IEquatable<TComponent>, IComparable<TComponent>;
    }

    public interface IComponentNumberOperation
    {
        TNumber Invoke<TNumber, TComponent>() where TNumber : struct, INumber<TNumber, TComponent> where TComponent : struct, IEquatable<TComponent>, IComparable<TComponent>;
    }

    public interface IComponentNumberOperation<in T1>
    {
        TNumber Invoke<TNumber, TComponent>(T1 arg) where TNumber : struct, INumber<TNumber, TComponent> where TComponent : struct, IEquatable<TComponent>, IComparable<TComponent>;
    }

    public interface IComponentNumberOperation<in T1, in T2>
    {
        TNumber Invoke<TNumber, TComponent>(T1 arg1, T2 arg2) where TNumber : struct, INumber<TNumber, TComponent> where TComponent : struct, IEquatable<TComponent>, IComparable<TComponent>;
    }

    public interface IComponentNumberOperation<in T1, in T2, in T3>
    {
        TNumber Invoke<TNumber, TComponent>(T1 arg1, T2 arg2, T3 arg3) where TNumber : struct, INumber<TNumber, TComponent> where TComponent : struct, IEquatable<TComponent>, IComparable<TComponent>;
    }

    public interface IComponentNumberOperation<in T1, in T2, in T3, in T4>
    {
        TNumber Invoke<TNumber, TComponent>(T1 arg1, T2 arg2, T3 arg3, T4 arg4) where TNumber : struct, INumber<TNumber, TComponent> where TComponent : struct, IEquatable<TComponent>, IComparable<TComponent>;
    }

    public interface IComponentNumberOperation<in T1, in T2, in T3, in T4, in T5>
    {
        TNumber Invoke<TNumber, TComponent>(T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5) where TNumber : struct, INumber<TNumber, TComponent> where TComponent : struct, IEquatable<TComponent>, IComparable<TComponent>;
    }

    public interface IComponentNumberOperation<in T1, in T2, in T3, in T4, in T5, in T6>
    {
        TNumber Invoke<TNumber, TComponent>(T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6) where TNumber : struct, INumber<TNumber, TComponent> where TComponent : struct, IEquatable<TComponent>, IComparable<TComponent>;
    }

    public interface IComponentNumberOperation<in T1, in T2, in T3, in T4, in T5, in T6, in T7>
    {
        TNumber Invoke<TNumber, TComponent>(T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7) where TNumber : struct, INumber<TNumber, TComponent> where TComponent : struct, IEquatable<TComponent>, IComparable<TComponent>;
    }

    public interface IComponentNumberOperation<in T1, in T2, in T3, in T4, in T5, in T6, in T7, in T8>
    {
        TNumber Invoke<TNumber, TComponent>(T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7, T8 arg8) where TNumber : struct, INumber<TNumber, TComponent> where TComponent : struct, IEquatable<TComponent>, IComparable<TComponent>;
    }

    public interface IComponentUnaryNumberOperation
    {
        TNumber Invoke<TNumber, TComponent>(in TNumber numArg) where TNumber : struct, INumber<TNumber, TComponent> where TComponent : struct, IEquatable<TComponent>, IComparable<TComponent>;
    }

    public interface IComponentUnaryNumberOperation<in T1>
    {
        TNumber Invoke<TNumber, TComponent>(in TNumber numArg, T1 arg) where TNumber : struct, INumber<TNumber, TComponent> where TComponent : struct, IEquatable<TComponent>, IComparable<TComponent>;
    }

    public interface IComponentUnaryNumberOperation<in T1, in T2>
    {
        TNumber Invoke<TNumber, TComponent>(in TNumber numArg, T1 arg1, T2 arg2) where TNumber : struct, INumber<TNumber, TComponent> where TComponent : struct, IEquatable<TComponent>, IComparable<TComponent>;
    }

    public interface IComponentUnaryNumberOperation<in T1, in T2, in T3>
    {
        TNumber Invoke<TNumber, TComponent>(in TNumber numArg, T1 arg1, T2 arg2, T3 arg3) where TNumber : struct, INumber<TNumber, TComponent> where TComponent : struct, IEquatable<TComponent>, IComparable<TComponent>;
    }

    public interface IComponentUnaryNumberOperation<in T1, in T2, in T3, in T4>
    {
        TNumber Invoke<TNumber, TComponent>(in TNumber numArg, T1 arg1, T2 arg2, T3 arg3, T4 arg4) where TNumber : struct, INumber<TNumber, TComponent> where TComponent : struct, IEquatable<TComponent>, IComparable<TComponent>;
    }

    public interface IComponentUnaryNumberOperation<in T1, in T2, in T3, in T4, in T5>
    {
        TNumber Invoke<TNumber, TComponent>(in TNumber numArg, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5) where TNumber : struct, INumber<TNumber, TComponent> where TComponent : struct, IEquatable<TComponent>, IComparable<TComponent>;
    }

    public interface IComponentUnaryNumberOperation<in T1, in T2, in T3, in T4, in T5, in T6>
    {
        TNumber Invoke<TNumber, TComponent>(in TNumber numArg, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6) where TNumber : struct, INumber<TNumber, TComponent> where TComponent : struct, IEquatable<TComponent>, IComparable<TComponent>;
    }

    public interface IComponentUnaryNumberOperation<in T1, in T2, in T3, in T4, in T5, in T6, in T7>
    {
        TNumber Invoke<TNumber, TComponent>(in TNumber numArg, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7) where TNumber : struct, INumber<TNumber, TComponent> where TComponent : struct, IEquatable<TComponent>, IComparable<TComponent>;
    }

    public interface IComponentUnaryNumberOperation<in T1, in T2, in T3, in T4, in T5, in T6, in T7, in T8>
    {
        TNumber Invoke<TNumber, TComponent>(in TNumber numArg, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7, T8 arg8) where TNumber : struct, INumber<TNumber, TComponent> where TComponent : struct, IEquatable<TComponent>, IComparable<TComponent>;
    }

    public interface IComponentBinaryNumberOperation
    {
        TNumber Invoke<TNumber, TComponent>(in TNumber numArg1, in TNumber numArg2) where TNumber : struct, INumber<TNumber, TComponent> where TComponent : struct, IEquatable<TComponent>, IComparable<TComponent>;
    }

    public interface IComponentBinaryNumberOperation<in T1>
    {
        TNumber Invoke<TNumber, TComponent>(in TNumber numArg1, in TNumber numArg2, T1 arg) where TNumber : struct, INumber<TNumber, TComponent> where TComponent : struct, IEquatable<TComponent>, IComparable<TComponent>;
    }

    public interface IComponentBinaryNumberOperation<in T1, in T2>
    {
        TNumber Invoke<TNumber, TComponent>(in TNumber numArg1, in TNumber numArg2, T1 arg1, T2 arg2) where TNumber : struct, INumber<TNumber, TComponent> where TComponent : struct, IEquatable<TComponent>, IComparable<TComponent>;
    }

    public interface IComponentBinaryNumberOperation<in T1, in T2, in T3>
    {
        TNumber Invoke<TNumber, TComponent>(in TNumber numArg1, in TNumber numArg2, T1 arg1, T2 arg2, T3 arg3) where TNumber : struct, INumber<TNumber, TComponent> where TComponent : struct, IEquatable<TComponent>, IComparable<TComponent>;
    }

    public interface IComponentBinaryNumberOperation<in T1, in T2, in T3, in T4>
    {
        TNumber Invoke<TNumber, TComponent>(in TNumber numArg1, in TNumber numArg2, T1 arg1, T2 arg2, T3 arg3, T4 arg4) where TNumber : struct, INumber<TNumber, TComponent> where TComponent : struct, IEquatable<TComponent>, IComparable<TComponent>;
    }

    public interface IComponentBinaryNumberOperation<in T1, in T2, in T3, in T4, in T5>
    {
        TNumber Invoke<TNumber, TComponent>(in TNumber numArg1, in TNumber numArg2, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5) where TNumber : struct, INumber<TNumber, TComponent> where TComponent : struct, IEquatable<TComponent>, IComparable<TComponent>;
    }

    public interface IComponentBinaryNumberOperation<in T1, in T2, in T3, in T4, in T5, in T6>
    {
        TNumber Invoke<TNumber, TComponent>(in TNumber numArg1, in TNumber numArg2, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6) where TNumber : struct, INumber<TNumber, TComponent> where TComponent : struct, IEquatable<TComponent>, IComparable<TComponent>;
    }

    public interface IComponentBinaryNumberOperation<in T1, in T2, in T3, in T4, in T5, in T6, in T7>
    {
        TNumber Invoke<TNumber, TComponent>(in TNumber numArg1, in TNumber numArg2, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7) where TNumber : struct, INumber<TNumber, TComponent> where TComponent : struct, IEquatable<TComponent>, IComparable<TComponent>;
    }

    public interface IComponentBinaryNumberOperation<in T1, in T2, in T3, in T4, in T5, in T6, in T7, in T8>
    {
        TNumber Invoke<TNumber, TComponent>(in TNumber numArg1, in TNumber numArg2, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7, T8 arg8) where TNumber : struct, INumber<TNumber, TComponent> where TComponent : struct, IEquatable<TComponent>, IComparable<TComponent>;
    }

    public interface IComponentTernaryNumberOperation
    {
        TNumber Invoke<TNumber, TComponent>(in TNumber numArg1, in TNumber numArg2, in TNumber numArg3) where TNumber : struct, INumber<TNumber, TComponent> where TComponent : struct, IEquatable<TComponent>, IComparable<TComponent>;
    }

    public interface IComponentTernaryNumberOperation<in T1>
    {
        TNumber Invoke<TNumber, TComponent>(in TNumber numArg1, in TNumber numArg2, in TNumber numArg3, T1 arg) where TNumber : struct, INumber<TNumber, TComponent> where TComponent : struct, IEquatable<TComponent>, IComparable<TComponent>;
    }

    public interface IComponentTernaryNumberOperation<in T1, in T2>
    {
        TNumber Invoke<TNumber, TComponent>(in TNumber numArg1, in TNumber numArg2, in TNumber numArg3, T1 arg1, T2 arg2) where TNumber : struct, INumber<TNumber, TComponent> where TComponent : struct, IEquatable<TComponent>, IComparable<TComponent>;
    }

    public interface IComponentTernaryNumberOperation<in T1, in T2, in T3>
    {
        TNumber Invoke<TNumber, TComponent>(in TNumber numArg1, in TNumber numArg2, in TNumber numArg3, T1 arg1, T2 arg2, T3 arg3) where TNumber : struct, INumber<TNumber, TComponent> where TComponent : struct, IEquatable<TComponent>, IComparable<TComponent>;
    }

    public interface IComponentTernaryNumberOperation<in T1, in T2, in T3, in T4>
    {
        TNumber Invoke<TNumber, TComponent>(in TNumber numArg1, in TNumber numArg2, in TNumber numArg3, T1 arg1, T2 arg2, T3 arg3, T4 arg4) where TNumber : struct, INumber<TNumber, TComponent> where TComponent : struct, IEquatable<TComponent>, IComparable<TComponent>;
    }

    public interface IComponentTernaryNumberOperation<in T1, in T2, in T3, in T4, in T5>
    {
        TNumber Invoke<TNumber, TComponent>(in TNumber numArg1, in TNumber numArg2, in TNumber numArg3, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5) where TNumber : struct, INumber<TNumber, TComponent> where TComponent : struct, IEquatable<TComponent>, IComparable<TComponent>;
    }

    public interface IComponentTernaryNumberOperation<in T1, in T2, in T3, in T4, in T5, in T6>
    {
        TNumber Invoke<TNumber, TComponent>(in TNumber numArg1, in TNumber numArg2, in TNumber numArg3, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6) where TNumber : struct, INumber<TNumber, TComponent> where TComponent : struct, IEquatable<TComponent>, IComparable<TComponent>;
    }

    public interface IComponentTernaryNumberOperation<in T1, in T2, in T3, in T4, in T5, in T6, in T7>
    {
        TNumber Invoke<TNumber, TComponent>(in TNumber numArg1, in TNumber numArg2, in TNumber numArg3, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7) where TNumber : struct, INumber<TNumber, TComponent> where TComponent : struct, IEquatable<TComponent>, IComparable<TComponent>;
    }

    public interface IComponentTernaryNumberOperation<in T1, in T2, in T3, in T4, in T5, in T6, in T7, in T8>
    {
        TNumber Invoke<TNumber, TComponent>(in TNumber numArg1, in TNumber numArg2, in TNumber numArg3, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7, T8 arg8) where TNumber : struct, INumber<TNumber, TComponent> where TComponent : struct, IEquatable<TComponent>, IComparable<TComponent>;
    }
}
