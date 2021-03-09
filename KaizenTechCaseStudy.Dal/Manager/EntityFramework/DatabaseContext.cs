using KaizenTechCaseStudy.Dal.Concrete.DatabaseConfigurationServices;
using KaizenTechCaseStudy.Entities.BlogEntities;
using KaizenTechCaseStudy.Entities.UserEntities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace KaizenTechCaseStudy.Dal.Manager.EntityFramework
{
    public class DatabaseContext : DbContext
    {
        #region Properties

        public DbSet<Users> Users { get; set; }
        public DbSet<UserPassword> UserPassword { get; set; }
        public DbSet<Blogs> Blogs { get; set; }

        #endregion

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            DatabaseManager databaseManager = new DatabaseManager(new MySqlConfiguration());
            databaseManager.Configuration(ref optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            var mappingTypes = GetMappingTypes();

            foreach (var type in mappingTypes)
            {
                dynamic configurationInstance = Activator.CreateInstance(type);
                modelBuilder.ApplyConfiguration(configurationInstance);
            }
        }

        #region Utilities Functions

        private IEnumerable<Type> GetMappingTypes()
        {
            Type[] types = Assembly.Load("KaizenTechCaseStudy.Mappings").GetTypes();
            return types?.Where(type => type.BaseType.Name.StartsWith("BaseEntityMap"));
        }

        #endregion
    }
}
