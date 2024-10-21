using TaskManagement.Models.Entities;

namespace TaskManagement.DTO.DTOForIssue
{
    public class ShowIssueInUserDTO
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public string Status { get; set; }// WorkingIn => O     Waiting=>W           Finish=>F
        public string Priority { get; set; }// Low => L      Medium => M       High => H
        public DateTime Created { get; set; }
        public DateTime? LastUpdate { get; set; }
        public DateTime Deadline { get; set; }
        public string ProjectName { get; set; }
        public string? ManagerFullName { get; set; }
        public ShowIssueInUserDTO()
        {
            
        }
    }
}
