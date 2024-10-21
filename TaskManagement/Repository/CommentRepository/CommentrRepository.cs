using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using TaskManagement.DTO;
using TaskManagement.DTO.DTOForComment;
using TaskManagement.Models.Data;
using TaskManagement.Models.Entities;

namespace TaskManagement.Repository.CommentRepository
{
    public class CommentrRepository : ICommentRepository
    {
        private readonly AppDbContext _context;
        public CommentrRepository(AppDbContext context)
        {
            this._context = context;
        }

        public ShowResultDTO AddComment(AddCommentDTO comment)
        {
            var newComment = new Comment(comment);
            _context.Comments.Add(newComment);
            try
            {
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                return new ShowResultDTO() { Id = 0, Massage = ex.Message };
            }
            return new ShowResultDTO() { Id = newComment.Id };
        }

        public string DeleteComent(int id)
        {
            var comment=_context.Comments.Find(id);
            if (comment is null)
            {
                return "No Comment has this Id";
            }
            _context.Comments.Remove(comment);
            try
            {
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
            return string.Empty;
        }

        public ShowCommentDTO GetComment(int id)
        {
            return _context.Comments.Where(x=>x.Id==id).Select(x=> new ShowCommentDTO() { Content=x.Content,IssueTitle=x.Issue.Title,ProjectName=x.Issue.Project.Name,UserName=x.User.FirstName+x.User.LastName }).FirstOrDefault();
        }

        public List<ShowCommentInIssue> GetCommentsInIssue(int id)
        {
            List<ShowCommentInIssue> comments = _context.Comments.Where(x => x.IssueId == id).Select(x => new ShowCommentInIssue() { Content = x.Content, UserName = x.User.FirstName + x.User.LastName }).ToList();
            return comments;
        }

        public List<ShowCommentInProjectDTO> GetCommentsInProject(int id)
        {
            List<ShowCommentInProjectDTO> comments = _context.Comments.Where(x => x.Issue.ProjectId == id).Select(x => new ShowCommentInProjectDTO() { Content = x.Content, IssueTitle = x.Issue.Title, UserName = x.User.FirstName + x.User.LastName }).ToList();
            return comments;
        }
    }
}
