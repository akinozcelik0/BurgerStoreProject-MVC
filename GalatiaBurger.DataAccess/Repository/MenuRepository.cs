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
    public class MenuRepository : Repository<Menu>, IMenuRepository
    {
        private ApplicationDbContext _db;

        public MenuRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }

        public void Save()
        {
            _db.SaveChanges();
        }

        public void Update(Menu objMenu)
        {
            _db.Menus.Update(objMenu);
        }
    }
}
