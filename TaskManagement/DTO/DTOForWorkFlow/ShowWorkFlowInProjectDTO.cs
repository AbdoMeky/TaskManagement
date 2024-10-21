using Microsoft.IdentityModel.Tokens;
using TaskManagement.DTO.DTOForWorkFlowSteps;
using TaskManagement.Models.Entities;

namespace TaskManagement.DTO.DTOForWorkFlow
{
    public class ShowWorkFlowInProjectDTO
    {
        public List<ShowWorkFlowStepsDTO> WorkFlowSteps { get; set; }
        public ShowWorkFlowInProjectDTO(IEnumerable<WorkFlowStep> steps)
        {
            this.WorkFlowSteps=new List<ShowWorkFlowStepsDTO>();
            if (steps.IsNullOrEmpty())
                return;
            foreach (var step in steps)
            {
                this.WorkFlowSteps.Add(new ShowWorkFlowStepsDTO(step));
            }
        }
    }
}
