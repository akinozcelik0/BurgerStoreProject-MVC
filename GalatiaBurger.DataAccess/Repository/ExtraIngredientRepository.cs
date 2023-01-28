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
    public class ExtraIngredientRepository : Repository<ExtraIngredient>, IExtraIngredientRepository
    {
        private ApplicationDbContext _db;

        public ExtraIngredientRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }

        public void Save()
        {
            _db.SaveChanges();
        }

        public void Update(ExtraIngredient objEx)
        {
            _db.ExtraIngredients.Update(objEx);
        }
    }
}
