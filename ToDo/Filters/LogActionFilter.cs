using Microsoft.AspNetCore.Mvc.Filters;
using ToDo.Services;

namespace ToDo.Filters
{
    public class LogActionFilter : ActionFilterAttribute
    {
        public override void OnActionExecuted(ActionExecutedContext context)
        {
            base.OnActionExecuted(context);
        }

        public override void OnActionExecuting(ActionExecutingContext context)
        {
            var httpContext = context.HttpContext;
            string user = httpContext.Session.GetString("userLogged");
            string actionName = context.ActionDescriptor.DisplayName;
            FileLogger.Log(user, actionName);
        }
    }
}
