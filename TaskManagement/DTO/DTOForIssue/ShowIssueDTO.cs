using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;
using TaskManagement.Models.Entities;

namespace TaskManagement.DTO.DTOForIssue
{
    public class ShowIssueDTO
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public string Status { get; set; }// WorkingIn => O     Waiting=>W           Finish=>F
        public string Priority { get; set; }// Low => L      Medium => M       High => H
        public DateTime Created { get; set; }
        public DateTime? LastUpdate { get; set; }
        public DateTime Deadline { get; set; }
        public string ProjectName { get; set; }
        public string? DeveloperFullName {  get; set; }
        public ShowIssueDTO(Issue issue)
        {
            this.Title = issue.Title;
            this.Description = issue.Description;
            this.Status = issue.Status == 'O' ? "WorkingIn" : issue.Status == 'W' ? "Waiting" : "Finish";
            this.Priority= issue.Priority == 'L' ? "Low" : issue.Priority == 'M' ? "Medium" : "High"; 
            this.Created = issue.Created;
            this.LastUpdate = issue.LastUpdate;
            this.Deadline = issue.Deadline;
            this.ProjectName = issue.Project.Name;
            this.DeveloperFullName = issue.User.FirstName + issue.User.LastName;
        }
    }
}
