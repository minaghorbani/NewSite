using AutoMapper;
using Domain.Entities;
using Domain.ViewModels.Blog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Common
{
   public class Mappers: Profile
    {
        public Mappers()
        {
            CreateMap<vmBlogInfo, Blog>();
            CreateMap<Blog, vmBlogInfo>();
            //CreateMap<Blog, vmBlogInfo>().ReverseMap();
        }
    }
}
