using Microsoft.AspNetCore.Identity;

namespace TaskManagement.Models.Entities
{
    public class ApplicationUser:IdentityUser
    {
       public User User { get; set; }
    }
}
