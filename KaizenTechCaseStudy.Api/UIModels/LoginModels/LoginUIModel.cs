using System.ComponentModel.DataAnnotations;

namespace KaizenTechCaseStudy.Api.UIModels.LoginModels
{
    public class LoginUIModel
    {
        [Required]
        public string Username { get; set; }

        [Required]
        public string Password { get; set; }
    }
}
