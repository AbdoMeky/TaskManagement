using TaskManagement.DTO;
using TaskManagement.DTO.DTOForAttachment;
using TaskManagement.Models.Data;
using TaskManagement.Models.Entities;

namespace TaskManagement.Repository.AttachmentRepository
{
    public class AttachmentRepository : IAttachmentRepository
    {
        private readonly string _storagePath = Path.Combine(Directory.GetCurrentDirectory(), "UploadedAttachment");
        private readonly AppDbContext _context;
        public AttachmentRepository(AppDbContext context)
        {
            this._context = context;
        }
        public async Task<List<ShowAttachmentDTO>> GetAllFilesInIssueAsync(int id)
        {
            var attachments = _context.Attachments.Where(x=>x.IssueId==id).ToList();
            List<ShowAttachmentDTO> result = new List<ShowAttachmentDTO>();
            foreach (var attachment in attachments)
            {
                var fileContent = await File.ReadAllBytesAsync(attachment.FilePath);
                result.Add(new ShowAttachmentDTO(attachment));
            }
            return result;
        }
        public async Task<ShowAttachmentDTO> GetFileAsync(int fileId)
        {
            var attachment = await _context.Attachments.FindAsync(fileId);
            if (attachment == null)
            {
                return null; 
            }
            var fileContent = await File.ReadAllBytesAsync(attachment.FilePath);
            return new ShowAttachmentDTO(attachment);
        }
        public async Task<ShowResultDTO> SaveFileAsync(AddAttachmentDTO attachmentModel)
        {
            if (!Directory.Exists(_storagePath))
            {
                Directory.CreateDirectory(_storagePath);
            }
            var fileName = Path.GetRandomFileName() + Path.GetExtension(attachmentModel.file.FileName);
            var filePath = Path.Combine(_storagePath, fileName);
            var attachment = new Attachment(attachmentModel, filePath);
            _context.Attachments.Add(attachment);
            try
            {
                await _context.SaveChangesAsync();
                using (var stream = new FileStream(filePath, FileMode.Create))
                {
                    await attachmentModel.file.CopyToAsync(stream);
                }
            }
            catch (Exception ex)
            {
                return new ShowResultDTO() { Massage = ex.Message, Id = 0 };
            }
            
            return new ShowResultDTO() {Id = attachment.Id };
        }
        public async Task<ShowResultDTO> DeleteFileAsync(int fileId)
        {
            var attachment = await _context.Attachments.FindAsync(fileId);
            if (attachment == null)
            {
                return new ShowResultDTO() { Id = 0, Massage = "File not found." };
            }
            try
            {
                if (File.Exists(attachment.FilePath))
                {
                    File.Delete(attachment.FilePath);
                }
                _context.Attachments.Remove(attachment);
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                return new ShowResultDTO() { Id = 0, Massage = ex.Message };
            }
            return new ShowResultDTO() { Id = fileId, Massage = "File deleted successfully." };
        }
        public async Task<ShowResultDTO> UpdateFileAsync(int fileId, IFormFile attachmentModel)
        {
            var attachment = await _context.Attachments.FindAsync(fileId);
            if (attachment == null)
            {
                return new ShowResultDTO() { Id = 0, Massage = "File not found." };
            }
            var fileName = Path.GetRandomFileName() + Path.GetExtension(attachmentModel.FileName);
            var filePath = Path.Combine(_storagePath, fileName);
            try
            {
                if (File.Exists(attachment.FilePath))
                {
                    File.Delete(attachment.FilePath);
                }
                attachment.FilePath = filePath;
                using (var stream = new FileStream(filePath, FileMode.Create))
                {
                    await attachmentModel.CopyToAsync(stream);
                }
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                return new ShowResultDTO() { Id = 0, Massage = ex.Message };
            }
            return new ShowResultDTO() { Id = attachment.Id, Massage = "File updated successfully." };
        }


    }
}
