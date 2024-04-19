using DashboardTemplate.BusinuessLogic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PAT.AccessModel.Models.Info;

namespace DashboardTemplate.Controllers
{
    public class RolesController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;

        public RolesController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<IActionResult> Index()
        {
            var roles = await _unitOfWork.Repository<Role>().GetAllAsync();
            return View(roles);
        }

        public IActionResult Create()
        {

            return View();
        }

        // POST: Roles/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Role role)
        {

            try
            {
                await _unitOfWork.Repository<Role>().Add(role);
                await _unitOfWork.Complete();
                return RedirectToAction(nameof(Index));
            }
            catch (Exception)
            {
                _unitOfWork.Rollback();
                ModelState.AddModelError("Error", "an error accoured while saving the model");
                return View(role);
            }

        }

        public async Task<IActionResult> Edit(int id)
        {
            var role = await _unitOfWork.Repository<Role>().GetBYIdAsync(id);
            if (role == null)
            {
                return NotFound();
            }
            return View(role);
        }

        // POST: Roles/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Role role)
        {
            if (id != role.id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _unitOfWork.Repository<Role>().Update(role);
                    await _unitOfWork.Complete();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!RoleExists(role.id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(role);
        }


        public async Task<IActionResult> Delete(int id)
        {
            var role = await _unitOfWork.Repository<Role>().GetBYIdAsync(id);
            if (role == null)
            {
                return NotFound();
            }
            _unitOfWork.Repository<Role>().Delete(role);
            var effectedRows = await _unitOfWork.Complete();
            if (effectedRows > 0)
                return Ok();

            return BadRequest();
        }

        private bool RoleExists(int id)
        {
            var role = _unitOfWork.Repository<Role>().GetBYIdAsync(id);
            if (role != null)
            {
                return true;
            }
            return false;
        }
    }
}
