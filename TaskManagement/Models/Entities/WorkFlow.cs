namespace TaskManagement.Models.Entities
{
    public class WorkFlow
    {
        public int Id { get; set; }
        public int ProjectId { get; set; }
        public Project Project { get; set; }
        public ICollection<WorkFlowStep>? WorkFlowSteps { get; set; }
    }
}
