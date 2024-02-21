using CoursesApi.Core.DTOs;
using CoursesApi.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoursesApi.Core.Interfaces
{
    public interface ICourseService
    {
        Task<List<CourseDto>> GetAll();
        Task<CourseDto> Get(int id);
        Task Update(CourseDto model);
        Task Delete(int id);
        Task Insert(CourseDto model);
        Task<List<CourseDto>> GetByCategory(int id);
        Task<List<CourseDto>> GetByTutorEmail(string email);
        Task<CourseDto> GetByName(string name);
    }
}
