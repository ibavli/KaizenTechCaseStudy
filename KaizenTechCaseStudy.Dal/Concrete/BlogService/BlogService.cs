using KaizenTechCaseStudy.Dal.Abstract.BlogService;
using KaizenTechCaseStudy.Dal.Manager.EntityFramework;
using KaizenTechCaseStudy.Entities.BlogEntities;
using System;
using System.Collections.Generic;
using System.Linq;

namespace KaizenTechCaseStudy.Dal.Concrete.BlogService
{
    //TODO Hepsini sp çevir
    public class BlogService : IBlogService
    {
        public bool AddNewBlog(Blogs blog)
        {
            using (var context = new DatabaseContext())
            {
                try
                {
                    context.Blogs.Add(blog);
                    context.SaveChanges();
                    return true;
                }
                catch (Exception ex)
                {
                    //TODO Loglama
                    return false;
                }
            }
        }

        public bool DeleteBlog(int blogId)
        {
            using (var context = new DatabaseContext())
            {
                try
                {
                    var blog = context.Blogs.FirstOrDefault(b => b.Id == blogId);
                    if (blog != null)
                    {
                        blog.Deleted = true;
                        context.SaveChanges();
                        return true;
                    }

                    return false;
                }
                catch (Exception ex)
                {
                    //TODO Loglama
                    return false;
                }
            }
        }

        public Blogs GetBlogById(int blogId)
        {
            using (var context = new DatabaseContext())
            {
                try
                {
                    var blog = context.Blogs.FirstOrDefault(b => b.Id == blogId);
                    return blog;
                }
                catch (Exception ex)
                {
                    //TODO Loglama
                    return null;
                }
            }
        }

        public List<Blogs> GetBlogList(string title = null, string description = null)
        {
            using (var context = new DatabaseContext())
            {
                try
                {
                    // Ortak filtreleme isteniyorsa && koşulu || çevrilebilir
                    var blogList = context.Blogs.Where(b => !b.Deleted &&
                    (title == null || b.BlogTitle.Contains(title)) &&
                    (description == null || b.BlogDescription.Contains(description))).ToList();
                    return blogList;
                }
                catch (Exception ex)
                {
                    //TODO Loglama
                    return null;
                }
            }
        }

        public bool UpdateBlog(Blogs blog)
        {
            using (var context = new DatabaseContext())
            {
                try
                {
                    var foundBlog = context.Blogs.Where(b => b.Id == blog.Id).FirstOrDefault();
                    if (foundBlog != null)
                    {
                        foundBlog.BlogTitle = blog.BlogTitle;
                        foundBlog.BlogDescription = blog.BlogDescription;
                        context.Blogs.Update(foundBlog);
                        context.SaveChanges();
                        return true;
                    }

                    return false;
                }
                catch (Exception ex)
                {
                    //TODO Loglama
                    return false;
                }
            }
        }
    }
}
