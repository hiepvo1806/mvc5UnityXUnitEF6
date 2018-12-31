using AutoMapper;
using DataAccessLayer.Models;
using ServiceLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceLayer
{
    public class ServiceMapperProfile : Profile
    {
        //public static void Configure()
        //{
        //    Mapper.Initialize(cfg => {
        //        cfg.CreateMap<AuthorVM, Author>();
        //        cfg.CreateMap<Author, AuthorVM>();
        //    });
        //}
        public ServiceMapperProfile()
        {
            CreateMap<AuthorVM, Author>();
            CreateMap<Author, AuthorVM>();
        }
    }
}
