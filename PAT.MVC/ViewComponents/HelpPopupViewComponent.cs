using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using PAT.AccessModel.Models;
using PAT.MVC.Models;
using PAT.Provider.Info.Repos.IRepos;

namespace PAT.MVC.ViewComponents
{

        public class HelpPopupViewComponent : ViewComponent
        {
        private readonly IFAQRepo fAQRepo;
        private readonly IHelperRepo helperRepo;
        private readonly IBranchRepo branchRepo;
        private readonly DBContext _context;

        public HelpPopupViewComponent(IFAQRepo fAQRepo , IHelperRepo helperRepo , IBranchRepo branchRepo , DBContext context)
        {
            this.fAQRepo = fAQRepo;
            this.helperRepo = helperRepo;
            this.branchRepo = branchRepo;
            _context = context;
        }
        
        public IViewComponentResult Invoke()
        {
        
            
            var messagesTypes = helperRepo.GetMessageType();
            var model = new PopupVM()
            {
              
                Types = messagesTypes.Select(x => new SelectListItem { Value = x.Id.ToString(), Text = x.Name }),
                Branches = branchRepo.GetAllBranches().Result.Select(x => new SelectListItem { Value = x.id.ToString(), Text = x.branchName }),
                FAQTypes = _context.FAQCategories.Select(x => new SelectListItem { Value = x.Id.ToString(), Text = x.Name })

            };
                return View(model);
            }
        }

   

}
