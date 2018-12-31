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
    public static class ServiceMapperProfile
    {
        public static void Configure()
        {
            Mapper.Initialize(cfg => {
                cfg.CreateMap<AuthorVM, Author>();
                cfg.CreateMap<Author, AuthorVM>();
            });
        }
    }
}
