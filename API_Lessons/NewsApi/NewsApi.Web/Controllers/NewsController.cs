using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NewsApi.Core.DTOs;
using NewsApi.Core.Entities;
using NewsApi.Core.Interfaces;
using NewsApi.Core.Services;

namespace NewsApi.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NewsController : ControllerBase
    {
        //private readonly IService<News> _newsService;
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
        [HttpPost("GetByCategory")]
        public async Task<IActionResult> GetByCategory(int id)
        {
            var news = await _newsService.GetByCategory(id);
            return Ok(news);
        }
        [HttpPost("GetByAuthor")]
        public async Task<IActionResult> GetByAuthor(string username)
        {
            var news = await _newsService.GetByAuthor(username);
            return Ok(news);
        }
        [HttpDelete("Delete")]
        public async Task<IActionResult> Delete(int id)
        {
            await _newsService.Delete(id);
            return Ok();
        }
        [HttpPatch("Update")]
        public async Task<IActionResult> Update(NewsUpdateDto newsToUpdate)
        {
            await _newsService.Update(newsToUpdate);
            return Ok();
        }
        [HttpPost("Insert")]
        public async Task<IActionResult> Insert(NewsDto model)
        {
            await _newsService.Insert(model);
            return Ok();
        }
    }
}
