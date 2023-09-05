using ProjectManagementSystem.Domain.Commons;
using ProjectManagementSystem.Domain.Enums;

namespace ProjectManagementSystem.Domain.Entities;

public sealed class Member : Auditable
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Email { get; set; }

    public long teamId { get; set; }
    public Team Team { get; set; }

    public Role Role { get; set; }

    public ICollection<Task> Tasks { get; set; }
}
