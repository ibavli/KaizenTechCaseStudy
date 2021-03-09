using KaizenTechCaseStudy.Entities.BlogEntities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace KaizenTechCaseStudy.Mappings.BlogMap
{
    public class BlogsMap : BaseEntityMap<Blogs>
    {
        public override void Configure(EntityTypeBuilder<Blogs> entityTypeBuilder)
        {
            base.Configure(entityTypeBuilder);
            entityTypeBuilder.Property(e => e.BlogTitle).IsRequired();
            entityTypeBuilder.Property(e => e.BlogDescription).IsRequired();
            entityTypeBuilder.ToTable(typeof(Blogs).Name);
        }
    }
}
