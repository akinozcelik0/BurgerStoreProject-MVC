
using GalatiaBurger.DataAccess.Data;
using GalatiaBurger.DataAccess.Repository.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace GalatiaBurger.DataAccess.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        private ApplicationDbContext _db;

        public UnitOfWork(ApplicationDbContext db)
        {
            _db = db;
            Menu = new MenuRepository(_db);
            SideMeal = new SideMealRepository(_db);
            ExtraIngredient = new ExtraIngredientRepository(_db);
            ShoppingCart = new ShoppingCartRepository(_db);
            Order = new OrderRepository(_db);
            
        }

        public IMenuRepository Menu { get; private set; }
        public ISideMealRepository SideMeal { get; private set; }
        public IExtraIngredientRepository ExtraIngredient { get; private set; }
        public IShoppingCartRepository ShoppingCart { get; private set; }
        public IOrderRepository Order { get; private set; }
        



        public void Save()
        {
            _db.SaveChanges();
        }
    }
}
