using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogSite.Models
{
    public interface IBlogPostRepository
    {
        IEnumerable<BlogPost> BlogPosts { get; }
        void SaveBlogPost(BlogPost blogPost);
        BlogPost DeleteBlogPost(int BlogID);
    }
}
