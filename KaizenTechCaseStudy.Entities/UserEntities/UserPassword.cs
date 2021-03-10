
namespace KaizenTechCaseStudy.Entities.UserEntities
{
    public class UserPassword : BaseEntity
    {
        public int UserId { get; set; }

        public string Password { get; set; }

        public string Salt { get; set; }
    }
}
