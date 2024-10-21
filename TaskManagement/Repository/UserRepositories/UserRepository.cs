using Microsoft.EntityFrameworkCore;
using System.Linq;
using TaskManagement.DTO;
using TaskManagement.DTO.DTOForIssue;
using TaskManagement.DTO.DTOForUser;
using TaskManagement.Models.Data;
using TaskManagement.Models.Entities;

namespace TaskManagement.Repository.UserRepositories
{
    public class UserRepository : IUserRepository
    {

        private readonly AppDbContext _context;
        public UserRepository(AppDbContext context)
        {
            _context = context;
        }



        public List<GetUserWithIssueDTO> GetAll()
        {
            var users = _context.Users.Select(x => new GetUserWithIssueDTO
            {
                Name = x.FirstName + x.LastName,
                Issues = (List<ShowIssueInUserDTO>)x.Issues.Select(i => new ShowIssueInUserDTO
                {
                    Title = i.Title,
                    Description = i.Description,
                    Status = i.Status == 'O' ? "WorkingIn" : i.Status == 'W' ? "Waiting" : "Finish",
                    Priority = i.Priority == 'L' ? "Low" : i.Priority == 'M' ? "Medium" : "High",
                    Created = i.Created,
                    LastUpdate = i.LastUpdate,
                    Deadline = i.Deadline,
                    ProjectName = i.Project.Name,
                    ManagerFullName = i.Project.User.FirstName + i.Project.User.LastName
                }).ToList()
            }).ToList();

            return users;
        }

        public GetUserWithIssueDTO GetUserWithAllIssueById(int id)
        {
            var user = _context.Users.Where(x => x.Id == id).Select(x => new GetUserWithIssueDTO
            {
                Name = x.FirstName + x.LastName,
                Issues = (List<ShowIssueInUserDTO>)x.Issues.Select(i => new ShowIssueInUserDTO
                {
                    Title = i.Title,
                    Description = i.Description,
                    Status = i.Status == 'O' ? "WorkingIn" : i.Status == 'W' ? "Waiting" : "Finish",
                    Priority = i.Priority == 'L' ? "Low" : i.Priority == 'M' ? "Medium" : "High",
                    Created = i.Created,
                    LastUpdate = i.LastUpdate,
                    Deadline = i.Deadline,
                    ProjectName = i.Project.Name,
                    ManagerFullName = i.Project.User.FirstName + i.Project.User.LastName
                }).ToList()
            }).ToList();
            return user.FirstOrDefault();
        }

