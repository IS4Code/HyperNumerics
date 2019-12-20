using System;

namespace IS4.HyperNumerics.Operations
{
    public interface INumberFunc<out TResult> : IPrimitiveNumberFunc<TResult>
    {
        TResult Invoke<TNumber>() where TNumber : struct, INumber<TNumber>;
    }

    public interface INumberFunc<in T1, out TResult> : IPrimitiveNumberFunc<T1, TResult>
    {
        TResult Invoke<TNumber>(T1 arg) where TNumber : struct, INumber<TNumber>;
    }

    public interface INumberFunc<in T1, in T2, out TResult> : IPrimitiveNumberFunc<T1, T2, TResult>
    {
        TResult Invoke<TNumber>(T1 arg1, T2 arg2) where TNumber : struct, INumber<TNumber>;
    }

    public interface INumberFunc<in T1, in T2, in T3, out TResult> : IPrimitiveNumberFunc<T1, T2, T3, TResult>
    {
        TResult Invoke<TNumber>(T1 arg1, T2 arg2, T3 arg3) where TNumber : struct, INumber<TNumber>;
    }

    public interface INumberFunc<in T1, in T2, in T3, in T4, out TResult> : IPrimitiveNumberFunc<T1, T2, T3, T4, TResult>
    {
        TResult Invoke<TNumber>(T1 arg1, T2 arg2, T3 arg3, T4 arg4) where TNumber : struct, INumber<TNumber>;
    }

    public interface INumberFunc<in T1, in T2, in T3, in T4, in T5, out TResult> : IPrimitiveNumberFunc<T1, T2, T3, T4, T5, TResult>
    {
        TResult Invoke<TNumber>(T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5) where TNumber : struct, INumber<TNumber>;
    }

    public interface INumberFunc<in T1, in T2, in T3, in T4, in T5, in T6, out TResult> : IPrimitiveNumberFunc<T1, T2, T3, T4, T5, T6, TResult>
    {
        TResult Invoke<TNumber>(T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6) where TNumber : struct, INumber<TNumber>;
    }

    public interface INumberFunc<in T1, in T2, in T3, in T4, in T5, in T6, in T7, out TResult> : IPrimitiveNumberFunc<T1, T2, T3, T4, T5, T6, T7, TResult>
    {
        TResult Invoke<TNumber>(T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7) where TNumber : struct, INumber<TNumber>;
    }

    public interface INumberFunc<in T1, in T2, in T3, in T4, in T5, in T6, in T7, in T8, out TResult> : IPrimitiveNumberFunc<T1, T2, T3, T4, T5, T6, T7, T8, TResult>
    {
        TResult Invoke<TNumber>(T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7, T8 arg8) where TNumber : struct, INumber<TNumber>;
    }

    public interface IUnaryNumberFunc<out TResult> : IPrimitiveUnaryNumberFunc<TResult>
    {
        TResult Invoke<TNumber>(in TNumber numArg) where TNumber : struct, INumber<TNumber>;
    }

    public interface IUnaryNumberFunc<in T1, out TResult> : IPrimitiveUnaryNumberFunc<T1, TResult>
    {
        TResult Invoke<TNumber>(in TNumber numArg, T1 arg) where TNumber : struct, INumber<TNumber>;
    }

    public interface IUnaryNumberFunc<in T1, in T2, out TResult> : IPrimitiveUnaryNumberFunc<T1, T2, TResult>
    {
        TResult Invoke<TNumber>(in TNumber numArg, T1 arg1, T2 arg2) where TNumber : struct, INumber<TNumber>;
    }

    public interface IUnaryNumberFunc<in T1, in T2, in T3, out TResult> : IPrimitiveUnaryNumberFunc<T1, T2, T3, TResult>
    {
        TResult Invoke<TNumber>(in TNumber numArg, T1 arg1, T2 arg2, T3 arg3) where TNumber : struct, INumber<TNumber>;
    }

    public interface IUnaryNumberFunc<in T1, in T2, in T3, in T4, out TResult> : IPrimitiveUnaryNumberFunc<T1, T2, T3, T4, TResult>
    {
        TResult Invoke<TNumber>(in TNumber numArg, T1 arg1, T2 arg2, T3 arg3, T4 arg4) where TNumber : struct, INumber<TNumber>;
    }

    public interface IUnaryNumberFunc<in T1, in T2, in T3, in T4, in T5, out TResult> : IPrimitiveUnaryNumberFunc<T1, T2, T3, T4, T5, TResult>
    {
        TResult Invoke<TNumber>(in TNumber numArg, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5) where TNumber : struct, INumber<TNumber>;
    }

    public interface IUnaryNumberFunc<in T1, in T2, in T3, in T4, in T5, in T6, out TResult> : IPrimitiveUnaryNumberFunc<T1, T2, T3, T4, T5, T6, TResult>
    {
        TResult Invoke<TNumber>(in TNumber numArg, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6) where TNumber : struct, INumber<TNumber>;
    }

    public interface IUnaryNumberFunc<in T1, in T2, in T3, in T4, in T5, in T6, in T7, out TResult> : IPrimitiveUnaryNumberFunc<T1, T2, T3, T4, T5, T6, T7, TResult>
    {
        TResult Invoke<TNumber>(in TNumber numArg, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7) where TNumber : struct, INumber<TNumber>;
    }

    public interface IUnaryNumberFunc<in T1, in T2, in T3, in T4, in T5, in T6, in T7, in T8, out TResult> : IPrimitiveUnaryNumberFunc<T1, T2, T3, T4, T5, T6, T7, T8, TResult>
    {
        TResult Invoke<TNumber>(in TNumber numArg, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7, T8 arg8) where TNumber : struct, INumber<TNumber>;
    }

    public interface IBinaryNumberFunc<out TResult> : IPrimitiveBinaryNumberFunc<TResult>
    {
        TResult Invoke<TNumber>(in TNumber numArg1, in TNumber numArg2) where TNumber : struct, INumber<TNumber>;
    }

    public interface IBinaryNumberFunc<in T1, out TResult> : IPrimitiveBinaryNumberFunc<T1, TResult>
    {
        TResult Invoke<TNumber>(in TNumber numArg1, in TNumber numArg2, T1 arg) where TNumber : struct, INumber<TNumber>;
    }

    public interface IBinaryNumberFunc<in T1, in T2, out TResult> : IPrimitiveBinaryNumberFunc<T1, T2, TResult>
    {
        TResult Invoke<TNumber>(in TNumber numArg1, in TNumber numArg2, T1 arg1, T2 arg2) where TNumber : struct, INumber<TNumber>;
    }

    public interface IBinaryNumberFunc<in T1, in T2, in T3, out TResult> : IPrimitiveBinaryNumberFunc<T1, T2, T3, TResult>
    {
        TResult Invoke<TNumber>(in TNumber numArg1, in TNumber numArg2, T1 arg1, T2 arg2, T3 arg3) where TNumber : struct, INumber<TNumber>;
    }

    public interface IBinaryNumberFunc<in T1, in T2, in T3, in T4, out TResult> : IPrimitiveBinaryNumberFunc<T1, T2, T3, T4, TResult>
    {
        TResult Invoke<TNumber>(in TNumber numArg1, in TNumber numArg2, T1 arg1, T2 arg2, T3 arg3, T4 arg4) where TNumber : struct, INumber<TNumber>;
    }

    public interface IBinaryNumberFunc<in T1, in T2, in T3, in T4, in T5, out TResult> : IPrimitiveBinaryNumberFunc<T1, T2, T3, T4, T5, TResult>
    {
        TResult Invoke<TNumber>(in TNumber numArg1, in TNumber numArg2, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5) where TNumber : struct, INumber<TNumber>;
    }

    public interface IBinaryNumberFunc<in T1, in T2, in T3, in T4, in T5, in T6, out TResult> : IPrimitiveBinaryNumberFunc<T1, T2, T3, T4, T5, T6, TResult>
    {
        TResult Invoke<TNumber>(in TNumber numArg1, in TNumber numArg2, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6) where TNumber : struct, INumber<TNumber>;
    }

    public interface IBinaryNumberFunc<in T1, in T2, in T3, in T4, in T5, in T6, in T7, out TResult> : IPrimitiveBinaryNumberFunc<T1, T2, T3, T4, T5, T6, T7, TResult>
    {
        TResult Invoke<TNumber>(in TNumber numArg1, in TNumber numArg2, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7) where TNumber : struct, INumber<TNumber>;
    }

    public interface IBinaryNumberFunc<in T1, in T2, in T3, in T4, in T5, in T6, in T7, in T8, out TResult> : IPrimitiveBinaryNumberFunc<T1, T2, T3, T4, T5, T6, T7, T8, TResult>
    {
        TResult Invoke<TNumber>(in TNumber numArg1, in TNumber numArg2, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7, T8 arg8) where TNumber : struct, INumber<TNumber>;
    }

    public interface ITernaryNumberFunc<out TResult> : IPrimitiveTernaryNumberFunc<TResult>
    {
        TResult Invoke<TNumber>(in TNumber numArg1, in TNumber numArg2, in TNumber numArg3) where TNumber : struct, INumber<TNumber>;
    }

    public interface ITernaryNumberFunc<in T1, out TResult> : IPrimitiveTernaryNumberFunc<T1, TResult>
    {
        TResult Invoke<TNumber>(in TNumber numArg1, in TNumber numArg2, in TNumber numArg3, T1 arg) where TNumber : struct, INumber<TNumber>;
    }

