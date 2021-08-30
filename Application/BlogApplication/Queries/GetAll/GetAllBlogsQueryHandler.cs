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

namespace Application.BlogApplication.Queries.GetAll
{
    public class GetAllBlogsQueryHandler : IRequestHandler<GetAllBlogsQuery, IList<Blog>>
    {
        private readonly BlogRepository _blogRepository;
        private readonly IMapper _mapper;
        public GetAllBlogsQueryHandler(BlogRepository blogRepository, IMapper mapper)
        {
            _blogRepository = blogRepository;
            _mapper = mapper;
        }
        public Task<IList<Blog>> Handle(GetAllBlogsQuery request, CancellationToken cancellationToken)
        {
            return _blogRepository.GetAll();
        }
    }
}
