using NewsApi.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewsApi.Core.Interfaces
{
    public interface INewsService
    {
        Task<List<News>> GetAll();
        Task<News> Get(int id);
        Task<News> Update(News news);
        Task<News> Delete(int id);
    }
}
