using Microsoft.AspNetCore.Mvc;
using PAT.AccessModel.Models.Info;
using PAT.MVC.Models;
using PAT.Provider.Info.Repos.IRepos;


namespace PAT.MVC.Controllers
{
    public class HomeController : Controller
    {
        private readonly ICarousalRepo _carousalRepo;
        private readonly IHelperRepo _helperRepo;

        public HomeController(ICarousalRepo carousalRepo , IHelperRepo helperRepo)
        {
            _carousalRepo = carousalRepo;
            _helperRepo = helperRepo;
        }
        public async Task<IActionResult> Index()
        {
            var carusal = await _carousalRepo.GetCarousalAsync();
            var statItems = await _carousalRepo.GetStatItemsAsync();
            var model = new HomeResponse
            {
                Carousal = carusal,
                StatItems = statItems.ToList()
            };
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(PopupVM model)
        {

            var message = new Message
            {
                Content = model.MessageBody,
                Sender = 1,
                Type = model.TypeId,
                SendDate = DateTime.UtcNow,
                ReplyDate = DateTime.Now,
                Subject = model.Topic,
                Reply = "",
                Reviewer = 1,
                BranchId = model.BranchId
            };
            try
            {
                _helperRepo.AddMessage(message);
                return Json(new { success = true, message = "Sent Successfully" });

            }
            catch (Exception)
            {
                ModelState.AddModelError("Error", "an error accoured while saving the model");
                return View(model);
            }

        }
    }
}