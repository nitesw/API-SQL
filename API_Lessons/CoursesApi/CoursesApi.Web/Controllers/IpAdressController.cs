using CoursesApi.Core.DTOs;
using CoursesApi.Core.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CoursesApi.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class IpAdressController : ControllerBase
    {
        private readonly IIpAdressService _ipAdressService;

        public IpAdressController(IIpAdressService ipAdressService)
        {
            _ipAdressService = ipAdressService;
        }

        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAll()
        {
            var ipAdress = HttpContext.Connection.RemoteIpAddress;
            await _ipAdressService.CreateLog(ipAdress.ToString(), "IpAdress GetAll funct");

            var adress = await _ipAdressService.GetAll();
            return Ok(adress);
        }
        [HttpPost("Get")]
        public async Task<IActionResult> GetById(int id)
        {
            var ipAdress = HttpContext.Connection.RemoteIpAddress;
            await _ipAdressService.CreateLog(ipAdress.ToString(), "IpAdress GetById funct");

            var adress = await _ipAdressService.Get(id);
            return Ok(adress);
        }
        
        [HttpDelete("Delete")]
        public async Task<IActionResult> Delete(int id)
        {
            var ipAdress = HttpContext.Connection.RemoteIpAddress;
            await _ipAdressService.CreateLog(ipAdress.ToString(), "IpAdress Delete funct");

            var adress = await _ipAdressService.Delete(id);
            return Ok(adress);
        }
    }
}
