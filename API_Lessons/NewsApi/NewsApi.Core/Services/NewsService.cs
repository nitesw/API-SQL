using NewsApi.Core.Entities;
using NewsApi.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewsApi.Core.Services
{
    public class NewsService : INewsService
    {
        private readonly IRepository<News> _newsRepository;

        public NewsService(IRepository<News> newsRepository)
        {
            _newsRepository = newsRepository;
        }

        public async Task Delete(int id)
        {
            await _newsRepository.Delete(id);
            await _newsRepository.Save();
        }

        public async Task<News> Get(int id)
        {
            return (News)await _newsRepository.GetById(id);
        }

        public async Task<List<News>> GetAll()
        {
            return (List<News>)await _newsRepository.GetAll();
        }

        public async Task Insert(News model)
        {
            await _newsRepository.Insert(model);
            await _newsRepository.Save();
        }

        public async Task Update(News model)
        {
            await _newsRepository.Update(model);
            await _newsRepository.Save();
        }
    }
}
