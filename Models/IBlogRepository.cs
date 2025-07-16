using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogSite.Models
{
    public interface IBlogRepository
    {
        IEnumerable<Blog> Blogs { get; }
        void SaveBlog(Blog blog);
        Blog DeleteBlog(int BlogID); } }
