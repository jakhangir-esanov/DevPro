using ProjectManagementSystem.Service.DTOs.Members;
using ProjectManagementSystem.Service.DTOs.Tasks;

namespace ProjectManagementSystem.Service.Interfaces;

public interface IMemberService
{
    Task<MemberResultDto> AddAsync(MemberCreationDto dto);
    Task<MemberResultDto> ModifyAsync(MemberUpdateDto dto);
    Task<bool> RemoveAsync(long id);
    Task<MemberResultDto> RetrieveAsync(long id);
    Task<IEnumerable<MemberResultDto>> RetrieveAllAsync();
    Task<IEnumerable<TaskResultDto>> RetrieveAllTasksAsync(long memberId);
}
