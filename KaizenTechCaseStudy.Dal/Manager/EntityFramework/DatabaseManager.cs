using KaizenTechCaseStudy.Dal.Abstract.DatabaseConfigurationServices;
using Microsoft.EntityFrameworkCore;

namespace KaizenTechCaseStudy.Dal.Manager.EntityFramework
{
    public class DatabaseManager
    {
        private IDatabaseConfiguration _databaseConfiguration;

        public DatabaseManager(IDatabaseConfiguration databaseConfiguration)
        {
            _databaseConfiguration = databaseConfiguration;
        }

        public void Configuration(ref DbContextOptionsBuilder dbContextOptionsBuilder)
        {
            _databaseConfiguration.Configuration(ref dbContextOptionsBuilder);
        }
    }
}
