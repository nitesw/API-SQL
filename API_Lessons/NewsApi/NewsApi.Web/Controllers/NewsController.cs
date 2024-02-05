using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NewsApi.Core.Entities;
using NewsApi.Core.Interfaces;

namespace NewsApi.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NewsController : ControllerBase
    {
        private readonly INewsService _newsService;

        public NewsController(INewsService newsService)
        {
            _newsService = newsService;
        }

        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAll()
        {
            var news = await _newsService.GetAll();
            return Ok(news);
        }
        [HttpPost("Get")]
        public async Task<IActionResult> GetById(int id)
        {
            var news = await _newsService.Get(id);
            return Ok(news);
        }
        [HttpDelete("Delete")]
        public async Task<IActionResult> Delete(int id)
        {
            await _newsService.Delete(id);
            return Ok();
        }
        [HttpPatch("Update")]
        public async Task<IActionResult> Update(News newsToUpdate)
        {
            await _newsService.Update(newsToUpdate);
            return Ok();
        }
        [HttpPost("Insert")]
        public async Task<IActionResult> Insert(News model)
        {
            await _newsService.Insert(model);
            return Ok();
        }
    }
}
