using CoursesApi.Core.DTOs;
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

        public CategoryController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAll()
        {
            var category = await _categoryService.GetAll();
            return Ok(category);
        }
        [HttpPost("Get")]
        public async Task<IActionResult> GetById(int id)
        {
            var category = await _categoryService.Get(id);
            return Ok(category);
        }
        [HttpPost("GetByName")]
        public async Task<IActionResult> GetByName(string name)
        {
            var category = await _categoryService.GetByName(name);
            return Ok(category);
        }
        [HttpDelete("Delete")]
        public async Task<IActionResult> Delete(int id)
        {
            var course = await _categoryService.Delete(id);
            return Ok(course);
        }
        [HttpPatch("Update")]
        public async Task<IActionResult> Update(CategoryDto categoryToUpdate)
        {
            var course = await _categoryService.Update(categoryToUpdate);
            return Ok(course);
        }
        [HttpPost("Insert")]
        public async Task<IActionResult> Insert(CategoryDto model)
        {
            var course = await _categoryService.Insert(model);
            return Ok(course);
        }
    }
}
