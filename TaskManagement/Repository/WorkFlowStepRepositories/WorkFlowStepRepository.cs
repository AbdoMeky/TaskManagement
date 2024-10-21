using Microsoft.EntityFrameworkCore.Query.Internal;
using TaskManagement.DTO;
using TaskManagement.DTO.DTOForWorkFlowSteps;
using TaskManagement.Models.Data;
using TaskManagement.Models.Entities;

namespace TaskManagement.Repository.WorkFlowStepRepositories
{
    public class WorkFlowStepRepository : IWorkFlowStepRepository
    {
        private readonly AppDbContext _context;
        public WorkFlowStepRepository()
        {
            
        }
        public WorkFlowStepRepository(AppDbContext context)
        {
            this._context = context;
        }
        public ShowResultDTO Add(AddWorkFlowStepDTO step)
        {
            var newStep = new WorkFlowStep(step);
            _context.WorkFlowSteps.Add(newStep);
            try
            {
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                return new ShowResultDTO() { Id = 0, Massage = ex.Message };
            }
            return new ShowResultDTO(){Id=newStep.Id};
        }

        public string Delete(int id)
        {
            var step = _context.WorkFlowSteps.Find(id);
            if (step == null)
            {
                return "No WorkFlowStep has this Id to delete.";
            }
            _context.WorkFlowSteps.Remove(step);
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

        public string Edit(EditWorkFlowStepDTO step, int id)
        {
            var oldStep=_context.WorkFlowSteps.FirstOrDefault(x=>x.Id == id);
            if(oldStep == null)
            {
                return "No WorkFlowStep has this Id.";
            }
            oldStep.StepName = step.StepName;
            oldStep.StepDescription = step.StepDescription;
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
        public ShowWorkFlowStepsDTO Get(int id)
        {
            var step= _context.WorkFlowSteps.Find(id);
            if(step is null)
            {
                return null;
            }
            ShowWorkFlowStepsDTO showStep = new ShowWorkFlowStepsDTO(step);
            return showStep;
        }
    }
}
