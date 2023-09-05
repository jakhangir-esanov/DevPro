using ProjectManagementSystem.Service.DTOs.Tasks;

namespace ProjectManagementSystem.Service.Interfaces;

public interface ITaskService
{
    Task<TaskResultDto> AddAsync(TaskCreationDto dto);
    Task<TaskResultDto> ModifyAsync(TaskUpdateDto dto);
    Task<bool> RemoveAsync(long id);
    Task<TaskResultDto> RetrieveAsync(long id);
    Task<IEnumerable<TaskResultDto>> RetrieveAllAsync();
}
