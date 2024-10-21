using TaskManagement.DTO;
using TaskManagement.DTO.DTOForIssue;
using TaskManagement.Models.Entities;
namespace TaskManagement.Repository.IssueRepositories
{
    public interface IIssueRepository
    {
        List<ShowIssueDTO> GetAll();
        ShowIssueDTO GetDetails(int id);
        string Update(UpdateIssueDTO issue, int id);
        string Delete(int id);
        ShowResultDTO Add(AddIssueDTO issue);
        string MakeItDone(int id);
        string MakeItWaiting(int id);
        string MakeItOnWorking(int id);
    }
}
