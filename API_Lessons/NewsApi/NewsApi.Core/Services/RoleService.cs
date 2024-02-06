using NewsApi.Core.Entities;
using NewsApi.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewsApi.Core.Services
{
    public class RoleService : IRoleService
    {
        private readonly IRepository<Role> _roleRepository;

        public RoleService(IRepository<Role> roleRepository)
        {
            _roleRepository = roleRepository;
        }

        public async Task Delete(int id)
        {
            await _roleRepository.Delete(id);
            await _roleRepository.Save();
        }

        public async Task<Role> Get(int id)
        {
            return (Role)await _roleRepository.GetById(id);
        }

        public async Task<List<Role>> GetAll()
        {
            return (List<Role>)await _roleRepository.GetAll();
        }

        public async Task Insert(Role model)
        {
            await _roleRepository.Insert(model);
            await _roleRepository.Save();
        }

        public async Task Update(Role model)
        {
            await _roleRepository.Update(model);
            await _roleRepository.Save();
        }
    }
}
