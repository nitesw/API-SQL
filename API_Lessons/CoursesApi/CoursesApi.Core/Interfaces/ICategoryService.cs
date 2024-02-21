using CoursesApi.Core.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoursesApi.Core.Interfaces
{
    public interface ICategoryService
    {
        Task<List<CategoryDto>> GetAll();
        Task<CategoryDto> Get(int id);
        Task Update(CategoryDto model);
        Task Delete(int id);
        Task Insert(CategoryDto model);
        Task<CategoryDto> GetByName(string name);
    }
}
