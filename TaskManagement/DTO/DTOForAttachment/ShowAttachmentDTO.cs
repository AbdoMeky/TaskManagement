using TaskManagement.Models.Entities;

namespace TaskManagement.DTO.DTOForAttachment
{
    public class ShowAttachmentDTO
    {
        public int Id { get; set; }
        public string AttachPath { get; set; }
        public int IssueId {  get; set; }
        public int? UserId {  get; set; }
        public DateTime Updated { get; set; }
        public ShowAttachmentDTO(Attachment attachment)
        {
            this.Id = attachment.Id;
            this.AttachPath = attachment.FilePath;
            this.IssueId = attachment.IssueId;
            this.UserId = attachment.UserId;
            this.Updated = attachment.UploadedAt;
        }
    }
}
