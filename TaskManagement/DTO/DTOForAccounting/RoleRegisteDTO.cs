using System.ComponentModel.DataAnnotations;

namespace TaskManagement.DTO.DTOForAccounting
{
    public class RoleRegisteDTO
    {
        [Required]
        public Guid Id { get; set; }
        [Required]
        public string Name { get; set; }
    }
}
