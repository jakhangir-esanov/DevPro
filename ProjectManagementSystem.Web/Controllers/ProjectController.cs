using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using ProjectManagementSystem.Domain.Entities;
using ProjectManagementSystem.Service.DTOs.Projects;
using ProjectManagementSystem.Service.DTOs.Tasks;
using ProjectManagementSystem.Service.Interfaces;
using ProjectManagementSystem.Service.Services;

namespace ProjectManagementSystem.Web.Controllers;

public class ProjectController : Controller
{
    private readonly IProjectService projectService;
    private readonly IMapper mapper;
    public ProjectController(IProjectService projectService, IMapper mapper)
    {
        this.projectService = projectService;
        this.mapper = mapper;
    }

    public async Task<IActionResult> Index()
    {
        var res = (await this.projectService.RetrieveAllAsync()).OrderBy(i => i.Id);
        return View(res);
    }

    public IActionResult Create()
    {
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> Create(ProjectCreationDto dto)
    {
        await this.projectService.AddAsync(dto);
        return RedirectToAction("Create");
    }

    public async Task<IActionResult> Edit(long id)
    {
        var project = await this.projectService.RetrieveAsync(id);
        var mappedProject = this.mapper.Map<Project>(project);
        return View(mappedProject);
    }

    [HttpPost]
    public async Task<IActionResult> Edit(Project model)
    {
        var mappedProject = this.mapper.Map<ProjectUpdateDto>(model);
        await this.projectService.ModifyAsync(mappedProject);
        return RedirectToAction("Edit");
    }

    public async Task<IActionResult> Task(long id)
    {
        var project = await projectService.RetrieveAllTasksAync(id);
        var res = mapper.Map<IEnumerable<TaskResultDto>>(project);
        return View(res);
    }

    public async Task<IActionResult> Detail(long id)
    {
        var member = await projectService.RetrieveAsync(id);
        return View(member);
    }

    public async Task<IActionResult> Delete(long id)
    {
        await this.projectService.RemoveAsync(id);
        return RedirectToAction("Index");
    }
}