    public interface ITernaryNumberFunc<in T1, in T2, out TResult> : IPrimitiveTernaryNumberFunc<T1, T2, TResult>
    {
        TResult Invoke<TNumber>(in TNumber numArg1, in TNumber numArg2, in TNumber numArg3, T1 arg1, T2 arg2) where TNumber : struct, INumber<TNumber>;
    }

    public interface ITernaryNumberFunc<in T1, in T2, in T3, out TResult> : IPrimitiveTernaryNumberFunc<T1, T2, T3, TResult>
    {
        TResult Invoke<TNumber>(in TNumber numArg1, in TNumber numArg2, in TNumber numArg3, T1 arg1, T2 arg2, T3 arg3) where TNumber : struct, INumber<TNumber>;
    }

    public interface ITernaryNumberFunc<in T1, in T2, in T3, in T4, out TResult> : IPrimitiveTernaryNumberFunc<T1, T2, T3, T4, TResult>
    {
        TResult Invoke<TNumber>(in TNumber numArg1, in TNumber numArg2, in TNumber numArg3, T1 arg1, T2 arg2, T3 arg3, T4 arg4) where TNumber : struct, INumber<TNumber>;
    }

    public interface ITernaryNumberFunc<in T1, in T2, in T3, in T4, in T5, out TResult> : IPrimitiveTernaryNumberFunc<T1, T2, T3, T4, T5, TResult>
    {
        TResult Invoke<TNumber>(in TNumber numArg1, in TNumber numArg2, in TNumber numArg3, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5) where TNumber : struct, INumber<TNumber>;
    }

    public interface ITernaryNumberFunc<in T1, in T2, in T3, in T4, in T5, in T6, out TResult> : IPrimitiveTernaryNumberFunc<T1, T2, T3, T4, T5, T6, TResult>
    {
        TResult Invoke<TNumber>(in TNumber numArg1, in TNumber numArg2, in TNumber numArg3, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6) where TNumber : struct, INumber<TNumber>;
    }

    public interface ITernaryNumberFunc<in T1, in T2, in T3, in T4, in T5, in T6, in T7, out TResult> : IPrimitiveTernaryNumberFunc<T1, T2, T3, T4, T5, T6, T7, TResult>
    {
        TResult Invoke<TNumber>(in TNumber numArg1, in TNumber numArg2, in TNumber numArg3, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7) where TNumber : struct, INumber<TNumber>;
    }

    public interface ITernaryNumberFunc<in T1, in T2, in T3, in T4, in T5, in T6, in T7, in T8, out TResult> : IPrimitiveTernaryNumberFunc<T1, T2, T3, T4, T5, T6, T7, T8, TResult>
    {
        TResult Invoke<TNumber>(in TNumber numArg1, in TNumber numArg2, in TNumber numArg3, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7, T8 arg8) where TNumber : struct, INumber<TNumber>;
    }

    public interface INumberAction : IPrimitiveNumberAction
    {
        void Invoke<TNumber>() where TNumber : struct, INumber<TNumber>;
    }

    public interface INumberAction<in T1> : IPrimitiveNumberAction<T1>
    {
        void Invoke<TNumber>(T1 arg) where TNumber : struct, INumber<TNumber>;
    }

    public interface INumberAction<in T1, in T2> : IPrimitiveNumberAction<T1, T2>
    {
        void Invoke<TNumber>(T1 arg1, T2 arg2) where TNumber : struct, INumber<TNumber>;
    }

    public interface INumberAction<in T1, in T2, in T3> : IPrimitiveNumberAction<T1, T2, T3>
    {
        void Invoke<TNumber>(T1 arg1, T2 arg2, T3 arg3) where TNumber : struct, INumber<TNumber>;
    }

    public interface INumberAction<in T1, in T2, in T3, in T4> : IPrimitiveNumberAction<T1, T2, T3, T4>
    {
        void Invoke<TNumber>(T1 arg1, T2 arg2, T3 arg3, T4 arg4) where TNumber : struct, INumber<TNumber>;
    }

    public interface INumberAction<in T1, in T2, in T3, in T4, in T5> : IPrimitiveNumberAction<T1, T2, T3, T4, T5>
    {
        void Invoke<TNumber>(T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5) where TNumber : struct, INumber<TNumber>;
    }

    public interface INumberAction<in T1, in T2, in T3, in T4, in T5, in T6> : IPrimitiveNumberAction<T1, T2, T3, T4, T5, T6>
    {
        void Invoke<TNumber>(T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6) where TNumber : struct, INumber<TNumber>;
    }

    public interface INumberAction<in T1, in T2, in T3, in T4, in T5, in T6, in T7> : IPrimitiveNumberAction<T1, T2, T3, T4, T5, T6, T7>
    {
        void Invoke<TNumber>(T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7) where TNumber : struct, INumber<TNumber>;
    }

    public interface INumberAction<in T1, in T2, in T3, in T4, in T5, in T6, in T7, in T8> : IPrimitiveNumberAction<T1, T2, T3, T4, T5, T6, T7, T8>
    {
        void Invoke<TNumber>(T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7, T8 arg8) where TNumber : struct, INumber<TNumber>;
    }

    public interface IUnaryNumberAction : IPrimitiveUnaryNumberAction
    {
        void Invoke<TNumber>(in TNumber numArg) where TNumber : struct, INumber<TNumber>;
    }

    public interface IUnaryNumberAction<in T1> : IPrimitiveUnaryNumberAction<T1>
    {
        void Invoke<TNumber>(in TNumber numArg, T1 arg) where TNumber : struct, INumber<TNumber>;
    }

    public interface IUnaryNumberAction<in T1, in T2> : IPrimitiveUnaryNumberAction<T1, T2>
    {
        void Invoke<TNumber>(in TNumber numArg, T1 arg1, T2 arg2) where TNumber : struct, INumber<TNumber>;
    }

    public interface IUnaryNumberAction<in T1, in T2, in T3> : IPrimitiveUnaryNumberAction<T1, T2, T3>
    {
        void Invoke<TNumber>(in TNumber numArg, T1 arg1, T2 arg2, T3 arg3) where TNumber : struct, INumber<TNumber>;
    }

    public interface IUnaryNumberAction<in T1, in T2, in T3, in T4> : IPrimitiveUnaryNumberAction<T1, T2, T3, T4>
    {
        void Invoke<TNumber>(in TNumber numArg, T1 arg1, T2 arg2, T3 arg3, T4 arg4) where TNumber : struct, INumber<TNumber>;
    }

    public interface IUnaryNumberAction<in T1, in T2, in T3, in T4, in T5> : IPrimitiveUnaryNumberAction<T1, T2, T3, T4, T5>
    {
        void Invoke<TNumber>(in TNumber numArg, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5) where TNumber : struct, INumber<TNumber>;
    }

    public interface IUnaryNumberAction<in T1, in T2, in T3, in T4, in T5, in T6> : IPrimitiveUnaryNumberAction<T1, T2, T3, T4, T5, T6>
    {
        void Invoke<TNumber>(in TNumber numArg, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6) where TNumber : struct, INumber<TNumber>;
    }

    public interface IUnaryNumberAction<in T1, in T2, in T3, in T4, in T5, in T6, in T7> : IPrimitiveUnaryNumberAction<T1, T2, T3, T4, T5, T6, T7>
    {
        void Invoke<TNumber>(in TNumber numArg, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7) where TNumber : struct, INumber<TNumber>;
    }

    public interface IUnaryNumberAction<in T1, in T2, in T3, in T4, in T5, in T6, in T7, in T8> : IPrimitiveUnaryNumberAction<T1, T2, T3, T4, T5, T6, T7, T8>
    {
        void Invoke<TNumber>(in TNumber numArg, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7, T8 arg8) where TNumber : struct, INumber<TNumber>;
    }

    public interface IBinaryNumberAction : IPrimitiveBinaryNumberAction
    {
        void Invoke<TNumber>(in TNumber numArg1, in TNumber numArg2) where TNumber : struct, INumber<TNumber>;
    }

    public interface IBinaryNumberAction<in T1> : IPrimitiveBinaryNumberAction<T1>
    {
        void Invoke<TNumber>(in TNumber numArg1, in TNumber numArg2, T1 arg) where TNumber : struct, INumber<TNumber>;
    }

    public interface IBinaryNumberAction<in T1, in T2> : IPrimitiveBinaryNumberAction<T1, T2>
    {
        void Invoke<TNumber>(in TNumber numArg1, in TNumber numArg2, T1 arg1, T2 arg2) where TNumber : struct, INumber<TNumber>;
    }

    public interface IBinaryNumberAction<in T1, in T2, in T3> : IPrimitiveBinaryNumberAction<T1, T2, T3>
    {
        void Invoke<TNumber>(in TNumber numArg1, in TNumber numArg2, T1 arg1, T2 arg2, T3 arg3) where TNumber : struct, INumber<TNumber>;
    }

    public interface IBinaryNumberAction<in T1, in T2, in T3, in T4> : IPrimitiveBinaryNumberAction<T1, T2, T3, T4>
    {
        void Invoke<TNumber>(in TNumber numArg1, in TNumber numArg2, T1 arg1, T2 arg2, T3 arg3, T4 arg4) where TNumber : struct, INumber<TNumber>;
    }

    public interface IBinaryNumberAction<in T1, in T2, in T3, in T4, in T5> : IPrimitiveBinaryNumberAction<T1, T2, T3, T4, T5>
    {
        void Invoke<TNumber>(in TNumber numArg1, in TNumber numArg2, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5) where TNumber : struct, INumber<TNumber>;
    }

