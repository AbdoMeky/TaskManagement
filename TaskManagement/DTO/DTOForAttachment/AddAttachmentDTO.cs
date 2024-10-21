using System.ComponentModel.DataAnnotations;
using TaskManagement.Models.Entities;

namespace TaskManagement.DTO.DTOForAttachment
{
    public class AddAttachmentDTO
    {
        [Required]
        public IFormFile file {  get; set; }
        [Required]
        public int IssueId { get; set; }
        [Required]
        public int? UserId { get; set; }
    }
}
