using System.ComponentModel.DataAnnotations;

namespace KaizenTechCaseStudy.Api.UIModels.UserModels
{
    public class DeleteUserUIModel
    {
        [Required]
        public int UserId { get; set; }
    }
}
