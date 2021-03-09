using KaizenTechCaseStudy.Entities.UserEntities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace KaizenTechCaseStudy.Mappings.UserMap
{
    public class UserPasswordMap : BaseEntityMap<UserPassword>
    {
        public override void Configure(EntityTypeBuilder<UserPassword> entityTypeBuilder)
        {
            base.Configure(entityTypeBuilder);
            entityTypeBuilder.Property(e => e.Password).IsRequired();
            entityTypeBuilder.Property(e => e.Salt).IsRequired();
            entityTypeBuilder.ToTable(typeof(UserPassword).Name);
        }
    }
}
