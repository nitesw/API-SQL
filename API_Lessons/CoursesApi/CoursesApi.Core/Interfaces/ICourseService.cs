using CoursesApi.Core.DTOs;
using CoursesApi.Core.Entities;
using CoursesApi.Core.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoursesApi.Core.Interfaces
{
    public interface ICourseService
    {
        Task<ServiceResponse> GetAll();
        Task<ServiceResponse> Get(int id);
        Task<ServiceResponse> Update(CourseDto model);
        Task<ServiceResponse> Delete(int id);
        Task<ServiceResponse> Insert(CourseDto model);
        Task<ServiceResponse> GetByCategory(int id);
        Task<ServiceResponse> GetByTutorEmail(string email);
        Task<ServiceResponse> GetByName(string name);
    }
}
