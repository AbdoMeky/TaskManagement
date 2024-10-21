using TaskManagement.DTO.DTOForIssue;
using TaskManagement.Models.Entities;

namespace TaskManagement.DTO.DTOForUser
{

    public class GetUserWithIssueDTO
    {
        public string Name { get; set; }
        public List<ShowIssueInUserDTO> Issues { get; set; }
        public GetUserWithIssueDTO()
        {
            
        }
    }
}
