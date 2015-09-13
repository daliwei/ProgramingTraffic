using ProgramingTraffic.Core.Objects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgramingTraffic.Core
{
    public interface IBlogRepository
    {
        IList<Post> Posts(int pageNo, int pageSize);
        IList<Post> Posts_Category(int pageNo, int pageSize, string category);
        int TotalPosts();
        IList<Category> Categories();
        int TotalCatePosts(string name);
    }
}
