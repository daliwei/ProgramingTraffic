using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ProgramingTraffic.Core;
using ProgramingTraffic.Models;
using System.IO;

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

        public ViewResult Posts(int page= 1)
        {
            // pick latest 10 posts
            var viewModel = new ListViewModel(_blogRepository, page);

            ViewBag.Title = "Programing Traffic";

            return View("List", viewModel);
        }

        public ActionResult InfinateScroll(int page=1)
        {
            // pick latest 10 posts
            var viewModel = new ListViewModel(_blogRepository, page);
            JsonModel_ListView jsonModel = new JsonModel_ListView();
            jsonModel.NoMoreData = page >= viewModel.totalPages;
            jsonModel.HTMLString = RenderPartialViewToString("_PartialList", viewModel.Posts);

            if (HttpContext.Request.HttpMethod == "get")
                return Json(jsonModel, JsonRequestBehavior.AllowGet);
            else
                return Json(jsonModel);
            //return PartialView("List_Partial", viewModel);
        }

        protected string RenderPartialViewToString(string viewName, object model)
        {
            if (string.IsNullOrEmpty(viewName))
                viewName = ControllerContext.RouteData.GetRequiredString("action");

            ViewData.Model = model;

            using (StringWriter sw = new StringWriter())
            {
                ViewEngineResult viewResult = ViewEngines.Engines.FindPartialView(ControllerContext, viewName);
                ViewContext viewContext = new ViewContext(ControllerContext, viewResult.View, ViewData, TempData, sw);
                viewResult.View.Render(viewContext, sw);

                return sw.GetStringBuilder().ToString();
            }
        }
    }
}