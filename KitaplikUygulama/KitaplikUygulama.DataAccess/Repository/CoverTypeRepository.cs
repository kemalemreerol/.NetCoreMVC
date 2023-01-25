using KitaplikUygulama.DataAccess.Repository.IRepository;
using KitaplikUygulama.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KitaplikUygulama.DataAccess.Repository
{
    public class CoverTypeRepository : Repository<CoverType>, ICoverTypeRepository
    {
        private readonly ApplicationDbContext _db;
        public CoverTypeRepository(ApplicationDbContext db) : base(db)
        {
            _db= db;
        }

        //SAVE İŞLEMLERİNİ UNİTOFWORK YAPMAKTADIR BU YÜZDEN BURADA BU İŞLEME GEREK YOKTUR.

        //public void Save()
        //{
        //    _db.SaveChanges();
        //}

        public void Update(CoverType entity)
        {
            _db.CoverTypes.Update(entity);
        }
    }
}
