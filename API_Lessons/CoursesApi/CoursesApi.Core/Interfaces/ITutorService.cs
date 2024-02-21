using CoursesApi.Core.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoursesApi.Core.Interfaces
{
    public interface ITutorService
    {
        Task<List<TutorDto>> GetAll();
        Task<TutorDto> Get(int id);
        Task Update(TutorDto model);
        Task Delete(int id);
        Task Insert(TutorDto model);
        Task<List<TutorDto>> GetByRating(int rating);
        Task<TutorDto> GetByEmail(string email);
    }
}
