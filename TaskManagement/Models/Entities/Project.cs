using TaskManagement.DTO.DTOForProject;

namespace TaskManagement.Models.Entities
{
    public class Project
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime DeadLine { get; set;}
        public List<Issue>? Issues { get; set; }
        public int? UserId {  get; set; }
        public User? User { get; set; }//As Manager
        public WorkFlow? WorkFlow { get; set; }
        public Project()
        {
            
        }
        public Project(AddProjectDTO project)
        {
            this.Name = project.Name;
            this.Description = project.Description;
            this.CreatedDate=DateTime.Now;
            this.DeadLine = DateTime.Now;
            this.UserId = project.UserId;
        }
    }
}
