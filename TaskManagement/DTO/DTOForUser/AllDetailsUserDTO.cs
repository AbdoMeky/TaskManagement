using TaskManagement.DTO.DTOForIssue;
using TaskManagement.DTO.DTOForProject;
using TaskManagement.Models.Entities;

namespace TaskManagement.DTO.DTOForUser
{
    public class AllDetailsUserDTO
    {
        public string Name { get; set; }
        public List<ShowIssueDTO> Issues { get; set; }
        public List<ShowProjectInManagerDTO> ShowProjects { get; set; }
        public AllDetailsUserDTO(string Name, List<Project> projects, List<Issue> issues)
        {
            this.Name = Name;
            this.ShowProjects = new List<ShowProjectInManagerDTO>();
            foreach (var project in projects)
            {
                ShowProjects.Add(new ShowProjectInManagerDTO(project));
            }
            Issues = new List<ShowIssueDTO>();
            foreach (var issue in issues)
            {
                var newIssue = new ShowIssueDTO(issue);
                Issues.Add(newIssue);
            }
        }
    }
}
