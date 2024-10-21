using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TaskManagement.Models.Entities;

namespace TaskManagement.Models.Data.Config
{
    public class IssueConfig : IEntityTypeConfiguration<Issue>
    {
        public void Configure(EntityTypeBuilder<Issue> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x=>x.Title).HasColumnType("VARCHAR").HasMaxLength(50).IsRequired();
            builder.Property(x => x.Description).HasColumnType("VARCHAR").HasMaxLength(1024).IsRequired();
            builder.Property(x =>x.Created).IsRequired();
            builder.Property(x=>x.Deadline).IsRequired();
            builder.Property(x=>x.Deadline).IsRequired();
            builder.HasOne(x => x.User).WithMany(x => x.Issues).HasForeignKey(x => x.UserId).OnDelete(DeleteBehavior.SetNull);
            builder.HasOne(x=>x.Project).WithMany(x=>x.Issues).HasForeignKey(x => x.ProjectId).OnDelete(DeleteBehavior.Cascade);
            builder.ToTable("Issues");
        }
    }
}
