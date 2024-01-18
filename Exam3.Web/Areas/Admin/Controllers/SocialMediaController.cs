using AutoMapper;
using Exam3.Business.Models;
using Exam3.Business.Models.SocialMedia;
using Exam3.Business.Services.SocialMedias;
using Microsoft.AspNetCore.Mvc;

namespace Exam3.Web.Areas.Admin.Controllers
{
    [Area("Admin")]
	public class SocialMediaController : Controller
	{

        private ISocialMediaService _socialMediaService { get; }
        public IMapper _mapper { get; }

        public SocialMediaController(ISocialMediaService socialMediaService,IMapper mapper)
        {
            _socialMediaService = socialMediaService;
            _mapper = mapper;
        }


        public async Task<IActionResult> Index()
		{
            var model = await _socialMediaService.GetAllPaginatedAsync(1,23);
			return View(model);
		}

        public async Task<IActionResult> Delete(int id)
        {
            await _socialMediaService.SoftDeleteAsync(id);
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> RevokeDelete(int id)
        {
            await _socialMediaService.RevokeSoftDeleteAsync(id);
            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public async Task<IActionResult> Update(int id)
        {
            var model = await _socialMediaService.GetByIdAsync(id);
            var umodel = _mapper.Map<SocialMediaUpdateVM>(model);
            return View(umodel);
        }
        
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Update(int id, SocialMediaUpdateVM model)
        {
            if(!ModelState.IsValid) return View(model);

            await _socialMediaService.UpdateAsync(id,model);

            return RedirectToAction(nameof(Index));
        }

        [HttpPost]
        public async Task<IActionResult> Create(SocialMediaCreateVM model)
        {
            if(!ModelState.IsValid) return View(model);

            await _socialMediaService.AddAsync(model);

            return RedirectToAction(nameof(Index));
        }

    }
}
