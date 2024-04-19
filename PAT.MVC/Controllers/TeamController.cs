using Microsoft.AspNetCore.Mvc;
using PAT.Provider.Info.Repos.IRepos;

namespace PAT.MVC.Controllers
{
    public class TeamController : Controller
    {
        private readonly ITeamMembersRepo _teamRepo;
        public TeamController(ITeamMembersRepo teamRepo)
        {
            _teamRepo = teamRepo;
        }
        public async Task<IActionResult> IndexAsync()
        {
            var team = await _teamRepo.GetTeamMembers();
            return View(team);
        }
    }
}
