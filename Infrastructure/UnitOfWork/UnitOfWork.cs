using Infrastructure.Persistance;
using Infrastructure.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly SiteDbContext _context;
        public UnitOfWork(SiteDbContext context)
        {
            _context = context;
            BlogRepository = new BlogRepository(context);
            PostRepository = new PostRepository(context);
        }

        public IBlogRepository BlogRepository { get; }

        public IPostRepository PostRepository { get; }

        public async Task<bool> CommitAsync()
        {
            try
            {
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
