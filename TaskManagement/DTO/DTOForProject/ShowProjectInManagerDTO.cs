using TaskManagement.Models.Entities;

namespace TaskManagement.DTO.DTOForProject
{
    public class ShowProjectInManagerDTO
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime DeadLine { get; set; }
        public WorkFlow WorkFlow { get; set; }
        public ShowProjectInManagerDTO(Project project)
        {
            this.Name = project.Name;
            this.Description = project.Description;
            this.CreatedDate = project.CreatedDate;
            this.DeadLine = project.DeadLine;
            this.WorkFlow = project.WorkFlow;
        }
    }
}
