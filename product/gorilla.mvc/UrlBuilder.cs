using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Reflection;
using System.Text;
using System.Web.Mvc;
using Gorilla.Commons.Utility.Extensions;

namespace gorilla.mvc
{
    public class UrlBuilder
    {
        readonly IDictionary<Type, IExpressionParser> parsers;

        public UrlBuilder()
        {
            parsers = new Dictionary<Type, IExpressionParser>
                          {
                              {typeof (ConstantExpression), new ConstantExpressionParser()},
                              {typeof (MemberExpression), new MemberExpressionParser()},
                          };
        }

        public string create_url_for<Controller>(MethodCallExpression expression) where Controller : IController
        {
            var method = expression.Method;

            return @"{0}\{1}{2}".formatted_using(
                pretty_name_for<Controller>(),
                method.Name,
                append_parameters_using(method, expression.Arguments));
        }

        string append_parameters_using(MethodInfo method, IEnumerable<Expression> expressions)
        {
            var builder = new StringBuilder();
            var i = 0;
            foreach (var expression in expressions ?? new List<Expression>())
            {
                builder.Append((0 == i) ? "?" : "&");
                builder.AppendFormat("{0}={1}", parameter_name_at_index(method, i), parser_for(expression).parse_value_from(expression));
                i++;
            }
            return builder.ToString();
        }

        IExpressionParser parser_for(Expression expression)
        {
            return parsers[expression.GetType()];
        }

        string parameter_name_at_index(MethodInfo method, int index)
        {
            return method.GetParameters()[index].Name;
        }

        string pretty_name_for<Controller>() where Controller : IController
        {
            return typeof (Controller).Name.Replace("Controller", "");
        }
    }
}