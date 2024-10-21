using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using TaskManagement.DTO;
using TaskManagement.DTO.DTOForAccounting;
using TaskManagement.Models.Entities;
using TaskManagement.Repository;
using TaskManagement.Repository.Accounting;

namespace TaskManagement.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountingController : ControllerBase
    {
        private readonly IAccountingRepository _accountingRepository;
        public AccountingController(IAccountingRepository accountingRepository)
        {
            this._accountingRepository = accountingRepository;
        }
        [HttpPost("login")]
        public async Task<IActionResult> LogIn(LoginUserDTO userDTO)
        {
            if (ModelState.IsValid)
            {
                RegisteResult result =await _accountingRepository.Login(userDTO);
                if (result.IsAuthanticated==false)
                {
                    return BadRequest(result.Massage);
                }
                return Ok(result);
            }
            return BadRequest(ModelState);
        }
        [HttpPost("signup")]
        public async Task<IActionResult> Registe(RegisteModel registeModel)
        {
            if (ModelState.IsValid)
            {
                RegisteResult result=await _accountingRepository.RegisteUser(registeModel);
                if(result.IsAuthanticated == false)
                {
                    return BadRequest(result.Massage);
                }
                return Ok(result);
            }
            return BadRequest(ModelState);
        }
    }
}
