using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApi.Common;
using WebApi.DbOperations;

namespace WebApi.BookOperations.GetBookDetail
{
   public class GetBookDetailQuery
   {
    public int BookId {get;set;}
    private readonly BookStoreDbContext _dbContext;
    private readonly IMapper _mapper;
        public GetBookDetailQuery(BookStoreDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public BookDetailVM Handle()
     {
        var book= _dbContext.Books.Include(x=>x.Genre).Where(x=>x.Id == BookId).FirstOrDefault();
        if(book is null)
        throw new InvalidOperationException("Kitap Bulunamadı");

        BookDetailVM bm = _mapper.Map<BookDetailVM>(book);
      //   bm.Title= book.Title;
      //   bm.GenreId=((GenreEnum)book.GenreId).ToString();
      //   bm.PageCount=book.PageCount;
      //   bm.PublishDate=book.PublishDate.Date.ToString("dd/MM/yyyy");
        return bm;
          
        
     }

   }

   public class BookDetailVM
   {
       public string Title { get; set; }
       public string GenreId { get; set; }
       public int PageCount { get; set; }
       public string PublishDate { get; set; }
   }
}