using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ProgramingTraffic.Core;
using ProgramingTraffic.Models;

namespace ProgramingTraffic.Controllers
{
    public class BlogController : Controller
    {
        private readonly IBlogRepository _blogRepository;

        public BlogController(IBlogRepository blogRepository)
        {
            _blogRepository = blogRepository;
        }

        // GET: Blog
        public ActionResult Index()
        {
            return View();
        }

        public ViewResult Posts(int p=1)
        {
            // pick latest 10 posts
            var viewModel = new ListViewModel(_blogRepository, p);

            ViewBag.Title = "Programing Traffic";

            return View("List", viewModel);
        }
    }
}