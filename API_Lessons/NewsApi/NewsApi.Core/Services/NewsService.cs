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
        public Task<News> Delete(int id)
        {
            throw new NotImplementedException();
        }

        public Task<News> Get(int id)
        {
            throw new NotImplementedException();
        }

        public Task<List<News>> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task<News> Update(News news)
        {
            throw new NotImplementedException();
        }
    }
}
