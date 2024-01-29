using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace NewsApi.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NewsController : ControllerBase
    {
        [HttpGet("GetAll")]
        public IActionResult GetAll()
        {
            var news = new
            {
                Title = "Microsoft Office’s RTC (Real-Time Channel) migration to modern .NET",
                Description = "Real-Time Channel (RTC) is Microsoft Office Online’s websocket service that powers " +
                "the real-time collaboration experiences for Office applications. It serves hundreds of millions " +
                "of document sessions per day from dozens of datacenters and thousands of server VMs around the world.",
                Text = "Real-Time Channel (RTC) is Microsoft Office Online’s websocket service " +
                "that powers the real-time collaboration experiences for Office applications. " +
                "It serves hundreds of millions of document sessions per day from dozens of datacenters and thousands " +
                "of server VMs around the world.\r\n\r\nThe service was written in .NET Framework (4.7.2) with IIS and " +
                "ASP.NET. It is mainly built around a SignalR service providing real-time communication and has additional " +
                "functionality like routing, session management, and notifications."
            };
            return Ok(news);
        }
    }
}
