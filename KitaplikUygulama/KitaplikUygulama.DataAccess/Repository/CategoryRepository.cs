using KitaplikUygulama.DataAccess.Repository.IRepository;
using KitaplikUygulama.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KitaplikUygulama.DataAccess.Repository
{
    public class CategoryRepository : Repository<Category>, ICategoryRepository
    {
        private readonly ApplicationDbContext _db;
        public CategoryRepository(ApplicationDbContext db) :base(db)
        {
            _db = db;
        }

        //SAVE İŞLEMLERİNİ UNİTOFWORK YAPMAKTADIR BU YÜZDEN BURADA BU İŞLEME GEREK YOKTUR.

        //public void Save()
        //{
        //    _db.SaveChanges();
        //}

        public void Update(Category obj)
        {
            _db.Categories.Update(obj);
        }
    }
}
