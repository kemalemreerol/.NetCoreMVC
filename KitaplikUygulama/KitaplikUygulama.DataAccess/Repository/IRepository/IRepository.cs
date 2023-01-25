using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace KitaplikUygulama.DataAccess.Repository.IRepository
{

    // Burada IRepository<İSTEDİĞİN BİR İSİM>  where T : class (T nin class olduğunu Tanımdalık)
    // Bu interfacesin içinde imzalarını sadece imzalarını atıyoruz. 
    public interface IRepository<T> where T : class
    {
         
        // Tnin yerine  hangi models classını yazarsan onun tüm verilerini getirecek
        //Listeleme metodu
        IEnumerable<T> GetAll();


        //Ekleme Metodu
        void Add(T entity);

        //Filtreleme 
        //Burada t yazılan yere model sınıflarındaki class isimleri gelir ve bize true false değeri döndüren fonksiyondur.
        T GetFirstOrDefault(Expression<Func<T, bool>> filter);

        void Remove(T entity);

        //Çoklu silme // belli aralıktaki verileri silme
        void RemoveRange(IEnumerable<T> entity);


    }
}
