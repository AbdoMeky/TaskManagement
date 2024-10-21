using System.ComponentModel.DataAnnotations;
using TaskManagement.Models.Entities;

namespace TaskManagement.DTO.DTOForComment
{
    public class AddCommentDTO
    {
        [Required]
        public string Content { get; set; }
        [Required]
        public int IssueId { get; set; }
        [Required]
        public int UserId { get; set; }
    }
}
