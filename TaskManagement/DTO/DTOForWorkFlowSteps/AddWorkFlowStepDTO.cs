using System.ComponentModel.DataAnnotations;
using TaskManagement.Models.Entities;

namespace TaskManagement.DTO.DTOForWorkFlowSteps
{
    public class AddWorkFlowStepDTO
    {
        [Required]
        public int WorkflowId { get; set; }
        [Required]
        public string StepName { get; set; }
        [Required]
        public string StepDescription { get; set; }
    }
}
