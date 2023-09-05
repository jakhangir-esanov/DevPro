using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using ProjectManagementSystem.Domain.Entities;
using ProjectManagementSystem.Service.DTOs.Members;
using ProjectManagementSystem.Service.DTOs.Projects;
using ProjectManagementSystem.Service.DTOs.Teams;
using ProjectManagementSystem.Service.Interfaces;

namespace ProjectManagementSystem.Web.Controllers;

public class TeamController : Controller
{
    private readonly ITeamService teamService;
    private readonly IMapper mapper;
    public TeamController(ITeamService teamService, IMapper mapper)
    {
        this.teamService = teamService;
        this.mapper = mapper;
    }
    public async Task<IActionResult> Index()
    {
        var res = (await this.teamService.RetrieveAllAsync()).OrderBy(i => i.Id);
        return View(res);
    }

    public IActionResult Create()
    {
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> Create(TeamCreationDto dto)
    {
        await this.teamService.AddAsync(dto);
        return RedirectToAction("Create");
    }

    public async Task<IActionResult> Edit(long id)
    {
        var team = await this.teamService.RetrieveAsync(id);
        var mappedTeam = this.mapper.Map<Team>(team);
        return View(mappedTeam);
    }

    [HttpPost]
    public async Task<IActionResult> Edit(Team model)
    {
        var mappedTeam = this.mapper.Map<TeamUpdateDto>(model);
        await this.teamService.ModifyAsync(mappedTeam);
        return RedirectToAction("Edit");
    }

    public async Task<IActionResult> Detail(long id)
    {
        var member = await teamService.RetrieveAllMembersAsync(id);
        var res = mapper.Map<IEnumerable<MemberResultDto>>(member);
        return View(res);
    }

    public async Task<IActionResult> Delete(long id)
    {
        await this.teamService.RemoveAsync(id);
        return RedirectToAction("Index");
    }

    public async Task<IActionResult> Project(long id)
    {
        var project = await teamService.RetrieveAllProjectsAsync(id);
        var res = mapper.Map<IEnumerable<ProjectResultDto>>(project);
        return View(res);
    }
}
