using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RepublicaEmpleos.Data
{
    public class ApplicationDbContextDeployd:IdentityDbContext
    {
        public ApplicationDbContextDeployd(DbContextOptions<ApplicationDbContextDeployd> options)
            : base(options)
        {
        }
    }
}
