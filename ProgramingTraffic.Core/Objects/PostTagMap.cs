using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgramingTraffic.Core.Objects
{
    public class PostTagMap
    {
        public virtual int Id
        { get; set; }

        public virtual Post Post { get; set; }
        public virtual Tag Tag { get; set; }

        //public virtual int Post_id
        //{ get; set; }

        //public virtual int Tag_id
        //{ get; set; }
    }
}
