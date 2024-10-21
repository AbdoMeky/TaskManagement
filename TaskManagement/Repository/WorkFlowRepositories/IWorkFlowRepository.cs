using TaskManagement.DTO.DTOForWorkFlow;

namespace TaskManagement.Repository.WorkFlowRepositories
{
    public interface IWorkFlowRepository
    {
        String Add(int projectId);
        ShowWorkFlowDTO Get(int id);
    }
}