    public interface IBinaryNumberAction<in T1, in T2, in T3, in T4, in T5, in T6> : IPrimitiveBinaryNumberAction<T1, T2, T3, T4, T5, T6>
    {
        void Invoke<TNumber>(in TNumber numArg1, in TNumber numArg2, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6) where TNumber : struct, INumber<TNumber>;
    }

    public interface IBinaryNumberAction<in T1, in T2, in T3, in T4, in T5, in T6, in T7> : IPrimitiveBinaryNumberAction<T1, T2, T3, T4, T5, T6, T7>
    {
        void Invoke<TNumber>(in TNumber numArg1, in TNumber numArg2, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7) where TNumber : struct, INumber<TNumber>;
    }

    public interface IBinaryNumberAction<in T1, in T2, in T3, in T4, in T5, in T6, in T7, in T8> : IPrimitiveBinaryNumberAction<T1, T2, T3, T4, T5, T6, T7, T8>
    {
        void Invoke<TNumber>(in TNumber numArg1, in TNumber numArg2, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7, T8 arg8) where TNumber : struct, INumber<TNumber>;
    }

    public interface ITernaryNumberAction : IPrimitiveTernaryNumberAction
    {
        void Invoke<TNumber>(in TNumber numArg1, in TNumber numArg2) where TNumber : struct, INumber<TNumber>;
    }

    public interface ITernaryNumberAction<in T1> : IPrimitiveTernaryNumberAction<T1>
    {
        void Invoke<TNumber>(in TNumber numArg1, in TNumber numArg2, in TNumber numArg3, T1 arg) where TNumber : struct, INumber<TNumber>;
    }

    public interface ITernaryNumberAction<in T1, in T2> : IPrimitiveTernaryNumberAction<T1, T2>
    {
        void Invoke<TNumber>(in TNumber numArg1, in TNumber numArg2, in TNumber numArg3, T1 arg1, T2 arg2) where TNumber : struct, INumber<TNumber>;
    }

    public interface ITernaryNumberAction<in T1, in T2, in T3> : IPrimitiveTernaryNumberAction<T1, T2, T3>
    {
        void Invoke<TNumber>(in TNumber numArg1, in TNumber numArg2, in TNumber numArg3, T1 arg1, T2 arg2, T3 arg3) where TNumber : struct, INumber<TNumber>;
    }

    public interface ITernaryNumberAction<in T1, in T2, in T3, in T4> : IPrimitiveTernaryNumberAction<T1, T2, T3, T4>
    {
        void Invoke<TNumber>(in TNumber numArg1, in TNumber numArg2, in TNumber numArg3, T1 arg1, T2 arg2, T3 arg3, T4 arg4) where TNumber : struct, INumber<TNumber>;
    }

    public interface ITernaryNumberAction<in T1, in T2, in T3, in T4, in T5> : IPrimitiveTernaryNumberAction<T1, T2, T3, T4, T5>
    {
        void Invoke<TNumber>(in TNumber numArg1, in TNumber numArg2, in TNumber numArg3, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5) where TNumber : struct, INumber<TNumber>;
    }

    public interface ITernaryNumberAction<in T1, in T2, in T3, in T4, in T5, in T6> : IPrimitiveTernaryNumberAction<T1, T2, T3, T4, T5, T6>
    {
        void Invoke<TNumber>(in TNumber numArg1, in TNumber numArg2, in TNumber numArg3, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6) where TNumber : struct, INumber<TNumber>;
    }

    public interface ITernaryNumberAction<in T1, in T2, in T3, in T4, in T5, in T6, in T7> : IPrimitiveTernaryNumberAction<T1, T2, T3, T4, T5, T6, T7>
    {
        void Invoke<TNumber>(in TNumber numArg1, in TNumber numArg2, in TNumber numArg3, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7) where TNumber : struct, INumber<TNumber>;
    }

    public interface ITernaryNumberAction<in T1, in T2, in T3, in T4, in T5, in T6, in T7, in T8> : IPrimitiveTernaryNumberAction<T1, T2, T3, T4, T5, T6, T7, T8>
    {
        void Invoke<TNumber>(in TNumber numArg1, in TNumber numArg2, in TNumber numArg3, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7, T8 arg8) where TNumber : struct, INumber<TNumber>;
    }

    public interface INumberOperation : IPrimitiveNumberOperation
    {
        TNumber Invoke<TNumber>() where TNumber : struct, INumber<TNumber>;
    }

    public interface INumberOperation<in T1> : IPrimitiveNumberOperation<T1>
    {
        TNumber Invoke<TNumber>(T1 arg) where TNumber : struct, INumber<TNumber>;
    }

    public interface INumberOperation<in T1, in T2> : IPrimitiveNumberOperation<T1, T2>
    {
        TNumber Invoke<TNumber>(T1 arg1, T2 arg2) where TNumber : struct, INumber<TNumber>;
    }

    public interface INumberOperation<in T1, in T2, in T3> : IPrimitiveNumberOperation<T1, T2, T3>
    {
        TNumber Invoke<TNumber>(T1 arg1, T2 arg2, T3 arg3) where TNumber : struct, INumber<TNumber>;
    }

    public interface INumberOperation<in T1, in T2, in T3, in T4> : IPrimitiveNumberOperation<T1, T2, T3, T4>
    {
        TNumber Invoke<TNumber>(T1 arg1, T2 arg2, T3 arg3, T4 arg4) where TNumber : struct, INumber<TNumber>;
    }

    public interface INumberOperation<in T1, in T2, in T3, in T4, in T5> : IPrimitiveNumberOperation<T1, T2, T3, T4, T5>
    {
        TNumber Invoke<TNumber>(T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5) where TNumber : struct, INumber<TNumber>;
    }

    public interface INumberOperation<in T1, in T2, in T3, in T4, in T5, in T6> : IPrimitiveNumberOperation<T1, T2, T3, T4, T5, T6>
    {
        TNumber Invoke<TNumber>(T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6) where TNumber : struct, INumber<TNumber>;
    }

    public interface INumberOperation<in T1, in T2, in T3, in T4, in T5, in T6, in T7> : IPrimitiveNumberOperation<T1, T2, T3, T4, T5, T6, T7>
    {
        TNumber Invoke<TNumber>(T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7) where TNumber : struct, INumber<TNumber>;
    }

    public interface INumberOperation<in T1, in T2, in T3, in T4, in T5, in T6, in T7, in T8> : IPrimitiveNumberOperation<T1, T2, T3, T4, T5, T6, T7, T8>
    {
        TNumber Invoke<TNumber>(T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7, T8 arg8) where TNumber : struct, INumber<TNumber>;
    }

    public interface IUnaryNumberOperation : IPrimitiveUnaryNumberOperation
    {
        TNumber Invoke<TNumber>(in TNumber numArg) where TNumber : struct, INumber<TNumber>;
    }

    public interface IUnaryNumberOperation<in T1> : IPrimitiveUnaryNumberOperation<T1>
    {
        TNumber Invoke<TNumber>(in TNumber numArg, T1 arg) where TNumber : struct, INumber<TNumber>;
    }

    public interface IUnaryNumberOperation<in T1, in T2> : IPrimitiveUnaryNumberOperation<T1, T2>
    {
        TNumber Invoke<TNumber>(in TNumber numArg, T1 arg1, T2 arg2) where TNumber : struct, INumber<TNumber>;
    }

    public interface IUnaryNumberOperation<in T1, in T2, in T3> : IPrimitiveUnaryNumberOperation<T1, T2, T3>
    {
        TNumber Invoke<TNumber>(in TNumber numArg, T1 arg1, T2 arg2, T3 arg3) where TNumber : struct, INumber<TNumber>;
    }

    public interface IUnaryNumberOperation<in T1, in T2, in T3, in T4> : IPrimitiveUnaryNumberOperation<T1, T2, T3, T4>
    {
        TNumber Invoke<TNumber>(in TNumber numArg, T1 arg1, T2 arg2, T3 arg3, T4 arg4) where TNumber : struct, INumber<TNumber>;
    }

    public interface IUnaryNumberOperation<in T1, in T2, in T3, in T4, in T5> : IPrimitiveUnaryNumberOperation<T1, T2, T3, T4, T5>
    {
        TNumber Invoke<TNumber>(in TNumber numArg, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5) where TNumber : struct, INumber<TNumber>;
    }

    public interface IUnaryNumberOperation<in T1, in T2, in T3, in T4, in T5, in T6> : IPrimitiveUnaryNumberOperation<T1, T2, T3, T4, T5, T6>
    {
        TNumber Invoke<TNumber>(in TNumber numArg, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6) where TNumber : struct, INumber<TNumber>;
    }

    public interface IUnaryNumberOperation<in T1, in T2, in T3, in T4, in T5, in T6, in T7> : IPrimitiveUnaryNumberOperation<T1, T2, T3, T4, T5, T6, T7>
    {
        TNumber Invoke<TNumber>(in TNumber numArg, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7) where TNumber : struct, INumber<TNumber>;
    }

    public interface IUnaryNumberOperation<in T1, in T2, in T3, in T4, in T5, in T6, in T7, in T8> : IPrimitiveUnaryNumberOperation<T1, T2, T3, T4, T5, T6, T7, T8>
    {
        TNumber Invoke<TNumber>(in TNumber numArg, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7, T8 arg8) where TNumber : struct, INumber<TNumber>;
    }

    public interface IBinaryNumberOperation : IPrimitiveBinaryNumberOperation
    {
        TNumber Invoke<TNumber>(in TNumber numArg1, in TNumber numArg2) where TNumber : struct, INumber<TNumber>;
    }

