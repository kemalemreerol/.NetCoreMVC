using KitaplikUygulama.DataAccess.Repository.IRepository;
using KitaplikUygulama.Models;
using Microsoft.AspNetCore.Mvc;

namespace KitaplikUygulamaWeb.Areas.Admin.Controllers
{
    public class CoverTypeController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        public CoverTypeController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }



        public IActionResult Index()
        {
            IEnumerable<CoverType> coverTypes = _unitOfWork.CoverType.GetAll();
            return View(coverTypes);    
        }


        //Create Post işlemleri
        [HttpGet]
        public IActionResult Create()
        {

            return View();
        }
        public IActionResult Create(CoverType obj)
        {
            if(obj.Name==obj.Id.ToString())
            {
                ModelState.AddModelError("CustomError", "Name değeri Id Değerine eşit olamaz.");
            }

            if (ModelState.IsValid)
            {
                _unitOfWork.CoverType.Add(obj);
                _unitOfWork.Save();
                return RedirectToAction("Index", "CoverType");
            }
            return View(obj);   
        }

        //Update Post işlemi
        [HttpGet]
        public IActionResult Edit(int id)
        {
            if(id == 0 || id == null)
            {
                return NotFound();
            }

            var CoverTypeEdit = _unitOfWork.CoverType.GetFirstOrDefault(u => u.Id == id);
            if(CoverTypeEdit == null)
            {
                return NotFound();
            }
            return View(CoverTypeEdit);
        }
        [HttpPost]
        public IActionResult Edit(CoverType obj)
        {
            if(obj.Name == obj.Id.ToString())
            {
                ModelState.AddModelError("CustomError", "Name değeri Id değeriyle aynı olamaz.");
            }

            if (ModelState.IsValid)
            {
                _unitOfWork.CoverType.Update(obj);
                _unitOfWork.Save();
                return RedirectToAction("Index", "CoverType");
            }
            return View(obj);
        }

        // Delete Post 
        [HttpGet]
        public IActionResult Delete(int id)
        {
            if(id==null || id == 0)
            {
                return NotFound();
            }
            var CoverTypeId = _unitOfWork.CoverType.GetFirstOrDefault(u => u.Id == id);

            if (CoverTypeId == null)
            {
                return NotFound();
            }

            return View(CoverTypeId);
           


        }
        [HttpPost]
        public IActionResult DeletePost(int id)
        {
            var CoverTypeId= _unitOfWork.CoverType.GetFirstOrDefault(u => u.Id == id);

            if (CoverTypeId == null)
            {
                return NotFound();
            }

            _unitOfWork.CoverType.Remove(CoverTypeId);
            _unitOfWork.Save();
            return RedirectToAction("Index", "CoverType");
        }

    }
}
