using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NewsApi.Core.DTOs;
using NewsApi.Core.Entities;
using NewsApi.Core.Interfaces;

namespace NewsApi.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAll()
        {
            var users = await _userService.GetAll();
            return Ok(users);
        }
        [HttpPost("Get")]
        public async Task<IActionResult> GetById(int id)
        {
            var users = await _userService.Get(id);
            return Ok(users);
        }
        [HttpDelete("Delete")]
        public async Task<IActionResult> Delete(int id)
        {
            await _userService.Delete(id);
            return Ok();
        }
        [HttpPatch("Update")]
        public async Task<IActionResult> Update(UserUpdateDto userToUpdate)
        {
            await _userService.Update(userToUpdate);
            return Ok();
        }
        [HttpPost("Insert")]
        public async Task<IActionResult> Insert(UserDto model)
        {
            await _userService.Insert(model);
            return Ok();
        }
    }
}
