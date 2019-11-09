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

namespace RepublicaEmpleos.Controllers
{
    [AllowAnonymous]
    public class HomeController : BaseController
    {
        private readonly ApplicationDbContextDeployd _db;
        private readonly ILogger<HomeController> _logger;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;

        [TempData]
        public string StatusMessage { get; set; }

        public HomeController(
            ApplicationDbContextDeployd db,
            ILogger<HomeController> logger,
            UserManager<ApplicationUser> userManager,
            SignInManager<ApplicationUser> signInManager)
        {
            _db = db;
            _logger = logger;
            _userManager = userManager;
            _signInManager = signInManager;
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
        public async Task<IActionResult> FullProfile()
        {
            var genero = new List<SelectListItem> {
                new SelectListItem() {Text = "Masculino", Value = "1", Selected=true},
                new SelectListItem() {Text = "Femenino", Value = "2"},
                new SelectListItem() {Text = "No Binario", Value = "3"}
            };
            var Nacionalidad = new List<SelectListItem> {
                new SelectListItem() {Text = "Dominicano", Value = "1", Selected=true},
            };
            var EstadoCivil = new List<SelectListItem> {
                new SelectListItem() {Text = "Soltero", Value = "1", Selected=true},
                new SelectListItem() {Text = "Casado", Value = "2"},
                new SelectListItem() {Text = "union libre", Value = "3"}
            };
            var NivelEducativo = new List<SelectListItem> {
                new SelectListItem() {Text = "Estudiante", Value = "1", Selected=true},
                new SelectListItem() {Text = "Universitario", Value = "2"},
                new SelectListItem() {Text = "Bachiller", Value = "3"}
            };
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

            ViewData["Genero"] = genero;
            ViewData["Nacionalidad"] = Nacionalidad;
            ViewData["EstadoCivil"] = EstadoCivil;
            ViewData["NivelEducativo"] = NivelEducativo;
            ViewData["Licencia"] = Licencia;
            ViewData["Vehiculo"] = Vehiculo;
            ViewData["CabezaHogar"] = CabezaHogar;
            ViewData["Estatura"] = Estatura;

            var Profile = await _userManager.GetUserAsync(User);
            if (Profile == null)
            {
                return NotFound($"Unable to load user with ID '{_userManager.GetUserId(User)}'.");
            }
            return View(new ProfileViewModel
            {
                Email = Profile.Email,
                FullName = Profile.FullName,
                account = new ApplicationUser
                {
                    BirthDate = Profile.BirthDate,
                    PhoneNumber = Profile.PhoneNumber,
                    JobDescription = Profile.JobDescription
                }
            });
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

        [HttpGet("/privacy")]
        public IActionResult Privacy()
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
