using TaskManagement.DTO.DTOForUser;

namespace TaskManagement.Models.Entities
{
    public class User
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public List<Comment>? Comments { get; set; }
        public string ApplicationUserId { get; set; }
        public ApplicationUser ApplicationUser { get; set; }
        public List<Issue>? Issues { get; set; }
        public List<Attachment>? Attachments { get; set; }
        public List<Project>? Projects { get; set; }
        public User()
        {
            
        }
        public User(AddUserDTO newUser)
        {
            this.FirstName = newUser.FirstName;
            this.LastName = newUser.LastName;
            this.ApplicationUserId = newUser.ApplicationUserId;
        }
    }
}
