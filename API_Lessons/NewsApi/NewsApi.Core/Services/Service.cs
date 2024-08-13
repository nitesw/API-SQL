using AutoMapper;
using NewsApi.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewsApi.Core.Services
{
    public class Service<T> : IService<T> where T : class, IEntity
    {
        private readonly IRepository<T> _repository;
        private readonly IMapper _mapper;

        public Service(IRepository<T> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task Delete(int id)
        {
            await _repository.Delete(id);
            await _repository.Save();
        }

        public async Task<T> Get(int id)
        {
            return _mapper.Map<T>(await _repository.GetById(id));
        }

        public async Task<List<T>> GetAll()
        {
            return _mapper.Map<List<T>>(await _repository.GetAll());
        }

        public Task<List<T>> GetBySpec(int id)
        {
            //var result = await _repository.GetListBySpec(new )
            throw new NotImplementedException();
        }

        public Task<List<T>> GetBySpec(string username)
        {
            throw new NotImplementedException();
        }

        public async Task Insert(T model)
        {
            await _repository.Insert(_mapper.Map<T>(model));
            await _repository.Save();
        }

        public async Task Update(T model)
        {
            await _repository.Update(_mapper.Map<T>(model));
            await _repository.Save();
        }

        /*public async Task<List<T>> GetBySpec(int id)
        {
            var result = await _repository.GetListBySpec(new Service.)
        }*/
    }
}
