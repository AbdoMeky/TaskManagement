using TaskManagement.DTO.DTOForWorkFlow;
using TaskManagement.Models.Entities;

namespace TaskManagement.DTO.DTOForProject
{
    public class ShowProjectDTO
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime DeadLine { get; set;}
        public string ManagerName { get; set; }
        public ShowWorkFlowInProjectDTO WorkFlowProj { get; set; }
        public ShowProjectDTO(Project project)
        {
            this.Name = project.Name;
            this.Description = project.Description;
            this.CreatedDate = project.CreatedDate;
            this.DeadLine = project.DeadLine;
            this.ManagerName=project.User.FirstName+project.User.LastName;
            this.WorkFlowProj = new ShowWorkFlowInProjectDTO(project.WorkFlow.WorkFlowSteps);
        }
    }
}
