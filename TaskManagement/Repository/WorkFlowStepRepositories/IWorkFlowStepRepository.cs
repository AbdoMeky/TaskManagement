using TaskManagement.DTO;
using TaskManagement.DTO.DTOForWorkFlowSteps;

namespace TaskManagement.Repository.WorkFlowStepRepositories
{
    public interface IWorkFlowStepRepository
    {
        ShowWorkFlowStepsDTO Get(int id);
        ShowResultDTO Add(AddWorkFlowStepDTO step);
        string Edit(EditWorkFlowStepDTO step,int id);
        string Delete(int id);

    }
}
