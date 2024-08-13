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
    public class CourseService : ICourseService
    {
        private readonly IRepository<Course> _courseRepository;
        private readonly IMapper _mapper;

        public CourseService(IRepository<Course> courseRepository, IMapper mapper)
        {
            _courseRepository = courseRepository;
            _mapper = mapper;
        }

        public async Task<ServiceResponse> Delete(int id)
        {
            var data = await GetAll();
            List<CourseDto> courses = (List<CourseDto>)data.Payload;
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
            else if(isExists)
            {
                await _courseRepository.Delete(id);
                await _courseRepository.Save();

                return new ServiceResponse
                {
                    Success = true,
                    Message = "Course successfully deleted",
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
            var data = _mapper.Map<CourseDto>(await _courseRepository.Get(id));
            if (data != null)
            {
                return new ServiceResponse
                {
                    Success = true,
                    Message = "The course successfully loaded",
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
            var data = _mapper.Map<List<CourseDto>>(await _courseRepository.GetAll());
            if(data != null)
            {
                return new ServiceResponse
                {
                    Success = true,
                    Message = "All courses successfully loaded",
                    Payload = data
                };
            }
            else if(data == null)
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

        public async Task<ServiceResponse> GetByCategory(int id)
        {
            var data = await _courseRepository.GetListBySpec(new CoursesSpecification.ByCategory(id));
            if (data != null && data.Any())
            {
                return new ServiceResponse
                {
                    Success = true,
                    Message = "Courses successfully loaded by category id",
                    Payload = _mapper.Map<List<CourseDto>>(data)
                };
            }
            else if (data != null && !data.Any())
            {
                return new ServiceResponse
                {
                    Success = true,
                    Message = "The category id you are trying to access does not exist",
                    Payload = _mapper.Map<List<CourseDto>>(data)
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
            var data = await _courseRepository.GetItemBySpec(new CoursesSpecification.ByName(name));
            if (data != null)
            {
                return new ServiceResponse
                {
                    Success = true,
                    Message = "Course successfully loaded by name",
                    Payload = _mapper.Map<CourseDto>(data)
                };
            }
            else if (data == null)
            {
                return new ServiceResponse
                {
                    Success = true,
                    Message = "The course name you are trying to access does not exist",
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

        public async Task<ServiceResponse> GetByTutorEmail(string email)
        {
            var data = await _courseRepository.GetListBySpec(new CoursesSpecification.ByTutorMail(email));
            if (data != null && data.Any())
            {
                return new ServiceResponse
                {
                    Success = true,
                    Message = "Courses successfully loaded by tutor email",
                    Payload = _mapper.Map<List<CourseDto>>(data)
                };
            }
            else if (data != null && !data.Any())
            {
                return new ServiceResponse
                {
                    Success = true,
                    Message = "The tutor's email you are trying to access does not exist",
                    Payload = _mapper.Map<List<CourseDto>>(data)
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

        public async Task<ServiceResponse> Insert(CourseDto model)
        {
            var data = await GetByName(model.Name);

            if (data.Success && data.Payload == null)
            {
                await _courseRepository.Insert(_mapper.Map<Course>(model));
                await _courseRepository.Save();

                return new ServiceResponse
                {
                    Success = true,
                    Message = "Course is successfully added",
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
                    Message = "A course with the same name already exists",
                    Payload = null
                };
            }
        }

        public async Task<ServiceResponse> Update(CourseDto model)
        {
            var data = await GetByName(model.Name);

            if (data.Success && data.Payload != null && ((CourseDto)data.Payload).Id != model.Id)
            {
                return new ServiceResponse
                {
                    Success = true,
                    Message = "A course with the same name already exists",
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
                await _courseRepository.Update(_mapper.Map<Course>(model));
                await _courseRepository.Save();

                return new ServiceResponse
                {
                    Success = true,
                    Message = "Course is successfully updated",
                    Payload = null
                };
                
            }
        }
    }
}
