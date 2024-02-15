using CoursesApi.Core.DTOs;
using CoursesApi.Core.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CoursesApi.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CourseController : ControllerBase
    {
        private readonly ICourseService _courseService;

        public CourseController(ICourseService courseService)
        {
            _courseService = courseService;
        }

        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAll()
        {
            var news = await _courseService.GetAll();
            return Ok(news);
        }
        [HttpPost("Get")]
        public async Task<IActionResult> GetById(int id)
        {
            var news = await _courseService.Get(id);
            return Ok(news);
        }
        [HttpDelete("Delete")]
        public async Task<IActionResult> Delete(int id)
        {
            await _courseService.Delete(id);
            return Ok();
        }
        [HttpPatch("Update")]
        public async Task<IActionResult> Update(CourseDto courseToUpdate)
        {
            await _courseService.Update(courseToUpdate);
            return Ok();
        }
        [HttpPost("Insert")]
        public async Task<IActionResult> Insert(CourseDto model)
        {
            await _courseService.Insert(model);
            return Ok();
        }
    }
}
