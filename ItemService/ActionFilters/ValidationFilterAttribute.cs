using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace MicroServices.ActionFilters
{
    public class ValidationFilterAttribute : IActionFilter
    {
        public void OnActionExecuted(ActionExecutedContext context) { }

        public void OnActionExecuting(ActionExecutingContext context)
        {
            var dtoObject = context
                .ActionArguments.SingleOrDefault(x =>
                    x.Value != null && x.Value.ToString().Contains("Dto")
                )
                .Value;

            if (dtoObject == null || !context.ModelState.IsValid)
            {
                context.Result = new BadRequestObjectResult("Object is bad");
                return;
            }
        }
    }
}
