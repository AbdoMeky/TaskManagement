using TaskManagement.DTO.DTOForIssue;
using TaskManagement.DTO.DTOForWorkFlow;
using TaskManagement.Models.Entities;

namespace TaskManagement.DTO.DTOForProject
{
    public class ProjectAllDetailsDTO
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime DeadLine { get; set; }
        public string ManagerName { get; set; }//As Manager
        public ShowWorkFlowInProjectDTO WorkFlow { get; set; }
        public List<ShowIssueInProjectDTO> ShowIssues { get; set; }
        public ProjectAllDetailsDTO(Project project)
        {
            this.Name = project.Name;
            this.Description = project.Description;
            this.CreatedDate = project.CreatedDate;
            this.DeadLine = project.DeadLine;
            this.ManagerName = project.User.FirstName + project.User.LastName;
            if(project.WorkFlow is not null)
            {
               this.WorkFlow = new ShowWorkFlowInProjectDTO(project.WorkFlow.WorkFlowSteps);
            }
            this.ShowIssues = new List<ShowIssueInProjectDTO>();
            foreach(var issue in project.Issues)
            {
                ShowIssues.Add(new ShowIssueInProjectDTO(issue));
            }
        }
    }
}
