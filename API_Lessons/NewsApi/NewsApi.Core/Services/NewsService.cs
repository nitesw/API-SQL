using AutoMapper;
using NewsApi.Core.DTOs;
using NewsApi.Core.Entities;
using NewsApi.Core.Entities.Specifications;
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
        private readonly IMapper _mapper;

        public NewsService(IRepository<News> newsRepository, IMapper mapper)
        {
            _newsRepository = newsRepository;
            _mapper = mapper;
        }

        public async Task Delete(int id)
        {
            await _newsRepository.Delete(id);
            await _newsRepository.Save();
        }

        public async Task<NewsDto> Get(int id)
        {
            return _mapper.Map<NewsDto>(await _newsRepository.GetById(id));
        }

        public async Task<List<NewsDto>> GetAll()
        {
            return _mapper.Map<List<NewsDto>>(await _newsRepository.GetAll());
        }

        public async Task Insert(NewsDto model)
        {
            await _newsRepository.Insert(_mapper.Map<News>(model));
            await _newsRepository.Save();
        }

        public async Task Update(NewsUpdateDto model)
        {
            await _newsRepository.Update(_mapper.Map<News>(model));
            await _newsRepository.Save();
        }

        public async Task<List<News>> GetByCategory(int id)
        {
            var result = await _newsRepository.GetListBySpec(new NewsSpecification.ByCategory(id));
            return _mapper.Map<List<News>>(result);
        }

        public async Task<List<News>> GetByAuthor(string username)
        {
            var result = await _newsRepository.GetListBySpec(new NewsSpecification.ByAuthor(username));
            return _mapper.Map<List<News>>(result);
        }
    }
}
