using day05.Filters;
using day05.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace day05.Controllers
{
    public class HomeController : BaseController
    {
        [ResourceFilter]
        [ActionFilter]
        [ExceptionFilter]
        [Authorize(AuthenticationSchemes = CookieAuthenticationDefaults.AuthenticationScheme)]
        public IActionResult Index()
        {
            //业务逻辑
            UserModel user = new UserModel() { Name = "张三" };
            ViewBag.Sex = "男";
            return View(user);
        }

        public IActionResult Login()
        {
            return Content("Login");
        }

        public IActionResult DoLogin()
        {
            /*
             * 登录以后获取token，
             * 获取传递的token，去用户信息
             * 
             */
            string token = "123456";
            string name = "张三";
            ClaimsIdentity identity = new ClaimsIdentity("Forms");

            identity.AddClaim(new Claim(ClaimTypes.Sid, token));
            identity.AddClaim(new Claim(ClaimTypes.Name, name));

            ClaimsPrincipal claimsPrincipal = new ClaimsPrincipal(identity);
            HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, claimsPrincipal);

            return Content("登录成功");
        }

        [Authorize(AuthenticationSchemes = CookieAuthenticationDefaults.AuthenticationScheme)]
        public IActionResult Center()
        {
            var token = User.FindFirstValue(ClaimTypes.Sid);
            var identity = User.Identity;

            return Content("Center");
        }
    }
}
