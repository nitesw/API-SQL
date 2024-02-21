using AutoMapper;
using CoursesApi.Core.DTOs;
using CoursesApi.Core.Entities;
using CoursesApi.Core.Entities.Specifications;
using CoursesApi.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static CoursesApi.Core.Entities.Specifications.TutorSpecification;

namespace CoursesApi.Core.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly IRepository<Category> _categoryRepository;
        private readonly IMapper _mapper;

        public CategoryService(IRepository<Category> categoryRepository, IMapper mapper)
        {
            _categoryRepository = categoryRepository;
            _mapper = mapper;
        }

        public async Task Delete(int id)
        {
            await _categoryRepository.Delete(id);
            await _categoryRepository.Save();
        }

        public async Task<CategoryDto> Get(int id)
        {
            return _mapper.Map<CategoryDto>(await _categoryRepository.Get(id));
        }

        public async Task<List<CategoryDto>> GetAll()
        {
            return _mapper.Map<List<CategoryDto>>(await _categoryRepository.GetAll());
        }

        public async Task<CategoryDto> GetByName(string name)
        {
            var res = await _categoryRepository.GetItemBySpec(new CategorySpecification.ByName(name));
            if(res != null)
            { 
                return _mapper.Map<CategoryDto>(res);
            }
            return null;
        }

        public async Task Insert(CategoryDto model)
        {
            await _categoryRepository.Insert(_mapper.Map<Category>(model));
            await _categoryRepository.Save();
        }

        public async Task Update(CategoryDto model)
        {
            await _categoryRepository.Update(_mapper.Map<Category>(model));
            await _categoryRepository.Save();
        }
    }
}
