using System;
using System.Linq.Expressions;
using System.Web.Mvc;

namespace gorilla.mvc
{
    public class Url
    {
        public static string to<Controller>(Expression<Action<Controller>> url) where Controller : IController
        {
            var expression = url.Body as MethodCallExpression;
            return null != expression ? new UrlBuilder().create_url_for<Controller>(expression) : string.Empty;
        }
    }
}