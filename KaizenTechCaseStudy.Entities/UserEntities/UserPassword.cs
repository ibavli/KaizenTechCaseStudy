
namespace KaizenTechCaseStudy.Entities.UserEntities
{
    public class UserPassword : BaseEntity
    {
        public string Password { get; set; }

        public string Salt { get; set; }
    }
}
