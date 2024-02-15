using AutoMapper;
using CoursesApi.Core.DTOs;
using CoursesApi.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoursesApi.Core.AutoMapper
{
    public class AutoMapperCoursesProfile : Profile
    {
        public AutoMapperCoursesProfile()
        {
            CreateMap<CourseDto, Course>().ReverseMap();
            CreateMap<CategoryDto, Category>().ReverseMap();
            CreateMap<TutorDto, Tutor>().ReverseMap();
        }
    }
}
