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

        public ListViewModel(IBlogRepository _blogRepository, int p)
        {
            Posts = _blogRepository.Posts(p - 1, 5);
            TotalPosts = _blogRepository.TotalPosts();
        }
    }
}