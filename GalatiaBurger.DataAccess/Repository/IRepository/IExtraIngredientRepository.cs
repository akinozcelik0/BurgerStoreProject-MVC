using GalatiaBurger.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GalatiaBurger.DataAccess.Repository.IRepository
{
    public interface IExtraIngredientRepository : IRepository<ExtraIngredient>
    {
        void Update(ExtraIngredient objEx);

        void Save();
    }
}
