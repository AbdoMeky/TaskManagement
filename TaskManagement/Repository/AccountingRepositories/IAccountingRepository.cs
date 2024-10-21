using TaskManagement.DTO;
using TaskManagement.DTO.DTOForAccounting;

namespace TaskManagement.Repository.Accounting
{
    public interface IAccountingRepository
    {
        Task<RegisteResult> RegisteUser(RegisteModel registeModel);
        Task<RegisteResult> Login(LoginUserDTO userDTO);
        Task<string> AddRoleToUser(RoleRegisteDTO roleDTO);
    }
}
