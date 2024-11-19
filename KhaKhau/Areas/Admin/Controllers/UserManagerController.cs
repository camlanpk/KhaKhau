using KhaKhau.Repositories;
using Microsoft.AspNetCore.Mvc;
using KhaKhau.Areas.Admin.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using KhaKhau.Migrations;
using KhaKhau.Areas.Identity.Data;
namespace KhaKhau.Areas.Admin.Controllers
{
    [Area("admin")]
    [Authorize]
    public class UserManagerController : Controller
    {
        private readonly IUserResponsitory _userReponsitory;

        public UserManagerController(IUserResponsitory userReponsitory)
        {
            _userReponsitory = userReponsitory;
        }
        public async Task<IActionResult> Index()
        {
            var user = await _userReponsitory.GetAllAsync();
            return View(user);
        }

        public async Task<IActionResult> Delete(string id)
        {
            var user = await _userReponsitory.GetByIdAsync(id);
            if (user == null)
            {
                return NotFound();
            }
            return View(user);
        }

        [HttpPost, ActionName("DeleteConfirmed")]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            await _userReponsitory.DeleteAsync(id);
            return RedirectToAction(nameof(Index));
        }
        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Add(ApplicationUser user)
        {
            if (ModelState.IsValid)
            {
                await _userReponsitory.AddAsync(user);
                return RedirectToAction(nameof(Index));
            }
            return View(user);
        }

        public async Task<IActionResult> Update(string id)
        {
            var user = await _userReponsitory.GetByIdAsync(id);
            if (user == null)
            {
                return NotFound();
            }
            return View(user);
        }

        // Xử lý sửa người dùng
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Update(string id, ApplicationUser user)
        {
            if (ModelState.IsValid)
            {
                await _userReponsitory.UpdateAsync(user);
                return RedirectToAction(nameof(Index));
            }
            return View(user);
        }
}

}
