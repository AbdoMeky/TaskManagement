using TaskManagement.DTO;
using TaskManagement.DTO.DTOForProject;

namespace TaskManagement.Repository.ProjectRepositories
{
    public interface IProjectRepository
    {
        List<ShowProjectDTO> GetAll();
        ShowProjectDTO GetProject(int id);
        ProjectAllDetailsDTO GetProjectWithAllDetails(int id);
        ShowResultDTO AddProject(AddProjectDTO project);
        string UpdateProject(UpdateProjectDTO project,int id);
        string DeleteProject(int id);
    }
}
