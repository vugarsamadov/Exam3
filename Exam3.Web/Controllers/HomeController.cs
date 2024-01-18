using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Exam3.Web.Models;
using Exam3.Business.Services.TeamMembers;
using Exam3.Web.Models.Home;

namespace Exam3.Web.Controllers;

public class HomeController : Controller
{

    private ITeamMemberService _teamMemberService { get; }

    public HomeController(ITeamMemberService teamMemberService)
    {
        _teamMemberService = teamMemberService;
    }


    public async Task<IActionResult> Index()
    {
        var teamMembers = await _teamMemberService.GetLastNTeamMembersAsync(3);
        var model = new IndexVM { TeamMembers = teamMembers };
        return View(model);
    }

    public IActionResult Privacy()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
