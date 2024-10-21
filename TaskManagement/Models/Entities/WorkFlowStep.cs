using TaskManagement.DTO.DTOForWorkFlowSteps;

namespace TaskManagement.Models.Entities
{
    public class WorkFlowStep
    {
        public int Id { get; set; }
        public int WorkflowId { get; set; }
        public WorkFlow WorkFlow { get; set; }
        public DateTime Created { get; set; }
        public string StepName { get; set; } 
        public string StepDescription { get; set; }
        public WorkFlowStep()
        {
            
        }
        public WorkFlowStep(AddWorkFlowStepDTO step)
        {
            this.WorkflowId = step.WorkflowId;
            this.StepName = step.StepName;
            this.StepDescription = step.StepDescription;
            this.Created=DateTime.Now;
        }
    }
}
