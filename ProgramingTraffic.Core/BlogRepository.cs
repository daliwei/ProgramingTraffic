﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProgramingTraffic.Core.Objects;
using NHibernate;
using NHibernate.Linq;

namespace ProgramingTraffic.Core
{
    public class BlogRepository : IBlogRepository
    {
        // NHibernate object
        private readonly ISession _session;

        public BlogRepository(ISession session)
        {
            _session = session;
        }

        public IList<Post> Posts(int pageNo, int pageSize)
        {
            var posts = _session.Query<Post>()
                                  .Where(p => p.Published)
                                  .OrderByDescending(p => p.PostedOn)
                                  .Skip(pageNo * pageSize)
                                  .Take(pageSize)
                                  .Fetch(p => p.Category)
                                  .ToList();

            var postIds = posts.Select(p => p.Id).ToList();

            return _session.Query<Post>()
                  .Where(p => postIds.Contains(p.Id))
                  .OrderByDescending(p => p.PostedOn)
                  //.FetchMany(p => p.Tags)
                  .ToList();
        }

        public int TotalPosts()
        {
            return _session.Query<Post>().Where(p => p.Published).Count();
        }

        public IList<Category> Categories()
        {
            var categories = _session.Query<Category>().ToList();
            return categories;

        }
    }
}
