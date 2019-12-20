using System;
using System.Linq.Expressions;

namespace IS4.HyperNumerics
{
    public static class PrimitiveOperations<TPrimitive> where TPrimitive : struct, IEquatable<TPrimitive>, IComparable<TPrimitive>
    {
        public static readonly Func<TPrimitive, TPrimitive, TPrimitive> Add;
        public static readonly Func<TPrimitive, TPrimitive, TPrimitive> Subtract;
        public static readonly Func<TPrimitive, TPrimitive, TPrimitive> Multiply;
        public static readonly Func<TPrimitive, TPrimitive, TPrimitive> Divide;
        public static readonly Func<TPrimitive, TPrimitive, TPrimitive> Modulo;
        public static readonly Func<TPrimitive, TPrimitive> Negate;
        public static readonly Func<TPrimitive, TPrimitive> Increment;
        public static readonly Func<TPrimitive, TPrimitive> Decrement;

        static PrimitiveOperations()
        {
            Add = CreateBinary(Expression.AddChecked);
            Subtract = CreateBinary(Expression.SubtractChecked);
            Multiply = CreateBinary(Expression.MultiplyChecked);
            Divide = CreateBinary(Expression.Divide);
            Modulo = CreateBinary(Expression.Modulo);
            Negate = CreateUnary(Expression.Negate);
            Increment = CreateUnary(Expression.Increment);
            Decrement = CreateUnary(Expression.Decrement);
        }

        static Func<TPrimitive, TPrimitive> CreateUnary(Func<Expression, Expression> unaryExpression)
        {
            var param = Expression.Parameter(typeof(TPrimitive));
            var expr = unaryExpression(param);
            return Expression.Lambda<Func<TPrimitive, TPrimitive>>(expr, param).Compile();
        }

        static Func<TPrimitive, TPrimitive, TPrimitive> CreateBinary(Func<Expression, Expression, Expression> binaryExpression)
        {
            var param1 = Expression.Parameter(typeof(TPrimitive));
            var param2 = Expression.Parameter(typeof(TPrimitive));
            var expr = binaryExpression(param1, param2);
            return Expression.Lambda<Func<TPrimitive, TPrimitive, TPrimitive>>(expr, param1, param2).Compile();
        }
    }
}
