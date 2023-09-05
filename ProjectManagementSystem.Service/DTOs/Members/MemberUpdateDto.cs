using ProjectManagementSystem.Domain.Enums;

namespace ProjectManagementSystem.Service.DTOs.Members;

public class MemberUpdateDto
{
    public long Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Email { get; set; }

    public long teamId { get; set; }

    public Role Role { get; set; }
}
