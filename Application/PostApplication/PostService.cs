using AutoMapper;
using Domain.Common;
using Domain.ViewModels.Blog;
using Infrastructure.Repositories;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.PostApplication
{
    public class PostService : IPostService
    {
        private PostRepository _blogRepository;
        private readonly IMapper _mapper;
        private readonly ILogger _logger;

        public PostService(PostRepository blogRepository, IMapper mapper, ILogger<PostService> logger)
        {
            _blogRepository = blogRepository;
            _mapper = mapper;
            _logger = logger;
        }

       
    }
}
