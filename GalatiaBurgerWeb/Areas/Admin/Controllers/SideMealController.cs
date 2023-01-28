using GalatiaBurger.DataAccess.Repository.IRepository;
using GalatiaBurger.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace GalatiaBurgerWeb.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class SideMealController : Controller
    {

        private readonly IUnitOfWork _unitOfWork;
        private readonly IWebHostEnvironment _hostEnvironment;

        public SideMealController(IUnitOfWork unitOfWork, IWebHostEnvironment hostEnvironment)
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
            SideMeal sideMeal = new SideMeal();
            if (id == null || id == 0)
            {
                //Create Product
                //ViewBag.CategoryList = CategoryList;
                //ViewData["CoverTypeList"] = CoverTypeList;
                return View(sideMeal);
            }
            else
            {
                sideMeal = _unitOfWork.SideMeal.GetFirstOrDefault(u => u.Id == id);
                return View(sideMeal);
                //Update Product
            }
        }

        //POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Upsert(SideMeal objSM, IFormFile file)
        {

            if (ModelState.IsValid)
            {
                string wwwRootPath = _hostEnvironment.WebRootPath;
                if (file != null)
                {
                    string fileName = Guid.NewGuid().ToString();
                    var uploads = Path.Combine(wwwRootPath, @"images\sidemeals");
                    var extension = Path.GetExtension(file.FileName);

                    if (objSM.ImageUrl != null)
                    {
                        var oldImagePath = Path.Combine(wwwRootPath, objSM.ImageUrl.TrimStart('\\'));
                        if (System.IO.File.Exists(oldImagePath))
                        {
                            System.IO.File.Delete(oldImagePath);
                        }
                    }

                    using (var fileStreams = new FileStream(Path.Combine(uploads, fileName + extension), FileMode.Create))
                    {
                        file.CopyTo(fileStreams);
                    }
                    objSM.ImageUrl = @"\images\sidemeals\" + fileName + extension;
                }

                if (objSM.Id == 0)
                {
                    _unitOfWork.SideMeal.Add(objSM);
                }
                else
                {
                    _unitOfWork.SideMeal.Update(objSM);
                }
                _unitOfWork.Save();
                TempData["Success"] = "Side Meal created successfully!";
                return RedirectToAction("Index");

            }
            return View(objSM);
        }

        #region API CALLS
        [HttpGet]
        public IActionResult GetAll()
        {
            var sideMealList = _unitOfWork.SideMeal.GetAll();
            return Json(new { data = sideMealList });
        }

        //POST
        [HttpDelete]
        public IActionResult Delete(int? id)
        {
            var objSM = _unitOfWork.SideMeal.GetFirstOrDefault(c => c.Id == id);
            if (objSM == null)
            {
                return Json(new { success = false, message = "Error while Deleting!" });
            }
            var oldImagePath = Path.Combine(_hostEnvironment.WebRootPath, objSM.ImageUrl.TrimStart('\\'));
            if (System.IO.File.Exists(oldImagePath))
            {
                System.IO.File.Delete(oldImagePath);
            }
            _unitOfWork.SideMeal.Remove(objSM);
            _unitOfWork.Save();
            return Json(new { success = true, message = "Deleted Successfully!" });
        }
        #endregion
    }
}
