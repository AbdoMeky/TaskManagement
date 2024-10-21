using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TaskManagement.Models.Entities;

namespace TaskManagement.Models.Data.Config
{
    public class CommentConfig : IEntityTypeConfiguration<Comment>
    {
        public void Configure(EntityTypeBuilder<Comment> builder)
        {
            builder.HasKey(e => e.Id);
            builder.Property(x => x.Content).HasMaxLength(1024).IsRequired();
            builder.Property(x => x.CreatedAt).IsRequired();
            builder.HasOne(x=>x.User).WithMany(x => x.Comments).HasForeignKey(e=>e.UserId).OnDelete(DeleteBehavior.SetNull);
            builder.HasOne(x=>x.Issue).WithMany(x=>x.Comments).HasForeignKey(e=>e.IssueId).OnDelete(DeleteBehavior.Cascade);
            builder.ToTable("Comments");
        }
    }
}
