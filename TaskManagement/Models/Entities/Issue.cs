using TaskManagement.DTO.DTOForIssue;

namespace TaskManagement.Models.Entities
{
    public class Issue
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public char Status { get; set; }// WorkingIn => O     Waiting=>W           Finish=>F
        public char Priority { get; set; }// Low => L      Medium => M       High => H
        public DateTime Created { get; set; }
        public DateTime? LastUpdate { get; set; }
        public DateTime Deadline { get; set; }
        public int ProjectId { get; set; }
        public Project Project { get; set; }
        public int? UserId { get; set; }
        public User? User { get; set; }
        public List<Comment>? Comments { get; set; }
        public List<Attachment>? Attachments { get; set; }
        public Issue(AddIssueDTO issue)
        {
            this.Title = issue.Title;
            this.Description = issue.Description;
            this.Priority = issue.Priority;
            this.Deadline = issue.Deadline;
            this.ProjectId = issue.ProjectId;
            this.UserId = issue.UserId;
            this.Status = 'O';
            this.Created=DateTime.Now;
        }
        public Issue()
        {
            
        }
    }
}
