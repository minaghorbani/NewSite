using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repositories
{
    public interface IPostRepository
    {
        Task<int> Create(Post post);
        IList<Post> GetPostsByBlogId(int blogId);
    }
}
