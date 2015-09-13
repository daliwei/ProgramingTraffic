using ProgramingTraffic.Core;
using ProgramingTraffic.Core.Objects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProgramingTraffic.Models
{

    public class CategoryViewModel
    {
        public IList<Category> Categories { get; set; }

        public CategoryViewModel(IBlogRepository _blogRepository)
        {
            this.Categories = _blogRepository.Categories();
        }

        public CategoryViewModel(BlogContext _blogContext)
        {
            this.Categories = _blogContext.AllCategories();
        }

    }

    public class JsonModel_CategoryView
    {
        //put routes 
        public string element { get; set; }
        public string name { get; set; }
    }
}