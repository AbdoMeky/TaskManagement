using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TaskManagement.Models.Entities;

namespace TaskManagement.Models.Data.Config
{
    public class ProjectConfig : IEntityTypeConfiguration<Project>
    {
        public void Configure(EntityTypeBuilder<Project> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Name).HasColumnType("VARCHAR").HasMaxLength(50).IsRequired();
            builder.Property(x => x.Description).HasColumnType("VARCHAR").HasMaxLength(256).IsRequired();
            builder.Property(x=>x.CreatedDate).IsRequired();
            builder.Property(x=>x.DeadLine).IsRequired();
            builder.HasOne(x => x.User).WithMany(x => x.Projects).HasForeignKey(X => X.UserId).OnDelete(DeleteBehavior.SetNull);
            builder.ToTable("Projects");
        }
    }
}
