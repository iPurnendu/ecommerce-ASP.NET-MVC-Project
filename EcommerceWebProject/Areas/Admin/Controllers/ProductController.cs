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
    //[Authorize(Roles = StaticDetails.Role_Admin)]
    [Authorize(Roles = StaticDetails.Role_Admin + "," + StaticDetails.Role_Company)]
    public class ProductController : Controller
    {
        private readonly IUnitOfWork _unitofwork; //all the implemation value in database and method to collection value all present in Db context
        private readonly IWebHostEnvironment _webHostEnvironment;
        public ProductController(IUnitOfWork unitOfWork, IWebHostEnvironment webHostEnvironment)
        {
            _unitofwork = unitOfWork;
            _webHostEnvironment = webHostEnvironment;
        }

        public IActionResult Index()
        {
            List<Product> objProductList = _unitofwork.Product.GetAll(includeProperties:"Category").ToList();
             
            return View(objProductList);
        }

        public IActionResult UpsertProduct(int? id)   //update and insert
        {
            ProductVM productVM = new()
            {   
                CategoryList = _unitofwork.Category.GetAll().ToList().Select(u =>new SelectListItem
            {
                Text = u.Name,
                Value = u.Id.ToString()
            }),
                Product = new Product()
            };
            if(id==null || id == 0)
            {
                return View(productVM);
            }
            else
            {
                productVM.Product = _unitofwork.Product.Get(u => u.Id == id);
                return View(productVM);
            }
        }

        [HttpPost]
        public IActionResult UpsertProduct(ProductVM productVM, IFormFile? file)
        {
            if (ModelState.IsValid)
            {
                String wwwRootPath = _webHostEnvironment.WebRootPath;
                if(file != null)
                {
                    String fileName= Guid.NewGuid().ToString() + Path.GetExtension(file.FileName); 
                    String productPath = Path.Combine(wwwRootPath, @"images\product");

                    if (!String.IsNullOrEmpty(productVM.Product.ImageURl))
                    {
                        var oldImagepath = Path.Combine(wwwRootPath,productVM.Product.ImageURl.TrimStart('\\'));

                        if(System.IO.File.Exists(oldImagepath))
                        {
                            System.IO.File.Delete(oldImagepath);
                        }
                    }
                    using(var fileStream = new FileStream(Path.Combine(productPath, fileName), FileMode.Create))
                    {
                        file.CopyTo(fileStream);
                    }

                    productVM.Product.ImageURl = @"\images\product\" + fileName;
                }
                if(productVM.Product.Id == 0)
                {
                    _unitofwork.Product.Add(productVM.Product);
                }
                else
                {
                    _unitofwork.Product.Update(productVM.Product);
                }
                _unitofwork.save();
                return RedirectToAction("Index");
            }
            else
            {
                productVM.CategoryList = _unitofwork.Category.GetAll().ToList().Select(u => new SelectListItem
                {
                   Text = u.Name,
                   Value = u.Id.ToString()
               });
               return View(productVM);
            }
            
        }

        //public IActionResult EditProduct(int? id)
        //{
        //    if (id == null || id == 0)
        //    {
        //        return NotFound();
        //    }
        //    Product? products = _unitofwork.Product.Get(u => u.Id == id);

        //    if (products == null)
        //    {
        //        return NotFound();
        //    }
        //    return View(products);
        //}

        //[HttpPost]
        //public IActionResult EditProduct(Product ct)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        _unitofwork.Product.Update(ct);
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
        //    Product? products = _unitofwork.Product.Get(u => u.Id == id);

        //    if (products == null)
        //    {
        //        return NotFound();
        //    }
        //    return View(products);
        //}

        //[HttpPost, ActionName("Delete")]
        //public IActionResult DeleteProduct(int? id)
        //{
        //    Product? product = _unitofwork.Product.Get(u => u.Id == id);
        //    if (product == null)
        //    {
        //        return NotFound();
        //    }
        //    _unitofwork.Product.Remove(product);
        //    _unitofwork.save();
        //    return RedirectToAction("Index");

        //}

        #region API CALLS
        [HttpGet]
        public IActionResult GetAll(int id)
        {
            List<Product> objProductList = _unitofwork.Product.GetAll(includeProperties: "Category").ToList();
            return Json(new {data=objProductList});
        }
        [HttpDelete]
        public IActionResult Delete(int? id)
        {
            var productToBeDeleted = _unitofwork.Product.Get(u => u.Id == id);
            if (productToBeDeleted == null)
            {
                return Json(new { success = false, message = "Error while deleting" });
            }

            string productPath = @"images\products\product-" + id;
            string finalPath = Path.Combine(_webHostEnvironment.WebRootPath, productPath);

            if (Directory.Exists(finalPath))
            {
                string[] filePaths = Directory.GetFiles(finalPath);
                foreach (string filePath in filePaths)
                {
                    System.IO.File.Delete(filePath);
                }

                Directory.Delete(finalPath);
            }


            _unitofwork.Product.Remove(productToBeDeleted);
            _unitofwork.save();

            return Json(new { success = true, message = "Delete Successful" });
        }

        #endregion
    }
}
