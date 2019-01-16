using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using day05.Models;
using Microsoft.AspNetCore.Authorization;

namespace day05.Controllers
{
    /*
        asp.net 
        asp.net mvc
        asp.net core mvc

        模型绑定机制把获取http请求的参数（get，post）action的参数名字对应的参数进行绑定
        id参数
        IBindModel
        ModelState
        Views
         */

    public class BindController : BaseController
    { 
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Index(Person person)
        {
            ModelState.Remove("name");
            if (!ModelState.IsValid)
            {
                return Content("数据验证不通过");
            }

            return View();
        }
    }
}