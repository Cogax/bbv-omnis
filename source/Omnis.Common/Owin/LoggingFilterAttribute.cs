namespace Omnis.Common.Owin
{
    using System;
    using System.Web.Http.Filters;

    using log4net;

    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method)]
    public sealed class LoggingFilterAttribute : ActionFilterAttribute
    {
        private static readonly ILog Logger = LogManager.GetLogger("OMNIS");

        public override void OnActionExecuted(HttpActionExecutedContext actionExecutedContext)
        {
            base.OnActionExecuted(actionExecutedContext);
            if (actionExecutedContext.Exception == null)
            {
                Logger.Debug(actionExecutedContext.GetLogMessage());
            }
        }
    }
}