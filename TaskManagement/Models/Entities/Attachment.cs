using TaskManagement.DTO.DTOForAttachment;

namespace TaskManagement.Models.Entities
{
    public class Attachment
    {
        public int Id { get; set; }
        public string FilePath { get; set; }
        public int IssueId { get; set; }
        public Issue Issue { get; set; }
        public int? UserId { get; set; }
        public User? User { get; set; }
        public DateTime UploadedAt { get; set; }
        public Attachment()
        {
            
        }
        public Attachment(AddAttachmentDTO attachment,string path)
        {
            this.FilePath = path;
            this.IssueId = attachment.IssueId;
            this.UserId = attachment.UserId;
            this.UploadedAt=DateTime.Now;
        }
    }
}
