using Application.BlogApplication;
using Application.BlogApplication.Command.Create;
//using Application.BlogApplication.Queries.FindById;
//using Application.BlogApplication.Queries.GetAll;
using Domain.ViewModels.Blog;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebPresentation.Controllers
{
    public class BlogController : Controller
    {
        //private readonly IMediator _mediator;
        //public BlogController(IMediator mediator)
        //{
        //    _mediator = mediator;
        //}
        private readonly IBlogService _blogService;
        
        public BlogController(IBlogService blogService)
        {
            _blogService = blogService;
        }

        public async Task<IActionResult> Create()
        {

            vmBlogInfo model = new vmBlogInfo { Description = "22245", Title = "222" };
            var result = await _blogService.Create(model);
            return Ok(result);
        }

        //[HttpPost]
        //public async Task<IActionResult> Create(vmBlogInfo model)
        //{

        //    var result = await _blogService.Create(model);
        //    return Ok(result);
        //}

        //public async Task<IActionResult> Create(vmBlogInfo model)
        //{
        //    var result = await _mediator.Send(new BlogCreateCommand()
        //    {
        //        Description = model.Description,
        //        Title = model.Title
        //    });

        //    return Ok(result);
        //}
        //public async Task<IActionResult> FindAll()
        //{
        //    var model = await _mediator.Send(new GetAllBlogsQuery());
        //    return View();
        //}
        //public async Task<IActionResult> FindById(int id)
        //{
        //    var model = await _mediator.Send(new FindBlogsByIdQuery() { Id = id });
        //    return View();
        //}
    }
}
