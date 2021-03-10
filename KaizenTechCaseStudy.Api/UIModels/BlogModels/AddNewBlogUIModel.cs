using System.ComponentModel.DataAnnotations;

namespace KaizenTechCaseStudy.Api.UIModels.BlogModels
{
    public class AddNewBlogUIModel
    {
        [Required]
        public string BlogTitle { get; set; }

        [Required]
        public string BlogDescription { get; set; }
    }
}
