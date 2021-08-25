using AutoMapper;
using Domain.Common;
using Domain.Entities;
using Domain.ViewModels.Blog;
using Infrastructure.Repositories;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.BlogApplication
{
    public class BlogService : IBlogService
    {
        private BlogRepository _blogRepository;
        private readonly IMapper _mapper;
        private readonly ILogger _logger;

        public BlogService(BlogRepository blogRepository, IMapper mapper, ILogger<BlogService> logger)
        {
            _blogRepository = blogRepository;
            _mapper = mapper;
            _logger = logger;
        }

        public async Task<Result> Create(vmBlogInfo blog)
        {
            var result = new Result(false);

            var model = _mapper.Map<vmBlogInfo, Blog>(blog);

            var id = await _blogRepository.Create(model);

            result.State = id == 0 ? false : true;

            _logger.LogInformation($"blog {blog.Id} has Inserted", blog);

            return result;
        }

        public async Task<vmBlogInfo> FindById(int id)
        {
            var model = await _blogRepository.GetById(id);

            return _mapper.Map<Blog, vmBlogInfo>(model);
        }
        public Task<Result> Update(vmBlogInfo blogInfo)
        {
            var blog= _mapper.Map<vmBlogInfo,Blog>(blogInfo);
            return  _blogRepository.Update(blog);

            _logger.LogInformation($"blog {blog.Id} has updated", blog);
        }
        public Task<List<vmBlogInfo>> GetBySqlQuery()
        {
            throw new NotImplementedException();
        }

        
    }
}