    public interface IBinaryNumberOperation<in T1> : IPrimitiveBinaryNumberOperation<T1>
    {
        TNumber Invoke<TNumber>(in TNumber numArg1, in TNumber numArg2, T1 arg) where TNumber : struct, INumber<TNumber>;
    }

    public interface IBinaryNumberOperation<in T1, in T2> : IPrimitiveBinaryNumberOperation<T1, T2>
    {
        TNumber Invoke<TNumber>(in TNumber numArg1, in TNumber numArg2, T1 arg1, T2 arg2) where TNumber : struct, INumber<TNumber>;
    }

    public interface IBinaryNumberOperation<in T1, in T2, in T3> : IPrimitiveBinaryNumberOperation<T1, T2, T3>
    {
        TNumber Invoke<TNumber>(in TNumber numArg1, in TNumber numArg2, T1 arg1, T2 arg2, T3 arg3) where TNumber : struct, INumber<TNumber>;
    }

    public interface IBinaryNumberOperation<in T1, in T2, in T3, in T4> : IPrimitiveBinaryNumberOperation<T1, T2, T3, T4>
    {
        TNumber Invoke<TNumber>(in TNumber numArg1, in TNumber numArg2, T1 arg1, T2 arg2, T3 arg3, T4 arg4) where TNumber : struct, INumber<TNumber>;
    }

    public interface IBinaryNumberOperation<in T1, in T2, in T3, in T4, in T5> : IPrimitiveBinaryNumberOperation<T1, T2, T3, T4, T5>
    {
        TNumber Invoke<TNumber>(in TNumber numArg1, in TNumber numArg2, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5) where TNumber : struct, INumber<TNumber>;
    }

    public interface IBinaryNumberOperation<in T1, in T2, in T3, in T4, in T5, in T6> : IPrimitiveBinaryNumberOperation<T1, T2, T3, T4, T5, T6>
    {
        TNumber Invoke<TNumber>(in TNumber numArg1, in TNumber numArg2, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6) where TNumber : struct, INumber<TNumber>;
    }

    public interface IBinaryNumberOperation<in T1, in T2, in T3, in T4, in T5, in T6, in T7> : IPrimitiveBinaryNumberOperation<T1, T2, T3, T4, T5, T6, T7>
    {
        TNumber Invoke<TNumber>(in TNumber numArg1, in TNumber numArg2, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7) where TNumber : struct, INumber<TNumber>;
    }

    public interface IBinaryNumberOperation<in T1, in T2, in T3, in T4, in T5, in T6, in T7, in T8> : IPrimitiveBinaryNumberOperation<T1, T2, T3, T4, T5, T6, T7, T8>
    {
        TNumber Invoke<TNumber>(in TNumber numArg1, in TNumber numArg2, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7, T8 arg8) where TNumber : struct, INumber<TNumber>;
    }

    public interface ITernaryNumberOperation : IPrimitiveTernaryNumberOperation
    {
        TNumber Invoke<TNumber>(in TNumber numArg1, in TNumber numArg2, in TNumber numArg3) where TNumber : struct, INumber<TNumber>;
    }

    public interface ITernaryNumberOperation<in T1> : IPrimitiveTernaryNumberOperation<T1>
    {
        TNumber Invoke<TNumber>(in TNumber numArg1, in TNumber numArg2, in TNumber numArg3, T1 arg) where TNumber : struct, INumber<TNumber>;
    }

    public interface ITernaryNumberOperation<in T1, in T2> : IPrimitiveTernaryNumberOperation<T1, T2>
    {
        TNumber Invoke<TNumber>(in TNumber numArg1, in TNumber numArg2, in TNumber numArg3, T1 arg1, T2 arg2) where TNumber : struct, INumber<TNumber>;
    }

    public interface ITernaryNumberOperation<in T1, in T2, in T3> : IPrimitiveTernaryNumberOperation<T1, T2, T3>
    {
        TNumber Invoke<TNumber>(in TNumber numArg1, in TNumber numArg2, in TNumber numArg3, T1 arg1, T2 arg2, T3 arg3) where TNumber : struct, INumber<TNumber>;
    }

    public interface ITernaryNumberOperation<in T1, in T2, in T3, in T4> : IPrimitiveTernaryNumberOperation<T1, T2, T3, T4>
    {
        TNumber Invoke<TNumber>(in TNumber numArg1, in TNumber numArg2, in TNumber numArg3, T1 arg1, T2 arg2, T3 arg3, T4 arg4) where TNumber : struct, INumber<TNumber>;
    }

    public interface ITernaryNumberOperation<in T1, in T2, in T3, in T4, in T5> : IPrimitiveTernaryNumberOperation<T1, T2, T3, T4, T5>
    {
        TNumber Invoke<TNumber>(in TNumber numArg1, in TNumber numArg2, in TNumber numArg3, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5) where TNumber : struct, INumber<TNumber>;
    }

    public interface ITernaryNumberOperation<in T1, in T2, in T3, in T4, in T5, in T6> : IPrimitiveTernaryNumberOperation<T1, T2, T3, T4, T5, T6>
    {
        TNumber Invoke<TNumber>(in TNumber numArg1, in TNumber numArg2, in TNumber numArg3, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6) where TNumber : struct, INumber<TNumber>;
    }

    public interface ITernaryNumberOperation<in T1, in T2, in T3, in T4, in T5, in T6, in T7> : IPrimitiveTernaryNumberOperation<T1, T2, T3, T4, T5, T6, T7>
    {
        TNumber Invoke<TNumber>(in TNumber numArg1, in TNumber numArg2, in TNumber numArg3, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7) where TNumber : struct, INumber<TNumber>;
    }

    public interface ITernaryNumberOperation<in T1, in T2, in T3, in T4, in T5, in T6, in T7, in T8> : IPrimitiveTernaryNumberOperation<T1, T2, T3, T4, T5, T6, T7, T8>
    {
        TNumber Invoke<TNumber>(in TNumber numArg1, in TNumber numArg2, in TNumber numArg3, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7, T8 arg8) where TNumber : struct, INumber<TNumber>;
    }

    public interface IPrimitiveNumberFunc<out TResult>
    {
        TResult Invoke<TNumber, TPrimitive>() where TNumber : struct, INumber<TNumber, TPrimitive> where TPrimitive : struct, IEquatable<TPrimitive>, IComparable<TPrimitive>;
    }

    public interface IPrimitiveNumberFunc<in T1, out TResult>
    {
        TResult Invoke<TNumber, TPrimitive>(T1 arg) where TNumber : struct, INumber<TNumber, TPrimitive> where TPrimitive : struct, IEquatable<TPrimitive>, IComparable<TPrimitive>;
    }

    public interface IPrimitiveNumberFunc<in T1, in T2, out TResult>
    {
        TResult Invoke<TNumber, TPrimitive>(T1 arg1, T2 arg2) where TNumber : struct, INumber<TNumber, TPrimitive> where TPrimitive : struct, IEquatable<TPrimitive>, IComparable<TPrimitive>;
    }

    public interface IPrimitiveNumberFunc<in T1, in T2, in T3, out TResult>
    {
        TResult Invoke<TNumber, TPrimitive>(T1 arg1, T2 arg2, T3 arg3) where TNumber : struct, INumber<TNumber, TPrimitive> where TPrimitive : struct, IEquatable<TPrimitive>, IComparable<TPrimitive>;
    }

    public interface IPrimitiveNumberFunc<in T1, in T2, in T3, in T4, out TResult>
    {
        TResult Invoke<TNumber, TPrimitive>(T1 arg1, T2 arg2, T3 arg3, T4 arg4) where TNumber : struct, INumber<TNumber, TPrimitive> where TPrimitive : struct, IEquatable<TPrimitive>, IComparable<TPrimitive>;
    }

    public interface IPrimitiveNumberFunc<in T1, in T2, in T3, in T4, in T5, out TResult>
    {
        TResult Invoke<TNumber, TPrimitive>(T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5) where TNumber : struct, INumber<TNumber, TPrimitive> where TPrimitive : struct, IEquatable<TPrimitive>, IComparable<TPrimitive>;
    }

    public interface IPrimitiveNumberFunc<in T1, in T2, in T3, in T4, in T5, in T6, out TResult>
    {
        TResult Invoke<TNumber, TPrimitive>(T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6) where TNumber : struct, INumber<TNumber, TPrimitive> where TPrimitive : struct, IEquatable<TPrimitive>, IComparable<TPrimitive>;
    }

    public interface IPrimitiveNumberFunc<in T1, in T2, in T3, in T4, in T5, in T6, in T7, out TResult>
    {
        TResult Invoke<TNumber, TPrimitive>(T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7) where TNumber : struct, INumber<TNumber, TPrimitive> where TPrimitive : struct, IEquatable<TPrimitive>, IComparable<TPrimitive>;
    }

    public interface IPrimitiveNumberFunc<in T1, in T2, in T3, in T4, in T5, in T6, in T7, in T8, out TResult>
    {
        TResult Invoke<TNumber, TPrimitive>(T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7, T8 arg8) where TNumber : struct, INumber<TNumber, TPrimitive> where TPrimitive : struct, IEquatable<TPrimitive>, IComparable<TPrimitive>;
    }

    public interface IPrimitiveUnaryNumberFunc<out TResult>
    {
        TResult Invoke<TNumber, TPrimitive>(in TNumber numArg) where TNumber : struct, INumber<TNumber, TPrimitive> where TPrimitive : struct, IEquatable<TPrimitive>, IComparable<TPrimitive>;
    }

