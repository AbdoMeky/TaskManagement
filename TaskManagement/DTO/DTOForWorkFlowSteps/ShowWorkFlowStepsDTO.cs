using TaskManagement.Models.Entities;

namespace TaskManagement.DTO.DTOForWorkFlowSteps
{
    public class ShowWorkFlowStepsDTO
    {
        public DateTime Created { get; set; }
        public string StepName { get; set; }
        public string StepDescription { get; set; }
        public ShowWorkFlowStepsDTO()
        {
            
        }
        public ShowWorkFlowStepsDTO(WorkFlowStep flowStep)
        {
            this.StepDescription = flowStep.StepDescription;
            this.Created = flowStep.Created;
            this.StepName = flowStep.StepName;
        }
    }
}
