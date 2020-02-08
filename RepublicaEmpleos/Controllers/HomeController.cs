using System.Diagnostics;
using System.Threading.Tasks;
using RepublicaEmpleos.Infrastructure;
using RepublicaEmpleos.Infrastructure.ErrorHandling;
using Microsoft.AspNetCore.Mvc;
using RepublicaEmpleos.Models;
using RepublicaEmpleos.Models.Identity;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.WebUtilities;
using Microsoft.Extensions.Logging;
using RepublicaEmpleos.Data;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
using System;
using System.IO;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using RepublicaEmpleos.Services.Interfaces;
using AutoMapper;

namespace RepublicaEmpleos.Controllers
{
    [AllowAnonymous]
    public class HomeController : BaseController
    {
        private readonly ILogger<HomeController> _logger;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly ApplicationDbContext _dbContext;
        private readonly IProfileServices _profileServices;
        private readonly IMapper _mapper;
        private FullProfileViewModel FPVM = new FullProfileViewModel();

        [TempData]
        public string StatusMessage { get; set; }

        public HomeController(
            IMapper mapper,
            ApplicationDbContext dbContext,
            ILogger<HomeController> logger,
            UserManager<ApplicationUser> userManager,
            SignInManager<ApplicationUser> signInManager,
            IProfileServices profileServices)
        {
            _logger = logger;
            _userManager = userManager;
            _signInManager = signInManager;
            _dbContext = dbContext;
            _profileServices = profileServices;
            _mapper = mapper;
        }

        [HttpGet("/")]
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet("/icons")]
        public IActionResult Icons()
        {
            return View();
        }

        [HttpGet("/maps")]
        public IActionResult Maps()
        {
            return View();
        }

        [ImportModelState]
        [HttpGet("/profile")]
        public async Task<IActionResult> Profile()
        {
            var user = await _userManager.GetUserAsync(User);
            if (user == null)
            {
                return NotFound($"Unable to load user with ID '{_userManager.GetUserId(User)}'.");
            }
            return View(new ProfileViewModel
            {
                Email = user.Email,
                FullName = user.FullName
            });
        }

        [HttpGet("/FullProfile")]
        public async Task<ActionResult<FullProfileViewModel>> FullProfile()
        {
            var Licencia = new List<SelectListItem> {
                new SelectListItem() {Text = "No", Value = "1", Selected=true},
                new SelectListItem() {Text = "Si", Value = "2"},
            };
            var Vehiculo = new List<SelectListItem> {
                new SelectListItem() {Text = "No", Value = "1", Selected=true},
                new SelectListItem() {Text = "Si", Value = "2"},
            };
            var CabezaHogar = new List<SelectListItem> {
                new SelectListItem() {Text = "No", Value = "1", Selected=true},
                new SelectListItem() {Text = "Si", Value = "2"},
            };
            var Estatura = new List<SelectListItem> {
                new SelectListItem() {Text = "5' 7\"", Value = "1", Selected=true},
                new SelectListItem() {Text = "5' 8\"", Value = "2"},
                new SelectListItem() {Text = "5' 9\"", Value = "3"}
            };
            ViewData["Genero"] = new SelectList(_dbContext.Genders.ToListAsync().Result.OrderBy(x => x.Description), "Id", "Description");
            ViewData["Nacionalidad"] = new SelectList(_dbContext.Nationalities.ToListAsync().Result.OrderBy(x => x.Description), "Id", "Description");
            ViewData["EstadoCivil"] = new SelectList(_dbContext.MatiralStatuses.ToListAsync().Result.OrderBy(x => x.Description), "Id", "Description");
            ViewData["NivelEducativo"] = new SelectList(_dbContext.EducativeTitles.ToListAsync().Result.OrderBy(x => x.Description), "Id", "Description");
            ViewData["Licencia"] = Licencia;
            ViewData["Vehiculo"] = Vehiculo;
            ViewData["CabezaHogar"] = CabezaHogar;
            ViewData["Estatura"] = Estatura;
            var profile = await _userManager.GetUserAsync(User);
            if (profile == null)
            {
                return NotFound($"Unable to load user with ID '{_userManager.GetUserId(User)}'.");
            }
            var Fpvm =await _profileServices.GetProfileById(profile.Id);
            if (Fpvm == null)
                return View(FPVM);
            else
                return View(Fpvm);
            
        }
        [ExportModelState]
        [HttpPost("/FullProfile")]
        public async Task<IActionResult> FullProfile([FromForm]FullProfileViewModel input)
        {
            var user = await _userManager.GetUserAsync(User);
            if (user == null) { return NotFound(); }

            if (input.ApplicationUserId == user.Id)
            {
                await _profileServices.UpdateProfileAsync(input);
            }
            else
            {
                input.ApplicationUserId = user.Id;
                await _profileServices.CreateProfileAsync(input);
            }
            StatusMessage = "Your profile has been updated";
            return RedirectToAction(nameof(FullProfile));
        }

