using Infrastructure.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.UnitOfWork
{
    public interface IUnitOfWork
    {
        //IBlogRepository BlogRepository { get; }
        //IPostRepository PostRepository { get; }

        Task<bool> CommitAsync();
    }
}
