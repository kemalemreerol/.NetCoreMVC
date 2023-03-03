using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using WebApi.DbOperations;

namespace WebApi.Application.AuthorOperations.Commands.UpdateAuthorCommand
{
    public class UpdateAuthorCommand
    {
        public int AuthorId { get; set; }
        public UpdateAuthorViewModel Model { get; set; }

        private readonly BookStoreDbContext _context;
        private readonly IMapper _mapper;

        public UpdateAuthorCommand(BookStoreDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public void Handle()
        {
           var response = _context.Authors.SingleOrDefault(x=>x.Id == AuthorId);
           if ( response is null)
           throw new InvalidOperationException("Yazar Mevcut değil güncellenemez.");

            // UpdateAuthorViewModel vm = _mapper.Map<UpdateAuthorViewModel>(response);
            
            response.AuthorName=Model.AuthorName;
            response.AuthorSurname=Model.AuthorSurname;
            response.AuthorIsActive=Model.AuthorIsActive;


            _context.SaveChanges();
            // return vm;
        }

    }
    public class UpdateAuthorViewModel
    {
        
        public string AuthorName { get; set; }
        public string AuthorSurname { get; set; }
        public bool AuthorIsActive {get;set;} = true;
    }
}