using Microsoft.EntityFrameworkCore;

namespace KaizenTechCaseStudy.Dal.Abstract.DatabaseConfigurationServices
{
    public interface IDatabaseConfiguration
    {
        void Configuration(ref DbContextOptionsBuilder optionsBuilder);
    }
}
