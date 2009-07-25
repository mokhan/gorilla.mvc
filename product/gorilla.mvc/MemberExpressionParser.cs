using System;
using System.Linq.Expressions;

namespace gorilla.mvc
{
    public class MemberExpressionParser : IExpressionParser
    {
        public object parse_value_from(Expression expression)
        {
            return Expression.Lambda<Func<object>>(Expression.Convert(expression, typeof (object))).Compile()();
        }

        public bool can_parse(Expression expression)
        {
            return (expression is MemberExpression);
        }
    }
}