    public interface IPrimitiveUnaryNumberFunc<in T1, out TResult>
    {
        TResult Invoke<TNumber, TPrimitive>(in TNumber numArg, T1 arg) where TNumber : struct, INumber<TNumber, TPrimitive> where TPrimitive : struct, IEquatable<TPrimitive>, IComparable<TPrimitive>;
    }

    public interface IPrimitiveUnaryNumberFunc<in T1, in T2, out TResult>
    {
        TResult Invoke<TNumber, TPrimitive>(in TNumber numArg, T1 arg1, T2 arg2) where TNumber : struct, INumber<TNumber, TPrimitive> where TPrimitive : struct, IEquatable<TPrimitive>, IComparable<TPrimitive>;
    }

    public interface IPrimitiveUnaryNumberFunc<in T1, in T2, in T3, out TResult>
    {
        TResult Invoke<TNumber, TPrimitive>(in TNumber numArg, T1 arg1, T2 arg2, T3 arg3) where TNumber : struct, INumber<TNumber, TPrimitive> where TPrimitive : struct, IEquatable<TPrimitive>, IComparable<TPrimitive>;
    }

    public interface IPrimitiveUnaryNumberFunc<in T1, in T2, in T3, in T4, out TResult>
    {
        TResult Invoke<TNumber, TPrimitive>(in TNumber numArg, T1 arg1, T2 arg2, T3 arg3, T4 arg4) where TNumber : struct, INumber<TNumber, TPrimitive> where TPrimitive : struct, IEquatable<TPrimitive>, IComparable<TPrimitive>;
    }

    public interface IPrimitiveUnaryNumberFunc<in T1, in T2, in T3, in T4, in T5, out TResult>
    {
        TResult Invoke<TNumber, TPrimitive>(in TNumber numArg, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5) where TNumber : struct, INumber<TNumber, TPrimitive> where TPrimitive : struct, IEquatable<TPrimitive>, IComparable<TPrimitive>;
    }

    public interface IPrimitiveUnaryNumberFunc<in T1, in T2, in T3, in T4, in T5, in T6, out TResult>
    {
        TResult Invoke<TNumber, TPrimitive>(in TNumber numArg, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6) where TNumber : struct, INumber<TNumber, TPrimitive> where TPrimitive : struct, IEquatable<TPrimitive>, IComparable<TPrimitive>;
    }

    public interface IPrimitiveUnaryNumberFunc<in T1, in T2, in T3, in T4, in T5, in T6, in T7, out TResult>
    {
        TResult Invoke<TNumber, TPrimitive>(in TNumber numArg, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7) where TNumber : struct, INumber<TNumber, TPrimitive> where TPrimitive : struct, IEquatable<TPrimitive>, IComparable<TPrimitive>;
    }

    public interface IPrimitiveUnaryNumberFunc<in T1, in T2, in T3, in T4, in T5, in T6, in T7, in T8, out TResult>
    {
        TResult Invoke<TNumber, TPrimitive>(in TNumber numArg, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7, T8 arg8) where TNumber : struct, INumber<TNumber, TPrimitive> where TPrimitive : struct, IEquatable<TPrimitive>, IComparable<TPrimitive>;
    }

    public interface IPrimitiveBinaryNumberFunc<out TResult>
    {
        TResult Invoke<TNumber, TPrimitive>(in TNumber numArg1, in TNumber numArg2) where TNumber : struct, INumber<TNumber, TPrimitive> where TPrimitive : struct, IEquatable<TPrimitive>, IComparable<TPrimitive>;
    }

    public interface IPrimitiveBinaryNumberFunc<in T1, out TResult>
    {
        TResult Invoke<TNumber, TPrimitive>(in TNumber numArg1, in TNumber numArg2, T1 arg) where TNumber : struct, INumber<TNumber, TPrimitive> where TPrimitive : struct, IEquatable<TPrimitive>, IComparable<TPrimitive>;
    }

    public interface IPrimitiveBinaryNumberFunc<in T1, in T2, out TResult>
    {
        TResult Invoke<TNumber, TPrimitive>(in TNumber numArg1, in TNumber numArg2, T1 arg1, T2 arg2) where TNumber : struct, INumber<TNumber, TPrimitive> where TPrimitive : struct, IEquatable<TPrimitive>, IComparable<TPrimitive>;
    }

    public interface IPrimitiveBinaryNumberFunc<in T1, in T2, in T3, out TResult>
    {
        TResult Invoke<TNumber, TPrimitive>(in TNumber numArg1, in TNumber numArg2, T1 arg1, T2 arg2, T3 arg3) where TNumber : struct, INumber<TNumber, TPrimitive> where TPrimitive : struct, IEquatable<TPrimitive>, IComparable<TPrimitive>;
    }

    public interface IPrimitiveBinaryNumberFunc<in T1, in T2, in T3, in T4, out TResult>
    {
        TResult Invoke<TNumber, TPrimitive>(in TNumber numArg1, in TNumber numArg2, T1 arg1, T2 arg2, T3 arg3, T4 arg4) where TNumber : struct, INumber<TNumber, TPrimitive> where TPrimitive : struct, IEquatable<TPrimitive>, IComparable<TPrimitive>;
    }

    public interface IPrimitiveBinaryNumberFunc<in T1, in T2, in T3, in T4, in T5, out TResult>
    {
        TResult Invoke<TNumber, TPrimitive>(in TNumber numArg1, in TNumber numArg2, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5) where TNumber : struct, INumber<TNumber, TPrimitive> where TPrimitive : struct, IEquatable<TPrimitive>, IComparable<TPrimitive>;
    }

    public interface IPrimitiveBinaryNumberFunc<in T1, in T2, in T3, in T4, in T5, in T6, out TResult>
    {
        TResult Invoke<TNumber, TPrimitive>(in TNumber numArg1, in TNumber numArg2, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6) where TNumber : struct, INumber<TNumber, TPrimitive> where TPrimitive : struct, IEquatable<TPrimitive>, IComparable<TPrimitive>;
    }

    public interface IPrimitiveBinaryNumberFunc<in T1, in T2, in T3, in T4, in T5, in T6, in T7, out TResult>
    {
        TResult Invoke<TNumber, TPrimitive>(in TNumber numArg1, in TNumber numArg2, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7) where TNumber : struct, INumber<TNumber, TPrimitive> where TPrimitive : struct, IEquatable<TPrimitive>, IComparable<TPrimitive>;
    }

    public interface IPrimitiveBinaryNumberFunc<in T1, in T2, in T3, in T4, in T5, in T6, in T7, in T8, out TResult>
    {
        TResult Invoke<TNumber, TPrimitive>(in TNumber numArg1, in TNumber numArg2, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7, T8 arg8) where TNumber : struct, INumber<TNumber, TPrimitive> where TPrimitive : struct, IEquatable<TPrimitive>, IComparable<TPrimitive>;
    }

    public interface IPrimitiveTernaryNumberFunc<out TResult>
    {
        TResult Invoke<TNumber, TPrimitive>(in TNumber numArg1, in TNumber numArg2, in TNumber numArg3) where TNumber : struct, INumber<TNumber, TPrimitive> where TPrimitive : struct, IEquatable<TPrimitive>, IComparable<TPrimitive>;
    }

    public interface IPrimitiveTernaryNumberFunc<in T1, out TResult>
    {
        TResult Invoke<TNumber, TPrimitive>(in TNumber numArg1, in TNumber numArg2, in TNumber numArg3, T1 arg) where TNumber : struct, INumber<TNumber, TPrimitive> where TPrimitive : struct, IEquatable<TPrimitive>, IComparable<TPrimitive>;
    }

    public interface IPrimitiveTernaryNumberFunc<in T1, in T2, out TResult>
    {
        TResult Invoke<TNumber, TPrimitive>(in TNumber numArg1, in TNumber numArg2, in TNumber numArg3, T1 arg1, T2 arg2) where TNumber : struct, INumber<TNumber, TPrimitive> where TPrimitive : struct, IEquatable<TPrimitive>, IComparable<TPrimitive>;
    }

    public interface IPrimitiveTernaryNumberFunc<in T1, in T2, in T3, out TResult>
    {
        TResult Invoke<TNumber, TPrimitive>(in TNumber numArg1, in TNumber numArg2, in TNumber numArg3, T1 arg1, T2 arg2, T3 arg3) where TNumber : struct, INumber<TNumber, TPrimitive> where TPrimitive : struct, IEquatable<TPrimitive>, IComparable<TPrimitive>;
    }

    public interface IPrimitiveTernaryNumberFunc<in T1, in T2, in T3, in T4, out TResult>
    {
        TResult Invoke<TNumber, TPrimitive>(in TNumber numArg1, in TNumber numArg2, in TNumber numArg3, T1 arg1, T2 arg2, T3 arg3, T4 arg4) where TNumber : struct, INumber<TNumber, TPrimitive> where TPrimitive : struct, IEquatable<TPrimitive>, IComparable<TPrimitive>;
    }

    public interface IPrimitiveTernaryNumberFunc<in T1, in T2, in T3, in T4, in T5, out TResult>
    {
        TResult Invoke<TNumber, TPrimitive>(in TNumber numArg1, in TNumber numArg2, in TNumber numArg3, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5) where TNumber : struct, INumber<TNumber, TPrimitive> where TPrimitive : struct, IEquatable<TPrimitive>, IComparable<TPrimitive>;
    }

