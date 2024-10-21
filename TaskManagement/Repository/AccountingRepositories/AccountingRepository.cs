using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using TaskManagement.DTO;
using TaskManagement.DTO.DTOForAccounting;
using TaskManagement.Models.Data;
using TaskManagement.Models.Entities;
using TaskManagement.Repository.UserRepositories;

namespace TaskManagement.Repository.Accounting
{
    public class AccountingRepository : IAccountingRepository
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly IUserRepository _userRepository;
        private readonly IConfiguration _configuration;
        private readonly AppDbContext _context;
        public AccountingRepository(AppDbContext context,IConfiguration configuration, UserManager<ApplicationUser> userManager, RoleManager<IdentityRole> roleManager, IUserRepository userRepository)
        {
            _roleManager = roleManager;
            _userManager = userManager;
            _userRepository = userRepository;
            _configuration = configuration;
            _context = context;
        }
        public async Task<RegisteResult> Login(LoginUserDTO userDTO)
        {
            ApplicationUser user = await _userManager.FindByEmailAsync(userDTO.Email);
            if (user is null || !await _userManager.CheckPasswordAsync(user, userDTO.Password))
            {
                return new RegisteResult { Massage = "Email or Password is not correct" };
            }
            JwtSecurityToken JwtToken = await CreateToken(user,_userRepository.GetId(user.Id));
            return new RegisteResult
            {
                IsAuthanticated = true,
                Token = new JwtSecurityTokenHandler().WriteToken(JwtToken),
                expiration = JwtToken.ValidTo
            };
        }
        public async Task<RegisteResult> RegisteUser(RegisteModel registeModel)
        {
            if (await _userManager.FindByEmailAsync(registeModel.Email) is not null)
            {
                return new RegisteResult { Massage = "Email is used." };
            }
            if (await _userManager.FindByNameAsync(registeModel.Username) is not null)
            {
                return new RegisteResult { Massage = "Username is used." };
            }
            var newAppUser = new ApplicationUser();
            newAppUser.Email = registeModel.Email;
            newAppUser.UserName = registeModel.Username;

            using (var transaction = _context.Database.BeginTransaction())
            {
                try
                {
                   
                    var result = await _userManager.CreateAsync(newAppUser, registeModel.Password);
                    
                    if (result.Succeeded)
                    {
                        
                        int UserId = _userRepository.Add(new DTO.DTOForUser.AddUserDTO()
                        {
                            FirstName = registeModel.FirstName,
                            LastName = registeModel.LastName,
                            ApplicationUserId = newAppUser.Id
                        });
                        await _context.SaveChangesAsync();
                        await _userManager.AddToRoleAsync(newAppUser, "User");
                        JwtSecurityToken JwtToken = await CreateToken(newAppUser, UserId);
                        transaction.Commit();
                        return new RegisteResult
                        {
                            IsAuthanticated = true,
                            Token = new JwtSecurityTokenHandler().WriteToken(JwtToken),
                            expiration = JwtToken.ValidTo
                        };
                    }
                    string errors = "";
                    foreach (var error in result.Errors)
                    {
                        errors += $", {error.Description}";
                    }
                    return new RegisteResult { Massage = errors };
                }
                catch (Exception ex)
                {
                    return new RegisteResult() { Massage = ex.Message };
                }
            }
        }
        public async Task<string> AddRoleToUser(RoleRegisteDTO roleDTO)
        {
            ApplicationUser user = await _userManager.FindByIdAsync(roleDTO.Id.ToString());
            if (user is null || !await _roleManager.RoleExistsAsync(roleDTO.Name))
            {
                return "user Id or Role Name is not correct";
            }
            if (await _userManager.IsInRoleAsync(user, roleDTO.Name))
            {
                return "the User is already in this Role";
            }
            var result = await _userManager.AddToRoleAsync(user, roleDTO.Name);
            if (result.Succeeded)
            {
                return string.Empty;
            }
            string returnValue = "";
            foreach (var error in result.Errors)
            {
                returnValue += $"{error.Description} ,";
            }
            return returnValue;

        }
        private async Task<JwtSecurityToken> CreateToken(ApplicationUser user,int UserId)
        {
            var claims = new List<Claim>
                        {
                            new Claim(ClaimTypes.NameIdentifier, UserId.ToString()),
                            new Claim(ClaimTypes.Name, user.UserName),
                            new Claim(JwtRegisteredClaimNames.Email,user.Email),
                            new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                        };
            var roles = await _userManager.GetRolesAsync(user);
            foreach (var role in roles)
            {
                claims.Add(new Claim(ClaimTypes.Role, role));
            }
            SecurityKey securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["JWT:SecretKey"]));
            SigningCredentials credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);
            JwtSecurityToken myToken = new JwtSecurityToken(issuer: _configuration["JWT:ValidIssuer"],
                audience: _configuration["JWT:ValidAudiance"],
                claims: claims,
                expires: DateTime.Now.AddMinutes(10),
                signingCredentials: credentials);
            return myToken;
        }
    }
}
