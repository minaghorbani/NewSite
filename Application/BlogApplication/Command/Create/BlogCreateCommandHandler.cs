using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using Domain.Entities;
using Infrastructure.Repositories;
using MediatR;

namespace Application.BlogApplication.Command.Create
{
    public class BlogCreateCommandHandler : IRequestHandler<BlogCreateCommand, int>
    {
        private readonly IBlogRepository _blogRepository;
        private readonly IMapper _mapper;
        public BlogCreateCommandHandler(IBlogRepository blogRepository, IMapper mapper)
        {
            _blogRepository = blogRepository;
            _mapper = mapper;
        }
        public async Task<int> Handle(BlogCreateCommand request, CancellationToken cancellationToken)
        {
            //var model = _mapper.Map<request vmBlogInfo, Blog>(blog);

            var blog = new Blog()
            {
                Description = request.Description,
                Title = request.Title,
            };
            var id = await _blogRepository.Create(blog);

            return id;


        }

        //public async Task<int> Handle(BlogCreateCommand request, CancellationToken cancellationToken)
        //{
        //    //var model = _mapper.Map<request vmBlogInfo, Blog>(blog);
        //    var validator = new BlogCreateCommandValidator();
        //    var validate = validator.Validate(request);
        //    if (validate.IsValid)
        //    {
        //        var blog = new Blog()
        //        {
        //            Description = request.Description,
        //            Title = request.Title,
        //        };
        //        var id = await _blogRepository.Create(blog);

        //        return id;
        //    }
        //    else
        //    {
        //        throw new Exception("Food is not valid");
        //    }

        //}

    }
}
