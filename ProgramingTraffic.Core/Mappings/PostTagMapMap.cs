using FluentNHibernate.Mapping;
using ProgramingTraffic.Core.Objects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JustBlog.Core.Mappings
{
    public class PostTagMapMap : ClassMap<PostTagMap>
    {
        public PostTagMapMap()
        {
            Id(x => x.Id);
            References(x => x.Post)
            .Not.Nullable();   // foreign key
            References(x => x.Tag)
            .Not.Nullable();  // foreign key
        }
    }
}
