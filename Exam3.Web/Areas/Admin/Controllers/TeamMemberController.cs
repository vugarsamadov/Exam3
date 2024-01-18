using AutoMapper;
using Exam3.Business.Models.SocialMedia;
using Exam3.Business.Models.TeamMember;
using Exam3.Business.Services.SocialMedias;
using Exam3.Business.Services.TeamMembers;
using Microsoft.AspNetCore.Mvc;

namespace Exam3.Web.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class TeamMemberController : Controller
	{

        private ITeamMemberService _teamMemberService { get; }
        public IMapper _mapper { get; }

        public TeamMemberController(ITeamMemberService teamMemberService, IMapper mapper)
        {
            _teamMemberService = teamMemberService;
            _mapper = mapper;
        }

        public async Task<IActionResult> Index()
        {
            var model = await _teamMemberService.GetAllPaginatedAsync(1, 23);
            return View(model);
        }

        public async Task<IActionResult> Delete(int id)
        {
            await _teamMemberService.SoftDeleteAsync(id);
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> RevokeDelete(int id)
        {
            await _teamMemberService.RevokeSoftDeleteAsync(id);
            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public async Task<IActionResult> Update(int id)
        {
            var model = await _teamMemberService.GetByIdAsync(id);
            var umodel = _mapper.Map<SocialMediaUpdateVM>(model);
            return View(umodel);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Update(int id, UpdateTeamMemberVM model)
        {
            if (!ModelState.IsValid) return View(model);

            await _teamMemberService.UpdateAsync(id, model);

            return RedirectToAction(nameof(Index));
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateTeamMemberVM model)
        {
            if (!ModelState.IsValid) return View(model);

            await _teamMemberService.AddAsync(model);

            return RedirectToAction(nameof(Index));
        }


    }
}