    public interface IPrimitiveTernaryNumberFunc<in T1, in T2, in T3, in T4, in T5, in T6, out TResult>
    {
        TResult Invoke<TNumber, TPrimitive>(in TNumber numArg1, in TNumber numArg2, in TNumber numArg3, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6) where TNumber : struct, INumber<TNumber, TPrimitive> where TPrimitive : struct, IEquatable<TPrimitive>, IComparable<TPrimitive>;
    }

    public interface IPrimitiveTernaryNumberFunc<in T1, in T2, in T3, in T4, in T5, in T6, in T7, out TResult>
    {
        TResult Invoke<TNumber, TPrimitive>(in TNumber numArg1, in TNumber numArg2, in TNumber numArg3, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7) where TNumber : struct, INumber<TNumber, TPrimitive> where TPrimitive : struct, IEquatable<TPrimitive>, IComparable<TPrimitive>;
    }

    public interface IPrimitiveTernaryNumberFunc<in T1, in T2, in T3, in T4, in T5, in T6, in T7, in T8, out TResult>
    {
        TResult Invoke<TNumber, TPrimitive>(in TNumber numArg1, in TNumber numArg2, in TNumber numArg3, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7, T8 arg8) where TNumber : struct, INumber<TNumber, TPrimitive> where TPrimitive : struct, IEquatable<TPrimitive>, IComparable<TPrimitive>;
    }

    public interface IPrimitiveNumberAction
    {
        void Invoke<TNumber, TPrimitive>() where TNumber : struct, INumber<TNumber, TPrimitive> where TPrimitive : struct, IEquatable<TPrimitive>, IComparable<TPrimitive>;
    }

    public interface IPrimitiveNumberAction<in T1>
    {
        void Invoke<TNumber, TPrimitive>(T1 arg) where TNumber : struct, INumber<TNumber, TPrimitive> where TPrimitive : struct, IEquatable<TPrimitive>, IComparable<TPrimitive>;
    }

    public interface IPrimitiveNumberAction<in T1, in T2>
    {
        void Invoke<TNumber, TPrimitive>(T1 arg1, T2 arg2) where TNumber : struct, INumber<TNumber, TPrimitive> where TPrimitive : struct, IEquatable<TPrimitive>, IComparable<TPrimitive>;
    }

    public interface IPrimitiveNumberAction<in T1, in T2, in T3>
    {
        void Invoke<TNumber, TPrimitive>(T1 arg1, T2 arg2, T3 arg3) where TNumber : struct, INumber<TNumber, TPrimitive> where TPrimitive : struct, IEquatable<TPrimitive>, IComparable<TPrimitive>;
    }

    public interface IPrimitiveNumberAction<in T1, in T2, in T3, in T4>
    {
        void Invoke<TNumber, TPrimitive>(T1 arg1, T2 arg2, T3 arg3, T4 arg4) where TNumber : struct, INumber<TNumber, TPrimitive> where TPrimitive : struct, IEquatable<TPrimitive>, IComparable<TPrimitive>;
    }

    public interface IPrimitiveNumberAction<in T1, in T2, in T3, in T4, in T5>
    {
        void Invoke<TNumber, TPrimitive>(T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5) where TNumber : struct, INumber<TNumber, TPrimitive> where TPrimitive : struct, IEquatable<TPrimitive>, IComparable<TPrimitive>;
    }

    public interface IPrimitiveNumberAction<in T1, in T2, in T3, in T4, in T5, in T6>
    {
        void Invoke<TNumber, TPrimitive>(T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6) where TNumber : struct, INumber<TNumber, TPrimitive> where TPrimitive : struct, IEquatable<TPrimitive>, IComparable<TPrimitive>;
    }

    public interface IPrimitiveNumberAction<in T1, in T2, in T3, in T4, in T5, in T6, in T7>
    {
        void Invoke<TNumber, TPrimitive>(T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7) where TNumber : struct, INumber<TNumber, TPrimitive> where TPrimitive : struct, IEquatable<TPrimitive>, IComparable<TPrimitive>;
    }

    public interface IPrimitiveNumberAction<in T1, in T2, in T3, in T4, in T5, in T6, in T7, in T8>
    {
        void Invoke<TNumber, TPrimitive>(T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7, T8 arg8) where TNumber : struct, INumber<TNumber, TPrimitive> where TPrimitive : struct, IEquatable<TPrimitive>, IComparable<TPrimitive>;
    }

    public interface IPrimitiveUnaryNumberAction
    {
        void Invoke<TNumber, TPrimitive>(in TNumber numArg) where TNumber : struct, INumber<TNumber, TPrimitive> where TPrimitive : struct, IEquatable<TPrimitive>, IComparable<TPrimitive>;
    }

    public interface IPrimitiveUnaryNumberAction<in T1>
    {
        void Invoke<TNumber, TPrimitive>(in TNumber numArg, T1 arg) where TNumber : struct, INumber<TNumber, TPrimitive> where TPrimitive : struct, IEquatable<TPrimitive>, IComparable<TPrimitive>;
    }

    public interface IPrimitiveUnaryNumberAction<in T1, in T2>
    {
        void Invoke<TNumber, TPrimitive>(in TNumber numArg, T1 arg1, T2 arg2) where TNumber : struct, INumber<TNumber, TPrimitive> where TPrimitive : struct, IEquatable<TPrimitive>, IComparable<TPrimitive>;
    }

    public interface IPrimitiveUnaryNumberAction<in T1, in T2, in T3>
    {
        void Invoke<TNumber, TPrimitive>(in TNumber numArg, T1 arg1, T2 arg2, T3 arg3) where TNumber : struct, INumber<TNumber, TPrimitive> where TPrimitive : struct, IEquatable<TPrimitive>, IComparable<TPrimitive>;
    }

    public interface IPrimitiveUnaryNumberAction<in T1, in T2, in T3, in T4>
    {
        void Invoke<TNumber, TPrimitive>(in TNumber numArg, T1 arg1, T2 arg2, T3 arg3, T4 arg4) where TNumber : struct, INumber<TNumber, TPrimitive> where TPrimitive : struct, IEquatable<TPrimitive>, IComparable<TPrimitive>;
    }

    public interface IPrimitiveUnaryNumberAction<in T1, in T2, in T3, in T4, in T5>
    {
        void Invoke<TNumber, TPrimitive>(in TNumber numArg, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5) where TNumber : struct, INumber<TNumber, TPrimitive> where TPrimitive : struct, IEquatable<TPrimitive>, IComparable<TPrimitive>;
    }

    public interface IPrimitiveUnaryNumberAction<in T1, in T2, in T3, in T4, in T5, in T6>
    {
        void Invoke<TNumber, TPrimitive>(in TNumber numArg, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6) where TNumber : struct, INumber<TNumber, TPrimitive> where TPrimitive : struct, IEquatable<TPrimitive>, IComparable<TPrimitive>;
    }

    public interface IPrimitiveUnaryNumberAction<in T1, in T2, in T3, in T4, in T5, in T6, in T7>
    {
        void Invoke<TNumber, TPrimitive>(in TNumber numArg, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7) where TNumber : struct, INumber<TNumber, TPrimitive> where TPrimitive : struct, IEquatable<TPrimitive>, IComparable<TPrimitive>;
    }

    public interface IPrimitiveUnaryNumberAction<in T1, in T2, in T3, in T4, in T5, in T6, in T7, in T8>
    {
        void Invoke<TNumber, TPrimitive>(in TNumber numArg, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7, T8 arg8) where TNumber : struct, INumber<TNumber, TPrimitive> where TPrimitive : struct, IEquatable<TPrimitive>, IComparable<TPrimitive>;
    }

    public interface IPrimitiveBinaryNumberAction
    {
        void Invoke<TNumber, TPrimitive>(in TNumber numArg1, in TNumber numArg2) where TNumber : struct, INumber<TNumber, TPrimitive> where TPrimitive : struct, IEquatable<TPrimitive>, IComparable<TPrimitive>;
    }

    public interface IPrimitiveBinaryNumberAction<in T1>
    {
        void Invoke<TNumber, TPrimitive>(in TNumber numArg1, in TNumber numArg2, T1 arg) where TNumber : struct, INumber<TNumber, TPrimitive> where TPrimitive : struct, IEquatable<TPrimitive>, IComparable<TPrimitive>;
    }

    public interface IPrimitiveBinaryNumberAction<in T1, in T2>
    {
        void Invoke<TNumber, TPrimitive>(in TNumber numArg1, in TNumber numArg2, T1 arg1, T2 arg2) where TNumber : struct, INumber<TNumber, TPrimitive> where TPrimitive : struct, IEquatable<TPrimitive>, IComparable<TPrimitive>;
    }

    public interface IPrimitiveBinaryNumberAction<in T1, in T2, in T3>
    {
        void Invoke<TNumber, TPrimitive>(in TNumber numArg1, in TNumber numArg2, T1 arg1, T2 arg2, T3 arg3) where TNumber : struct, INumber<TNumber, TPrimitive> where TPrimitive : struct, IEquatable<TPrimitive>, IComparable<TPrimitive>;
    }

    public interface IPrimitiveBinaryNumberAction<in T1, in T2, in T3, in T4>
    {
        void Invoke<TNumber, TPrimitive>(in TNumber numArg1, in TNumber numArg2, T1 arg1, T2 arg2, T3 arg3, T4 arg4) where TNumber : struct, INumber<TNumber, TPrimitive> where TPrimitive : struct, IEquatable<TPrimitive>, IComparable<TPrimitive>;
    }

