using System.ComponentModel.DataAnnotations;

namespace KaizenTechCaseStudy.Api.UIModels.UserModels
{
    public class GetUserByIdUIModel
    {
        [Required]
        public int UserId { get; set; }
    }
}
