using DashboardTemplate.BusinuessLogic;
using DashboardTemplate.Models.PermissionsVM;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using PAT.AccessModel.Models.Info;
using PAT.AccessModel.Models.PermessionsRolesModels;

namespace DashboardTemplate.Controllers
{
    public class RolesPermessionsController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;

        public RolesPermessionsController(IUnitOfWork unitOfWork)
        {

            _unitOfWork = unitOfWork;
        }
        public IActionResult Index()
        {
            if (TempData["Success"] != null)
            {
                ViewBag.Success = TempData["Success"];
            }
            var model = new AssignPermissionsToRoleVM
            {
                Roles = _unitOfWork.Repository<Role>().GetAllQueryable()
                //.Where(r => r.Name != "Super")
                .Select(r => new SelectListItem
                {
                    Text = r.Name,
                    Value = r.id.ToString()
                }),
                Permissions = _unitOfWork.Repository<Permission>().GetAllQueryable().Select(p => new SelectListItem
                {
                    Text = p.MethodName,
                    Value = p.Id.ToString()
                })
            };
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Index(AssignPermissionsToRoleVM model)
        {
            try
            {
                var role = await _unitOfWork.Repository<Role>().GetBYIdAsync(model.RoleId);
                role.Permissions = model.PermissionsIds.Select(id => new RolePermission
                {
                    RoleId = model.RoleId,
                    PermissionId = id
                }).ToList();
                _unitOfWork.Repository<Role>().Update(role);
                await _unitOfWork.Complete();
                TempData["Success"] = "Permissions assigned successfully";
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
                model.Permissions = _unitOfWork.Repository<Permission>().GetAllQueryable().Select(p => new SelectListItem
                {
                    Text = p.MethodName,
                    Value = p.Id.ToString()
                });
                _unitOfWork.Rollback();
                return View(model);
            }

        }

    }
}
