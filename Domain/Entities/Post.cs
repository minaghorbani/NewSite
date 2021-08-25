using Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Post:IEntity
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Body { get; set; }
        public byte[] Thumbnail { get; set; }
        public int UserId { get; set; }
        public int BlogId { get; set; }


        public DateTime DateInsert { get; set; }
        public byte[] TimeStamp { get; set; }

    }
}
