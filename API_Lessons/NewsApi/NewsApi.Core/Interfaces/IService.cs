using NewsApi.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewsApi.Core.Interfaces
{
    public interface IService<T>
    {
        Task<List<T>> GetAll();
        Task<T> Get(int id);
        Task Update(T model);
        Task Delete(int id);
        Task Insert(T model);
        Task<List<T>> GetBySpec(int id);
        Task<List<T>> GetBySpec(string username);
    }
}
