using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
namespace FxStore.ProductAPI.Filters
{
    public class PrivateEndpointAttribute:ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            var header = context.HttpContext.Request.Headers["cross_token"].FirstOrDefault();

            if(string.IsNullOrEmpty(header) || (!string.IsNullOrEmpty(header) && header != "2812fx"))
            {
                context.Result = new UnauthorizedObjectResult("You are not authorized in cross api communication");
            }
        }
    }
}
