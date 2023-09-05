using ProjectManagementSystem.Service.DTOs.Members;
using ProjectManagementSystem.Service.DTOs.Projects;
using ProjectManagementSystem.Service.DTOs.Teams;

namespace ProjectManagementSystem.Service.Interfaces;

public interface ITeamService
{
    Task<TeamResultDto> AddAsync(TeamCreationDto dto);
    Task<TeamResultDto> ModifyAsync(TeamUpdateDto dto);
    Task<bool> RemoveAsync(long id);
    Task<TeamResultDto> RetrieveAsync(long id);
    Task<IEnumerable<TeamResultDto>> RetrieveAllAsync();
    Task<IEnumerable<MemberResultDto>> RetrieveAllMembersAsync(long teamId);
    Task<IEnumerable<ProjectResultDto>> RetrieveAllProjectsAsync(long teamId);
}
