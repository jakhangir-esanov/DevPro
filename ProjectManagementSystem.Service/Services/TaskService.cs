using AutoMapper;
using Microsoft.EntityFrameworkCore;
using ProjectManagementSystem.DAL.IRepositories;
using ProjectManagementSystem.Domain.Entities;
using ProjectManagementSystem.Service.DTOs.Tasks;
using ProjectManagementSystem.Service.Exceptions;
using ProjectManagementSystem.Service.Interfaces;

namespace ProjectManagementSystem.Service.Services;

public class TaskService : ITaskService
{
    private readonly IRepository<Domain.Entities.Task> repository;
    private readonly IMapper mapper;
    public TaskService(IRepository<Domain.Entities.Task> repository, IMapper mapper)
    {
        this.repository = repository;
        this.mapper = mapper;
    }

    public async Task<TaskResultDto> AddAsync(TaskCreationDto dto)
    {
        var task = await repository.GetAsync(x => x.Name.Equals(dto.Name));
        if (task is not null)
            throw new AlreadyExistException("Already exist!");

        var mapTask = mapper.Map<Domain.Entities.Task>(dto);
        await repository.InsertAsync(mapTask);
        await repository.SaveAsync();

        var res = mapper.Map<TaskResultDto>(mapTask);
        return res;
    }

    public async Task<TaskResultDto> ModifyAsync(TaskUpdateDto dto)
    {
        var task = await repository.GetAsync(x => x.Id.Equals(dto.Id))
            ?? throw new NotFoundException("Not found!");

        var mapTask = mapper.Map(dto, task);
        repository.Update(mapTask);
        await repository.SaveAsync();

        var res = mapper.Map<TaskResultDto>(mapTask);
        return res;
    }

    public async Task<bool> RemoveAsync(long id)
    {
        var task = await repository.GetAsync(x => x.Id.Equals(id))
            ?? throw new NotFoundException("Not found!");

        repository.Drop(task);
        await repository.SaveAsync();

        return true;
    }

    public async Task<TaskResultDto> RetrieveAsync(long id)
    {
        var task = await repository.GetAsync(x => x.Id.Equals(id))
            ?? throw new NotFoundException("Not found!");

        var res = mapper.Map<TaskResultDto>(task);
        return res;
    }

    public async Task<IEnumerable<TaskResultDto>> RetrieveAllAsync()
    {
        var task = await repository.GetAllAsync().ToListAsync();
        var res = mapper.Map<IEnumerable<TaskResultDto>>(task);
        return res;
    }
}
