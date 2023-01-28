using GalatiaBurger.DataAccess.Data;
using GalatiaBurger.DataAccess.Repository.IRepository;
using GalatiaBurger.Models;
using Microsoft.AspNetCore.Mvc;

namespace GalatiaBurgerWeb.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ExtraIngredientController : Controller
    {
        private readonly ApplicationDbContext _db;
        private readonly IUnitOfWork _unitOfWork;

        public ExtraIngredientController(IUnitOfWork unitOfWork, ApplicationDbContext db)
        {
            _unitOfWork = unitOfWork;
            _db = db;
        }



        public IActionResult Index()
        {
            IEnumerable<ExtraIngredient> objEx = _unitOfWork.ExtraIngredient.GetAll();
            return View(objEx);
        }

        //GET
        public IActionResult Create()
        {

            return View();
        }

        //POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(ExtraIngredient extra)
        {

            //if (extra.Name = _db.ExtraIngredients.Where(e => e.Name == extra.Name))
            //{
            //    //Custom Error Message
            //    ModelState.AddModelError("name", "Display order cannot be same with Name value.");
            //}
            if (ModelState.IsValid)
            {
                _unitOfWork.ExtraIngredient.Add(extra);
                _unitOfWork.Save();
                TempData["Success"] = "Extra Ingredient created successfully!";
                return RedirectToAction("Index");

            }
            return View(extra);
        }

        //EDIT ------------------------------
        //GET
        public IActionResult Edit(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }

            var extraEdit = _unitOfWork.ExtraIngredient.GetFirstOrDefault(c => c.Id == id);
            

            if (extraEdit == null)
            {
                return NotFound();
            }

            return View(extraEdit);
        }

        //POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(ExtraIngredient extra)
        {
            //if (extra.Name == category.DisplayOrder.ToString())
            //{
            //    //Custom Error Message
            //    ModelState.AddModelError("name", "Display order cannot be same with Name value.");
            //}
            if (ModelState.IsValid)
            {
                _unitOfWork.ExtraIngredient.Update(extra);
                _unitOfWork.Save();
                TempData["Success"] = "Extra Ingredient updated successfully!";
                return RedirectToAction("Index");

            }
            return View(extra);
        }


        //DELETE ------------------------------
        //GET
        public IActionResult Delete(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            var extraDelete = _unitOfWork.ExtraIngredient.GetFirstOrDefault(c => c.Id == id);

            if (extraDelete == null)
            {
                return NotFound();
            }

            return View(extraDelete);
        }

        //POST
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeletePOST(int? id)
        {
            var extra = _unitOfWork.ExtraIngredient.GetFirstOrDefault(c => c.Id == id);
            if (extra == null)
            {
                return NotFound();
            }

            _unitOfWork.ExtraIngredient.Remove(extra);
            _unitOfWork.Save();
            TempData["Success"] = "Extra Ingredient deleted successfully!";
            return RedirectToAction("Index");

        }
    }
}
