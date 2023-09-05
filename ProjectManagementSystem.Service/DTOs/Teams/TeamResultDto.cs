using ProjectManagementSystem.Domain.Entities;

namespace ProjectManagementSystem.Service.DTOs.Teams;

public class TeamResultDto
{
    public long Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public ICollection<Member> Members { get; set; }
    public ICollection<Project> Projects { get; set; }
}