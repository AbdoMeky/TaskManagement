using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TaskManagement.Models.Entities;

namespace TaskManagement.Models.Data.Config
{
    public class WorkFlowStepConfig : IEntityTypeConfiguration<WorkFlowStep>
    {
        public void Configure(EntityTypeBuilder<WorkFlowStep> builder)
        {
            builder.Property(x=>x.StepName).HasColumnType("VARCHAR").HasMaxLength(50).IsRequired();
            builder.Property(x=>x.StepDescription).HasColumnType("VARCHAR").HasMaxLength(256).IsRequired();
            builder.HasOne(x=>x.WorkFlow).WithMany(x => x.WorkFlowSteps).HasForeignKey(x=>x.WorkflowId).OnDelete(DeleteBehavior.Cascade);
            builder.ToTable("WorkFlowSteps");
        }
    }
}
