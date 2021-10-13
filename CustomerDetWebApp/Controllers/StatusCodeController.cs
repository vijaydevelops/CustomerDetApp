using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CustomerDetWebApp.Controllers
{
    public class StatusCodeController : Controller
    {
        public IActionResult Index()
        {
            return View("StatusCode");
        }
    }
}
