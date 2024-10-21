using TaskManagement.DTO.DTOForComment;

namespace TaskManagement.Models.Entities
{
    public class Comment
    {
        public int Id { get; set; }  
        public string Content { get; set; }  
        public int IssueId { get; set; }  
        public Issue Issue { get; set; }  
        public int? UserId { get; set; }  
        public User? User { get; set; }  
        public DateTime CreatedAt { get; set; }
        public Comment()
        {
            
        }
        public Comment(AddCommentDTO comment)
        {
            this.IssueId=comment.IssueId;
            this.UserId=comment.UserId;
            this.Content = comment.Content;
        }
    }
}
