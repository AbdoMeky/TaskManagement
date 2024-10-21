using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TaskManagement.DTO.DTOForComment;
using TaskManagement.Repository.CommentRepository;

namespace TaskManagement.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class CommentController : ControllerBase
    {
        private readonly ICommentRepository _commentRepository;
        public CommentController(ICommentRepository commentRepository)
        {
            this._commentRepository = commentRepository;
        }
        [HttpGet("OneComment/{id:int}")] 
        public IActionResult GetById(int id)
        {
            var result =_commentRepository.GetComment(id);
            if(result == null)
            {
                return BadRequest("No comment has this Id.");
            }
            return Ok(result);
        }
        [HttpGet("Commentinissue/{id:int}")]
        public IActionResult GetCommentOnIssue(int id)
        {
            var result =_commentRepository.GetCommentsInIssue(id);
            if(result == null)
            {
                return BadRequest("No comment in this Issue Or No issue has this Id.");
            }
            return Ok(result);
        }
        [HttpGet("CommentinAllProject/{id:int}")]
        public IActionResult GetCommentOnAllIssueInProject(int id)
        {
            var result = _commentRepository.GetCommentsInProject(id);
            if (result == null)
            {
                return BadRequest("No comment in this Issue Or No issue has this Id.");
            }
            return Ok(result);
        }
        [HttpPost]
        public ActionResult Add(AddCommentDTO comment)
        {
            if (ModelState.IsValid)
            {
                var result = _commentRepository.AddComment(comment);
                if (result.Id == 0)
                {
                    return BadRequest(result.Massage);
                }
                string url=Url.Action(nameof(GetById),new {id=result.Id});
                return Created(url,_commentRepository.GetComment(result.Id));
            }
            return BadRequest(ModelState);
        }
        [HttpDelete]
        public ActionResult Delete(int id)
        {
            var result=_commentRepository.DeleteComent(id);
            if (string.IsNullOrEmpty(result))
            {
                return StatusCode(StatusCodes.Status204NoContent,"Comment is Deleted.");
            }
            return BadRequest(result);
        }
    }
}
