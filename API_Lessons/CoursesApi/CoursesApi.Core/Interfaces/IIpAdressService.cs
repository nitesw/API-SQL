using CoursesApi.Core.Entities;
using CoursesApi.Core.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoursesApi.Core.Interfaces
{
    public interface IIpAdressService
    {
        Task<ServiceResponse> GetAll();
        Task<ServiceResponse> Get(int id);
        Task<ServiceResponse> Delete(int id);
        Task Insert(IpAdress model);
        Task CreateLog(string ip, string operation);
    }
}
