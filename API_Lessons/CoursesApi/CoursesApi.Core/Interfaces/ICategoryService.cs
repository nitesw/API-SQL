using CoursesApi.Core.DTOs;
using CoursesApi.Core.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoursesApi.Core.Interfaces
{
    public interface ICategoryService
    {
        Task<ServiceResponse> GetAll();
        Task<ServiceResponse> Get(int id);
        Task<ServiceResponse> Update(CategoryDto model);
        Task<ServiceResponse> Delete(int id);
        Task<ServiceResponse> Insert(CategoryDto model);
        Task<ServiceResponse> GetByName(string name);
    }
}
