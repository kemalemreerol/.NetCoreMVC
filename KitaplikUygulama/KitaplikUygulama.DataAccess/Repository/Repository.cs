using KitaplikUygulama.DataAccess.Repository.IRepository;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace KitaplikUygulama.DataAccess.Repository
{
    public class Repository<T> : IRepository<T> where T : class
    {

        private readonly ApplicationDbContext _db;
        internal DbSet<T> dbSet;

        public Repository(ApplicationDbContext db)
        {
            _db = db;
            this.dbSet= _db.Set<T>();
        }



        public void Add(T entity)
        {
            dbSet.Add(entity);
        }

        public IEnumerable<T> GetAll()
        {

            // IEnumarable ile IQuaryable arasındaki farklar şöyledir; IEnumarable tüm verileri alıp memory de tutarak sorguları memory üzerinden yapar. IQueryable ise şartlara bağlı olan query oluşturur ve bu şartlar sonucu olarak veritabanı üzerinden sorgu çeker. Çoklu kayıplar üzerinden sorgu yapıyorsak IQueryable çok daha hızlı çalışır. IEnumarable koleksiyonlar için idealdir. Hafıza dışı kolekyisonlarda (veritabanı, servisler vs.) Querylabel ddaha idealdir.

            IQueryable<T> query = dbSet;
            return query.ToList();
        }

        public T GetFirstOrDefault(Expression<Func<T, bool>> filter)
        {
            IQueryable<T> query = dbSet;
            //Buradaki where ifadesi filtreden geçen elamnaları gösteren ifadedir. 
            query=query.Where(filter);
            return query.FirstOrDefault();
        }

        public void Remove(T entity)
        {
            dbSet.Remove(entity);
        }

        public void RemoveRange(IEnumerable<T> entity)
        {
            dbSet.RemoveRange(entity);
        }

    }
}
