using Domain.Common;
using Domain.ViewModels.Blog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.BlogApplication
{
    public interface IBlogService
    {
        Task<Result> Create(vmBlogInfo info);
        Task<vmBlogInfo> FindById(int id);
        Task<Result> Update(vmBlogInfo foodEditInfo);
        Task<List<vmBlogInfo>> GetBySqlQuery();
    }
}
