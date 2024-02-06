using NewsApi.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewsApi.Core.Interfaces
{
    public interface IRoleService
    {
        Task<List<Role>> GetAll();
        Task<Role> Get(int id);
        Task Update(Role model);
        Task Delete(int id);
        Task Insert(Role model);
    }
}