        public GetUserWithIssueDTO GetWithIssueExpiredDone(int id)
        {
            var user = _context.Users.Where(x=>x.Id==id).Select(x => new GetUserWithIssueDTO { Name = x.FirstName + x.LastName,
                Issues = (List<ShowIssueInUserDTO>)x.Issues.Where(i=>i.Status=='F'&&i.Deadline<DateTime.Now).Select(i => new ShowIssueInUserDTO
                {
                    Title = i.Title,
                    Description = i.Description,
                    Status = i.Status == 'O' ? "WorkingIn" : i.Status == 'W' ? "Waiting" : "Finish",
                    Priority = i.Priority == 'L' ? "Low" : i.Priority == 'M' ? "Medium" : "High",
                    Created = i.Created,
                    LastUpdate = i.LastUpdate,
                    Deadline = i.Deadline,
                    ProjectName = i.Project.Name,
                    ManagerFullName = i.Project.User.FirstName + i.Project.User.LastName
                }).ToList()
            }).ToList(); 

            if (user.Count <= 0)
            {
                return null;
            }
            
            return user.FirstOrDefault();
        }
        public GetUserWithIssueDTO GetWithIssueExpiredFailed(int id)
        {
            var user = _context.Users.Where(x => x.Id == id).Select(x => new GetUserWithIssueDTO
            {
                Name = x.FirstName + x.LastName,
                Issues = (List<ShowIssueInUserDTO>)x.Issues.Where(i => i.Status != 'F' && i.Deadline < DateTime.Now).Select(i => new ShowIssueInUserDTO
                {
                    Title = i.Title,
                    Description = i.Description,
                    Status = i.Status == 'O' ? "WorkingIn" : i.Status == 'W' ? "Waiting" : "Finish",
                    Priority = i.Priority == 'L' ? "Low" : i.Priority == 'M' ? "Medium" : "High",
                    Created = i.Created,
                    LastUpdate = i.LastUpdate,
                    Deadline = i.Deadline,
                    ProjectName = i.Project.Name,
                    ManagerFullName = i.Project.User.FirstName + i.Project.User.LastName
                }).ToList()
            }).ToList();
            return user.FirstOrDefault();
        }
        public GetUserWithIssueDTO GetWithIsuueDone(int id)
        {
            var user = _context.Users.Where(x => x.Id == id).Select(x => new GetUserWithIssueDTO
            {
                Name = x.FirstName + x.LastName,
                Issues = (List<ShowIssueInUserDTO>)x.Issues.Where(i => i.Status == 'F').Select(i => new ShowIssueInUserDTO
                {
                    Title = i.Title,
                    Description = i.Description,
                    Status = i.Status == 'O' ? "WorkingIn" : i.Status == 'W' ? "Waiting" : "Finish",
                    Priority = i.Priority == 'L' ? "Low" : i.Priority == 'M' ? "Medium" : "High",
                    Created = i.Created,
                    LastUpdate = i.LastUpdate,
                    Deadline = i.Deadline,
                    ProjectName = i.Project.Name,
                    ManagerFullName = i.Project.User.FirstName + i.Project.User.LastName
                }).ToList()
            }).ToList();
            return user.FirstOrDefault();
        }
        public GetUserWithIssueDTO GetWithIssueDidNotFinished(int id)
        {
            var user = _context.Users.Where(x => x.Id == id).Select(x => new GetUserWithIssueDTO
            {
                Name = x.FirstName + x.LastName,
                Issues = (List<ShowIssueInUserDTO>)x.Issues.Where(i => i.Status != 'F').Select(i => new ShowIssueInUserDTO
                {
                    Title = i.Title,
                    Description = i.Description,
                    Status = i.Status == 'O' ? "WorkingIn" : i.Status == 'W' ? "Waiting" : "Finish",
                    Priority = i.Priority == 'L' ? "Low" : i.Priority == 'M' ? "Medium" : "High",
                    Created = i.Created,
                    LastUpdate = i.LastUpdate,
                    Deadline = i.Deadline,
                    ProjectName = i.Project.Name,
                    ManagerFullName = i.Project.User.FirstName + i.Project.User.LastName
                }).ToList()
            }).ToList();
            return user.FirstOrDefault();
        }
        public GetUserWithIssueDTO GetWithIssueWait(int id)
        {
            var user = _context.Users.Where(x => x.Id == id).Select(x => new GetUserWithIssueDTO
            {
                Name = x.FirstName + x.LastName,
                Issues = (List<ShowIssueInUserDTO>)x.Issues.Where(i => i.Status == 'W').Select(i => new ShowIssueInUserDTO
                {
                    Title = i.Title,
                    Description = i.Description,
                    Status = i.Status == 'O' ? "WorkingIn" : i.Status == 'W' ? "Waiting" : "Finish",
                    Priority = i.Priority == 'L' ? "Low" : i.Priority == 'M' ? "Medium" : "High",
                    Created = i.Created,
                    LastUpdate = i.LastUpdate,
                    Deadline = i.Deadline,
                    ProjectName = i.Project.Name,
                    ManagerFullName = i.Project.User.FirstName + i.Project.User.LastName
                }).ToList()
            }).ToList();
            return user.FirstOrDefault();
        }
        public GetUserWithProjectDTO GetWithAllProject(int id) 
        { 
            var user=_context.Users.Include(x=>x.Projects).FirstOrDefault(x=>x.Id == id);
            if(user == null)
            {
                return null;
            }
            return new GetUserWithProjectDTO(user.FirstName+user.LastName, user.Projects);
        }
        public GetUserWithProjectDTO GetWithProjectExpired(int id)
        {
            var user = _context.Users.Include(x => x.Projects).FirstOrDefault(x => x.Id == id);
            if (user == null)
            {
                return null;
            }
            var list = user.Projects.Where(x => x.DeadLine < DateTime.Now).ToList();
            return new GetUserWithProjectDTO(user.FirstName + user.LastName, list);
        }
        public GetUserWithProjectDTO GetWithProjectDoNotExpired(int id)
        {
            var user = _context.Users.Include(x => x.Projects).FirstOrDefault(x => x.Id == id);
            if (user == null)
            {
                return null;
            }
            var list = user.Projects.Where(x => x.DeadLine >= DateTime.Now).ToList();
            return new GetUserWithProjectDTO(user.FirstName + user.LastName, list);
        }
        public AllDetailsUserDTO GetWithAllDetails(int id)
        {
            var user=_context.Users.Include(x=>x.Projects).Include(x=>x.Issues).ThenInclude(x=>x.Project).FirstOrDefault(x=>x.Id == id);
            if (user==null)
            {
                return null;                
            }
            return new AllDetailsUserDTO(user.FirstName + user.LastName,user.Projects,user.Issues);
        }
        public ShowResultDTO Update(UpdateUserDTO newUser,int id)
        {
            var user = _context.Users.FirstOrDefault(x => x.Id == id);
            if (user is null)
            {
                return new ShowResultDTO() { Id = 0, Massage = "No User has this Id." };
            }
            user.FirstName = newUser.FirstName;
            user.LastName = newUser.LastName;
            try
            {
                _context.SaveChanges();
            }
            catch(Exception ex){
                return new ShowResultDTO() { Massage=ex.Message ,Id=0};
            }
            return new ShowResultDTO() { Id= id };
        }
        public int Add(AddUserDTO newUser)
        {
            User user=new User(newUser);
            _context.Users.Add(user);
            _context.SaveChanges();
            return user.Id;
        }
        public int GetId(string ApplicationUserId)
        {
            return _context.Users.FirstOrDefault(x => x.ApplicationUserId == ApplicationUserId).Id;
        }
    }
}
