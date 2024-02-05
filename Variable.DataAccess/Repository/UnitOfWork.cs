﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Variable.DataAccess.Data;
using Variable.DataAccess.Repository.IRepository;
using Variable.Models;

namespace Variable.DataAccess.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        private ApplicationDbContext _db;
		public IOrderDetailRepository OrderDetail { get; set; }
		public IOrderHeaderRepository OrderHeader { get; set; }
		public ICategoryRepository Category { get; set; }
        public IProductRepository Product { get; set; }
        public ICompanyRepository Company { get; set; }

        public IShoppingCartRepository ShoppingCart { get; set; }

        public IApplicationUserRepository ApplicationUser { get; set; }
        public UnitOfWork(ApplicationDbContext db)
        {
            _db = db;
            ApplicationUser= new ApplicationUserRepository(_db);
            ShoppingCart = new ShoppingCartRepository(_db);
            Category = new CategoryRepository(_db);
            Product = new ProductRepository(_db);
            Company= new CompanyRepository(_db);
            OrderHeader = new OrderHeaderRepository(_db);
            OrderDetail = new OrderDetailRepository(_db);
        }

        public void save()
        {
            _db.SaveChanges();
        }
    }
}
