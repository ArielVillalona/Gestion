using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using RepublicaEmpleos.Models.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RepublicaEmpleos.Data
{
    public class ApplicationDbContextDeployd : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContextDeployd(DbContextOptions<ApplicationDbContextDeployd> options)
            : base(options)
        {
        }
    }
}
