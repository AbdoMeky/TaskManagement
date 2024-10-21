using Microsoft.EntityFrameworkCore;
using TaskManagement.DTO.DTOForWorkFlow;
using TaskManagement.Models.Data;
using TaskManagement.Models.Entities;

namespace TaskManagement.Repository.WorkFlowRepositories
{
    public class WorkFlowRepository : IWorkFlowRepository
    {
        private readonly AppDbContext _context;
        public WorkFlowRepository(AppDbContext context)
        {
            _context = context;
        }
        public string Add(int projectId)
        {
            var Flow=new WorkFlow() { ProjectId=projectId};
            _context.WorkFlows.Add(Flow);
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

        public ShowWorkFlowDTO Get(int id)
        {
            var workFlow=_context.WorkFlows.Include(x=>x.Project).Include(x=>x.WorkFlowSteps).FirstOrDefault(x=>x.Id==id);
            if(workFlow == null)
            {
                return null;
            }
            var result = new ShowWorkFlowDTO(workFlow.WorkFlowSteps.ToList(), workFlow.Project.Name);
            return result;
        }
    }
}
