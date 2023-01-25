using KitaplikUygulama.DataAccess;
using KitaplikUygulama.DataAccess.Repository.IRepository;
using KitaplikUygulama.Models;
using Microsoft.AspNetCore.Mvc;

namespace KitaplikUygulamaWeb.Areas.Admin.Controllers
{

    

    public class CategoryController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        public CategoryController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public IActionResult Index()
        {

            IEnumerable<Category> objCategoryList = _unitOfWork.Category.GetAll();
            return View(objCategoryList);
        }


        //------------CREATE SAYFASI---------

        //Get 
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }


        //Post
        [HttpPost]
        public IActionResult Create(Category obj)
        {
            if (obj.Name == obj.DisplayOrder.ToString())
            {
                ModelState.AddModelError("CustomError", "Category Name Cant Be Equal To Display Order");
            }


            if (ModelState.IsValid)
            {
                _unitOfWork.Category.Add(obj);
                _unitOfWork.Save();
                TempData["success"] = "Category Create Succesfullyl! :)";
                return RedirectToAction("Index", "Category");
            }

            return View(obj);
        }


        //------------EDIT SAYFASI----------

        //Get 
        [HttpGet]
        public IActionResult Edit(int id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }

            // PrimaryKey yazmassa bu metotta id bulamaz. 
            /*var categoryFromDb = _db.Categories.Find(id)*/;

            //İdlere primary key vermessen [Key] vermessen burada bu işlemi yaparak id lere ulaşabiliyoruz.
            var categoryFromDbFirst = _unitOfWork.Category.GetFirstOrDefault(u => u.ID == id); //burada u değişkeni bir ID yakalar bu Id değeri id ye eşitse true döner.

            //var categoryFromDbFirs = _db.Categories.FirstOrDefault(u => u.Name=="Kemal"); // İstediğin verinyide aratabilirsin.

            if (categoryFromDbFirst == null)
            {
                return NotFound();
            }

            return View(categoryFromDbFirst);
        }


        //Post
        [HttpPost]
        public IActionResult Edit(Category obj)
        {
            if (obj.Name == obj.DisplayOrder.ToString())
            {
                ModelState.AddModelError("CustomError", "Category Name Cant Be Equal To Display Order");
            }


            if (ModelState.IsValid)
            {
                _unitOfWork.Category.Update(obj);
                _unitOfWork.Save();
                TempData["success"] = "Category Edit Succesfullyl! :)";
                return RedirectToAction("Index", "Category");
            }

            return View(obj);
        }


        //-----------DELETE SAYFASI----------------

        //Get 
        [HttpGet]
        public IActionResult Delete(int id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }

            var categoryFromDb = _unitOfWork.Category.GetFirstOrDefault(u => u.ID == id);

            if (categoryFromDb == null)
            {
                return NotFound();
            }

            return View(categoryFromDb);
        }


        //Post
        [HttpPost, ActionName("Delete")]
        public IActionResult DeletePost(int id)
        {
            var obj = _unitOfWork.Category.GetFirstOrDefault(u => u.ID == id);

            if (obj == null)
            {
                return NotFound();

            }
            _unitOfWork.Category.Remove(obj);
            _unitOfWork.Save();
            TempData["success"] = "Category Delete Succesfullyl! :)";
            return RedirectToAction("Index", "Category");

        }


    }
}
