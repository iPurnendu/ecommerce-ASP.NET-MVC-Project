using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Variable.DataAccess.Repository.IRepository;
using Variable.Models;
using Variable.Utility;

namespace EcommerceWebProject.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles =StaticDetails.Role_Admin)]
    public class CategoryController : Controller
    {
        private readonly IUnitOfWork _unitofwork; //all the implemation value in database and method to collection value all present in Db context

        public CategoryController(IUnitOfWork unitOfWork)
        {
            _unitofwork = unitOfWork;
        }
        public IActionResult Index()
        {
            List<Category> objCategoryList = _unitofwork.Category.GetAll().ToList();
            return View(objCategoryList);
        }

        public IActionResult CreateCategory()
        {
            return View();
        }

        [HttpPost]
        public IActionResult CreateCategory(Category ct)
        {
            if (ct.Name == ct.DisplayOrder.ToString())
            {
                ModelState.AddModelError("", "Display Order Cannot Exactly match the Name");
            }
            if (ModelState.IsValid)
            {
                _unitofwork.Category.Add(ct);
                _unitofwork.save();
                return RedirectToAction("Index");
            }
            return View();
        }

        public IActionResult EditCategory(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            Category? categorys = _unitofwork.Category.Get(u => u.Id == id);

            if (categorys == null)
            {
                return NotFound();
            }
            return View(categorys);
        }

        [HttpPost]
        public IActionResult EditCategory(Category ct)
        {
            if (ModelState.IsValid)
            {
                _unitofwork.Category.Update(ct);
                _unitofwork.save();
                return RedirectToAction("Index");
            }
            return View();
        }

        public IActionResult Delete(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            Category? categorys = _unitofwork.Category.Get(u => u.Id == id);

            if (categorys == null)
            {
                return NotFound();
            }
            return View(categorys);
        }

        [HttpPost, ActionName("Delete")]
        public IActionResult DeleteCategory(int? id)
        {
            Category? category = _unitofwork.Category.Get(u => u.Id == id);
            if (category == null)
            {
                return NotFound();
            }
            _unitofwork.Category.Remove(category);
            _unitofwork.save();
            return RedirectToAction("Index");

        }


    }
}
