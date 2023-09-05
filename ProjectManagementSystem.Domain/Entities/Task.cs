using ProjectManagementSystem.Domain.Commons;

namespace ProjectManagementSystem.Domain.Entities;

public sealed class Task : Auditable
{
    public string Name { get; set; }
    public string Description { get; set; }
    public DateTime DueDate { get; set; }

    public long projectId { get; set; }
    public Project Project { get; set; }

    public long memberId { get; set; }
    public Member Member { get; set; }
}
