using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using WebApi.DbOperations;
using WebApi.Entities;

namespace WebApi.Application.GenreOperations.Commands.UpdateGenreCommand
{
    public class UpdateGenreCommand
    {
        public int GenreId {get;set;}
        public UpdateGenreViewModel model;
        private readonly BookStoreDbContext _context;
        

        public UpdateGenreCommand(BookStoreDbContext context)
        {
            _context = context;
            
        }

        public void Handle()
        {
            var genre = _context.Genres.SingleOrDefault(x=>x.Id == GenreId);
            if ( genre is null)
            throw new InvalidOperationException("Kitap türü Bulanamadı.");

            if(_context.Genres.Any(x=>x.Name.ToLower() == model.Name.ToLower() && x.Id != GenreId))
             throw new InvalidOperationException("Aynı isimli bir kitap türü zaten mevcut.");

            genre.Name = string.IsNullOrEmpty(model.Name.Trim()) ? genre.Name:model.Name ;
            genre.IsActive = model.IsActive;
            _context.SaveChanges();

            
        }
    }

    public class UpdateGenreViewModel
    {
        public string Name { get; set; }
        public bool IsActive { get; set; } = true;
    }
}