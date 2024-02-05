using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Variable.DataAccess.Data;
using Variable.DataAccess.Repository.IRepository;
using Variable.Models;

namespace Variable.DataAccess.Repository
{
    public class ProductRepository : Repository<Product>, IProductRepository
    {
        private ApplicationDbContext _db;
        public ProductRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }



        public void Update(Product obj)
        {
            var objFromDb = _db.Products.FirstOrDefault(u=>u.Id == obj.Id);
            if(objFromDb != null)
            {
                objFromDb.ProductName= obj.ProductName;
                objFromDb.Storage= obj.Storage;
                objFromDb.Brand= obj.Brand;
                objFromDb.DisccountPrice= obj.DisccountPrice;
                objFromDb.Price= obj.Price;
                objFromDb.CategoryId= obj.CategoryId;
                objFromDb.Color= obj.Color;
                objFromDb.Description1 = obj.Description1;
                objFromDb.Description2 = obj.Description2;
                objFromDb.Description3 = obj.Description3;
                if(obj.ImageURl!=null)
                {
                    objFromDb.ImageURl= obj.ImageURl;
                }
            }
        }
    }
}
