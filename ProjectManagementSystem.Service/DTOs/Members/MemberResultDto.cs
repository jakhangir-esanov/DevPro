using ProjectManagementSystem.Domain.Entities;
using ProjectManagementSystem.Domain.Enums;

namespace ProjectManagementSystem.Service.DTOs.Members;

public class MemberResultDto
{
    public long Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Email { get; set; }

    public Team Team { get; set; }

    public Role Role { get; set; }

    public ICollection<Domain.Entities.Task> Tasks { get; set; }
}