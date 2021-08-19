using Core.Entities.Concrete;
using DataAccess.Concrete.EntityFramework.Mappings;
using Entities.Concrete;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Concrete.EntityFramework.Contexts
{
    public class SeyirContext :DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (optionsBuilder.IsConfigured) return;
            optionsBuilder.UseSqlServer("Server=(localdb)\\MSSQLLocalDB;Database=FrameworkStartup;Trusted_Connection=true;");

        }

        public DbSet<Language> Languages { get; set; }
        public DbSet<OperationClaim> OperationClaims { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<UserOperationClaim> UserOperationClaims { get; set; }
        public DbSet<Session> Sessions { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            #region System
            modelBuilder.ApplyConfiguration(new LanguageMap());
            modelBuilder.ApplyConfiguration(new SessionMap());
            //modelBuilder.ApplyConfiguration(new LookupMap());
            //modelBuilder.ApplyConfiguration(new LookupResourceMap());
            //modelBuilder.ApplyConfiguration(new LanguageResourceMap());

            #region System_Auth
            //modelBuilder.ApplyConfiguration(new TableOperationMap());
            //modelBuilder.ApplyConfiguration(new AuthorizationMap());
            //modelBuilder.ApplyConfiguration(new UserMap());
            //modelBuilder.ApplyConfiguration(new DealerOrganizationChartMap());
            #endregion
            #endregion

            #region Adress

            //modelBuilder.ApplyConfiguration(new CountryMap());
            //modelBuilder.ApplyConfiguration(new CityMap());
            //modelBuilder.ApplyConfiguration(new TownMap());
            //modelBuilder.ApplyConfiguration(new DistrictMap());
            //modelBuilder.ApplyConfiguration(new NeighborhoodMap());

            #endregion
        }
    }
}
