using System;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using RepublicaEmpleos.Data;
using RepublicaEmpleos.Infrastructure;
using RepublicaEmpleos.Infrastructure.ApplicationUserClaims;
using RepublicaEmpleos.Infrastructure.AppSettingsModels;
using RepublicaEmpleos.Models.Identity;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.HttpOverrides;
using Microsoft.AspNetCore.Mvc.ApplicationModels;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using RepublicaEmpleos.Services.Interfaces;
using RepublicaEmpleos.Services;
using AutoMapper;
using Microsoft.Extensions.Hosting;
using Newtonsoft.Json.Serialization;
using RepublicaEmpleos.Core.Extensionsmethods;
using RepublicaEmpleos.Models;

namespace RepublicaEmpleos
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }
        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.Configure<ForwardedHeadersOptions>(options =>
            {
                options.ForwardedHeaders =
                    ForwardedHeaders.XForwardedFor | ForwardedHeaders.XForwardedProto;
            });
            services.AddHealthChecks();
            services.Configure<CookiePolicyOptions>(options =>
            {
                // This lambda determines whether user consent for non-essential cookies is needed for a given request.
                options.CheckConsentNeeded = context => true;
                options.MinimumSameSitePolicy = SameSiteMode.Strict;
            });

            services.AddAutoMapper(typeof(Startup));
            services.AddCustomRazonPage();
            services.AddDbContext<ApplicationDbContext>(options =>
            {
                // options.UseSqlite(Configuration.GetConnectionString("SqliteConnection"));
                options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection"));
            });
            services.AddIdentity<ApplicationUser, IdentityRole>()
                .AddEntityFrameworkStores<ApplicationDbContext>();

            services.AddScoped<IUserClaimsPrincipalFactory<ApplicationUser>, ApplicationUserClaimsPrincipalFactory>();
            services.AddScoped<IProfileServices, ProfileServices>();
            services.AddScoped<IPhoneServices<Phone>, PhoneServices>();
            services.AddScoped<IEmailServices<Email>, EmailServices>();
            services.AddScoped<ILanguajeServices<ProfileLanguage>, LanguageServices>();
            services.AddScoped(typeof(IGenericInterface<ProfileDocType>), typeof(DocTypeServices));
            services.AddScoped(typeof(IGenericInterface<Vehicle>), typeof(VehicleServices));

            services.Configure<IdentityOptions>(options =>
            {
                // Default Lockout settings.
                options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(1);
                options.Lockout.MaxFailedAccessAttempts = 5;
                options.Lockout.AllowedForNewUsers = true;

                // Default Password settings.
                options.Password.RequireDigit = true;
                options.Password.RequireLowercase = true;
                options.Password.RequireNonAlphanumeric = true;
                options.Password.RequireUppercase = true;
                options.Password.RequiredLength = 6;
                options.Password.RequiredUniqueChars = 1;

                // Default SignIn settings.
                options.SignIn.RequireConfirmedEmail = false;
                options.SignIn.RequireConfirmedPhoneNumber = false;

                // Default User settings.
                options.User.AllowedUserNameCharacters =
                    "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789-._@+";
                options.User.RequireUniqueEmail = true;
            });

            services.ConfigureApplicationCookie(options =>
            {
                options.Cookie.Name = "RepublicaEmpleos.AppCookie";
                options.Cookie.HttpOnly = true;
                options.Cookie.IsEssential = true;
                // You might want to only set the application cookies over a secure connection:
                // options.Cookie.SecurePolicy = CookieSecurePolicy.Always;
                options.Cookie.SameSite = SameSiteMode.Strict;
                options.ExpireTimeSpan = TimeSpan.FromMinutes(15);
                options.SlidingExpiration = true;
            });

            // As per https://github.com/aspnet/AspNetCore/issues/5828
            // the settings for the cookie would get overwritten if using the default UI so
            // we need to "post-configure" the authentication cookie
            services.PostConfigure<CookieAuthenticationOptions>(IdentityConstants.ApplicationScheme, options =>
            {
                options.AccessDeniedPath = "/access-denied";
                options.LoginPath = "/login";
                options.LogoutPath = "/logout";

                options.ReturnUrlParameter = CookieAuthenticationDefaults.ReturnUrlParameter;
            });

            /*services.AddDataProtection()
                .PersistKeysToDbContext<ApplicationDbContext>();*/

            services.AddAntiforgery();

            services.Configure<ScriptTags>(Configuration.GetSection(nameof(ScriptTags)));
            services.AddRazorPages();
            services.AddMvc(options =>
            {
                // Slugify routes so that we can use /Phone/Phone-details/1 instead of
                // the default /Phone/PhoneDetails/1
                //
                // Using an outbound parameter transformer is a better choice as it also allows
                // the creation of correct routes using view helpers
                options.Conventions.Add(
                    new RouteTokenTransformerConvention(
                        new SlugifyParameterTransformer()));
                //options.Filters.Add(new AutoValidateAntiforgeryTokenAttribute());
            }).AddNewtonsoftJson(options => 
            {
                options.SerializerSettings.ContractResolver = new CamelCasePropertyNamesContractResolver();
                options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore;
            })
            .AddRazorPagesOptions(options =>
            {
                // Perform the same slugify configuration for Razor pages
                options.Conventions.Add(
                    new PageRouteTransformerConvention(
                        new SlugifyParameterTransformer()));
                options.Conventions.AddAreaPageRoute("Identity", "/Account/Register", "/register");
                options.Conventions.AddAreaPageRoute("Identity", "/Account/Login", "/login");
                options.Conventions.AddAreaPageRoute("Identity", "/Account/Logout", "/logout");
                options.Conventions.AddAreaPageRoute("Identity", "/Account/ForgotPassword", "/forgot-password");
                options.Conventions.AddAreaPageRoute("Admin", "/Casa/index", "/index");
            }).AddSessionStateTempDataProvider();
            // You probably want to use in-memory cache if not developing using docker-compose
            // services.AddMemoryCache();
            //services.AddDistributedRedisCache(action => { action.Configuration = Configuration["Redis:InstanceName"]; });

            services.AddSession(options =>
            {
                // Set a short timeout for easy testing.
                options.IdleTimeout = TimeSpan.FromMinutes(60);
                options.Cookie.Name = "RepublicaEmpleos.SessionCookie";
                // You might want to only set the application cookies over a secure connection:
                // options.Cookie.SecurePolicy = CookieSecurePolicy.Always;
                options.Cookie.SameSite = SameSiteMode.Strict;
                options.Cookie.HttpOnly = true;
                // Make the session cookie essential
                options.Cookie.IsEssential = true;
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            // This is required to make the application work behind a proxy like NGINX or HAPROXY
            // that also provides TLS termination (switching from incoming HTTPS to HTTP)
            app.UseForwardedHeaders();

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseDatabaseErrorPage();
            }
            else
            {
                app.UseExceptionHandler("/error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseStatusCodePagesWithReExecute("/status-code", "?code={0}");

            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseCookiePolicy();
            app.UseRouting();
            app.UseAuthorization();
            app.UseAuthentication();
            app.UseSession();
            app.UseEndpoints(endpoint =>
            {
                endpoint.MapRazorPages();
                endpoint.MapHealthChecks("/health");
                endpoint.MapControllerRoute("default", "{controller=home}/{action=index}/{id?}");
                endpoint.MapControllerRoute("Admin", "{area:exists}/{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
