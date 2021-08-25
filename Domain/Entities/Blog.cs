using Domain.Common;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Blog:IEntity
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }

        public Collection<Post> Posts { get; set; }
        public DateTime DateInsert { get; set; }
        public byte[] TimeStamp { get; set; }



    }
}
