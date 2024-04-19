using Microsoft.AspNetCore.Mvc;
using PAT.Provider.Info.Repos.IRepos;

namespace PAT.MVC.ViewComponents
{
    public class NavDarkViewComponent : ViewComponent
    {
        private readonly ISocialRepo _socialPAT;

        public NavDarkViewComponent(ISocialRepo socialPAT)
        {
            _socialPAT = socialPAT;
        }
        public  IViewComponentResult Invoke()
        {

            var topHeader =  _socialPAT.GetTopHeader();

            return View(topHeader);
        }
    }
}
