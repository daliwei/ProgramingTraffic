using ProgramingTraffic.Core.Objects;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgramingTraffic.Core.Configurations
{
    public class PostTypeConfiguration:EntityTypeConfiguration<Post>
    {
        public PostTypeConfiguration()
        {
            
        }
    }
}
