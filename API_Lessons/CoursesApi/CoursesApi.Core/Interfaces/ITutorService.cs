using CoursesApi.Core.DTOs;
using CoursesApi.Core.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoursesApi.Core.Interfaces
{
    public interface ITutorService
    {
        Task<ServiceResponse> GetAll();
        Task<ServiceResponse> Get(int id);
        Task<ServiceResponse> Update(TutorDto model);
        Task<ServiceResponse> Delete(int id);
        Task<ServiceResponse> Insert(TutorDto model);
        Task<ServiceResponse> GetByRating(int rating);
        Task<ServiceResponse> GetByEmail(string email);
    }
}
