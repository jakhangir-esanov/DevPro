using AutoMapper;
using Microsoft.EntityFrameworkCore;
using ProjectManagementSystem.DAL.IRepositories;
using ProjectManagementSystem.Domain.Entities;
using ProjectManagementSystem.Service.DTOs.Members;
using ProjectManagementSystem.Service.DTOs.Projects;
using ProjectManagementSystem.Service.DTOs.Teams;
using ProjectManagementSystem.Service.Exceptions;
using ProjectManagementSystem.Service.Interfaces;
using System.Linq.Expressions;

namespace ProjectManagementSystem.Service.Services;

public class TeamService : ITeamService
{
    private readonly IRepository<Team> repository;
    private readonly IMapper mapper;
    public TeamService(IRepository<Team> repository, IMapper mapper)
    {
        this.repository = repository;
        this.mapper = mapper;
    }

    public async Task<TeamResultDto> AddAsync(TeamCreationDto dto)
    {
        var team = await repository.GetAsync(x => x.Name.Equals(dto.Name));
        if (team is not null)
            throw new AlreadyExistException("Already exist!");

        var mapTeam = mapper.Map<Team>(dto);
        await repository.InsertAsync(mapTeam);
        await repository.SaveAsync();

        var res = mapper.Map<TeamResultDto>(mapTeam);
        return res;
    }

    public async Task<TeamResultDto> ModifyAsync(TeamUpdateDto dto)
    {
        var team = await repository.GetAsync(x => x.Id.Equals(dto.Id))
            ?? throw new NotFoundException("Not found!");

        var mapTeam = mapper.Map(dto, team);
        repository.Update(mapTeam);
        await repository.SaveAsync();

        var res = mapper.Map<TeamResultDto>(mapTeam);
        return res;
    }

    public async Task<bool> RemoveAsync(long id)
    {
        var team = await repository.GetAsync(x => x.Id.Equals(id))
            ?? throw new NotFoundException("Not found!");

        repository.Drop(team);
        await repository.SaveAsync();

        return true;
    }

    public async Task<TeamResultDto> RetrieveAsync(long id)
    {
        var team = await repository.GetAsync(x => x.Id.Equals(id))
           ?? throw new NotFoundException("Not found!");

        var res = mapper.Map<TeamResultDto>(team);
        return res;
    }

    public async Task<IEnumerable<TeamResultDto>> RetrieveAllAsync()
    {
        var team = await repository.GetAllAsync().ToListAsync();
        var res = mapper.Map<IEnumerable<TeamResultDto>>(team);
        return res;
    }

    public async Task<IEnumerable<MemberResultDto>> RetrieveAllMembersAsync(long teamId)
    {
        Expression<Func<Team, bool>> expression = b => b.Id.Equals(teamId);

        var team = await repository.GetAsync(expression, new[] { "Members" })
            ?? throw new NotFoundException("Not found!");

        var res = mapper.Map<IEnumerable<MemberResultDto>>(team.Members);
        return res;
    }

    public async Task<IEnumerable<ProjectResultDto>> RetrieveAllProjectsAsync(long teamId)
    {
        Expression<Func<Team, bool>> expression = b => b.Id.Equals(teamId);

        var team = await repository.GetAsync(expression, new[] { "Projects" })
           ?? throw new NotFoundException("Not found!");

        var res = mapper.Map<IEnumerable<ProjectResultDto>>(team.Projects);
        return res;
    }
}
