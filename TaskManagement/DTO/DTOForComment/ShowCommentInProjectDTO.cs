using TaskManagement.Models.Entities;

namespace TaskManagement.DTO.DTOForComment
{
    public class ShowCommentInProjectDTO
    {
        public string Content { get; set; }
        public string IssueTitle { get; set; }
        public string UserName { get; set; }
        public ShowCommentInProjectDTO()
        {
            
        }
        public ShowCommentInProjectDTO(Comment comment)
        {
            this.Content = comment.Content;
            this.UserName=comment.User.FirstName+comment.User.LastName;
            this.IssueTitle = comment.Issue.Title;
        }
    }
}
