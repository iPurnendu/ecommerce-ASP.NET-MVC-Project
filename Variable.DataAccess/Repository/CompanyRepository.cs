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
    public class CompanyRepository : Repository<Company>, ICompanyRepository
    {
        private ApplicationDbContext _db;
        public CompanyRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }



        public void Update(Company obj)
        {
            _db.Companies.Update(obj);
        }
    }
}
