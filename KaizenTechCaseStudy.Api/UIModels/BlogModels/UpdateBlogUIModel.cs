using System.ComponentModel.DataAnnotations;

namespace KaizenTechCaseStudy.Api.UIModels.BlogModels
{
    public class UpdateBlogUIModel
    {
        [Required]
        public int Id { get; set; }

        [Required]
        public string BlogTitle { get; set; }

        [Required]
        public string BlogDescription { get; set; }
    }
}
