using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TaskManagement.Models.Entities;

namespace TaskManagement.Models.Data.Config
{
    public class WorkFlowConfig : IEntityTypeConfiguration<WorkFlow>
    {
        public void Configure(EntityTypeBuilder<WorkFlow> builder)
        {
            builder.HasKey(x => x.Id);
            builder.HasOne(x=>x.Project).WithOne(x=>x.WorkFlow).HasForeignKey<WorkFlow>(x=>x.ProjectId).OnDelete(DeleteBehavior.Cascade);
            builder.ToTable("WorkFlows");
        }
    }
}
