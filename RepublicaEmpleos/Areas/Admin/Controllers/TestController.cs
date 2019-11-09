using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace RepublicaEmpleos.Areas.Admin.Controllers
{
    [Area("test")]
    public class TestController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}