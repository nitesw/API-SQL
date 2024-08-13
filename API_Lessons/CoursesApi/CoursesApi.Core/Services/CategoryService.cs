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

        public async Task<ServiceResponse> Delete(int id)
        {
            var data = await GetAll();
            List<CategoryDto> courses = (List<CategoryDto>)data.Payload;
            bool isExists = false;

            foreach (var item in courses)
            {
                if (item.Id == id)
                {
                    isExists = true;
                }
            }

            if (!isExists)
            {
                return new ServiceResponse
                {
                    Success = true,
                    Message = "The id you are trying to access does not exist",
                    Payload = null
                };
            }
            else if (isExists)
            {
                await _categoryRepository.Delete(id);
                await _categoryRepository.Save();

                return new ServiceResponse
                {
                    Success = true,
                    Message = "Category successfully deleted",
                    Payload = null
                };
            }
            else
            {
                return new ServiceResponse
                {
                    Success = false,
                    Message = "There is some error has occurred",
                    Payload = null
                };
            }
        }

        public async Task<ServiceResponse> Get(int id)
        {
            var data = _mapper.Map<CategoryDto>(await _categoryRepository.Get(id));

            if (data != null)
            {
                return new ServiceResponse
                {
                    Success = true,
                    Message = "The category successfully loaded",
                    Payload = data
                };
            }
            else if (data == null)
            {
                return new ServiceResponse
                {
                    Success = true,
                    Message = "The id you are trying to access does not exist",
                    Payload = null
                };
            }
            else
            {
                return new ServiceResponse
                {
                    Success = false,
                    Message = "There is some error has occurred",
                    Payload = null
                };
            }
        }

        public async Task<ServiceResponse> GetAll()
        {
            var data = _mapper.Map<List<CategoryDto>>(await _categoryRepository.GetAll());

            if (data != null)
            {
                return new ServiceResponse
                {
                    Success = true,
                    Message = "All categories successfully loaded",
                    Payload = data
                };
            }
            else if (data == null)
            {
                return new ServiceResponse
                {
                    Success = true,
                    Message = "The database is empty",
                    Payload = data
                };
            }
            else
            {
                return new ServiceResponse
                {
                    Success = false,
                    Message = "There is some error has occurred",
                    Payload = null
                };
            }
        }

        public async Task<ServiceResponse> GetByName(string name)
        {
            var data = await _categoryRepository.GetItemBySpec(new CategorySpecification.ByName(name));
            if (data != null)
            {
                return new ServiceResponse
                {
                    Success = true,
                    Message = "Category successfully loaded by name",
                    Payload = _mapper.Map<CategoryDto>(data)
                };
            }
            else if (data == null)
            {
                return new ServiceResponse
                {
                    Success = true,
                    Message = "The category name you are trying to access does not exist",
                    Payload = null
                };
            }
            else
            {
                return new ServiceResponse
                {
                    Success = false,
                    Message = "There is some error has occurred",
                    Payload = null
                };
            }
        }

        public async Task<ServiceResponse> Insert(CategoryDto model)
        {
            var data = await GetByName(model.Name);

            if (data.Success && data.Payload == null)
            {
                await _categoryRepository.Insert(_mapper.Map<Category>(model));
                await _categoryRepository.Save();

                return new ServiceResponse
                {
                    Success = true,
                    Message = "Category is successfully added",
                    Payload = null
                };
            }
            else if (!data.Success)
            {
                return new ServiceResponse
                {
                    Success = false,
                    Message = "There is some error has occurred",
                    Payload = null
                };
            }
            else
            {
                return new ServiceResponse
                {
                    Success = true,
                    Message = "A category with the same name already exists",
                    Payload = null
                };
            }       
        }

        public async Task<ServiceResponse> Update(CategoryDto model)
        {
            var data = await GetByName(model.Name);

            if (data.Success && data.Payload != null && ((CategoryDto)data.Payload).Id != model.Id)
            {
                return new ServiceResponse
                {
                    Success = true,
                    Message = "A category with the same name already exists",
                    Payload = null
                };
            }
            else if (!data.Success)
            {
                return new ServiceResponse
                {
                    Success = false,
                    Message = "There is some error has occurred",
                    Payload = null
                };
            }
            else
            {
                await _categoryRepository.Update(_mapper.Map<Category>(model));
                await _categoryRepository.Save();

                return new ServiceResponse
                {
                    Success = true,
                    Message = "Category is successfully updated",
                    Payload = null
                };

            }
        }
    }
}
