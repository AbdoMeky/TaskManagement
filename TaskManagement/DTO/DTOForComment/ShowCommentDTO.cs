using System.ComponentModel.DataAnnotations;
using TaskManagement.Models.Entities;

namespace TaskManagement.DTO.DTOForComment
{
    public class ShowCommentDTO
    {
        public string Content { get; set; }
        public string IssueTitle { get; set; }
        public string ProjectName {  get; set; }
        public string UserName { get; set; }
        public ShowCommentDTO()
        {
            
        }
        public ShowCommentDTO(Comment comment)
        {
            this.Content = comment.Content;
            this.IssueTitle = comment.Issue.Title;
            this.ProjectName = comment.Issue.Project.Name;
            this.UserName=comment.User.FirstName+comment.User.LastName;
        }
    }
}
