﻿using RepublicaEmpleos.Models.Identity;
//using Microsoft.AspNetCore.DataProtection.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using RepublicaEmpleos.Models;

namespace RepublicaEmpleos.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<ProfileAddress>()
                .HasKey(pa => new { pa.AddressID, pa.ProfileID });
            modelBuilder.Entity<Email>()
                .Property(x => x.Id)
                .ValueGeneratedOnAdd();
            modelBuilder.Entity<Phone>()
                .Property(f => f.Id)
                .ValueGeneratedOnAdd();
            modelBuilder.Entity<ProfileDocType>()
                .HasKey(pdt => new { pdt.ProfileID, pdt.DocTypeID});
            modelBuilder.Entity<Vehicle>(b =>
            {
                b.HasKey(pf => new { pf.Id, pf.ProfileId });
                b.Property(e=>e.Id).ValueGeneratedOnAdd();
            });

            modelBuilder.Entity<ProfileLanguage>(b =>
            {
                b.HasKey(PL => new { PL.LanguageId, PL.ProfileId });
            });
        }

        //public DbSet<DataProtectionKey> DataProtectionKeys { get; set; }
        public DbSet<Address> Addresses { get; set; }
        public DbSet<City> Cities { get; set; }
        public DbSet<Country> Countries { get; set; }
        public DbSet<EducativeTitle> EducativeTitles { get; set; }
        public DbSet<Email> Emails { get; set; }
        public DbSet<Gender> Genders { get; set; }
        public DbSet<MatiralStatus> MatiralStatuses { get; set; }
        public DbSet<Nationality> Nationalities { get; set; }
        public DbSet<Neighborhood> Neighborhoods { get; set; }
        public DbSet<Phone> Phones { get; set; }
        public DbSet<Profile> Profiles { get; set; }
        public DbSet<Sector> Sectors { get; set; }
        public DbSet<Vehicle> Vehicles { get; set; }
        public DbSet<VehicleType> VehicleTypes { get; set; }
        public DbSet<DocType> DocTypes { get; set; }
        public DbSet<ProfileDocType> ProfileDocType { get; set; }
        public DbSet<Languaje> Languajes { get; set; }
        public DbSet<ProfileLanguage> ProfileLanguages { get; set; }
    }
}
