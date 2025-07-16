using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using BlogSite.Models;

namespace BlogSite.Controllers;

public class HomeController : Controller
{
    
    {
        IBlogRepository repository;
        public BlogController(IBlogRepository repPassedIn)
        {
            repository = repPassedIn; 
        }
        // GET: Blog
        public ActionResult InventoryList()
        {
            return View(repository.Blogs.OrderBy(p => p.DateAdded));
        }
        public ActionResult Edit(int blogId)
        {
            Blog blog = repository.Blogs.FirstOrDefault(p => p.BlogID == blogId);
            ViewBag.BlogID = new SelectList(repository.Blogs, "BlogID", "BlogModel", blog.BlogID);
            return View(blog);
        }

        [HttpPost]
        public ActionResult Edit(Blog blog)
        {
            if (ModelState.IsValid)
            {
                repository.SaveBlog(blog);
                TempData["message"] = string.Format("{0} has been saved", blog.BlogModel);
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
            ViewBag.BlogID = new SelectList(repository.Blogs, "BlogID", "BlogModel");
            return View("Edit", new Blog());
        }
        public ActionResult Delete(int BlogId)
        {
            Blog deletedBlog = repository.DeleteBlog(BlogId);
            if (deletedBlog != null)
            {
                TempData["message"] = string.Format("{0} was deleted", deletedBlog.BlogModel);
            }
            return RedirectToAction("InventoryList");
        }
    }
}
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
}
