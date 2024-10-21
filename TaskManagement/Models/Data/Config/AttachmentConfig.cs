using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TaskManagement.Models.Entities;

namespace TaskManagement.Models.Data.Config
{
    public class AttachmentConfig : IEntityTypeConfiguration<Attachment>
    {
        public void Configure(EntityTypeBuilder<Attachment> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x=>x.FilePath).HasColumnType("VARCHAR").HasMaxLength(256).IsRequired();
            builder.Property(x=>x.UploadedAt).IsRequired();
            builder.HasOne(x=>x.Issue).WithMany(x=>x.Attachments).HasForeignKey(x=>x.IssueId).OnDelete(DeleteBehavior.Cascade);
            builder.HasOne(x=>x.User).WithMany(x=>x.Attachments).HasForeignKey(x=>x.UserId).OnDelete(DeleteBehavior.SetNull);
            builder.ToTable("Attachments");
        }
    }
}
