using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using ProjectManagementSystem.Domain.Entities;
using ProjectManagementSystem.Service.DTOs.Members;
using ProjectManagementSystem.Service.Interfaces;

namespace ProjectManagementSystem.Web.Controllers;

public class MemberController : Controller
{
    private readonly IMemberService memberService;
    private readonly IMapper mapper;
    public MemberController(IMemberService memberService, IMapper mapper)
    {
        this.memberService = memberService;
        this.mapper = mapper;
    }
    public async Task<IActionResult> Index()
    {
        var res = (await memberService.RetrieveAllAsync()).OrderBy(i => i.Id);
        return View(res);
    }

    public IActionResult Create() 
    {
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> Create(MemberCreationDto dto)
    {
        await this.memberService.AddAsync(dto);
        return RedirectToAction("Create");
    }

    public async Task<IActionResult> Edit(long id)
    {
        var member = await this.memberService.RetrieveAsync(id);
        var mappedMember = this.mapper.Map<Member>(member);
        return View(mappedMember);
    }

    [HttpPost]
    public async Task<IActionResult> Edit(Member model)
    {
        var mappedMember = this.mapper.Map<MemberUpdateDto>(model);
        await this.memberService.ModifyAsync(mappedMember);
        return RedirectToAction("Edit");
    }

    public async Task<IActionResult> Detail(long id)
    {
        var member = await memberService.RetrieveAsync(id);
        return View(member);
    }

    public async Task<IActionResult> Delete(long id)
    {
        await this.memberService.RemoveAsync(id);
        return RedirectToAction("Index");
    }
}
