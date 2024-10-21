using System.ComponentModel.DataAnnotations;

namespace TaskManagement.DTO.DTOForUser
{
    public class AddUserDTO
    {
        [Required]
        public string FirstName {  get; set; }
        [Required]
        public string LastName { get; set; }
        [Required]
        public string ApplicationUserId { get; set; }
    }
}
