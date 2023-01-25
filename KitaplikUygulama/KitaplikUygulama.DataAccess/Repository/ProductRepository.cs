using KitaplikUygulama.DataAccess.Repository.IRepository;
using KitaplikUygulama.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KitaplikUygulama.DataAccess.Repository
{
    public class ProductRepository : Repository<Product>, IProductRepository
    {
        private readonly ApplicationDbContext _db;
        public ProductRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }

        //SAVE İŞLEMLERİNİ UNİTOFWORK YAPMAKTADIR BU YÜZDEN BURADA BU İŞLEME GEREK YOKTUR.

        //public void Save()
        //{
        //    _db.SaveChanges();
        //}

        public void Update(Product obj)  //Sadece bir alanda update işlemi yaptırıyoruz çünkü modelda birden çok propumuz var.!
        {
            //_db.Products.Update(obj); //Bu yüzden burayı kaldırdık. Etkilenmesini değişim istediğin tek bir propa işlemler uygylayacağız.

            var objFromDb=_db.Products.FirstOrDefault(x => x.Id == obj.Id);
            if(objFromDb != null)
            {
                objFromDb.Title = obj.Title;
                objFromDb.ISBN = obj.ISBN;
                objFromDb.Description = obj.Description;
                objFromDb.ListPrice = obj.ListPrice;
                objFromDb.Price = obj.Price;
                objFromDb.Price50 = obj.Price50;
                objFromDb.Price100 = obj.Price100;    
                objFromDb.Author = obj.Author;
                objFromDb.CoverTypeId = obj.CoverTypeId;
                objFromDb.CategoryId = obj.CategoryId;
                if(obj.ImageURL != null)
                {
                    objFromDb.ImageURL = obj.ImageURL;
                }

            }
        }
    }

}
