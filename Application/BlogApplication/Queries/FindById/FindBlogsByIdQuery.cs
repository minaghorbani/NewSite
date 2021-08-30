using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.BlogApplication.Queries.FindById
{
    public class FindBlogsByIdQuery : IRequest<Blog>
    {
        public int Id { get; set; }
    }
}
