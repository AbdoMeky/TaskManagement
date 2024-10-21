using TaskManagement.Models.Entities;

namespace TaskManagement.DTO.DTOForIssue
{
    public class ShowIssueInProjectDTO
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public string Status { get; set; }// WorkingIn => O     Waiting=>W           Finish=>F
        public DateTime Deadline { get; set; }
        public string? DeveloperFullName { get; set; }
        public ShowIssueInProjectDTO(Issue issue)
        {
            this.Title = issue.Title;
            this.Description = issue.Description;
            this.Status = issue.Status == 'O' ? "WorkingIn" : issue.Status == 'W' ? "Waiting" : "Finish";
            this.Deadline = issue.Deadline;
            this.DeveloperFullName = issue.User.FirstName + issue.User.LastName;
        }
    }
}
