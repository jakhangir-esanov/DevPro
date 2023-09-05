using AutoMapper;
using Microsoft.EntityFrameworkCore;
using ProjectManagementSystem.DAL.IRepositories;
using ProjectManagementSystem.Domain.Entities;
using ProjectManagementSystem.Service.DTOs.Members;
using ProjectManagementSystem.Service.DTOs.Tasks;
using ProjectManagementSystem.Service.Exceptions;
using ProjectManagementSystem.Service.Interfaces;
using System.Linq.Expressions;

namespace ProjectManagementSystem.Service.Services;

public class MemberService : IMemberService
{
    private readonly IRepository<Member> repository;
    private readonly IMapper mapper;
    public MemberService(IRepository<Member> repository, IMapper mapper)
    {
        this.repository = repository;
        this.mapper = mapper;
    }

    public async Task<MemberResultDto> AddAsync(MemberCreationDto dto)
    {
        var member = await repository.GetAsync(x => x.Email.Equals(dto.Email));
        if (member is not null)
            throw new AlreadyExistException("Already exist!");

        var mapMember = mapper.Map<Member>(dto);
        await repository.InsertAsync(mapMember);
        await repository.SaveAsync();

        var res = mapper.Map<MemberResultDto>(mapMember);
        return res;
    }

    public async Task<MemberResultDto> ModifyAsync(MemberUpdateDto dto)
    {
        var member = await repository.GetAsync(x => x.Id.Equals(dto.Id))
            ?? throw new NotFoundException("Not found!");

        var mapMember = mapper.Map(dto, member);
        repository.Update(mapMember);
        await repository.SaveAsync();

        var res = mapper.Map<MemberResultDto>(mapMember);
        return res;
    }

    public async Task<bool> RemoveAsync(long id)
    {
        var member = await repository.GetAsync(x => x.Id.Equals(id))
            ?? throw new NotFoundException("Not found!");

        repository.Drop(member);
        await repository.SaveAsync();

        return true;
    }

    public async Task<MemberResultDto> RetrieveAsync(long id)
    {
        var member = await repository.GetAsync(x => x.Id.Equals(id))
                   ?? throw new NotFoundException("Not found!");

        var res = mapper.Map<MemberResultDto>(member);
        return res;
    }

    public async Task<IEnumerable<TaskResultDto>> RetrieveAllTasksAsync(long memberId)
    {
        Expression<Func<Member, bool>> expression = b => b.Id.Equals(memberId);

        var member = await repository.GetAsync(expression, new[] {"Task"})
            ?? throw new NotFoundException("Not found!");

        var res = mapper.Map<IEnumerable<TaskResultDto>>(member.Tasks);
        return res;
    }

    public async Task<IEnumerable<MemberResultDto>> RetrieveAllAsync()
    {
        var member = await repository.GetAllAsync().ToListAsync();
        var res = mapper.Map<IEnumerable<MemberResultDto>>(member);
        return res;
    }
}
