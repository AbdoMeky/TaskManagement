using TaskManagement.Models.Entities;

namespace TaskManagement.DTO.DTOForComment
{
    public class ShowCommentInIssue
    {
        public string Content { get; set; }
        public string UserName { get; set; }
        public ShowCommentInIssue()
        {
            
        }
        public ShowCommentInIssue(Comment comment)
        {
            this.Content = comment.Content;
            this.UserName=comment.User.FirstName+comment.User.LastName;
        }
    }
}
