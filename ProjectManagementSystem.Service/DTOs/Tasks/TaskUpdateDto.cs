namespace ProjectManagementSystem.Service.DTOs.Tasks;

public class TaskUpdateDto
{
    public long Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public DateTime DueDate { get; set; }

    public long projectId { get; set; }

    public long memberId { get; set; }
}
