using NewsApi.Core.DTOs;
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
        Task<List<UserDto>> GetAll();
        Task<UserDto> Get(int id);
        Task Update(UserUpdateDto model);
        Task Delete(int id);
        Task Insert(UserDto model);
    }
}
