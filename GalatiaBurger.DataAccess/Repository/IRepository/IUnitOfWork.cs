using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GalatiaBurger.DataAccess.Repository.IRepository
{
    public interface IUnitOfWork
    {
        IMenuRepository Menu { get; }
        ISideMealRepository SideMeal { get; }
        IExtraIngredientRepository ExtraIngredient { get; }
        IShoppingCartRepository ShoppingCart { get; }  
        IOrderRepository Order { get; }

       
        

        void Save();
    }
}
