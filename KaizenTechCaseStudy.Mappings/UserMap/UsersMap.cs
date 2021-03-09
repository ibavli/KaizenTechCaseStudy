using KaizenTechCaseStudy.Entities.UserEntities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace KaizenTechCaseStudy.Mappings.UserMap
{
    public class UsersMap : BaseEntityMap<Users>
    {
        public override void Configure(EntityTypeBuilder<Users> entityTypeBuilder)
        {
            base.Configure(entityTypeBuilder);
            entityTypeBuilder.Property(e => e.Email).IsRequired();
            entityTypeBuilder.Property(e => e.Username).IsRequired().HasMaxLength(100);
            entityTypeBuilder.ToTable(typeof(Users).Name);
        }
    }
}
