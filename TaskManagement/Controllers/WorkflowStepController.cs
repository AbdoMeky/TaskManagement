using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TaskManagement.DTO.DTOForWorkFlowSteps;
using TaskManagement.Repository.WorkFlowStepRepositories;

namespace TaskManagement.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class WorkflowStepController : ControllerBase
    {
        private readonly IWorkFlowStepRepository _workFlowStepRepository;
        public WorkflowStepController(IWorkFlowStepRepository workFlowStepRepository)
        {
            this._workFlowStepRepository = workFlowStepRepository;
        }
        [HttpGet]
        public ActionResult Get(int id)
        {
            var result= _workFlowStepRepository.Get(id);
            if(result is null)
            {
                return BadRequest("No WorkFlowStep has this Id.");
            }
            return Ok(result);
        }
        [HttpPost]
        public ActionResult Add(AddWorkFlowStepDTO step)
        {
            var result=_workFlowStepRepository.Add(step);
            if (result.Id == 0)
            {
                return BadRequest(result.Massage);
            }
            string url = Url.Action(nameof(Get), new {id=result.Id});
            return Created(url,_workFlowStepRepository.Get(result.Id));
        }
        [HttpDelete("{id:int}")]
        public ActionResult Delete(int id) {
            var result = _workFlowStepRepository.Delete(id);
            if (string.IsNullOrEmpty(result))
            {
                return StatusCode(StatusCodes.Status204NoContent, "is deleted");
            }
            return BadRequest(result);
        }
        [HttpPut("{id:int}")]
        public ActionResult update(int id,EditWorkFlowStepDTO step)
        {
            var result = _workFlowStepRepository.Edit(step, id);
            if(string.IsNullOrEmpty(result))
            {
                return StatusCode(StatusCodes.Status204NoContent, "is updated");
            }
            return BadRequest(result);
        }
    }
}
