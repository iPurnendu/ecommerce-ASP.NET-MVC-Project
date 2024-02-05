using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
using Variable.DataAccess.Repository;
using Variable.DataAccess.Repository.IRepository;
using Variable.Models;
using Variable.Models.ViewModels;
using Variable.Utility;

namespace EcommerceWebProject.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = StaticDetails.Role_Admin)]
    public class CompanyController : Controller
    {
        private readonly IUnitOfWork _unitofwork; //all the implemation value in database and method to collection value all present in Db context
        
        public CompanyController(IUnitOfWork unitOfWork)
        {
            _unitofwork = unitOfWork;
            
        }

        public IActionResult Index()
        {
            List<Company> objCompanyList = _unitofwork.Company.GetAll().ToList();
             
            return View(objCompanyList);
        }

        public IActionResult UpsertCompany(int? id)   //update and insert
        {
            
            if(id==null || id == 0)
            {
                return View(new Company());
            }
            else
            {
                Company companyobj = _unitofwork.Company.Get(u => u.Id == id);
                return View(companyobj);
            }
        }

        [HttpPost]
        public IActionResult UpsertCompany(Company Companyobj)
        {
            if (ModelState.IsValid)
            {
                
                if(Companyobj.Id == 0)
                {
                    _unitofwork.Company.Add(Companyobj);
                }
                else
                {
                    _unitofwork.Company.Update(Companyobj);
                }
                _unitofwork.save();
                return RedirectToAction("Index");
            }
            else
            {
               return View(Companyobj);
            }
            
        }

        //public IActionResult EditCompany(int? id)
        //{
        //    if (id == null || id == 0)
        //    {
        //        return NotFound();
        //    }
        //    Company? Companys = _unitofwork.Company.Get(u => u.Id == id);

        //    if (Companys == null)
        //    {
        //        return NotFound();
        //    }
        //    return View(Companys);
        //}

        //[HttpPost]
        //public IActionResult EditCompany(Company ct)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        _unitofwork.Company.Update(ct);
        //        _unitofwork.save();
        //        return RedirectToAction("Index");
        //    }
        //    return View();
        //}

        //public IActionResult Delete(int? id)
        //{
        //    if (id == null || id == 0)
        //    {
        //        return NotFound();
        //    }
        //    Company? Companys = _unitofwork.Company.Get(u => u.Id == id);

        //    if (Companys == null)
        //    {
        //        return NotFound();
        //    }
        //    return View(Companys);
        //}

        //[HttpPost, ActionName("Delete")]
        //public IActionResult DeleteCompany(int? id)
        //{
        //    Company? Company = _unitofwork.Company.Get(u => u.Id == id);
        //    if (Company == null)
        //    {
        //        return NotFound();
        //    }
        //    _unitofwork.Company.Remove(Company);
        //    _unitofwork.save();
        //    return RedirectToAction("Index");

        //}

        #region API CALLS
        [HttpGet]
        public IActionResult GetAll(int id)
        {
            List<Company> objCompanyList = _unitofwork.Company.GetAll().ToList();
            return Json(new {data=objCompanyList});
        }
        [HttpDelete]
        public IActionResult Delete(int? id)
        {
            var CompanyToBeDeleted = _unitofwork.Company.Get(u => u.Id == id);
            if (CompanyToBeDeleted == null)
            {
                return Json(new { success = false, message = "Error while deleting" });
            }

            _unitofwork.Company.Remove(CompanyToBeDeleted);
            _unitofwork.save();

            return Json(new { success = true, message = "Delete Successful" });
        }

        #endregion
    }
}
