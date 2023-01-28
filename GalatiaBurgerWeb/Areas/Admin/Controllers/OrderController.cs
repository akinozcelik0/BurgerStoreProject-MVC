using GalatiaBurger.DataAccess.Repository.IRepository;
using GalatiaBurger.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace GalatiaBurgerWeb.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class OrderController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IWebHostEnvironment _hostEnvironment;

        public OrderController(IUnitOfWork unitOfWork, IWebHostEnvironment hostEnvironment)
        {
            _unitOfWork = unitOfWork;
            _hostEnvironment = hostEnvironment;
        }

        public IActionResult Index()
        {
            
            return View();
        }

        //INSERT-EDIT(UPSERT) ------------------------------
        //GET
        public IActionResult Upsert(int? id)
        {
            OrderViewModel orderViewModel = new()
            {
                Order = new(),
                MenuList = _unitOfWork.Menu.GetAll().Select(i => new SelectListItem
                {
                    Text = i.Name,
                    Value = i.Id.ToString()
                }),
                SideMealList = _unitOfWork.SideMeal.GetAll().Select(i => new SelectListItem
                {
                    Text = i.Name,
                    Value = i.Id.ToString()
                }),
                ExtraList = _unitOfWork.ExtraIngredient.GetAll().Select(i => new SelectListItem
                {
                    Text = i.Name,
                    Value = i.Id.ToString()
                })
            };
            if (id == null || id == 0)
            {
                return View(orderViewModel);
            }
            else
            {
                orderViewModel.Order = _unitOfWork.Order.GetFirstOrDefault(u => u.Id == id);
                return View(orderViewModel);
            }
        }

        //POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Upsert(OrderViewModel objOrder)
        {

            if (ModelState.IsValid)
            {
                if (objOrder.Order.Id == 0)
                {
                    _unitOfWork.Order.Add(objOrder.Order);
                }
                else
                {
                    _unitOfWork.Order.Update(objOrder.Order);
                }
                _unitOfWork.Save();
                TempData["Success"] = "Order created successfully!";
                return RedirectToAction("Index");

            }
            return View(objOrder);
        }

        #region API CALLS
        [HttpGet]
        public IActionResult GetAll()
        {
            var orderList = _unitOfWork.Order.GetAll(includeProperties: "Menu,SideMeal,ExtraIngredient");
            return Json(new { data = orderList });
        }

        //POST
        [HttpDelete]
        public IActionResult Delete(int? id)
        {
            var objOrder = _unitOfWork.Order.GetFirstOrDefault(c => c.Id == id);
            if (objOrder == null)
            {
                return Json(new { success = false, message = "Error while Deleting!" });
            }
            _unitOfWork.Order.Remove(objOrder);
            _unitOfWork.Save();
            return Json(new { success = true, message = "Deleted Successfully!" });
        }
        #endregion
    }
}
