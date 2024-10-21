using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TaskManagement.DTO.DTOForProject;
using TaskManagement.Repository.ProjectRepositories;

namespace TaskManagement.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class ProjectController : ControllerBase
    {
        private readonly IProjectRepository _projectRepository;
        public ProjectController(IProjectRepository projectRepository)
        {
            this._projectRepository = projectRepository;
        }
        [HttpGet]
        public ActionResult GetAll()
        {
            var result =_projectRepository.GetAll();
            if(result == null)
            {
                return BadRequest("No Project yet.");
            }
            return Ok(result);
        }
        [HttpGet("GetProject/{id:int}")]
        public ActionResult Get(int id)
        {
            var result=_projectRepository.GetProject(id);
            if (result == null)
            {
                return BadRequest("No Project has this Id.");
            }
            return Ok(result);
        }
        [HttpGet("GetProjectDetails/{id:int}")]
        public ActionResult GetWithDetails(int id)
        {
            var result = _projectRepository.GetProjectWithAllDetails(id);
            if (result == null)
            {
                return BadRequest("No Project has this Id.");
            }
            return Ok(result);
        }
        [HttpPost]
        public ActionResult Add(AddProjectDTO project)
        {
            if(ModelState.IsValid)
            {
                var result=_projectRepository.AddProject(project);
                if (result.Id==0)
                {
                    return BadRequest(result.Massage);
                }
                string url = Url.Action(nameof(GetWithDetails), new { id = result.Id });
                return Created(url, _projectRepository.GetProjectWithAllDetails(result.Id));
            }
            return BadRequest(ModelState);
        }
        [HttpPut]
        public ActionResult Update(UpdateProjectDTO project, int id)
        {
            if (ModelState.IsValid)
            {
                var result = _projectRepository.UpdateProject(project, id);
                if (string.IsNullOrEmpty(result))
                {
                    return StatusCode(StatusCodes.Status204NoContent, "Update is done");
                }
                return BadRequest(result);
            }
            return BadRequest(ModelState);
        }
        [HttpDelete("{id:int}")]
        public ActionResult Delete(int id)
        {
            var result= _projectRepository.DeleteProject(id);
            if (string.IsNullOrEmpty(result))
            {
                return StatusCode(StatusCodes.Status204NoContent, "Delete is done");
            }
            return BadRequest(result);
        }
    }
}
