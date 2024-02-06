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

        public UserService(IRepository<User> userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task Delete(int id)
        {
            await _userRepository.Delete(id);
            await _userRepository.Save();
        }

        public async Task<User> Get(int id)
        {
            return (User)await _userRepository.GetById(id); 
        }

        public async Task<List<User>> GetAll()
        {
            return (List<User>)await _userRepository.GetAll();
        }

        public async Task Insert(User model)
        {
            List<User> users = (List<User>)await _userRepository.GetAll();
            foreach (var u in users)
            {
                if(u.Email == model.Email)
                {
                    return;
                }
            }
            await _userRepository.Insert(model);
            await _userRepository.Save();
        }

        public async Task Update(User model)
        {
            List<User> users = (List<User>)await _userRepository.GetAll();
            foreach (var u in users)
            {
                if (u.Email == model.Email)
                {
                    return;
                }
            }
            await _userRepository.Update(model);
            await _userRepository.Save();
        }
    }
}