    public interface IPrimitiveBinaryNumberAction<in T1, in T2, in T3, in T4, in T5>
    {
        void Invoke<TNumber, TPrimitive>(in TNumber numArg1, in TNumber numArg2, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5) where TNumber : struct, INumber<TNumber, TPrimitive> where TPrimitive : struct, IEquatable<TPrimitive>, IComparable<TPrimitive>;
    }

    public interface IPrimitiveBinaryNumberAction<in T1, in T2, in T3, in T4, in T5, in T6>
    {
        void Invoke<TNumber, TPrimitive>(in TNumber numArg1, in TNumber numArg2, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6) where TNumber : struct, INumber<TNumber, TPrimitive> where TPrimitive : struct, IEquatable<TPrimitive>, IComparable<TPrimitive>;
    }

    public interface IPrimitiveBinaryNumberAction<in T1, in T2, in T3, in T4, in T5, in T6, in T7>
    {
        void Invoke<TNumber, TPrimitive>(in TNumber numArg1, in TNumber numArg2, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7) where TNumber : struct, INumber<TNumber, TPrimitive> where TPrimitive : struct, IEquatable<TPrimitive>, IComparable<TPrimitive>;
    }

    public interface IPrimitiveBinaryNumberAction<in T1, in T2, in T3, in T4, in T5, in T6, in T7, in T8>
    {
        void Invoke<TNumber, TPrimitive>(in TNumber numArg1, in TNumber numArg2, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7, T8 arg8) where TNumber : struct, INumber<TNumber, TPrimitive> where TPrimitive : struct, IEquatable<TPrimitive>, IComparable<TPrimitive>;
    }

    public interface IPrimitiveTernaryNumberAction
    {
        void Invoke<TNumber, TPrimitive>(in TNumber numArg1, in TNumber numArg2) where TNumber : struct, INumber<TNumber, TPrimitive> where TPrimitive : struct, IEquatable<TPrimitive>, IComparable<TPrimitive>;
    }

    public interface IPrimitiveTernaryNumberAction<in T1>
    {
        void Invoke<TNumber, TPrimitive>(in TNumber numArg1, in TNumber numArg2, in TNumber numArg3, T1 arg) where TNumber : struct, INumber<TNumber, TPrimitive> where TPrimitive : struct, IEquatable<TPrimitive>, IComparable<TPrimitive>;
    }

    public interface IPrimitiveTernaryNumberAction<in T1, in T2>
    {
        void Invoke<TNumber, TPrimitive>(in TNumber numArg1, in TNumber numArg2, in TNumber numArg3, T1 arg1, T2 arg2) where TNumber : struct, INumber<TNumber, TPrimitive> where TPrimitive : struct, IEquatable<TPrimitive>, IComparable<TPrimitive>;
    }

    public interface IPrimitiveTernaryNumberAction<in T1, in T2, in T3>
    {
        void Invoke<TNumber, TPrimitive>(in TNumber numArg1, in TNumber numArg2, in TNumber numArg3, T1 arg1, T2 arg2, T3 arg3) where TNumber : struct, INumber<TNumber, TPrimitive> where TPrimitive : struct, IEquatable<TPrimitive>, IComparable<TPrimitive>;
    }

    public interface IPrimitiveTernaryNumberAction<in T1, in T2, in T3, in T4>
    {
        void Invoke<TNumber, TPrimitive>(in TNumber numArg1, in TNumber numArg2, in TNumber numArg3, T1 arg1, T2 arg2, T3 arg3, T4 arg4) where TNumber : struct, INumber<TNumber, TPrimitive> where TPrimitive : struct, IEquatable<TPrimitive>, IComparable<TPrimitive>;
    }

    public interface IPrimitiveTernaryNumberAction<in T1, in T2, in T3, in T4, in T5>
    {
        void Invoke<TNumber, TPrimitive>(in TNumber numArg1, in TNumber numArg2, in TNumber numArg3, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5) where TNumber : struct, INumber<TNumber, TPrimitive> where TPrimitive : struct, IEquatable<TPrimitive>, IComparable<TPrimitive>;
    }

    public interface IPrimitiveTernaryNumberAction<in T1, in T2, in T3, in T4, in T5, in T6>
    {
        void Invoke<TNumber, TPrimitive>(in TNumber numArg1, in TNumber numArg2, in TNumber numArg3, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6) where TNumber : struct, INumber<TNumber, TPrimitive> where TPrimitive : struct, IEquatable<TPrimitive>, IComparable<TPrimitive>;
    }

    public interface IPrimitiveTernaryNumberAction<in T1, in T2, in T3, in T4, in T5, in T6, in T7>
    {
        void Invoke<TNumber, TPrimitive>(in TNumber numArg1, in TNumber numArg2, in TNumber numArg3, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7) where TNumber : struct, INumber<TNumber, TPrimitive> where TPrimitive : struct, IEquatable<TPrimitive>, IComparable<TPrimitive>;
    }

    public interface IPrimitiveTernaryNumberAction<in T1, in T2, in T3, in T4, in T5, in T6, in T7, in T8>
    {
        void Invoke<TNumber, TPrimitive>(in TNumber numArg1, in TNumber numArg2, in TNumber numArg3, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7, T8 arg8) where TNumber : struct, INumber<TNumber, TPrimitive> where TPrimitive : struct, IEquatable<TPrimitive>, IComparable<TPrimitive>;
    }

    public interface IPrimitiveNumberOperation
    {
        TNumber Invoke<TNumber, TPrimitive>() where TNumber : struct, INumber<TNumber, TPrimitive> where TPrimitive : struct, IEquatable<TPrimitive>, IComparable<TPrimitive>;
    }

    public interface IPrimitiveNumberOperation<in T1>
    {
        TNumber Invoke<TNumber, TPrimitive>(T1 arg) where TNumber : struct, INumber<TNumber, TPrimitive> where TPrimitive : struct, IEquatable<TPrimitive>, IComparable<TPrimitive>;
    }

    public interface IPrimitiveNumberOperation<in T1, in T2>
    {
        TNumber Invoke<TNumber, TPrimitive>(T1 arg1, T2 arg2) where TNumber : struct, INumber<TNumber, TPrimitive> where TPrimitive : struct, IEquatable<TPrimitive>, IComparable<TPrimitive>;
    }

    public interface IPrimitiveNumberOperation<in T1, in T2, in T3>
    {
        TNumber Invoke<TNumber, TPrimitive>(T1 arg1, T2 arg2, T3 arg3) where TNumber : struct, INumber<TNumber, TPrimitive> where TPrimitive : struct, IEquatable<TPrimitive>, IComparable<TPrimitive>;
    }

    public interface IPrimitiveNumberOperation<in T1, in T2, in T3, in T4>
    {
        TNumber Invoke<TNumber, TPrimitive>(T1 arg1, T2 arg2, T3 arg3, T4 arg4) where TNumber : struct, INumber<TNumber, TPrimitive> where TPrimitive : struct, IEquatable<TPrimitive>, IComparable<TPrimitive>;
    }

    public interface IPrimitiveNumberOperation<in T1, in T2, in T3, in T4, in T5>
    {
        TNumber Invoke<TNumber, TPrimitive>(T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5) where TNumber : struct, INumber<TNumber, TPrimitive> where TPrimitive : struct, IEquatable<TPrimitive>, IComparable<TPrimitive>;
    }

    public interface IPrimitiveNumberOperation<in T1, in T2, in T3, in T4, in T5, in T6>
    {
        TNumber Invoke<TNumber, TPrimitive>(T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6) where TNumber : struct, INumber<TNumber, TPrimitive> where TPrimitive : struct, IEquatable<TPrimitive>, IComparable<TPrimitive>;
    }

    public interface IPrimitiveNumberOperation<in T1, in T2, in T3, in T4, in T5, in T6, in T7>
    {
        TNumber Invoke<TNumber, TPrimitive>(T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7) where TNumber : struct, INumber<TNumber, TPrimitive> where TPrimitive : struct, IEquatable<TPrimitive>, IComparable<TPrimitive>;
    }

    public interface IPrimitiveNumberOperation<in T1, in T2, in T3, in T4, in T5, in T6, in T7, in T8>
    {
        TNumber Invoke<TNumber, TPrimitive>(T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7, T8 arg8) where TNumber : struct, INumber<TNumber, TPrimitive> where TPrimitive : struct, IEquatable<TPrimitive>, IComparable<TPrimitive>;
    }

    public interface IPrimitiveUnaryNumberOperation
    {
        TNumber Invoke<TNumber, TPrimitive>(in TNumber numArg) where TNumber : struct, INumber<TNumber, TPrimitive> where TPrimitive : struct, IEquatable<TPrimitive>, IComparable<TPrimitive>;
    }

    public interface IPrimitiveUnaryNumberOperation<in T1>
    {
        TNumber Invoke<TNumber, TPrimitive>(in TNumber numArg, T1 arg) where TNumber : struct, INumber<TNumber, TPrimitive> where TPrimitive : struct, IEquatable<TPrimitive>, IComparable<TPrimitive>;
    }

    public interface IPrimitiveUnaryNumberOperation<in T1, in T2>
    {
        TNumber Invoke<TNumber, TPrimitive>(in TNumber numArg, T1 arg1, T2 arg2) where TNumber : struct, INumber<TNumber, TPrimitive> where TPrimitive : struct, IEquatable<TPrimitive>, IComparable<TPrimitive>;
    }

    public interface IPrimitiveUnaryNumberOperation<in T1, in T2, in T3>
    {
        TNumber Invoke<TNumber, TPrimitive>(in TNumber numArg, T1 arg1, T2 arg2, T3 arg3) where TNumber : struct, INumber<TNumber, TPrimitive> where TPrimitive : struct, IEquatable<TPrimitive>, IComparable<TPrimitive>;
    }

