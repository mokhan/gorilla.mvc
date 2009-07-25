using System.Linq.Expressions;

namespace gorilla.mvc
{
    public class ConstantExpressionParser : IExpressionParser
    {
        public object parse_value_from(Expression expression)
        {
            var constant_expression = expression as ConstantExpression;
            return constant_expression.Value;
        }

        public bool can_parse(Expression expression)
        {
            return (expression is ConstantExpression);
        }
    }
}