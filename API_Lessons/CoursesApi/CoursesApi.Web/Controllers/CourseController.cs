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

        public CourseController(ICourseService courseService)
        {
            _courseService = courseService;
        }

        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAll()
        {
            var course = await _courseService.GetAll();
            return Ok(course);
        }
        [HttpPost("Get")]
        public async Task<IActionResult> GetById(int id)
        {
            var course = await _courseService.Get(id);
            return Ok(course);
        }
        [HttpPost("GetByCategory")]
        public async Task<IActionResult> GetByCategory(int id)
        {
            var course = await _courseService.GetByCategory(id);
            return Ok(course);
        }
        [HttpPost("GetByTutorEmail")]
        public async Task<IActionResult> GetByTutorEmail(string email)
        {
            var course = await _courseService.GetByTutorEmail(email);
            return Ok(course);
        }
        [HttpPost("GetByName")]
        public async Task<IActionResult> GetByName(string name)
        {
            var course = await _courseService.GetByName(name);
            return Ok(course);
        }
        [HttpDelete("Delete")]
        public async Task<IActionResult> Delete(int id)
        {
            List<CourseDto> courses = await _courseService.GetAll();

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
                return Ok("There is no course with this id!");
            }

            await _courseService.Delete(id);
            return Ok("Course deleted successfully!");
        }
        [HttpPatch("Update")]
        public async Task<IActionResult> Update(CourseDto courseToUpdate)
        {
            var existingCourse = await _courseService.GetByName(courseToUpdate.Name);

            if(existingCourse != null && existingCourse.Id != courseToUpdate.Id)
            {
                return Ok("Course with this name is already exists!");
            }    

            await _courseService.Update(courseToUpdate);
            return Ok("Course updated successfully!");
        }
        [HttpPost("Insert")]
        public async Task<IActionResult> Insert(CourseDto model)
        {
            var existingCourse = await _courseService.GetByName(model.Name);

            if (existingCourse != null)
            {
                return Ok("Course with this name is already exists!");
            }

            await _courseService.Insert(model);
            return Ok("Course added successfully!");
        }
    }
}
