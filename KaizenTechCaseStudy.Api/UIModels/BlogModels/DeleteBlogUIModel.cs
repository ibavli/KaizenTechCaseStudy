using System.ComponentModel.DataAnnotations;

namespace KaizenTechCaseStudy.Api.UIModels.BlogModels
{
    public class DeleteBlogUIModel
    {
        [Required]
        public int BlogId { get; set; }
    }
}
