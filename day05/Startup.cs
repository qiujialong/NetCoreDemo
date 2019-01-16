using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.FileProviders;
using System.IO;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Rewrite;

namespace day05
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc();

            services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme).
                AddCookie(CookieAuthenticationDefaults.AuthenticationScheme, o =>
                {
                    o.LoginPath = new PathString("/Home/DoLogin");
                });

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            //使用静态文件
            app.UseStaticFiles(new StaticFileOptions() {
                FileProvider =new PhysicalFileProvider(Path.Combine(Directory.GetCurrentDirectory(),"Images")),
                RequestPath=new PathString("/Images")
            });

            app.UseStaticFiles();

            app.UseMvcWithDefaultRoute();

            app.UseAuthentication();

            //
            var options = new RewriteOptions();
            options.AddRewrite("^rewrite/(.*)", "home/center", true).Add(reContext=> {
                reContext.Result = RuleResult.EndResponse;
            });
            //options.AddRedirect("^redirect/(.*)", "api/test");//默认状态码为 302
            //options.AddRedirect("^redirect/(.*)", "home/center", 301);
            app.UseRewriter(options);

            app.Run(async context =>
            {
                //注意重定向和重写URL两种情况下,浏览器地址栏和页面显示的 URL 的区别.
                await context.Response.WriteAsync($"URL:{context.Request.Path + context.Request.QueryString}");
            });

            app.UseMvc();
            //app.Run(async (context) =>
            //{
            //    await context.Response.WriteAsync("Hello World!");
            //});
        }
    }
}
