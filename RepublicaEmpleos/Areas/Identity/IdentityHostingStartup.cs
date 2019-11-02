using Microsoft.AspNetCore.Hosting;

[assembly: HostingStartup(typeof(RepublicaEmpleos.Areas.Identity.IdentityHostingStartup))]
namespace RepublicaEmpleos.Areas.Identity
{
    public class IdentityHostingStartup : IHostingStartup
    {
        public void Configure(IWebHostBuilder builder)
        {
            builder.ConfigureServices((context, services) => {
            });
        }
    }
}