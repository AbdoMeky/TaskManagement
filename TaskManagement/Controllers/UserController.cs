using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TaskManagement.DTO.DTOForUser;
using TaskManagement.Repository.UserRepositories;

namespace TaskManagement.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class UserController : ControllerBase
    {
        
        private readonly IUserRepository _userRepository;
        public UserController(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }
        [HttpGet]
        public ActionResult GetAll()
        {
            var result=_userRepository.GetAll();
            if (result == null)
            {
                return BadRequest("There is No Uesrs Yet.");
            }
            return Ok(result);
        }
        [HttpGet("{id:int}")]
        public ActionResult GetWithAllIssue(int id)
        {
            var user = _userRepository.GetUserWithAllIssueById(id);
            if(user== null)
            {
                return BadRequest("No User Has This Id.");
            }
            return Ok(user);
        }
        [HttpGet("ExpiredDoneIssue/{id:int}")]
        public ActionResult GetWithTaskExpiredDone(int id)
        {
            var result= _userRepository.GetWithIssueExpiredDone(id);
            if (result == null)
            {
                return BadRequest("No User Has This Id.");
            }
            return Ok(result);
        }
        [HttpGet("ExpiredFailedIssue/{id:int}")]
        public ActionResult GetWithTaskExpiredFailed(int id)
        {
            var result = _userRepository.GetWithIssueExpiredFailed(id);
            if (result == null)
            {
                return BadRequest("No User Has This Id.");
            }
            return Ok(result);
        }
        [HttpGet("DoneIssue/{id:int}")]
        public ActionResult GetWithIssueDone(int id)
        {
            var result = _userRepository.GetWithIsuueDone(id);
            if (result == null)
            {
                return BadRequest("No User Has This Id.");
            }
            return Ok(result);
        }
        [HttpGet("WaitingIssue/{id:int}")]
        public ActionResult GetWithIssueWait(int id)
        {
            var result = _userRepository.GetWithIssueWait(id);
            if (result == null)
            {
                return BadRequest("No User Has This Id.");
            }
            return Ok(result);
        }
        [HttpGet("DidNotFinishedIssue/{id:int}")]
        public ActionResult GetWithIssueDidNotFinished(int id)
        {
            var result = _userRepository.GetWithIssueDidNotFinished(id);
            if (result == null)
            {
                return BadRequest("No User Has This Id.");
            }
            return Ok(result);
        }
        [HttpGet("WithAllProject/{id:int}")]
        public ActionResult GetWithAllProject(int id)
        {
            var result=_userRepository.GetWithAllProject(id);
            if (result == null)
            {
                return BadRequest("No User Has This Id.");
            }
            return Ok(result);
        }
        [HttpGet("WithExpiredProject/{id:int}")]
        public ActionResult GetWithExpiredProject(int id)
        {
            var result = _userRepository.GetWithProjectExpired(id);
            if (result == null)
            {
                return BadRequest("No User Has This Id.");
            }
            return Ok(result);
        }
        [HttpGet("WithNotExpiredProject/{id:int}")]
        public ActionResult GetWithNotExpiredProject(int id)
        {
            var result = _userRepository.GetWithProjectDoNotExpired(id);
            if (result == null)
            {
                return BadRequest("No User Has This Id.");
            }
            return Ok(result);
        }
        [HttpGet("WithAllDetails/{id:int}")]
        public ActionResult GetWithAllDetails(int id)
        {
            var result = _userRepository.GetWithAllDetails(id);
            if (result == null)
            {
                return BadRequest("No User Has This Id.");
            }
            return Ok(result);
        }
        [HttpPatch("Update/{id:int}")]
        public ActionResult Update(int id,UpdateUserDTO newUser)
        {
            var result = _userRepository.Update(newUser,id);
            if (result.Id != 0)
            {
                return StatusCode(StatusCodes.Status204NoContent, "It is updated");
            }
            return BadRequest(result.Massage);
        }
    }
}
