using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using WebApi.BookOperations.GetBooks;
using WebApi.BookOperations.CreateBookViewModel;
using WebApi.DbOperations;
using WebApi.BookOperations.GetBookDetail;
using WebApi.BookOperations.UpdateBook;
using WebApi.BookOperations.DeleteBook;
using AutoMapper;
using FluentValidation.Results;
using FluentValidation;

namespace WebApi.AddControllers
{
    [ApiController]
    [Route("[controller]s")]
   public class BookController : ControllerBase
  {
        private readonly IMapper _mapper;
        private readonly BookStoreDbContext _context;

        public BookController(BookStoreDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }


    [HttpGet]
     public IActionResult GetBooks()
     {
       GetBooksQuery query = new GetBooksQuery(_context,_mapper);
       var result = query.Handle();
       return Ok(result);
     }

    [HttpGet("{id}")]
    public IActionResult GetById(int id)
    {
        BookDetailVM result;
        GetBookDetailQuery gb = new GetBookDetailQuery(_context, _mapper);
        gb.BookId = id;
        GetBookDetailValidator valid = new GetBookDetailValidator();
        valid.ValidateAndThrow(gb);
        result = gb.Handle();

       return Ok(result);
    }

   [HttpPost]
   public IActionResult AddBook([FromBody]CreateBookModel newBook)
   {
      CreateBookVM cv= new CreateBookVM(_context,_mapper);
     
        cv.Model = newBook;

        CreateBookVMValidator validator = new CreateBookVMValidator();
        validator.ValidateAndThrow(cv);
        cv.Handle();
        // if(!result.IsValid)
        // foreach(var item in result.Errors)
        //     System.Console.WriteLine("Özellik" + item.PropertyName + "-Error Message :" + item.ErrorMessage) ;
        // else

        return Ok();
   }

    [HttpPut("{id}")]
    public IActionResult UpdateBook(int id,[FromBody]UpdateBookModel updatedBook)
    {
     
        UpdateBookCommand uc = new UpdateBookCommand(_context);
        uc.BookId=id;
        uc.model= updatedBook;
        UpdateBookCommandValidator valid = new UpdateBookCommandValidator();
        valid.ValidateAndThrow(uc);
        uc.Handle();

         return Ok();
    }

    [HttpDelete("{id}")]
    public IActionResult DeleteBook(int id)
    {
      
        DeleteBookCommand dc = new DeleteBookCommand(_context);
        dc.BookId = id;
        DeleteBookCommandValidator valid = new DeleteBookCommandValidator();
        valid.ValidateAndThrow(dc);
        dc.Handle();

        return Ok();
    }
    
    
    //Benim yaptıpım id ye göre çağırma!
    // [HttpGet("{id}")]
    // public ActionResult GetById(int id)
    // {
    //     var response = bookList.FirstOrDefault(x=>x.Id == id);

    //      return Ok(response);
    // }


  }

}