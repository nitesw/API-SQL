using NewsApi.Core.DTOs;
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
        Task<List<RoleDto>> GetAll();
        Task<RoleDto> Get(int id);
        Task Update(RoleUpdateDto model);
        Task Delete(int id);
        Task Insert(RoleDto model);
    }
}
