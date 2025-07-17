using System.Diagnostics;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc;
using BlogSite.Models;

namespace BlogSite.Controllers
{
    public class BlogPostController : Controller
    {
        IBlogPostRepository repository;
        public BlogPostController(IBlogPostRepository repPassedIn)
        {
            repository = repPassedIn; 
        }
        // GET: BlogPost
        public ActionResult BlogPostList()
        {
            return View(repository.BlogPosts.OrderBy(p => p.DateAdded));
        }
        public ActionResult Edit(int blogId)
        {
            BlogPost blog = repository.BlogPosts.FirstOrDefault(p => p.Id == blogId);
            ViewBag.Id = new SelectList(repository.BlogPosts, "Id", "Title", blog.Id);
            return View(blog);
        }

        [HttpPost]
        public ActionResult Edit(BlogPost blog)
        {
            if (ModelState.IsValid)
            {
                repository.SaveBlogPost(blog);
                TempData["message"] = string.Format("{0} has been saved", blog.Title);
                return RedirectToAction("InventoryList");
            }
            else
            {
                // there is something wrong with the data values                
                return View(blog);
            }
        }
        public ActionResult Create()
        {
            ViewBag.Id = new SelectList(repository.BlogPosts, "Id", "Title");
            return View("Edit", new BlogPost());
        }
        public ActionResult Delete(int BlogPostId)
        {
            BlogPost deletedBlogPost = repository.DeleteBlogPost(BlogPostId);
            if (deletedBlogPost != null)
            {
                TempData["message"] = string.Format("{0} was deleted", deletedBlogPost.Title);
            }
            return RedirectToAction("InventoryList");
        }

/*
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
*/
    }
    
}
