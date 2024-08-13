using AutoMapper;
using CoursesApi.Core.DTOs;
using CoursesApi.Core.Entities;
using CoursesApi.Core.Interfaces;
using CoursesApi.Core.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CoursesApi.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CourseController : ControllerBase
    {
        private readonly ICourseService _courseService;
        private readonly IIpAdressService _ipAdressService;

        public CourseController(ICourseService courseService, IIpAdressService ipAdressService)
        {
            _courseService = courseService;
            _ipAdressService = ipAdressService;
        }

        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAll()
        {
            var ipAdress = HttpContext.Connection.RemoteIpAddress;
            await _ipAdressService.CreateLog(ipAdress.ToString(), "Course GetAll funct");

            var course = await _courseService.GetAll();
            return Ok(course);
        }
        [HttpPost("Get")]
        public async Task<IActionResult> GetById(int id)
        {
            var ipAdress = HttpContext.Connection.RemoteIpAddress;
            await _ipAdressService.CreateLog(ipAdress.ToString(), "Course GetById funct");

            var course = await _courseService.Get(id);
            return Ok(course);
        }
        [HttpPost("GetByCategory")]
        public async Task<IActionResult> GetByCategory(int id)
        {
            var ipAdress = HttpContext.Connection.RemoteIpAddress;
            await _ipAdressService.CreateLog(ipAdress.ToString(), "Course GetByCategory funct");

            var course = await _courseService.GetByCategory(id);
            return Ok(course);
        }
        [HttpPost("GetByTutorEmail")]
        public async Task<IActionResult> GetByTutorEmail(string email)
        {
            var ipAdress = HttpContext.Connection.RemoteIpAddress;
            await _ipAdressService.CreateLog(ipAdress.ToString(), "Course GetByTutorEmail funct");

            var course = await _courseService.GetByTutorEmail(email);
            return Ok(course);
        }
        [HttpPost("GetByName")]
        public async Task<IActionResult> GetByName(string name)
        {
            var ipAdress = HttpContext.Connection.RemoteIpAddress;
            await _ipAdressService.CreateLog(ipAdress.ToString(), "Course GetByName funct");

            var course = await _courseService.GetByName(name);
            return Ok(course);
        }
        [HttpDelete("Delete")]
        public async Task<IActionResult> Delete(int id)
        {
            var ipAdress = HttpContext.Connection.RemoteIpAddress;
            await _ipAdressService.CreateLog(ipAdress.ToString(), "Course Delete funct");

            var course = await _courseService.Delete(id);
            return Ok(course);
        }
        [HttpPatch("Update")]
        public async Task<IActionResult> Update(CourseDto courseToUpdate)
        {
            var ipAdress = HttpContext.Connection.RemoteIpAddress;
            await _ipAdressService.CreateLog(ipAdress.ToString(), "Course Update funct");

            var course = await _courseService.Update(courseToUpdate);
            return Ok(course);
        }
        [HttpPost("Insert")]
        public async Task<IActionResult> Insert(CourseDto model)
        {
            var ipAdress = HttpContext.Connection.RemoteIpAddress;
            await _ipAdressService.CreateLog(ipAdress.ToString(), "Course Insert funct");

            var course = await _courseService.Insert(model);
            return Ok(course);
        }
    }
}
