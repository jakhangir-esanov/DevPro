using ProjectManagementSystem.Domain.Entities;

namespace ProjectManagementSystem.Service.DTOs.Tasks;

public class TaskResultDto
{
    public long Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public DateTime DueDate { get; set; }

    public Project Project { get; set; }

    public Member Member { get; set; }
}
