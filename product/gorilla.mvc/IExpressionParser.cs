using System.Linq.Expressions;

namespace gorilla.mvc
{
    public interface IExpressionParser
    {
        object parse_value_from(Expression expression);
        bool can_parse(Expression expression);
    }
}