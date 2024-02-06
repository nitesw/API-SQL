using NewsApi.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewsApi.Core.Interfaces
{
    public interface IUserService
    {
        Task<List<User>> GetAll();
        Task<User> Get(int id);
        Task Update(User model);
        Task Delete(int id);
        Task Insert(User model);
    }
}
