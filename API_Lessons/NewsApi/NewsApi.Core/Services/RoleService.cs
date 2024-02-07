using AutoMapper;
using NewsApi.Core.DTOs;
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
        private readonly IMapper _mapper;

        public RoleService(IRepository<Role> roleRepository, IMapper mapper)
        {
            _roleRepository = roleRepository;
            _mapper = mapper;
        }

        public async Task Delete(int id)
        {
            await _roleRepository.Delete(id);
            await _roleRepository.Save();
        }

        public async Task<RoleDto> Get(int id)
        {
            return _mapper.Map<RoleDto>(await _roleRepository.GetById(id));
        }

        public async Task<List<RoleDto>> GetAll()
        {
            return _mapper.Map<List<RoleDto>>(await _roleRepository.GetAll());
        }

        public async Task Insert(RoleDto model)
        {
            await _roleRepository.Insert(_mapper.Map<Role>(model));
            await _roleRepository.Save();
        }

        public async Task Update(RoleUpdateDto model)
        {
            await _roleRepository.Update(_mapper.Map<Role>(model));
            await _roleRepository.Save();
        }
    }
}
