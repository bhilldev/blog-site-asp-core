using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BlogsForSale.Models
{
    public class EFBlogRepository : IBlogRepository
    {
        private EFDbContext context = new EFDbContext();
        public IEnumerable<Blog> Blogs
        {
            get { return context.Blogs; }
        }


        public void SaveBlog(Blog blog)
        {
            if (blog.BlogID == 0)
            {
                context.Blogs.Add(blog);
            }
            else
            {
                Blog dbEntry = context.Blogs.Find(blog.BlogID);
                if (dbEntry != null)
                {
                    dbEntry.Title = blog.Title;
                    dbEntry.Content = blog.Content;
                    dbEntry.DateAdded = blog.DateAdded;


                }
            }
            context.SaveChanges();
        }
        public Blog DeleteBlog(int productID)
        {
            Blog dbEntry = context.Blogs.Find(blogID);
            if (dbEntry != null)
            {
                context.Blogs.Remove(dbEntry);
                context.SaveChanges();
            }
            return dbEntry;
        }
    }
}
