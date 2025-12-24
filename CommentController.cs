using ATNewsprimeApp.DtoRequest;
using ATNewsprimeApp.IService;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ATNewsprimeApp.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class CommentController : ControllerBase
    {
        private readonly ICommentService _commentService;

        public CommentController(ICommentService commentService)
        {
            _commentService = commentService;
        }


        [HttpPost("AddComments")]

        public async Task<IActionResult> AddCommentAsync([FromBody] AddCommentRequest request)
        {
            var response = await _commentService.AddCommentAsync(request);

            if (!response.Success)

                return BadRequest(response);

            return Ok(response);
        }


        [HttpGet("GetAllComments")]
        public async Task<IActionResult> GetAllCommentsAsync([FromQuery] int? NewsId)
        {
            var see=await _commentService.GetAllCommentsAsync(NewsId);
            return Ok(see);
        }



        [HttpDelete("DeleteCommentById/{id}")]

        public async Task<IActionResult> DeleteCommentByIdAsync(int id)
        {
            var response = await _commentService.DeleteCommentByIdAsync(id);
            if (response.Success)
                return NotFound(response);
            return Ok(response);
        }
    }
}
