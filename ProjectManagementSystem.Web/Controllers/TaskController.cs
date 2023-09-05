using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using ProjectManagementSystem.Service.DTOs.Tasks;
using ProjectManagementSystem.Service.Interfaces;

namespace ProjectManagementSystem.Web.Controllers;

public class TaskController : Controller
{
    private readonly ITaskService taskService;
    private readonly IMapper mapper;
    public TaskController(ITaskService taskService, IMapper mapper)
    {
        this.taskService = taskService;
        this.mapper = mapper;
    }

    public async Task<IActionResult> Index()
    {
        var res = (await this.taskService.RetrieveAllAsync()).OrderBy(i => i.Id);
        return View(res);
    }

    public IActionResult Create()
    {
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> Create(TaskCreationDto dto)
    {
        await this.taskService.AddAsync(dto);
        return RedirectToAction("Create");
    }

    public async Task<IActionResult> Edit(long id)
    {
        var task = await this.taskService.RetrieveAsync(id);
        var mappedTask = mapper.Map<Domain.Entities.Task>(task);
        return View(mappedTask);
    }

    [HttpPost]
    public async Task<IActionResult> Edit(Domain.Entities.Task model)
    {
        var mappedTask = this.mapper.Map<TaskUpdateDto>(model);
        await this.taskService.ModifyAsync(mappedTask);
        return RedirectToAction("Edit");
    }

    public async Task<IActionResult> Detail(long id)
    {
        var project = await taskService.RetrieveAsync(id);
        var res = mapper.Map<TaskResultDto>(project);
        return View(res);
    }

    public async Task<IActionResult> Delete(long id)
    {
        await this.taskService.RemoveAsync(id);
        return RedirectToAction("Index");
    }

    public async Task<IActionResult> Remainder()
    {
        var tasks = (await taskService.RetrieveAllAsync()).OrderBy(i => i.Id);
        return View(tasks);
    }
}
