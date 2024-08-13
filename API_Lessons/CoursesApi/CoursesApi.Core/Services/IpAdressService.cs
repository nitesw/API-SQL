using AutoMapper;
using CoursesApi.Core.DTOs;
using CoursesApi.Core.Entities;
using CoursesApi.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace CoursesApi.Core.Services
{
    public class IpAdressService : IIpAdressService
    {
        private readonly IRepository<IpAdress> _ipAdressRepository;

        public IpAdressService(IRepository<IpAdress> ipAdressRepository)
        {
            _ipAdressRepository = ipAdressRepository;
        }

        public async Task<ServiceResponse> Delete(int id)
        {
            var data = await GetAll();
            List<IpAdress> courses = (List<IpAdress>)data.Payload;
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
                await _ipAdressRepository.Delete(id);
                await _ipAdressRepository.Save();

                return new ServiceResponse
                {
                    Success = true,
                    Message = "Log successfully deleted",
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
            var data = await _ipAdressRepository.Get(id);

            if (data != null)
            {
                return new ServiceResponse
                {
                    Success = true,
                    Message = "The ip adresses successfully loaded",
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
            var data = await _ipAdressRepository.GetAll();

            if (data != null && data.Any())
            {
                return new ServiceResponse
                {
                    Success = true,
                    Message = "All ip addresses successfully loaded",
                    Payload = data
                };
            }
            else if (data == null || !data.Any())
            {
                return new ServiceResponse
                {
                    Success = true,
                    Message = "The database is empty",
                    Payload = null
                };
            }
            else
            {
                return new ServiceResponse
                {
                    Success = false,
                    Message = "There is some error that has occurred",
                    Payload = null
                };
            }
        }

        public async Task Insert(IpAdress model)
        {
            await _ipAdressRepository.Insert(model);
            await _ipAdressRepository.Save();
        }

        public async Task CreateLog(string ip, string operation)
        {
            await Insert(new IpAdress
            {
                Ip = ip,
                Operation = operation,
                Date = DateOnly.FromDateTime(DateTime.Today),
                Time = TimeOnly.FromTimeSpan(DateTime.Now.TimeOfDay)
            });
        }
    }
}
