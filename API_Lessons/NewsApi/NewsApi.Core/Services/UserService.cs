using AutoMapper;
using NewsApi.Core.DTOs;
using NewsApi.Core.Entities;
using NewsApi.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace NewsApi.Core.Services
{
    public class UserService : IUserService
    {
        private readonly IRepository<User> _userRepository;
        private readonly IMapper _mapper;

        public UserService(IRepository<User> userRepository, IMapper mapper)
        {
            _userRepository = userRepository;
            _mapper = mapper;
        }

        public async Task Delete(int id)
        {
            await _userRepository.Delete(id);
            await _userRepository.Save();
        }

        public async Task<UserDto> Get(int id)
        {
            return _mapper.Map<UserDto>(await _userRepository.GetById(id)); 
        }

        public async Task<List<UserDto>> GetAll()
        {
            return _mapper.Map<List<UserDto>>(await _userRepository.GetAll());
        }

        public async Task Insert(UserDto model)
        {
            List<UserDto> users = _mapper.Map<List<UserDto>>(await _userRepository.GetAll());
            foreach (var u in users)
            {
                if(u.Email == model.Email)
                {
                    return;
                }
            }
            var user = _mapper.Map<User>(model);
            await _userRepository.Insert(user);
            await _userRepository.Save();
        }

        public async Task Update(UserUpdateDto model)
        {
            List<User> users = _mapper.Map<List<User>>(await _userRepository.GetAll());
            foreach (var u in users)
            {
                if (u.Email == model.Email)
                {
                    return;
                }
            }
            var user = _mapper.Map<User>(model);
            await _userRepository.Update(user);
            await _userRepository.Save();
        }
    }
}
