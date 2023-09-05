using AutoMapper;
using Microsoft.EntityFrameworkCore;
using ProjectManagementSystem.DAL.IRepositories;
using ProjectManagementSystem.Domain.Entities;
using ProjectManagementSystem.Service.DTOs.Projects;
using ProjectManagementSystem.Service.DTOs.Tasks;
using ProjectManagementSystem.Service.Exceptions;
using ProjectManagementSystem.Service.Interfaces;
using System.Linq.Expressions;

namespace ProjectManagementSystem.Service.Services;

public class ProjectService : IProjectService
{
    private readonly IRepository<Project> repository;
    private readonly IMapper mapper;
    public ProjectService(IRepository<Project> repository, IMapper mapper)
    {
        this.repository = repository;
        this.mapper = mapper;
    }

    public async Task<ProjectResultDto> AddAsync(ProjectCreationDto dto)
    {
        var project = await repository.GetAsync(x => x.Name.Equals(dto.Name));
        if (project is not null)
            throw new AlreadyExistException("Already exist!");

        var mapProject = mapper.Map<Project>(dto);
        await repository.InsertAsync(mapProject);
        await repository.SaveAsync();

        var res = mapper.Map<ProjectResultDto>(mapProject);
        return res;
    }
    
    public async Task<ProjectResultDto> ModifyAsync(ProjectUpdateDto dto)
    {
        var project = await repository.GetAsync(x => x.Id.Equals(dto.Id))
            ?? throw new NotFoundException("Not found!");

        var mapProject = mapper.Map(dto, project);
        repository.Update(mapProject);
        await repository.SaveAsync();

        var res = mapper.Map<ProjectResultDto>(mapProject);
        return res;
    }

    public async Task<bool> RemoveAsync(long id)
    {
        var project = await repository.GetAsync(x => x.Id.Equals(id))
            ?? throw new NotFoundException("Not found!");

        repository.Drop(project);
        await repository.SaveAsync();

        return true;
    }

    public async Task<ProjectResultDto> RetrieveAsync(long id)
    {
        var project = await repository.GetAsync(x => x.Id.Equals(id))
           ?? throw new NotFoundException("Not found!");

        var res = mapper.Map<ProjectResultDto>(project);
        return res;
    }

    public async Task<IEnumerable<ProjectResultDto>> RetrieveAllAsync()
    {
        var project = await repository.GetAllAsync().ToListAsync();
        var res = mapper.Map<IEnumerable<ProjectResultDto>>(project);
        return res;
    }

    public async Task<IEnumerable<TaskResultDto>> RetrieveAllTasksAync(long projectId)
    {
        Expression<Func<Project, bool>> expression = b => b.Id == projectId;

        var project = await repository.GetAsync(expression, new[] { "Tasks" })
            ?? throw new NotFoundException("Not found!");

        var res = mapper.Map<IEnumerable<TaskResultDto>>(project.Tasks);
        return res;
    }
}
