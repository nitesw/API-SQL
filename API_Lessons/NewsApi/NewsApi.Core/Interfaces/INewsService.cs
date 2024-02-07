using NewsApi.Core.DTOs;
using NewsApi.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewsApi.Core.Interfaces
{
    public interface INewsService
    {
        Task<List<NewsDto>> GetAll();
        Task<NewsDto> Get(int id);
        Task Update(NewsUpdateDto model);
        Task Delete(int id);
        Task Insert(NewsDto model);
    }
}
