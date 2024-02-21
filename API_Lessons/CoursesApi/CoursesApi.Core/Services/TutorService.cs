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
using System.Xml.Linq;
using static CoursesApi.Core.Entities.Specifications.TutorSpecification;

namespace CoursesApi.Core.Services
{
    public class TutorService : ITutorService
    {
        private readonly IRepository<Tutor> _tutorRepository;
        private readonly IMapper _mapper;

        public TutorService(IRepository<Tutor> tutorRepository, IMapper mapper)
        {
            _tutorRepository = tutorRepository;
            _mapper = mapper;
        }

        public async Task Delete(int id)
        {
            await _tutorRepository.Delete(id);
            await _tutorRepository.Save();
        }

        public async Task<TutorDto> Get(int id)
        {
            return _mapper.Map<TutorDto>(await _tutorRepository.Get(id));
        }

        public async Task<List<TutorDto>> GetAll()
        {
            return _mapper.Map<List<TutorDto>>(await _tutorRepository.GetAll());
        }

        public async Task<TutorDto> GetByEmail(string email)
        {
            var res = await _tutorRepository.GetItemBySpec(new TutorSpecification.ByEmail(email));
            if (res != null)
            {
                return _mapper.Map<TutorDto>(res);
            }
            return null;
        }

        public async Task<List<TutorDto>> GetByRating(int rating)
        {
            var res = await _tutorRepository.GetListBySpec(new TutorSpecification.ByRating(rating));
            return _mapper.Map<List<TutorDto>>(res);
        }

        public async Task Insert(TutorDto model)
        {
            await _tutorRepository.Insert(_mapper.Map<Tutor>(model));
            await _tutorRepository.Save();
        }

        public async Task Update(TutorDto model)
        {
            await _tutorRepository.Update(_mapper.Map<Tutor>(model));
            await _tutorRepository.Save();
        }
    }
}
