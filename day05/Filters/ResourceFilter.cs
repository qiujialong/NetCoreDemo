using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace day05.Filters
{
    public class ResourceFilter : Attribute, IResourceFilter
    {
        public void OnResourceExecuted(ResourceExecutedContext context)
        {

        }

        public void OnResourceExecuting(ResourceExecutingContext context)
        {
            var token = context.HttpContext.User.FindFirstValue(ClaimTypes.Sid);

            // context.Result = new ContentResult() { Content="结束执行"};
        }
    }
}
