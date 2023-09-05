using ProjectManagementSystem.Service.DTOs.Projects;
using ProjectManagementSystem.Service.DTOs.Tasks;

namespace ProjectManagementSystem.Service.Interfaces;

public interface IProjectService
{
    Task<ProjectResultDto> AddAsync(ProjectCreationDto dto);
    Task<ProjectResultDto> ModifyAsync(ProjectUpdateDto dto);
    Task<bool> RemoveAsync(long id);
    Task<ProjectResultDto> RetrieveAsync(long id);
    Task<IEnumerable<ProjectResultDto>> RetrieveAllAsync();
    Task<IEnumerable<TaskResultDto>> RetrieveAllTasksAync(long projectId);
}
