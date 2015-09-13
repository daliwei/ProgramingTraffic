using ProgramingTraffic.Core;
using ProgramingTraffic.Core.Objects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProgramingTraffic.Models
{
    public class ListViewModel
    {
        public IList<Post> Posts { get; set; }

        public int TotalPosts { get; set; }

        public int currentPage { get; set; }

        public int totalPages { get; set; }

        private int split = 5;

        public ListViewModel(IBlogRepository _blogRepository, int page)
        {
            currentPage = page;
            Posts = _blogRepository.Posts(page - 1, split);
            TotalPosts = _blogRepository.TotalPosts();
            totalPages = (int)Math.Ceiling((double)TotalPosts / (double)split);
        }


        public ListViewModel(IBlogRepository _blogRepository, int page, string category_name)
        {
            currentPage = page;
            Posts = _blogRepository.Posts_Category(page - 1, split, category_name);
            TotalPosts = _blogRepository.TotalCatePosts(category_name);
            totalPages = (int)Math.Ceiling((double)TotalPosts / (double)split);
        }
    }

    public class JsonModel_ListView
    {
        public string HTMLString { get; set; }
        public bool NoMoreData { get; set; }
    }
}