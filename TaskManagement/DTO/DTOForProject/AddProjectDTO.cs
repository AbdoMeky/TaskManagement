using System.ComponentModel.DataAnnotations;
using TaskManagement.Models.Entities;

namespace TaskManagement.DTO.DTOForProject
{
    public class AddProjectDTO
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public string Description { get; set; }
        [Required]
        public DateTime DeadLine { get; set; }
        [Required]
        public int? UserId { get; set; }
    }
}
