using TaskManagement.DTO.DTOForProject;
using TaskManagement.Models.Entities;

namespace TaskManagement.DTO.DTOForUser
{
    public class GetUserWithProjectDTO
    {
        public string Name {  get; set; }
        public List<ShowProjectInManagerDTO> ShowProjects { get; set; }
        public GetUserWithProjectDTO(string Name,List<Project>projects)
        {
            this.Name = Name;
            this.ShowProjects = new List<ShowProjectInManagerDTO>();
            foreach(var project in projects)
            {
                ShowProjects.Add(new ShowProjectInManagerDTO(project));
            }
        }
    }
}
