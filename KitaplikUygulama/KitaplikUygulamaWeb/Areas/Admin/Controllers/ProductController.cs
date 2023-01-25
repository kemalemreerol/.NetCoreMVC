using KitaplikUygulama.DataAccess.Repository.IRepository;
using KitaplikUygulama.Models;
using KitaplikUygulama.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace KitaplikUygulamaWeb.Areas.Admin.Controllers
{
    public class ProductController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IWebHostEnvironment _hostEnvironment;
        public ProductController(IUnitOfWork unitOfWork, IWebHostEnvironment hostEnvironment)
        {
            _unitOfWork = unitOfWork;
            _hostEnvironment = hostEnvironment; 
        }

        //0. Bu sayfada DI yaptık
        //1. product vm - prodcutlara ValidationNever eklyiyoruz
        //2. sonra upsert sayfama image tarafına name="file" ekle
        //3. upsert actionuna eklemeler yaptık.
        //4. API EKLEDİK
        //5. JS DOSYASINA BİR JAVASCRPİT TYPE AÇTIK
        //6 PRODUCTUN İNDEXİNE SCRİPT DOSYASINI ÇAĞIRDIK
        //7. JS DOSYASINA KOD YAZDIK

        public IActionResult Index()
        {
            
            return View();    
        }



        //Update Post işlemi
        [HttpGet]
        public IActionResult Upsert(int id)
        {
            ProductVM productVM = new()
            {
                   Product = new(),
                   CategoryList = _unitOfWork.Category.GetAll().Select(
                   u => new SelectListItem
                   {
                       Text = u.Name,
                       Value = u.ID.ToString()
                   }),
                 CoverTypeList = _unitOfWork.CoverType.GetAll().Select(
                   u => new SelectListItem
                   {
                       Text = u.Name,
                       Value = u.Id.ToString()
                   }),


            };


            if (id == 0 || id == null)
            {
                //Create
                //ViewBag.CategoryList=CategoryList;
                //ViewData["CoverTypeList"] = CoverTypeList;

                return View(productVM);
            }
            else
            {
                //update product
                
            }         
            return View(productVM);
        }




        [HttpPost]
        public IActionResult Upsert(ProductVM obj, IFormFile? file)
        {
           
            if (ModelState.IsValid)
            {
                string wwwRothPath = _hostEnvironment.WebRootPath;
                if (file != null )
                {
                    string fileName = Guid.NewGuid().ToString();
                    var uploads = Path.Combine(wwwRothPath,@"images\products");
                    var extension = Path.GetExtension(file.FileName);

                    using (var fileStreams = new FileStream(Path.Combine(uploads, fileName + extension),FileMode.Create))
                    {
                        file.CopyTo(fileStreams);
                    }
                    obj.Product.ImageURL = @"images\products\" + fileName + extension;
                      
                }


                //_unitOfWork.CoverType.Update(obj);
                _unitOfWork.Product.Add(obj.Product);
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


        // API FORMATI

        #region API CALL

        [HttpGet]
        public IActionResult GetAll()
        {
            var productList = _unitOfWork.Product.GetAll();
            return Json(new { data = productList });
        }

        #endregion




    }


}
