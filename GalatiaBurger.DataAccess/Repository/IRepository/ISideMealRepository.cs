using GalatiaBurger.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GalatiaBurger.DataAccess.Repository.IRepository
{
    public interface ISideMealRepository : IRepository<SideMeal>
    {
        void Update(SideMeal objSM);

        void Save();
    }
}
