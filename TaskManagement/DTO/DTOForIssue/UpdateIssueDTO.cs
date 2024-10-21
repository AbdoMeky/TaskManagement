using System.ComponentModel.DataAnnotations;

namespace TaskManagement.DTO.DTOForIssue
{
    public class UpdateIssueDTO
    {
        [Required]
        [MaxLength(50)]
        public string Title { get; set; }
        [Required]
        [MaxLength(256)]
        public string Description { get; set; }
        [RegularExpression("[LMH]", ErrorMessage = "The value must be either 'L', 'M', or 'H'.")]
        public char Priority { get; set; }
        [Required]
        public DateTime Deadline { get; set; }
    }
}
