using GalatiaBurger.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GalatiaBurger.DataAccess.Repository.IRepository
{
    public interface IMenuRepository : IRepository<Menu>
    {
        void Update(Menu objMenu);

        void Save();
    }
}
