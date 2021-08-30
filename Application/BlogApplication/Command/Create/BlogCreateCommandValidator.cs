using Domain.Entities;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.BlogApplication.Command.Create
{
    public class BlogCreateCommandValidator :AbstractValidator<BlogCreateCommand>
    {
        public BlogCreateCommandValidator()
        {
            RuleFor(u => u.Title).NotEmpty().WithMessage("عنوان بلاگ را وارد نمایید");
            RuleFor(u => u.Description).NotEmpty().WithMessage("توضیح کوتاهی وارد نمایید");
        }
    }
}
