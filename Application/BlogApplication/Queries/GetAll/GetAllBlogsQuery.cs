using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.BlogApplication.Queries.GetAll
{
    public class GetAllBlogsQuery:IRequest<IList<Blog>>
    {

    }
}
