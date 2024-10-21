using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TaskManagement.DTO.DTOForIssue;
using TaskManagement.Repository.IssueRepositories;

namespace TaskManagement.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class IssueController : ControllerBase
    {
        
        private readonly IIssueRepository _issueRepository;
        public IssueController(IIssueRepository issueRepository)
        {
            _issueRepository = issueRepository;
        }
        [HttpGet]
        public IActionResult GetAll()
        {
            var result=_issueRepository.GetAll();
            if(result == null)
            {
                return BadRequest("There is no Issue adden in table");
            }
            return Ok(result);
        }
        [HttpPost]
        public ActionResult Add([FromBody]AddIssueDTO issue)
        {
            if (ModelState.IsValid)
            {
                var result= _issueRepository.Add(issue);
                if(result.Id != 0 )
                {
                    string url = Url.Action(nameof(GetById), new { id = result.Id });
                    return Created(url,_issueRepository.GetDetails(result.Id));
                }
                return BadRequest(result.Massage);
            }
            return BadRequest(ModelState);
        }
        [HttpGet("{id:int}")] 
        public ActionResult GetById(int id) {
            var issue = _issueRepository.GetDetails(id);
            if(issue == null)
            {
                return BadRequest("No Task Has This Id.");
            }
            return Ok(issue);
        }

        [HttpPut("{id:int}")]
        public ActionResult Edit(UpdateIssueDTO issue,int id)
        {
            string result= _issueRepository.Update(issue,id);
            if(string.IsNullOrEmpty(result))
            {
                return StatusCode(StatusCodes.Status204NoContent, "It Is Edited.");
            }
            return BadRequest(result);
        }
        [HttpDelete] 
        public ActionResult Delete(int id) {
            string result= _issueRepository.Delete(id);
            if(string.IsNullOrEmpty(result)) {
                return StatusCode(StatusCodes.Status204NoContent,"It Is Deleted.");
            }
            return BadRequest(result);
        }
    }
}
