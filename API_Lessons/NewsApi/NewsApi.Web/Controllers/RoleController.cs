using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NewsApi.Core.DTOs;
using NewsApi.Core.Entities;
using NewsApi.Core.Interfaces;

namespace NewsApi.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RoleController : ControllerBase
    {
        private readonly IService<Role> _roleService;

        public RoleController(IService<Role> roleService)
        {
            _roleService = roleService;
        }

        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAll()
        {
            var roles = await _roleService.GetAll();
            return Ok(roles);
        }
        [HttpPost("Get")]
        public async Task<IActionResult> GetById(int id)
        {
            var roles = await _roleService.Get(id);
            return Ok(roles);
        }
        [HttpDelete("Delete")]
        public async Task<IActionResult> Delete(int id)
        {
            await _roleService.Delete(id);
            return Ok();
        }
        [HttpPatch("Update")]
        public async Task<IActionResult> Update(Role roleToUpdate)
        {
            await _roleService.Update(roleToUpdate);
            return Ok();
        }
        [HttpPost("Insert")]
        public async Task<IActionResult> Insert(Role model)
        {
            await _roleService.Insert(model);
            return Ok();
        }
    }
}
