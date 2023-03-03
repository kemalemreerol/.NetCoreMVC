using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using WebApi.DbOperations;
using WebApi.Entities;

namespace WebApi.Application.AuthorOperations.Commands.CreateAuthorCommand
{
    public class CreateAuthorCommand
    {
        private readonly BookStoreDbContext _context;
        private readonly IMapper _mapper;

        public CreateAuthorViewModel Model {get;set;}

        public CreateAuthorCommand(BookStoreDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public void Handle()
        {
          var addAuthor = _context.Authors.SingleOrDefault(x=>x.AuthorName == Model.Name);
          if(addAuthor is not null)
            throw new InvalidOperationException("Yazar zaten mevcuttur.");

          addAuthor = new Author();
            addAuthor.AuthorName  = Model.Name;
            addAuthor.AuthorSurname = Model.Surname;
            // create = _mapper.Map<Author>(Model);

            _context.Add(addAuthor);
            _context.SaveChanges();
          
        }
    }

    public class CreateAuthorViewModel
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        
    }
}