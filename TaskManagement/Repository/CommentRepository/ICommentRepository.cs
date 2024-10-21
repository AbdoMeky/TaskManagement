using TaskManagement.DTO;
using TaskManagement.DTO.DTOForComment;

namespace TaskManagement.Repository.CommentRepository
{
    public interface ICommentRepository
    {
        ShowResultDTO AddComment(AddCommentDTO comment);
        string DeleteComent(int id);
        ShowCommentDTO GetComment(int id);
        List<ShowCommentInIssue> GetCommentsInIssue(int id);
        List<ShowCommentInProjectDTO> GetCommentsInProject(int id);
    }
}
