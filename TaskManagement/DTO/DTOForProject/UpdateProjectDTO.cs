using System.ComponentModel.DataAnnotations;

namespace TaskManagement.DTO.DTOForProject
{
    public class UpdateProjectDTO
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public string Description { get; set; }
        [Required]
        public DateTime DeadLine { get; set; }
    }
}
