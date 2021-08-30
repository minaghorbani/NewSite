using AutoMapper;
using Domain.Entities;
using Infrastructure.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.BlogApplication.Queries.FindById
{
    public class FindBlogsByIdQueryHandler : IRequestHandler<FindBlogsByIdQuery, Blog>
    {
        private readonly BlogRepository _blogRepository;
        private readonly IMapper _mapper;
        public FindBlogsByIdQueryHandler(BlogRepository blogRepository, IMapper mapper)
        {
            _blogRepository = blogRepository;
            _mapper = mapper;
        }

        public Task<Blog> Handle(FindBlogsByIdQuery request, CancellationToken cancellationToken)
        {
            return _blogRepository.GetById(request.Id);
        }
    }
}
