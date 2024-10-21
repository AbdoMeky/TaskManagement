using TaskManagement.DTO.DTOForWorkFlowSteps;
using TaskManagement.Models.Entities;

namespace TaskManagement.DTO.DTOForWorkFlow
{
    public class ShowWorkFlowDTO
    {
        public string ProjectName { get; set; }
        public List<ShowWorkFlowStepsDTO>? WorkFlowSteps { get; set; }
        public ShowWorkFlowDTO()
        {
            
        }
        public ShowWorkFlowDTO(List<WorkFlowStep> steps,string name)
        {
            this.ProjectName = name;
            foreach (var step in steps)
            {
                this.WorkFlowSteps.Add(new ShowWorkFlowStepsDTO(step));
            }
        }
    }
}
