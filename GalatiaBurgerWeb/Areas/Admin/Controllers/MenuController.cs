using GalatiaBurger.DataAccess.Repository.IRepository;
using GalatiaBurger.Models;
using GalatiaBurger.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace GalatiaBurgerWeb.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class MenuController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IWebHostEnvironment _hostEnvironment;

        public MenuController(IUnitOfWork unitOfWork, IWebHostEnvironment hostEnvironment)
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
            MenuViewModel menuVM = new()
            {
                Menu = new(),
                ExtraIngredientList = _unitOfWork.ExtraIngredient.GetAll().Select(i => new SelectListItem
                {
                    Text = i.Name,
                    Value = i.Id.ToString()
                }),
            };
            if (id == null || id == 0)
            {
                
                return View(menuVM);
            }
            else
            {
                menuVM.Menu = _unitOfWork.Menu.GetFirstOrDefault(u => u.Id == id);
                return View(menuVM);
                
            }
        }

        //POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Upsert(MenuViewModel objMenu, IFormFile file)
        {

            if (ModelState.IsValid)
            {
                string wwwRootPath = _hostEnvironment.WebRootPath;
                if (file != null)
                {
                    string fileName = Guid.NewGuid().ToString();
                    var uploads = Path.Combine(wwwRootPath, @"images\menus");
                    var extension = Path.GetExtension(file.FileName);

                    if (objMenu.Menu.ImageUrl != null)
                    {
                        var oldImagePath = Path.Combine(wwwRootPath, objMenu.Menu.ImageUrl.TrimStart('\\'));
                        if (System.IO.File.Exists(oldImagePath))
                        {
                            System.IO.File.Delete(oldImagePath);
                        }
                    }

                    using (var fileStreams = new FileStream(Path.Combine(uploads, fileName + extension), FileMode.Create))
                    {
                        file.CopyTo(fileStreams);
                    }
                    objMenu.Menu.ImageUrl = @"\images\menus\" + fileName + extension;
                }

                if (objMenu.Menu.Id == 0)
                {
                    _unitOfWork.Menu.Add(objMenu.Menu);
                }
                else
                {
                    _unitOfWork.Menu.Update(objMenu.Menu);
                }
                _unitOfWork.Save();
                TempData["Success"] = "Menu created successfully!";
                return RedirectToAction("Index");

            }
            return View(objMenu);
        }

        #region API CALLS
        [HttpGet]
        public IActionResult GetAll()
        {
            var menuList = _unitOfWork.Menu.GetAll();
            return Json(new { data = menuList });
        }

        //POST
        [HttpDelete]
        public IActionResult Delete(int? id)
        {
            var objMenu = _unitOfWork.Menu.GetFirstOrDefault(c => c.Id == id);
            if (objMenu == null)
            {
                return Json(new { success = false, message = "Error while Deleting!" });
            }
            var oldImagePath = Path.Combine(_hostEnvironment.WebRootPath, objMenu.ImageUrl.TrimStart('\\'));
            if (System.IO.File.Exists(oldImagePath))
            {
                System.IO.File.Delete(oldImagePath);
            }
            _unitOfWork.Menu.Remove(objMenu);
            _unitOfWork.Save();
            return Json(new { success = true, message = "Deleted Successfully!" });
        }
        #endregion
    }
}
