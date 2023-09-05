using AutoMapper;
using ProjectManagementSystem.Domain.Entities;
using ProjectManagementSystem.Service.DTOs.Members;
using ProjectManagementSystem.Service.DTOs.Projects;
using ProjectManagementSystem.Service.DTOs.Tasks;
using ProjectManagementSystem.Service.DTOs.Teams;

namespace ProjectManagementSystem.Service.Mappers;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        //Member
        CreateMap<Member, MemberCreationDto>().ReverseMap();
        CreateMap<MemberUpdateDto, Member>().ReverseMap();
        CreateMap<MemberResultDto, Member>().ReverseMap();

        //Project
        CreateMap<Project, ProjectCreationDto>().ReverseMap();
        CreateMap<ProjectUpdateDto, Project>().ReverseMap();
        CreateMap<ProjectResultDto, Project>().ReverseMap();

        //Task
        CreateMap<Domain.Entities.Task, TaskCreationDto>().ReverseMap();
        CreateMap<TaskUpdateDto, Domain.Entities.Task>().ReverseMap();
        CreateMap<TaskResultDto, Domain.Entities.Task>().ReverseMap();

        //Team
        CreateMap<Team, TeamCreationDto>().ReverseMap();
        CreateMap<TeamUpdateDto, Team>().ReverseMap();
        CreateMap<TeamResultDto, Team>().ReverseMap();
    }
}
