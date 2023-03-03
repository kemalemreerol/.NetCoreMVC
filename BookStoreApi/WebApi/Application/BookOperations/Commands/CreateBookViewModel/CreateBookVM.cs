using System;
using System.Linq;
using AutoMapper;
using WebApi.DbOperations;
using WebApi.Entities;

namespace WebApi.BookOperations.CreateBookViewModel
{
    public class CreateBookVM
    {
        public CreateBookModel Model {get;set;}
        private readonly BookStoreDbContext _dbContext;
        private readonly IMapper _mapper;
        public CreateBookVM(BookStoreDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }



        public void Handle()
       {
          var addbook= _dbContext.Books.SingleOrDefault(x=>x.Title == Model.Title);
          if(addbook is not null)
            throw new InvalidOperationException("Kitap zaten mevcut");

            addbook= _mapper.Map<Book>(Model);

            // addbook.Title=Model.Title;
            // addbook.GenreId=Model.GenreId;
            // addbook.PageCount=Model.PageCount;
            // addbook.PublishDate=Model.PublishDate;

            _dbContext.Add(addbook);
            _dbContext.SaveChanges();

       }
       

    }

    public class CreateBookModel
    {
       public string Title { get; set; }
       public int GenreId { get; set; }
       public int PageCount { get; set; }
       public DateTime PublishDate { get; set; }
    }
}