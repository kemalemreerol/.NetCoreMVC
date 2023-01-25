using KitaplikUygulama.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace KitaplikUygulama.DataAccess.Repository.IRepository
{
    public interface ICoverTypeRepository : IRepository<CoverType>
    {
        void Update(CoverType entity);

        //SAVE İŞLEMLERİNİ UNİTOFWORK YAPMAKTADIR BU YÜZDEN BURADA BU İŞLEME GEREK YOKTUR.

        //void Save();

    }
}
