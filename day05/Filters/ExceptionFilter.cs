using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace day05.Filters
{
    public class ExceptionFilter: ExceptionFilterAttribute
    {
        public override void OnException(ExceptionContext context)
        {
            //
        
            context.Result = new ContentResult() { Content = "系统发生错误" };
        }
    }
}
