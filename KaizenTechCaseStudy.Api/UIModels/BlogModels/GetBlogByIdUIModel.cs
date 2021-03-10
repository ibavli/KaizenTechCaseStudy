using System.ComponentModel.DataAnnotations;

namespace KaizenTechCaseStudy.Api.UIModels.BlogModels
{
    public class GetBlogByIdUIModel
    {
        [Required]
        public int BlogId { get; set; }
    }
}
