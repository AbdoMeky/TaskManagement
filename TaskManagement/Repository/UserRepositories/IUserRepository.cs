using TaskManagement.DTO;
using TaskManagement.DTO.DTOForUser;

namespace TaskManagement.Repository.UserRepositories
{
    public interface IUserRepository
    {
        int GetId(string ApplicationUserId);
        List<GetUserWithIssueDTO> GetAll();
        GetUserWithIssueDTO GetUserWithAllIssueById(int id);
        GetUserWithIssueDTO GetWithIssueExpiredDone(int id);
        GetUserWithIssueDTO GetWithIssueExpiredFailed(int id);
        GetUserWithIssueDTO GetWithIsuueDone(int id);
        GetUserWithIssueDTO GetWithIssueWait(int id);
        GetUserWithIssueDTO GetWithIssueDidNotFinished(int id);
        GetUserWithProjectDTO GetWithAllProject(int id);
        GetUserWithProjectDTO GetWithProjectExpired(int id);
        GetUserWithProjectDTO GetWithProjectDoNotExpired(int id);
        AllDetailsUserDTO GetWithAllDetails(int id);
        ShowResultDTO Update(UpdateUserDTO newUser,int id);
        int Add(AddUserDTO newUser); 
    }
}
