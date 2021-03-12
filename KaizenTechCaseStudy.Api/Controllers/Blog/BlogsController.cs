using KaizenTechCaseStudy.Api.UIModels.BlogModels;
using KaizenTechCaseStudy.Dal.Abstract.BlogService;
using KaizenTechCaseStudy.Entities.BlogEntities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace KaizenTechCaseStudy.Api.Controllers.Blog
{
    [Authorize]
    [ApiController]
    [Route("[controller]")]
    public class BlogsController : Controller
    {
        //TODO Resource'dan çekilecek
        private readonly string _invalidMessage = "Lütfen girdiğiniz bilgileri kontrol edin";

        private readonly IBlogService _blogService;

        public BlogsController(IBlogService blogService)
        {
            _blogService = blogService;
        }

        [HttpPost("addnewblog")]
        public IActionResult AddNewBlog([FromBody]AddNewBlogUIModel model)
        {
            #region Check if the model is valid.

            if (!ModelState.IsValid)
                return BadRequest(new { message = _invalidMessage });

            #endregion

            //TODO nugetten AutoMapper indirip, mapper işlemi yap
            Blogs blog = new Blogs()
            {
                BlogTitle = model.BlogTitle,
                BlogDescription = model.BlogDescription
            };

            bool result = _blogService.AddNewBlog(blog: blog);

            if (result)
                return Ok();
            else
                return NotFound();
        }

        [HttpPost("deleteblog")]
        public IActionResult DeleteBlog([FromBody]DeleteBlogUIModel model)
        {
            #region Check if the model is valid.

            if (!ModelState.IsValid)
                return BadRequest(new { message = _invalidMessage });

            #endregion

            bool result = _blogService.DeleteBlog(blogId: model.Id);

            if (result)
                return Ok();
            else
                return NotFound();
        }

        [HttpPost("getblogbyid")]
        public IActionResult GetBlogById([FromBody]GetBlogByIdUIModel model)
        {
            #region Check if the model is valid.

            if (!ModelState.IsValid)
                return BadRequest(new { message = _invalidMessage });

            #endregion

            var blog = _blogService.GetBlogById(blogId: model.Id);

            if (blog != null)
                return Ok(blog);
            else
                return NotFound();
        }

        //TODO Filtre için model ekle
        [HttpGet("getbloglist")]
        public IActionResult GetBlogList()
        {
            var blogList = _blogService.GetBlogList();

            if (blogList != null)
                return Ok(blogList);
            else
                return NotFound();
        }

        [HttpPost("updateblog")]
        public IActionResult UpdateBlog([FromBody]UpdateBlogUIModel model)
        {
            #region Check if the model is valid.

            if (!ModelState.IsValid)
                return BadRequest(new { message = _invalidMessage });

            #endregion

            //TODO nugetten AutoMapper indirip, mapper işlemi yap
            Blogs blog = new Blogs()
            {
                Id = model.Id,
                BlogTitle = model.BlogTitle,
                BlogDescription = model.BlogDescription
            };

            bool result = _blogService.UpdateBlog(blog: blog);

            if (result)
                return Ok();
            else
                return NotFound();
        }
    }
}
