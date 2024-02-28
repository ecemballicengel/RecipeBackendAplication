using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Recipe.Bll.Services.CommentServices;
using Recipe.Dtos.Request;

namespace Recipe.Api.Controllers
{
    [Route("api/[controller]")]
    [Authorize]
    [ApiController]
    public class CommentController : ControllerBase
    {
        private readonly ICommentService _commentService;

        public CommentController(ICommentService commentService)
        {
            _commentService = commentService;
        }

        [HttpPost]
        public IActionResult CreateComment(CreateCommentRequestDto request)
        {
            _commentService.CreateComment(request);
            return Ok("Yorum başarıyla oluşturuldu.");
        }
        [HttpPut]
        public IActionResult UpdateComment(UpdateCommentRequestDto request)
        {
            _commentService.UpdateComment(request);
            return Ok("Yorum basarili bir sekilde guncellendi");
        }
        [HttpDelete]
        public IActionResult DeleteComment(DeleteCommentRequestDto request) 
        {
            _commentService.DeleteComment(request);
            return Ok("Yorum silindi");
        }

        [HttpGet("{id}")]
        public IActionResult GetCommentById(int id) 
        { 
            var data = _commentService.GetCommentById(new GetCommentByIdRequestDto { Id = id});
            return Ok(data);
        }

        [AllowAnonymous]
        [HttpGet]
        public IActionResult GetComments()
        {
            var data = _commentService.GetAllComment();
            return Ok(data);
        }


    }
}

