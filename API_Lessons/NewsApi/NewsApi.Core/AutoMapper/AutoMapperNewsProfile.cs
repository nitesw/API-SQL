using AutoMapper;
using NewsApi.Core.DTOs;
using NewsApi.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewsApi.Core.AutoMapper
{
    public class AutoMapperNewsProfile : Profile
    {
        public AutoMapperNewsProfile()
        {
            CreateMap<NewsDto, News>().ReverseMap();
            CreateMap<NewsUpdateDto, News>().ReverseMap();
            CreateMap<RoleDto, Role>().ReverseMap();
            CreateMap<RoleUpdateDto, Role>().ReverseMap();
            CreateMap<UserDto, User>().ReverseMap();
            CreateMap<UserUpdateDto, User>().ReverseMap();
        }
    }
}
