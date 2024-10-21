using System.IO;
using TaskManagement.DTO;
using TaskManagement.DTO.DTOForAttachment;

namespace TaskManagement.Repository.AttachmentRepository
{
    public interface IAttachmentRepository
    {
        Task<List<ShowAttachmentDTO>> GetAllFilesInIssueAsync(int id);
        Task<ShowAttachmentDTO> GetFileAsync(int fileId);
        Task<ShowResultDTO> SaveFileAsync(AddAttachmentDTO attachmentModel);
        Task<ShowResultDTO> DeleteFileAsync(int fileId);
        Task<ShowResultDTO> UpdateFileAsync(int fileId, IFormFile attachmentModel);
    }
}
