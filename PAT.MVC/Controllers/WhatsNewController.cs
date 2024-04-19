using Microsoft.AspNetCore.Mvc;
using PAT.Provider.Info.Repos.IRepos;

namespace PAT.MVC.Controllers
{
	public class WhatsNewController : Controller
	{
		private readonly IWhatsNewRepo _whatsNewRepo;
		public WhatsNewController(IWhatsNewRepo whatsNewRepo)
		{
			_whatsNewRepo = whatsNewRepo;
		}
		public async Task<IActionResult> Index()
		{
			var whatsNew = await _whatsNewRepo.GetWhatsNew();
			return View(whatsNew);
		}
	}
}
