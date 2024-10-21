using Microsoft.EntityFrameworkCore;
using TaskManagement.DTO;
using TaskManagement.DTO.DTOForIssue;
using TaskManagement.Models.Data;
using TaskManagement.Models.Entities;

namespace TaskManagement.Repository.IssueRepositories
{
    public class IssueRepository : IIssueRepository
    {
        
        private readonly AppDbContext _context;
        public IssueRepository(AppDbContext context)
        {
            _context = context;
        }
        public ShowResultDTO Add(AddIssueDTO issue)
        {
            /*var proj = _context.Projects.Find(issue.ProjectId);
            if (proj is not null && issue.Deadline > proj.DeadLine)
            {
                return new ShowResultDTO() { Id=0,Massage= "it will end fter project end , enter appropriate deadline." };
            }*/
            if (issue.Deadline > _context.Projects.Find(issue.ProjectId).DeadLine)
            {
                return new ShowResultDTO() { Massage = "You put deadline finish after project deadline.", Id = 0 };
            }
            Issue newIssue=new Issue(issue);
            try
            {
                _context.Issues.Add(newIssue);
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                return new ShowResultDTO() { Massage= ex.Message,Id=0};
            }
            return new ShowResultDTO() {Id=newIssue.Id};
        }
        public string Delete(int id)
        {
            Issue issue = this.Get(id);
            if (issue == null)
            {
                return "There is No Issue has this Id to Delete";
            }
            try
            {
                _context.Issues.Remove(issue);
                _context.SaveChanges();
            }
            catch(Exception ex)
            {
                return ex.Message;
            }
            return string.Empty;
        }

        public Issue Get(int id)
        {
            var issue = _context.Issues.Find(id);
            return issue;
        }
        public ShowIssueDTO GetDetails(int id)
        {
            var issue = _context.Issues.Include(x => x.User).Include(x => x.Project).FirstOrDefault(x=>x.Id ==id);
            if (issue is null)
                return null;
            return new ShowIssueDTO(issue);
        }
        public string Update(UpdateIssueDTO issue,int id)
        {
            Issue newIssue= this.Get(id);
            if(newIssue == null)
            {
                return "There is no Issue has this Id to update";
            } 
            newIssue.Priority = issue.Priority;
            newIssue.Description = issue.Description;
            newIssue.Title = issue.Title;
            newIssue.Deadline = issue.Deadline;
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
        public string MakeItDone(int id)
        {
            var task=this.Get(id);
            task.Status= 'F';
            try
            {
                _context.SaveChanges();
            }
            catch(Exception ex) { 
                return ex.Message;
            }
            return string.Empty;
        }

        public List<ShowIssueDTO> GetAll()
        {
            var issues=_context.Issues.Include(x=>x.User).Include(x=>x.Project).ToList();
            List<ShowIssueDTO> result=new List<ShowIssueDTO>();
            foreach( var issue in issues)
            {
                var newIssue = new ShowIssueDTO(issue);
                result.Add(newIssue);
            }
            return result;
        }

        public string MakeItWaiting(int id)
        {
            var task = this.Get(id);
            task.Status = 'W';
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

        public string MakeItOnWorking(int id)
        {
            var task = this.Get(id);
            task.Status = 'O';
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
    }
}