        [ExportModelState]
        [HttpPost("/profile")]
        public async Task<IActionResult> UpdateProfile(
            [FromForm]
            ProfileViewModel input)
        {
            if (!ModelState.IsValid)
            {
                return RedirectToAction(nameof(Profile));
            }

            var user = await _userManager.GetUserAsync(User);
            if (user == null)
            {
                return NotFound($"Unable to load user with ID '{_userManager.GetUserId(User)}'.");
            }

            var email = await _userManager.GetEmailAsync(user);
            if (input.Email != email)
            {
                var setEmailResult = await _userManager.SetEmailAsync(user, input.Email);
                if (!setEmailResult.Succeeded)
                {
                    foreach (var error in setEmailResult.Errors)
                    {
                        ModelState.AddModelError(string.Empty, error.Description);
                    }
                }
            }

            // Model state might not be valid anymore if we weren't able to change the e-mail address
            // so we need to check for that before proceeding
            if (ModelState.IsValid)
            {
                if (input.FullName != user.FullName)
                {
                    // If we receive an empty string, set a null full name instead
                    user.FullName = string.IsNullOrWhiteSpace(input.FullName) ? null : input.FullName;
                }

                await _userManager.UpdateAsync(user);

                await _signInManager.RefreshSignInAsync(user);

                StatusMessage = "Your profile has been updated";
            }

            return RedirectToAction(nameof(Profile));
        }

        [HttpGet("/tables")]
        public IActionResult Tables()
        {
            return View();
        }

        [HttpGet("/Puestos")]
        public IActionResult Puestos()
        {
            return View();
        }

        [HttpPost("/logout")]
        public async Task<IActionResult> Logout(string returnUrl = null)
        {
            await _signInManager.SignOutAsync();
            _logger.LogInformation("User logged out.");
            if (returnUrl != null)
            {
                return LocalRedirect(returnUrl);
            }
            else
            {
                return RedirectToAction(nameof(Index));
            }
        }

        [HttpGet("/error")]
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        [HttpGet("/status-code")]
        public IActionResult StatusCodeHandler(int code)
        {
            ViewBag.StatusCode = code;
            ViewBag.StatusCodeDescription = ReasonPhrases.GetReasonPhrase(code);
            ViewBag.OriginalUrl = null;


            var statusCodeReExecuteFeature = HttpContext.Features.Get<IStatusCodeReExecuteFeature>();
            if (statusCodeReExecuteFeature != null)
            {
                ViewBag.OriginalUrl =
                    statusCodeReExecuteFeature.OriginalPathBase
                    + statusCodeReExecuteFeature.OriginalPath
                    + statusCodeReExecuteFeature.OriginalQueryString;
            }

            if (code == 404)
            {
                return View("Status404");
            }

            return View("Status4xx");
        }
    }
}
