using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using WebApi.DbOperations;

namespace WebApi.Application.AuthorOperations.Commands.DeleteAuthorCommand
{
    public class DeleteAuthorCommand
    {
        public int AuthorId { get; set; }

        private readonly BookStoreDbContext _context;
        

        public DeleteAuthorCommand(BookStoreDbContext context)
        {
            _context = context;
            
        }

        public void Handle()
        {
            var response = _context.Authors.Where(x=>x.AuthorIsActive==false && x.Id == AuthorId).FirstOrDefault();
            if(response is null)
            throw new InvalidOperationException("Yazarın Kitabı yayındadır. Silinemez öncelikli olarak yayından kaldırılması gerekmektedir.");

            _context.Authors.Remove(response);
            _context.SaveChanges();
        }
        
    }

    
}