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
	public class OrderDetailRepository : Repository<OrderDetail>, IOrderDetailRepository
	{
		private ApplicationDbContext _db;
		public OrderDetailRepository(ApplicationDbContext db) : base(db)
		{
			_db = db;
		}



		public void Update(OrderDetail obj)
		{
			_db.OrderDetails.Update(obj);
		}
	}
}
