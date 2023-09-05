using ProjectManagementSystem.Domain.Commons;

namespace ProjectManagementSystem.Domain.Entities;

public sealed class Team : Auditable
{
    public string Name { get; set; }
    public string Description { get; set; }
    public ICollection<Member> Members { get; set; }
    public ICollection<Project> Projects { get; set; }
}

