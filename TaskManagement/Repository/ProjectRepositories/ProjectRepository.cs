using Microsoft.EntityFrameworkCore;
using TaskManagement.DTO;
using TaskManagement.DTO.DTOForProject;
using TaskManagement.Models.Data;
using TaskManagement.Models.Entities;
using TaskManagement.Repository.WorkFlowRepositories;

namespace TaskManagement.Repository.ProjectRepositories
{
    public class ProjectRepository : IProjectRepository
    {
        private readonly AppDbContext _context;
        private readonly IWorkFlowRepository _workFlowRepository;
        public ProjectRepository(AppDbContext context,IWorkFlowRepository workFlowRepository)
        {
            _context = context;
            _workFlowRepository = workFlowRepository;
        }

        public List<ShowProjectDTO> GetAll()
        {
            var projects =_context.Projects.Include(x=>x.User).Include(x=>x.WorkFlow).ThenInclude(x=>x.WorkFlowSteps).ToList();
            var result=new List<ShowProjectDTO>();
            foreach (var project in projects)
            {
                result.Add(new ShowProjectDTO(project));
            }
            return result;
        }

        public ShowProjectDTO GetProject(int id)
        {
            var project=_context.Projects.Include(x=>x.User).Include(x=>x.WorkFlow).ThenInclude(x=>x.WorkFlowSteps).FirstOrDefault(p => p.Id == id);
            if (project is null)
            {
                return null;
            }
            return new ShowProjectDTO(project);
        }

        public ProjectAllDetailsDTO GetProjectWithAllDetails(int id)
        {
            var project=_context.Projects.Include(x=>x.User).Include(x=>x.Issues).ThenInclude(x=>x.User).Include(x=>x.WorkFlow).ThenInclude(x=>x.WorkFlowSteps).FirstOrDefault(x=>x.Id == id);
            if (project is null)
            {
                return null;
            }
            return new ProjectAllDetailsDTO(project);
        }
        public ShowResultDTO AddProject(AddProjectDTO project)
        {
            Project newProject = new Project(project);
            _context.Projects.Add(newProject);
            using (var transaction = _context.Database.BeginTransaction())
            {
                try
                {
                    _context.SaveChanges();
                    var result=_workFlowRepository.Add(newProject.Id);
                    if (! string.IsNullOrEmpty(result))
                    {
                        throw new Exception(result);
                    }
                    transaction.Commit();
                }
                catch (Exception ex)
                {
                    return new ShowResultDTO() { Massage = ex.Message, Id = 0 };
                }/*Microsoft.EntityFrameworkCore.DbUpdateException: 'An error occurred while saving the entity changes. See the inner exception for details.SqlException: The INSERT statement conflicted with the FOREIGN KEY constraint "FK_Projects_Users_UserId". The conflict occurred in database "ManagmentTasks", table "dbo.Users", column 'Id'.'
*/
            }
            return new ShowResultDTO() { Id=newProject.Id};
        }
        public string UpdateProject(UpdateProjectDTO project, int id)
        {
            var oldProject=_context.Projects.FirstOrDefault(x=>x.Id==id);
            if (oldProject is null)
            {
                return "There is no project has this Id";
            }
            oldProject.Name = project.Name;
            oldProject.Description = project.Description;
            oldProject.DeadLine = project.DeadLine;
            try
            {
                _context.SaveChanges();
            }
            catch(Exception ex)
            {
                return ex.Message;
            }
            return string.Empty;
        }
        public string DeleteProject(int id)
        {
            var project = _context.Projects.FirstOrDefault(x=>x.Id==id);
            if(project is null)
            {
                return "There is no project has this Id";
            }
            _context.Projects.Remove(project);
            try
            {
                _context.SaveChanges();
            }
            catch( Exception ex) 
            {
                return ex.Message;
            }
            return string.Empty;
        }
    }
}
