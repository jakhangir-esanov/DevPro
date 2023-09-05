using ProjectManagementSystem.Domain.Enums;

namespace ProjectManagementSystem.Service.DTOs.Projects;

public class ProjectUpdateDto
{
    public long Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
    public ProjectStatus Status { get; set; }

    public long teamId { get; set; }
}