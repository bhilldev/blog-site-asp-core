using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BlogSite.Models
{
    public class EFBlogPostRepository : IBlogPostRepository
    {
        private readonly BlogDbContext context;
        public IEnumerable<BlogPost> BlogPosts
        {
            get { return context.BlogPosts; }
        }


        public void SaveBlogPost(BlogPost blog)
        {
            if (blog.Id == 0)
            {
                context.BlogPosts.Add(blog);
            }
            else
            {
                BlogPost dbEntry = context.BlogPosts.Find(blog.Id);
                if (dbEntry != null)
                {
                    dbEntry.Title = blog.Title;
                    dbEntry.Content = blog.Content;
                    dbEntry.DateAdded = blog.DateAdded;


                }
            }
            context.SaveChanges();
        }
        public BlogPost DeleteBlogPost(int blogID)
        {
            BlogPost dbEntry = context.BlogPosts.Find(blogID);
            if (dbEntry != null)
            {
                context.BlogPosts.Remove(dbEntry);
                context.SaveChanges();
            }
            return dbEntry;
        }
    }
}
