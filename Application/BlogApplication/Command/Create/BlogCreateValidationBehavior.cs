using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using MediatR;

namespace Application.BlogApplication.Command.Create
{
    public class BlogCreateValidationBehavior<TRequest, TResponse> : IPipelineBehavior<BlogCreateCommand, int>
    {
        public async Task<int> Handle(BlogCreateCommand request, CancellationToken cancellationToken, RequestHandlerDelegate<int> next)
        {
            var validator = new BlogCreateCommandValidator();
            var validate = validator.Validate(request);
            if (validate.IsValid)
            {
                var response = await next();
                return response;
            }
            else
            {
                throw new Exception("Food is not valid");
            }
            
        }
    }
}
