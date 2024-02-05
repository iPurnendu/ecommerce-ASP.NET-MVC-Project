using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Variable.DataAccess.Repository.IRepository
{
    public interface IUnitOfWork
    {
   
        ICategoryRepository Category { get; }
        IProductRepository Product { get; }
        ICompanyRepository Company { get; set; }

        IShoppingCartRepository ShoppingCart { get; set; }

        IApplicationUserRepository ApplicationUser { get; set; }

        IOrderDetailRepository OrderDetail { get; set; }
        IOrderHeaderRepository OrderHeader { get; set; }
        void save();
    }
}
