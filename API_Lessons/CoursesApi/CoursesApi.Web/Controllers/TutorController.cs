using CoursesApi.Core.DTOs;
using CoursesApi.Core.Interfaces;
using CoursesApi.Core.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CoursesApi.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TutorController : ControllerBase
    {
        private readonly ITutorService _tutorService;

        public TutorController(ITutorService tutorService)
        {
            _tutorService = tutorService;
        }

        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAll()
        {
            var tutor = await _tutorService.GetAll();
            return Ok(tutor);
        }
        [HttpPost("Get")]
        public async Task<IActionResult> GetById(int id)
        {
            var tutor = await _tutorService.Get(id);
            return Ok(tutor);
        }
        [HttpPost("GetByRating")]
        public async Task<IActionResult> GetByRating(int rating)
        {
            var tutor = await _tutorService.GetByRating(rating);
            return Ok(tutor);
        }
        [HttpPost("GetByEmail")]
        public async Task<IActionResult> GetByEmail(string email)
        {
            var tutor = await _tutorService.GetByEmail(email);
            return Ok(tutor);
        }
        [HttpDelete("Delete")]
        public async Task<IActionResult> Delete(int id)
        {
            List<TutorDto> tutors = await _tutorService.GetAll();

            bool isExists = false;
            foreach (var item in tutors)
            {
                if (item.Id == id)
                {
                    isExists = true;
                }
            }

            if (!isExists)
            {
                return Ok("There is no tutor with this id!");
            }

            await _tutorService.Delete(id);
            return Ok("Tutor deleted successfully!");
        }
        [HttpPatch("Update")]
        public async Task<IActionResult> Update(TutorDto tutorToUpdate)
        {
            var existingTutor = await _tutorService.GetByEmail(tutorToUpdate.Email);

            if (existingTutor != null && existingTutor.Id != tutorToUpdate.Id)
            {
                return Ok("Tutor with this name already exists!");
            }

            await _tutorService.Update(tutorToUpdate);
            return Ok("Tutor updated successfully!");
        }
        [HttpPost("Insert")]
        public async Task<IActionResult> Insert(TutorDto model)
        {
            var existingTutor = await _tutorService.GetByEmail(model.Email);

            if (existingTutor != null)
            {
                return Ok("Tutor with this email already exists!");
            }

            await _tutorService.Insert(model);
            return Ok("Tutor is added successfully!");
        }
    }
}
