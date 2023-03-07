using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using BookStoreWebAPI.Models;

namespace BookStoreWebAPI.Helper
{
    public class AutoMapper : Profile
    {
        public AutoMapper()
        {
            CreateMap<Books, BookModel>().ForMember(des=>des.Id, opt=>opt.MapFrom(src=>src.Id));
        }
    }
}