using System.ComponentModel.DataAnnotations;

namespace TaskManagement.DTO.DTOForUser
{
    public class UpdateUserDTO
    {
        [Required]
        public string FirstName {  get; set; }
        [Required] 
        public string LastName { get; set; }
    }
}
