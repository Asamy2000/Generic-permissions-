using DashboardTemplate.BusinuessLogic;
using DashboardTemplate.Models.PermissionsVM;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using PAT.AccessModel.Models.Info;
using PAT.AccessModel.Models.PermessionsRolesModels;

namespace DashboardTemplate.Controllers
{
    public class UsersRolesController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;

        public UsersRolesController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public IActionResult Index()
        {

            if (TempData["Success"] != null)
            {
                ViewBag.Success = TempData["Success"];
            }
            var model = new AssignRoleToUserVM()
            {
                Roles = _unitOfWork.Repository<Role>().GetAllQueryable()
                .Where(r => r.Name != "Super")
                .Select(r => new SelectListItem
                {
                    Text = r.Name,
                    Value = r.id.ToString()
                }),

                Users = _unitOfWork.Repository<User>().GetAllQueryable().Where(u => u.UserTypeId != 1)
                                                       .Select(u => new SelectListItem
                                                       {
                                                           Text = u.Email,
                                                           Value = u.id.ToString()
                                                       })
            };
            return View(model);
        }


        [HttpPost]
        public async Task<IActionResult> Index(AssignRoleToUserVM model)
        {
            try
            {
                var user = await _unitOfWork.Repository<User>().GetBYIdAsync(model.UserId);
                user.Roles = model.RolesIds.Select(id => new UserRole
                {
                    UserId = model.UserId,
                    RoleId = id
                }).ToList();
                _unitOfWork.Repository<User>().Update(user);
                await _unitOfWork.Complete();
                TempData["Success"] = "Roles assigned successfully";
                return RedirectToAction("Index");
            }
            catch (Exception e)
            {
               ModelState.AddModelError("", e.Message);
                model.Roles = _unitOfWork.Repository<Role>().GetAllQueryable()
                    .Where(r => r.Name != "Super")
                    .Select(r => new SelectListItem
                    {
                        Text = r.Name,
                        Value = r.id.ToString()
                    });
                model.Users = _unitOfWork.Repository<User>().GetAllQueryable().Where(u => u.UserTypeId != 1)
                    .Select(u => new SelectListItem
                    {
                        Text = u.Email,
                        Value = u.id.ToString()
                    });
                _unitOfWork.Rollback();
                return View(model);
            }
        }
    }
}
