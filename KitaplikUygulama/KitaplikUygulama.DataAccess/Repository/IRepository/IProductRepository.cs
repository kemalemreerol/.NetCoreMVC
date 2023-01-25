using KitaplikUygulama.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KitaplikUygulama.DataAccess.Repository.IRepository
{
    public interface IProductRepository : IRepository<Product>
    {
        void Update(Product obj);

        //SAVE İŞLEMLERİNİ UNİTOFWORK YAPMAKTADIR BU YÜZDEN BURADA BU İŞLEME GEREK YOKTUR.

        //void Save();
    }
}
