using ATNewsprimeApp.DtoRequest;
using ATNewsprimeApp.Entitys;
using ATNewsprimeApp.IService;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;

namespace ATNewsprimeApp.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class NewsController : ControllerBase
    {
        private readonly INewsService _newsService;
        public NewsController(INewsService newsService)
        {

            _newsService = newsService;
        }


        [HttpPost("AddNews")]

        public async Task<IActionResult> AddNewsAsync([FromBody] NewsCreateRequest request)
        {
            var adminIdClaim = User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier);
            if (adminIdClaim != null)
            {
                request.CreatedByAdminId = int.Parse(adminIdClaim.Value);
            }

            var result = await _newsService.AddNewsAsync(request);
            return Ok(new { Status = result, Message = "News created successfully" });

        }

        [HttpGet("GatAllNewses")]
        public async Task<IActionResult> GetAllNewAsyncs()
        {
            var list = await _newsService.GetAllNewAsyncs();
            return Ok(list);
        }



        [HttpGet("GetNewsById/{id}")]

        public async Task<IActionResult> GetNewsByIdAsync(int id)
        {
            var news = await _newsService.GetNewsByIdAsync(id);

            if (news == null)
                return NotFound(new { Status = false, Message = "News Not Found" });

            return Ok(news);
        }

        [HttpPut("UpdateNewsById/{id}")]
        public async Task<IActionResult> UpdateNews(int id, UpdatedNewsRequest request)
        {
            var result = await _newsService.UpdatNewsByIdAsync(id, request);

            if (result == null)
                return NotFound(new { message = "News not found" });

            return Ok(result);
        }


        [HttpDelete("DeleteNewsById/{id}")]

        public async Task<IActionResult> DeleteNewsByIdAsync(int id)
        {
            var response = await _newsService.DeleteNewsByIdAsync(id);
            if (response == null)
                return NotFound(new { Status = false, Message = "News Not Found!" });
            return Ok(response);
        }


        [HttpGet("GetAllPublicedNews")]
        public async Task<IActionResult> GetAllPublicedNewsAsync()
        {
            var all= await _newsService.GetAllPublicedNewAsyncs();
            return Ok(all);
        }
    }
}
