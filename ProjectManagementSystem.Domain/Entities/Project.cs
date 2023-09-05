using ProjectManagementSystem.Domain.Commons;
using ProjectManagementSystem.Domain.Enums;

namespace ProjectManagementSystem.Domain.Entities;

public sealed class Project : Auditable
{
    public string Name { get; set; }
    public string Description { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
    public ProjectStatus Status { get; set; }

    public long teamId { get; set; }
    public Team Team { get; set; }

    public ICollection<Task> Tasks { get; set; }
}
