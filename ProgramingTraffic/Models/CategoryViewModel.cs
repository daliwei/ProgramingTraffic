using ProgramingTraffic.Core;
using ProgramingTraffic.Core.Objects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProgramingTraffic.Models
{

    public class DeleCategory
    {
        public virtual int Id
        { get; set; }

        public virtual string Name
        { get; set; }

        public virtual string UrlSlug
        { get; set; }

        //public virtual string Description
        //{ get; set; }

        public DeleCategory(Category cate)
        {
            Id = cate.Id;
            Name = cate.Name;
            UrlSlug = cate.UrlSlug;
            //Description = cate.Description;
        }
    }

    public class CategoryViewModel
    {
        public IList<DeleCategory> Categories { get; set; }

        public CategoryViewModel(IBlogRepository _blogRepository)
        {
            Categories = new List<DeleCategory>();
            foreach (Category cate in _blogRepository.Categories())
                Categories.Add(new DeleCategory(cate));
        }
        
    }
}