using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;
using RepublicaEmpleos.Models.Identity;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using System.Text.Encodings.Web;
using RepublicaEmpleos.Services.Interfaces;
using AutoMapper;
using RepublicaEmpleos.Models;
using System.Collections.Generic;

namespace RepublicaEmpleos.Areas.Identity.Pages.Account
{
    [AllowAnonymous]
    public class RegisterModel : PageModel
    {
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly ILogger<RegisterModel> _logger;
        //private readonly IEmailSender _emailSender;
        private readonly IProfileServices _profileServices;
        private readonly FullProfileViewModel FPVM = new FullProfileViewModel();

        public RegisterModel(
            UserManager<ApplicationUser> userManager,
            SignInManager<ApplicationUser> signInManager,
            ILogger<RegisterModel> logger,
            //IEmailSender emailSender,
            IProfileServices profileServices)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _logger = logger;
           // _emailSender = emailSender;
            _profileServices = profileServices;
        }

        [BindProperty]
        public InputModel Input { get; set; }

        public string ReturnUrl { get; set; }

        public class InputModel
        {
            [Required]
            [StringLength(100, ErrorMessage = "The {0} must be at least {2} and at max {1} characters long.", MinimumLength = 2)]
            [Display(Name = "Nombre De Usuario")]
            //[RegularExpression(pattern: "/[^a-zA-Z0-9]/", ErrorMessage = "El {0} solo acepta Caracteres alphanumericos")]
            public string FullName { get; set; }
            
            [Required]
            [StringLength(100, ErrorMessage = "The {0} must be at least {2} and at max {1} characters long.", MinimumLength = 2)]
            [Display(Name = "Numero de telefono")]
            //[RegularExpression(pattern: "/(809|849|829){1}(-){1}[0-9]{3}(-)[0-9]{4}/", ErrorMessage = "El formato es incorrecto")]
            public string PhoneNumber { get; set; }

            [Required]
            [EmailAddress]
            [Display(Name = "Email")]
            public string Email { get; set; }

            [Required]
            [StringLength(100, ErrorMessage = "The {0} must be at least {2} and at max {1} characters long.", MinimumLength = 6)]
            [DataType(DataType.Password)]
            [Display(Name = "Password")]
            public string Password { get; set; }

            [Required]
            [DataType(DataType.Password)]
            [Display(Name = "Confirm password")]
            [Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
            public string ConfirmPassword { get; set; }

            [Required]
            public bool AcceptPrivacyPolicy { get; set; }
        }

        public void OnGet(string returnUrl = null)
        {
            ReturnUrl = returnUrl;
        }

        public async Task<IActionResult> OnPostAsync(string returnUrl = null)
        {
            returnUrl ??= Url.Content("~/");
            if (!Input.AcceptPrivacyPolicy)
            {
                ModelState.AddModelError(string.Empty, "You must accept the Privacy Policy in order to register");
            }
            else if (ModelState.IsValid)
            {
                var user = new ApplicationUser
                {
                    UserName = Input.Email,
                    Email = Input.Email,
                    // Remove the code below to require the user to confirm their e-mail
                    EmailConfirmed = true,
                    // Custom fields next
                    FullName = Input.FullName,
                    PhoneNumber = Input.PhoneNumber
                };
                var result = await _userManager.CreateAsync(user, Input.Password);
                if (result.Succeeded)
                {
                    _logger.LogInformation("User created a new account with password.");

                    // Uncomment the code below to enable sending a confirmation e-mail

                    //var code = await _userManager.GenerateEmailConfirmationTokenAsync(user);
                    //var callbackUrl = Url.Page(
                    //    "/Account/ConfirmEmail",
                    //    pageHandler: null,
                    //    values: new { userId = user.Id, code },
                    //    protocol: Request.Scheme);

                    //await _emailSender.SendEmailAsync(Input.Email, "Confirm your email",
                    //    $"Please confirm your account by <a href='{HtmlEncoder.Default.Encode(callbackUrl)}'>clicking here</a>.");


                    await _signInManager.SignInAsync(user, isPersistent: false);
                    FPVM.ApplicationUserId = user.Id;
                    FPVM.Name = user.FullName;
                    FPVM.ProfileEmails = new List<Email> {
                        new Email
                        {
                            Description = user.Email
                        }
                    };
                    FPVM.Phones = new List<Phone>
                    {
                        new Phone
                        {
                            Description = user.PhoneNumber
                        }
                    };
                    await _profileServices.CreateProfileAsync(FPVM);
                    return LocalRedirect(returnUrl);
                }
                foreach (var error in result.Errors)
                {
                    // We are setting the username to be the same as the e-mail address in the
                    // section above, so avoid complaining about the username when it is duplicated
                    if (error.Code == "DuplicateUserName") continue;
                    ModelState.AddModelError(string.Empty, error.Description);
                }
            }

            // If we got this far, something failed, redisplay form
            return Page();
        }
    }
}
