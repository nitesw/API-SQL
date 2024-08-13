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
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryService _categoryService;
        private readonly IIpAdressService _ipAdressService;

        public CategoryController(ICategoryService categoryService, IIpAdressService ipAdressService)
        {
            _categoryService = categoryService;
            _ipAdressService = ipAdressService;
        }

        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAll()
        {
            var ipAdress = HttpContext.Connection.RemoteIpAddress;
            await _ipAdressService.CreateLog(ipAdress.ToString(), "Category GetAll funct");

            var category = await _categoryService.GetAll();
            return Ok(category);
        }
        [HttpPost("Get")]
        public async Task<IActionResult> GetById(int id)
        {
            var ipAdress = HttpContext.Connection.RemoteIpAddress;
            await _ipAdressService.CreateLog(ipAdress.ToString(), "Category GetById funct");

            var category = await _categoryService.Get(id);
            return Ok(category);
        }
        [HttpPost("GetByName")]
        public async Task<IActionResult> GetByName(string name)
        {
            var ipAdress = HttpContext.Connection.RemoteIpAddress;
            await _ipAdressService.CreateLog(ipAdress.ToString(), "Category GetByName funct");

            var category = await _categoryService.GetByName(name);
            return Ok(category);
        }
        [HttpDelete("Delete")]
        public async Task<IActionResult> Delete(int id)
        {
            var ipAdress = HttpContext.Connection.RemoteIpAddress;
            await _ipAdressService.CreateLog(ipAdress.ToString(), "Category Delete funct");

            var course = await _categoryService.Delete(id);
            return Ok(course);
        }
        [HttpPatch("Update")]
        public async Task<IActionResult> Update(CategoryDto categoryToUpdate)
        {
            var ipAdress = HttpContext.Connection.RemoteIpAddress;
            await _ipAdressService.CreateLog(ipAdress.ToString(), "Category Update funct");

            var course = await _categoryService.Update(categoryToUpdate);
            return Ok(course);
        }
        [HttpPost("Insert")]
        public async Task<IActionResult> Insert(CategoryDto model)
        {
            var ipAdress = HttpContext.Connection.RemoteIpAddress;
            await _ipAdressService.CreateLog(ipAdress.ToString(), "Category Insert funct");

            var course = await _categoryService.Insert(model);
            return Ok(course);
        }
    }
}
