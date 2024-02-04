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

        public async Task<News> Delete(int id)
        {
            await _newsRepository.Delete(id);
            return null;
        }

        public async Task<News> Get(int id)
        {
            return (News)await _newsRepository.GetById(id);
        }

        public async Task<List<News>> GetAll()
        {
            return (List<News>)await _newsRepository.GetAll();
        }

        public async Task<News> Update(News news)
        {
            await _newsRepository.Update(news);
            return news;
        }
    }
}
