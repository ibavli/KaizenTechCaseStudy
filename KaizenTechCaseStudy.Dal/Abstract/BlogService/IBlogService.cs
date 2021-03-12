using KaizenTechCaseStudy.Entities.BlogEntities;
using System.Collections.Generic;

namespace KaizenTechCaseStudy.Dal.Abstract.BlogService
{
    public interface IBlogService
    {
        bool AddNewBlog(Blogs blog);

        bool UpdateBlog(Blogs blog);

        bool DeleteBlog(int blogId);

        Blogs GetBlogById(int blogId);

        List<Blogs> GetBlogList(string title = null, string description = null);
    }
}
