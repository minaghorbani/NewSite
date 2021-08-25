using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.ViewModels.Post
{
    public class vmPostInfo
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Body { get; set; }
        public byte[] Thumbnail { get; set; }
        public int UserId { get; set; }
        public int BlogId { get; set; }
    }
}
