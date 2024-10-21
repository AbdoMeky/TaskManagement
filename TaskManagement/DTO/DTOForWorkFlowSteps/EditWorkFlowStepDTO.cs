using System.ComponentModel.DataAnnotations;

namespace TaskManagement.DTO.DTOForWorkFlowSteps
{
    public class EditWorkFlowStepDTO
    {
        [Required]
        public string StepName { get; set; }
        [Required]
        public string StepDescription { get; set; }
    }
}
