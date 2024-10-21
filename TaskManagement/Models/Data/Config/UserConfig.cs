using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TaskManagement.Models.Entities;

namespace TaskManagement.Models.Data.Config
{
    public class UserConfig : IEntityTypeConfiguration<User>
    {
public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.FirstName).HasColumnType("VARCHAR").HasMaxLength(30).IsRequired();
            builder.Property(x => x.LastName).HasColumnType("VARCHAR").HasMaxLength(60).IsRequired();
            builder.HasOne(x => x.ApplicationUser).WithOne(x => x.User).HasForeignKey<User>(x => x.ApplicationUserId).OnDelete(DeleteBehavior.Cascade);
            builder.ToTable("Users");
        }
    }
}
