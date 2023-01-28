using GalatiaBurger.DataAccess.Data;
using GalatiaBurger.DataAccess.Repository.IRepository;
using GalatiaBurger.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GalatiaBurger.DataAccess.Repository
{
    public class OrderRepository : Repository<Order>, IOrderRepository
    {
        private ApplicationDbContext _db;

        public OrderRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }

        public void Save()
        {
            _db.SaveChanges();
        }

        public void Update(Order objOrder)
        {
            _db.Orders.Update(objOrder);
        }
    }
}