    public interface IPrimitiveUnaryNumberOperation<in T1, in T2, in T3, in T4>
    {
        TNumber Invoke<TNumber, TPrimitive>(in TNumber numArg, T1 arg1, T2 arg2, T3 arg3, T4 arg4) where TNumber : struct, INumber<TNumber, TPrimitive> where TPrimitive : struct, IEquatable<TPrimitive>, IComparable<TPrimitive>;
    }

    public interface IPrimitiveUnaryNumberOperation<in T1, in T2, in T3, in T4, in T5>
    {
        TNumber Invoke<TNumber, TPrimitive>(in TNumber numArg, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5) where TNumber : struct, INumber<TNumber, TPrimitive> where TPrimitive : struct, IEquatable<TPrimitive>, IComparable<TPrimitive>;
    }

    public interface IPrimitiveUnaryNumberOperation<in T1, in T2, in T3, in T4, in T5, in T6>
    {
        TNumber Invoke<TNumber, TPrimitive>(in TNumber numArg, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6) where TNumber : struct, INumber<TNumber, TPrimitive> where TPrimitive : struct, IEquatable<TPrimitive>, IComparable<TPrimitive>;
    }

    public interface IPrimitiveUnaryNumberOperation<in T1, in T2, in T3, in T4, in T5, in T6, in T7>
    {
        TNumber Invoke<TNumber, TPrimitive>(in TNumber numArg, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7) where TNumber : struct, INumber<TNumber, TPrimitive> where TPrimitive : struct, IEquatable<TPrimitive>, IComparable<TPrimitive>;
    }

    public interface IPrimitiveUnaryNumberOperation<in T1, in T2, in T3, in T4, in T5, in T6, in T7, in T8>
    {
        TNumber Invoke<TNumber, TPrimitive>(in TNumber numArg, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7, T8 arg8) where TNumber : struct, INumber<TNumber, TPrimitive> where TPrimitive : struct, IEquatable<TPrimitive>, IComparable<TPrimitive>;
    }

    public interface IPrimitiveBinaryNumberOperation
    {
        TNumber Invoke<TNumber, TPrimitive>(in TNumber numArg1, in TNumber numArg2) where TNumber : struct, INumber<TNumber, TPrimitive> where TPrimitive : struct, IEquatable<TPrimitive>, IComparable<TPrimitive>;
    }

    public interface IPrimitiveBinaryNumberOperation<in T1>
    {
        TNumber Invoke<TNumber, TPrimitive>(in TNumber numArg1, in TNumber numArg2, T1 arg) where TNumber : struct, INumber<TNumber, TPrimitive> where TPrimitive : struct, IEquatable<TPrimitive>, IComparable<TPrimitive>;
    }

    public interface IPrimitiveBinaryNumberOperation<in T1, in T2>
    {
        TNumber Invoke<TNumber, TPrimitive>(in TNumber numArg1, in TNumber numArg2, T1 arg1, T2 arg2) where TNumber : struct, INumber<TNumber, TPrimitive> where TPrimitive : struct, IEquatable<TPrimitive>, IComparable<TPrimitive>;
    }

    public interface IPrimitiveBinaryNumberOperation<in T1, in T2, in T3>
    {
        TNumber Invoke<TNumber, TPrimitive>(in TNumber numArg1, in TNumber numArg2, T1 arg1, T2 arg2, T3 arg3) where TNumber : struct, INumber<TNumber, TPrimitive> where TPrimitive : struct, IEquatable<TPrimitive>, IComparable<TPrimitive>;
    }

    public interface IPrimitiveBinaryNumberOperation<in T1, in T2, in T3, in T4>
    {
        TNumber Invoke<TNumber, TPrimitive>(in TNumber numArg1, in TNumber numArg2, T1 arg1, T2 arg2, T3 arg3, T4 arg4) where TNumber : struct, INumber<TNumber, TPrimitive> where TPrimitive : struct, IEquatable<TPrimitive>, IComparable<TPrimitive>;
    }

    public interface IPrimitiveBinaryNumberOperation<in T1, in T2, in T3, in T4, in T5>
    {
        TNumber Invoke<TNumber, TPrimitive>(in TNumber numArg1, in TNumber numArg2, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5) where TNumber : struct, INumber<TNumber, TPrimitive> where TPrimitive : struct, IEquatable<TPrimitive>, IComparable<TPrimitive>;
    }

    public interface IPrimitiveBinaryNumberOperation<in T1, in T2, in T3, in T4, in T5, in T6>
    {
        TNumber Invoke<TNumber, TPrimitive>(in TNumber numArg1, in TNumber numArg2, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6) where TNumber : struct, INumber<TNumber, TPrimitive> where TPrimitive : struct, IEquatable<TPrimitive>, IComparable<TPrimitive>;
    }

    public interface IPrimitiveBinaryNumberOperation<in T1, in T2, in T3, in T4, in T5, in T6, in T7>
    {
        TNumber Invoke<TNumber, TPrimitive>(in TNumber numArg1, in TNumber numArg2, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7) where TNumber : struct, INumber<TNumber, TPrimitive> where TPrimitive : struct, IEquatable<TPrimitive>, IComparable<TPrimitive>;
    }

    public interface IPrimitiveBinaryNumberOperation<in T1, in T2, in T3, in T4, in T5, in T6, in T7, in T8>
    {
        TNumber Invoke<TNumber, TPrimitive>(in TNumber numArg1, in TNumber numArg2, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7, T8 arg8) where TNumber : struct, INumber<TNumber, TPrimitive> where TPrimitive : struct, IEquatable<TPrimitive>, IComparable<TPrimitive>;
    }

    public interface IPrimitiveTernaryNumberOperation
    {
        TNumber Invoke<TNumber, TPrimitive>(in TNumber numArg1, in TNumber numArg2, in TNumber numArg3) where TNumber : struct, INumber<TNumber, TPrimitive> where TPrimitive : struct, IEquatable<TPrimitive>, IComparable<TPrimitive>;
    }

    public interface IPrimitiveTernaryNumberOperation<in T1>
    {
        TNumber Invoke<TNumber, TPrimitive>(in TNumber numArg1, in TNumber numArg2, in TNumber numArg3, T1 arg) where TNumber : struct, INumber<TNumber, TPrimitive> where TPrimitive : struct, IEquatable<TPrimitive>, IComparable<TPrimitive>;
    }

    public interface IPrimitiveTernaryNumberOperation<in T1, in T2>
    {
        TNumber Invoke<TNumber, TPrimitive>(in TNumber numArg1, in TNumber numArg2, in TNumber numArg3, T1 arg1, T2 arg2) where TNumber : struct, INumber<TNumber, TPrimitive> where TPrimitive : struct, IEquatable<TPrimitive>, IComparable<TPrimitive>;
    }

    public interface IPrimitiveTernaryNumberOperation<in T1, in T2, in T3>
    {
        TNumber Invoke<TNumber, TPrimitive>(in TNumber numArg1, in TNumber numArg2, in TNumber numArg3, T1 arg1, T2 arg2, T3 arg3) where TNumber : struct, INumber<TNumber, TPrimitive> where TPrimitive : struct, IEquatable<TPrimitive>, IComparable<TPrimitive>;
    }

    public interface IPrimitiveTernaryNumberOperation<in T1, in T2, in T3, in T4>
    {
        TNumber Invoke<TNumber, TPrimitive>(in TNumber numArg1, in TNumber numArg2, in TNumber numArg3, T1 arg1, T2 arg2, T3 arg3, T4 arg4) where TNumber : struct, INumber<TNumber, TPrimitive> where TPrimitive : struct, IEquatable<TPrimitive>, IComparable<TPrimitive>;
    }

    public interface IPrimitiveTernaryNumberOperation<in T1, in T2, in T3, in T4, in T5>
    {
        TNumber Invoke<TNumber, TPrimitive>(in TNumber numArg1, in TNumber numArg2, in TNumber numArg3, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5) where TNumber : struct, INumber<TNumber, TPrimitive> where TPrimitive : struct, IEquatable<TPrimitive>, IComparable<TPrimitive>;
    }

    public interface IPrimitiveTernaryNumberOperation<in T1, in T2, in T3, in T4, in T5, in T6>
    {
        TNumber Invoke<TNumber, TPrimitive>(in TNumber numArg1, in TNumber numArg2, in TNumber numArg3, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6) where TNumber : struct, INumber<TNumber, TPrimitive> where TPrimitive : struct, IEquatable<TPrimitive>, IComparable<TPrimitive>;
    }

    public interface IPrimitiveTernaryNumberOperation<in T1, in T2, in T3, in T4, in T5, in T6, in T7>
    {
        TNumber Invoke<TNumber, TPrimitive>(in TNumber numArg1, in TNumber numArg2, in TNumber numArg3, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7) where TNumber : struct, INumber<TNumber, TPrimitive> where TPrimitive : struct, IEquatable<TPrimitive>, IComparable<TPrimitive>;
    }

    public interface IPrimitiveTernaryNumberOperation<in T1, in T2, in T3, in T4, in T5, in T6, in T7, in T8>
    {
        TNumber Invoke<TNumber, TPrimitive>(in TNumber numArg1, in TNumber numArg2, in TNumber numArg3, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7, T8 arg8) where TNumber : struct, INumber<TNumber, TPrimitive> where TPrimitive : struct, IEquatable<TPrimitive>, IComparable<TPrimitive>;
    }
}
