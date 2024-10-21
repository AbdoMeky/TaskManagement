using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Diagnostics;
using Microsoft.IdentityModel.Tokens;
using TaskManagement.DTO.DTOForAttachment;
using TaskManagement.Repository.AttachmentRepository;

namespace TaskManagement.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class AttachmentController : ControllerBase
    {
        private readonly IAttachmentRepository _attachmentRepository;
        public AttachmentController(IAttachmentRepository attachmentRepository)
        {
            this._attachmentRepository = attachmentRepository;
        }
        [HttpGet("InIssue/{id:int}")]
        public async Task<ActionResult> GetAttachmentInIssue(int id)
        {
            var result=await _attachmentRepository.GetAllFilesInIssueAsync(id);
            if (result.IsNullOrEmpty())
            {
                return BadRequest("No Issue has this Id OR no Attachment in this Issue.");
            }
            return Ok(result);
        }
        [HttpGet("{id:int}")]
        public async Task<ActionResult> GetAttachment(int id)
        {
            var result=await _attachmentRepository.GetFileAsync(id);
            if(result is null)
            {
                return BadRequest("No Attachment has this Id.");
            }
            return Ok(result);
        }
        [HttpPost]
        public async Task<ActionResult> AddAttachment(AddAttachmentDTO attachmentModel)
        {
            if(ModelState.IsValid)
            {
                var result= await _attachmentRepository.SaveFileAsync(attachmentModel);
                if (result.Id == 0)
                {
                    return BadRequest(result.Massage);
                }
                string url = Url.Action(nameof(GetAttachment), new {id=result.Id});
                return Created(url,await _attachmentRepository.GetFileAsync(result.Id));
            }
            return BadRequest(ModelState);
        }
        [HttpPut("{id:int}")]
        public async Task<ActionResult> UpdateAttachment([FromRoute]int id,IFormFile attachmentModel) { 
            if(ModelState.IsValid)
            {
                var result =await _attachmentRepository.UpdateFileAsync(id, attachmentModel);
                if(result.Id == 0)
                {
                    return BadRequest(result.Massage);
                }
                return StatusCode(StatusCodes.Status204NoContent, "Updated Done.");
            }
            return BadRequest(ModelState);
        }
        [HttpDelete]
        public async Task<ActionResult> DeleteAttachment(int id) {
            var result = await _attachmentRepository.DeleteFileAsync(id);
            if (result.Id == 0)
            {
                return BadRequest(result.Massage);
            }
            return StatusCode(StatusCodes.Status204NoContent, "Deleted Done.");
        }

    }
}
