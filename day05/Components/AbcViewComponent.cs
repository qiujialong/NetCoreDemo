using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace day05.Components
{
    public class AbcViewComponent: ViewComponent
    {
        public IViewComponentResult Invoke()
        {



            return View(10);
        }
    }
}
