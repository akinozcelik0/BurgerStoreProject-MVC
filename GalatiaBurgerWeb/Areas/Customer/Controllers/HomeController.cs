using GalatiaBurger.DataAccess.Data;
using GalatiaBurger.DataAccess.Repository.IRepository;
using GalatiaBurger.Models;
using GalatiaBurger.Models.ViewModels;
using GalatiaBurgerWeb.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.Design;
using System.Diagnostics;
using System.Security.Claims;

namespace GalatiaBurgerWeb.Areas.Customer.Controllers
{
    [Area("Customer")]
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IUnitOfWork _unitOfWork;
        private readonly ApplicationDbContext _db;

        


        public HomeController(ILogger<HomeController> logger, IUnitOfWork unitOfWork, ApplicationDbContext db)
        {
            _logger = logger;
            _unitOfWork = unitOfWork;
            _db = db;
        }

        public IActionResult Index()
        {
            MenuSideMealExtraVM mseVM = new MenuSideMealExtraVM();
            ViewData["Menus"] = GetMenus();
            ViewData["ExtraIngredients"] = GetExtra();
            ViewData["SideMeals"] = GetSideMeal();
            return View();
        }

        private object? GetSideMeal()
        {
            IEnumerable<SideMeal> sideList = _unitOfWork.SideMeal.GetAll();

            return sideList;
        }

        private object? GetExtra()
        {
            IEnumerable<ExtraIngredient> extraList = _unitOfWork.ExtraIngredient.GetAll();

            return extraList;
        }

        private IEnumerable<Menu> GetMenus()
        {
            IEnumerable<Menu> menuList = _unitOfWork.Menu.GetAll();

            return menuList;
        }

        public IActionResult MenuDetails(int menuId)
        {
            ShoppingCart cartObj = new()
            {
                Count = 1,
                MenuId = menuId,
                Menu = _unitOfWork.Menu.GetFirstOrDefault(u => u.Id == menuId),
            };
            return View(cartObj);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]       
        public IActionResult MenuDetails(ShoppingCart shoppingCart)
        {

            ShoppingCart cartFromDb = _unitOfWork.ShoppingCart.GetFirstOrDefault(u => u.MenuId == shoppingCart.MenuId);

            if (cartFromDb == null)
            {
                _unitOfWork.ShoppingCart.Add(shoppingCart);
            }
            else
            {
                _unitOfWork.ShoppingCart.IncrementCount(cartFromDb, shoppingCart.Count);
            }


            _unitOfWork.Save();
            return RedirectToAction(nameof(Index));
        }

        public IActionResult SideMealDetails(int smId)
        {
            ShoppingCart cartObj = new()
            {
                Count = 1, 
                SideMealId = smId,
                SideMeal = _unitOfWork.SideMeal.GetFirstOrDefault(u => u.Id == smId),
            };
            return View(cartObj);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult SideMealDetails(ShoppingCart shoppingCart)
        {

            ShoppingCart cartFromDb = _unitOfWork.ShoppingCart.GetFirstOrDefault(u => u.SideMealId == shoppingCart.SideMealId);

            if (cartFromDb == null)
            {
                _unitOfWork.ShoppingCart.Add(shoppingCart);
            }
            else
            {
                _unitOfWork.ShoppingCart.IncrementCount(cartFromDb, shoppingCart.Count);
            }


            _unitOfWork.Save();
            return RedirectToAction(nameof(Index));
        }

        public IActionResult ExtrasDetail(int extraId)
        {
            ShoppingCart cartObj = new()
            {
                Count = 1,
                ExtraIngredientId = extraId,
                ExtraIngredient = _unitOfWork.ExtraIngredient.GetFirstOrDefault(u => u.Id == extraId)

            };
            return View(cartObj);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult ExtrasDetail(ShoppingCart shoppingCart)
        {

            ShoppingCart cartFromDb = _unitOfWork.ShoppingCart.GetFirstOrDefault(u => u.ExtraIngredientId == shoppingCart.ExtraIngredientId);

            if (cartFromDb == null)
            {
                _unitOfWork.ShoppingCart.Add(shoppingCart);
            }
            else
            {
                _unitOfWork.ShoppingCart.IncrementCount(cartFromDb, shoppingCart.Count);
            }


            _unitOfWork.Save();
            return RedirectToAction(nameof(Index));
        }



        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}