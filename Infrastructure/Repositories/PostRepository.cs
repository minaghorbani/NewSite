using Domain.Entities;
using Infrastructure.Persistance;
using Infrastructure.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repositories
{
    public class PostRepository : IPostRepository
    {
        private readonly SiteDbContext _context;
        private IUnitOfWork _unitOfWork;
        public PostRepository(SiteDbContext context)
        {
            _context = context;
            _unitOfWork = new Infrastructure.UnitOfWork.UnitOfWork(context);
        }
        public async Task<int> Create(Post post)
        {
            var result = _context.Posts.Add(post);
            await _unitOfWork.CommitAsync();

            return result.Entity.Id;
        }

        public IList<Post> GetPostsByBlogId(int blogId)
        {
            var result = _context.Posts.Where(s => s.BlogId == blogId).ToList();

            return result;
        }
    }
}
