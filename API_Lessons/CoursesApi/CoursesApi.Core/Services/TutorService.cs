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

        public async Task<ServiceResponse> Delete(int id)
        {
            var data = await GetAll();
            List<TutorDto> courses = (List<TutorDto>)data.Payload;
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
                await _tutorRepository.Delete(id);
                await _tutorRepository.Save();

                return new ServiceResponse
                {
                    Success = true,
                    Message = "Tutor successfully deleted",
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
            var data = _mapper.Map<TutorDto>(await _tutorRepository.Get(id));
            if (data != null)
            {
                return new ServiceResponse
                {
                    Success = true,
                    Message = "The tutor successfully loaded",
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
            var data = _mapper.Map<List<TutorDto>>(await _tutorRepository.GetAll());
            if (data != null)
            {
                return new ServiceResponse
                {
                    Success = true,
                    Message = "All tutors successfully loaded",
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

        public async Task<ServiceResponse> GetByEmail(string email)
        {
            var data = await _tutorRepository.GetItemBySpec(new TutorSpecification.ByEmail(email));
            if (data != null)
            {
                return new ServiceResponse
                {
                    Success = true,
                    Message = "Tutor successfully loaded by email",
                    Payload = _mapper.Map<TutorDto>(data)
                };
            }
            else if (data == null)
            {
                return new ServiceResponse
                {
                    Success = true,
                    Message = "The tutor's email you are trying to access does not exist",
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

        public async Task<ServiceResponse> GetByRating(int rating)
        {
            var data = await _tutorRepository.GetListBySpec(new TutorSpecification.ByRating(rating));
            if (data != null && data.Any())
            {
                return new ServiceResponse
                {
                    Success = true,
                    Message = "Tutors successfully loaded by rating",
                    Payload = _mapper.Map<List<TutorDto>>(data)
                };
            }
            else if (data != null && !data.Any())
            {
                return new ServiceResponse
                {
                    Success = true,
                    Message = "The tutors with rating you are trying to access does not exists",
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

        public async Task<ServiceResponse> Insert(TutorDto model)
        {
            var data = await GetByEmail(model.Email);

            if (data.Success && data.Payload == null)
            {
                await _tutorRepository.Insert(_mapper.Map<Tutor>(model));
                await _tutorRepository.Save();

                return new ServiceResponse
                {
                    Success = true,
                    Message = "Tutor is successfully added",
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

        public async Task<ServiceResponse> Update(TutorDto model)
        {
            var data = await GetByEmail(model.Email);

            if (data.Success && data.Payload != null && ((TutorDto)data.Payload).Id != model.Id)
            {
                return new ServiceResponse
                {
                    Success = true,
                    Message = "Tutor with the same name already exists",
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
                await _tutorRepository.Update(_mapper.Map<Tutor>(model));
                await _tutorRepository.Save();

                return new ServiceResponse
                {
                    Success = true,
                    Message = "Tutor is successfully updated",
                    Payload = null
                };

            }
        }
    }
}
