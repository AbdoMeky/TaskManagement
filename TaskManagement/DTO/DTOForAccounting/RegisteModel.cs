using System.ComponentModel.DataAnnotations;

namespace TaskManagement.DTO.DTOForAccounting
{
    public class RegisteModel
    {
        [Required]
        public string FirstName {  get; set; }
        [Required] 
        public string LastName { get; set; }
        [Required]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }
        [Required]
        public string Password { get; set; }
        [Required]
        [Compare("Password")]
        public string PasswordConfirmation { get; set; }
        [Required]
        public string Username { get; set; }
    }
}
