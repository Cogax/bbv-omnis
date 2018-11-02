namespace Omnis.Common.Owin
{
    using System;
    using System.Diagnostics.CodeAnalysis;
    using System.Net;
    using System.Net.Http;
    using System.Reflection;
    using System.Web.Http.Filters;

    using log4net;

    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method)]
    public class ExceptionFilterAttribute : ActionFilterAttribute
    {
        private static readonly ILog Logger = LogManager.GetLogger("OMNIS");

        public override void OnActionExecuted(HttpActionExecutedContext actionExecutedContext)
        {
            if (actionExecutedContext.Exception is ResourceNotFoundException)
            {
                const HttpStatusCode StatusCode = HttpStatusCode.NotFound;

                LogError(actionExecutedContext, StatusCode);
                actionExecutedContext.Response = CreateHttpResponseMessage(StatusCode, actionExecutedContext);
            }
            else if (actionExecutedContext.Exception is ConflictException)
            {
                const HttpStatusCode StatusCode = HttpStatusCode.Conflict;

                LogError(actionExecutedContext, StatusCode);
                actionExecutedContext.Response = CreateHttpResponseMessage(StatusCode, actionExecutedContext);
            }
            else if (actionExecutedContext.Exception != null)
            {
                const HttpStatusCode StatusCode = HttpStatusCode.InternalServerError;

                Logger.Error(
                    actionExecutedContext.GetLogMessage(StatusCode),
                    actionExecutedContext.Exception);

                actionExecutedContext.Response = CreateHttpResponseMessage(StatusCode, actionExecutedContext);
            }
        }

        [SuppressMessage("Microsoft.Reliability", "CA2000:Dispose objects before losing scope", Justification = "Reviewed, okay")]
        private static HttpResponseMessage CreateHttpResponseMessage(
            HttpStatusCode statusCode,
            HttpActionExecutedContext context)
        {
            return new HttpResponseMessage(statusCode) { ReasonPhrase = context.Exception.Message };
        }

        private static void LogError(HttpActionExecutedContext context, HttpStatusCode statusCode)
        {
            Logger.Error($"{context.GetLogMessage(statusCode)}\r\n\t{context.Exception.Message}");
        }
    }
}