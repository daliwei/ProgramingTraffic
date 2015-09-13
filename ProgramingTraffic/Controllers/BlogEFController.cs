using ProgramingTraffic.Core.Objects;
using ProgramingTraffic.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ProgramingTraffic.Controllers
{
    public class BlogEFController : Controller
    {
        private readonly BlogContext _blogContext = new BlogContext();

        public ViewResult Posts(int page = 1)
        {
            // pick latest 10 posts
            var viewModel = new ListViewModel(_blogContext, page);

            ViewBag.Title = "Programing Traffic";

            return View("FullList", viewModel);
        }

        public ActionResult Category()
        {
            //pick up the categories from database
            var categoryModel = new CategoryViewModel(_blogContext);
            List<JsonModel_CategoryView> jsonmodel = new List<JsonModel_CategoryView>();

            foreach (Category c in categoryModel.Categories)
            {
                var categoryJsonModel = new JsonModel_CategoryView();
                using (StringWriter sw = new StringWriter())
                {
                    ViewData.Model = c;
                    ViewEngineResult viewResult = ViewEngines.Engines.FindPartialView
                        (ControllerContext, "_PartialCategoryView");
                    ViewContext viewContext = new ViewContext(ControllerContext, viewResult.View, ViewData, TempData, sw);
                    viewResult.View.Render(viewContext, sw);

                    categoryJsonModel.element = sw.GetStringBuilder().ToString();
                    categoryJsonModel.name = c.Name;
                }
                jsonmodel.Add(categoryJsonModel);
            }

            if (HttpContext.Request.HttpMethod == "GET")
                return Json(jsonmodel, JsonRequestBehavior.AllowGet);
            else
                return Json(jsonmodel);
        }
    }
}