using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using PAT.AccessModel.Models.Info;
using PAT.Provider.Info.Dtos;
using PAT.Provider.Info.Service;

namespace PAT.MVC.Controllers
{
    public class BranchesController : Controller
    {
        private readonly BranchService _branchRepo;
        private readonly IMapper _mapper;

        public BranchesController(BranchService branchRepo, IMapper mapper)
        {
            _branchRepo = branchRepo;
            _mapper = mapper;
        }
        public async Task<ActionResult<BranchToReturnDto>> Index()
        {
            var model = new BranchToReturnDto()
            {
                BranchesDrobDownItems = await _branchRepo.GetAllBranchesForDropdown()
            };

            return View(model);
        }

        public async Task<ActionResult<BranchDetailsToReturnDto>> Details(int id)
        {
            var branch = await _branchRepo.GetBranchById(id);
            if (branch == null)
                return NotFound();

            var model = _mapper.Map<Branch, BranchDetailsToReturnDto>(branch);
            return PartialView("_BranchesDetails", model);
        }
    }
}
