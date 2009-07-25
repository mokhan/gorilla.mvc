using System;
using System.Linq.Expressions;
using System.Web.Mvc;

namespace gorilla.mvc
{
    public static class UrlHelpers
    {
        public static string To<Controller>(this UrlHelper helper, Expression<Action<Controller>> url) where Controller : IController
        {
            return Url.To(url);
        }
    }
}