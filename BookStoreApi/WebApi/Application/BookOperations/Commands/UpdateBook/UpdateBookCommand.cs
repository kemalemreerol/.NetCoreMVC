using System;
using System.Linq;
using WebApi.DbOperations;

namespace WebApi.BookOperations.UpdateBook
{
    public class UpdateBookCommand
    {
        public int BookId {get;set;}
        public UpdateBookModel model {get;set;}
        private readonly BookStoreDbContext _dbContext;
        public UpdateBookCommand(BookStoreDbContext dbContext)
        {
            _dbContext=dbContext;
        }

        public void Handle()
        {
          var book = _dbContext.Books.SingleOrDefault(x=>x.Id == BookId);
          if(book is null)
           throw new InvalidOperationException("Güncellenecek Kitap Bulunamadı.");

          book.GenreId= model.GenreId != default ? model.GenreId : book.GenreId;
          book.Title = model.Title != default ? model.Title : book.Title;
          _dbContext.SaveChanges();

       
        }

    }

    public class UpdateBookModel
    {
       public string Title { get; set; }
       public int GenreId { get; set; }
       
    }
}