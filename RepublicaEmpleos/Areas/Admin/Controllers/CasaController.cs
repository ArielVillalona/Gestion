using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using RepublicaEmpleos.Data;
using RepublicaEmpleos.Models.Identity;

namespace RepublicaEmpleos.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize]
    public class CasaController : Controller
    {
        private readonly ILogger<CasaController> _logger;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;

        [TempData]
        public string StatusMessage { get; set; }

        public CasaController(
            ILogger<CasaController> logger,
            UserManager<ApplicationUser> userManager,
            SignInManager<ApplicationUser> signInManager)
        {
            _logger = logger;
            _userManager = userManager;
            _signInManager = signInManager;
        }

        //[HttpGet("/")]
        public IActionResult Index()
        {
            return View();
        }
    }
}