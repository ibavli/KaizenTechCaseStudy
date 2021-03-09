using KaizenTechCaseStudy.Dal.Abstract.DatabaseConfigurationServices;
using KaizenTechCaseStudy.Dal.Models.DatabaseModels;
using Microsoft.EntityFrameworkCore;

namespace KaizenTechCaseStudy.Dal.Concrete.DatabaseConfigurationServices
{
    public class MySqlConfiguration : IDatabaseConfiguration
    {
        public void Configuration(ref DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                var connectionString = DatabaseConnectionClass.ConnectionString;
                optionsBuilder.UseSqlServer(connectionString);
            }
        }
    }
}
