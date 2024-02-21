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

        public async Task Delete(int id)
        {
            await _courseRepository.Delete(id);
            await _courseRepository.Save();
        }

        public async Task<CourseDto> Get(int id)
        {
            return _mapper.Map<CourseDto>(await _courseRepository.Get(id));
        }

        public async Task<List<CourseDto>> GetAll()
        {
            return _mapper.Map<List<CourseDto>>(await _courseRepository.GetAll());
        }

        public async Task<List<CourseDto>> GetByCategory(int id)
        {
            var res = await _courseRepository.GetListBySpec(new CoursesSpecification.ByCategory(id));
            return _mapper.Map<List<CourseDto>>(res);
        }

        public async Task<CourseDto> GetByName(string name)
        {
            var res = await _courseRepository.GetItemBySpec(new CoursesSpecification.ByName(name));
            if(res != null)
            {
                return _mapper.Map<CourseDto>(res);
            }
            return null;
        }

        public async Task<List<CourseDto>> GetByTutorEmail(string email)
        {
            var res = await _courseRepository.GetListBySpec(new CoursesSpecification.ByTutorMail(email));
            return _mapper.Map<List<CourseDto>>(res);
        }

        public async Task Insert(CourseDto model)
        {
            await _courseRepository.Insert(_mapper.Map<Course>(model));
            await _courseRepository.Save();
        }

        public async Task Update(CourseDto model)
        {
            await _courseRepository.Update(_mapper.Map<Course>(model));
            await _courseRepository.Save();
        }
    }
}
