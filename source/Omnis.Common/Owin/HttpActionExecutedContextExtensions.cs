namespace Omnis.Common.Owin
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Net;
    using System.Web.Http.Filters;

    public static class HttpActionExecutedContextExtensions
    {
        public static string GetLogMessage(this HttpActionExecutedContext context)
        {
            return context.GetLogMessage(context.Response?.StatusCode ?? HttpStatusCode.NotImplemented);
        }

        public static string GetLogMessage(this HttpActionExecutedContext context, HttpStatusCode statusCode)
        {
            var verb = context.Request.Method.Method;
            var uri = context.Request.RequestUri;
            var action = context.ActionContext.ActionDescriptor.ActionName;
            var arguments = GetLogMessage(context.ActionContext.ActionArguments);

            return $"{verb, -7}{uri} [{statusCode}] - {action}({arguments})";
        }

        private static string GetLogMessage(Dictionary<string, object> parameters)
        {
            IEnumerable<string> parameterKeyValues = parameters.Select(x => $"{x.Key}: {x.Value}");
            return string.Join(", ", parameterKeyValues);
        }
    }
}