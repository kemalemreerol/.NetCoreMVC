using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using WebApi.DbOperations;
using WebApi.Entities;

namespace WebApi.Application.GenreOperations.Commands.CreateGenreCommand
{
    public class CreateGenreCommand
    {
        private readonly BookStoreDbContext _context;
      
        public CreateGenreViewModel model;

        public CreateGenreCommand(BookStoreDbContext context)
        {
            _context = context;
            
        }

        public void Handle()
        {
            var genre = _context.Genres.SingleOrDefault(x=>x.Name == model.Name);
            if(genre is not null)
              throw new InvalidOperationException("Kitap Türü zaten mevcuttur.");

            genre = new Genre();
            genre.Name = model.Name;
            _context.Genres.Add(genre);
            _context.SaveChanges();
        }
    }

    public class CreateGenreViewModel
    {
        
        public string Name {get;set;}
        
    }
}