using Microsoft.AspNetCore.Mvc;
using PAT.AccessModel.Models.Info;
using PAT.Provider.Info.Dtos;
using PAT.Provider.Info.Service;

namespace PAT.MVC.Controllers
{
    public class ContactUsController : Controller
    {
        private readonly ContactService _ContactRepo;

        public ContactUsController(ContactService contactService)
        {
            _ContactRepo = contactService;
        }
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var model = new ContactUsDto()
            {
                ContactUsTopicDrobDownItems = await _ContactRepo.GetAllContactUsTopicForDropdown()
            };
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> CreateContact(ContactUsDto model)
        {
            if (ModelState.IsValid)
            {
                var contactToAdd = new ContactUs()
                {
                    ContactUsTopicId = model.ContactUsTopicId,
                    PhoneNumber = model.PhoneNumber,
                    Message = model.Message,
                    Name = model.Name
                };

                await _ContactRepo.AddBranch(contactToAdd);
                return RedirectToAction("Index");
            }

            //redirect to the same page or to a thank you page ?
            return RedirectToAction("Index");
        }
    }
}
