using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using WebApi.DbOperations;

namespace WebApi.Application.AuthorOperations.Queries.GetAuthorDetail
{
    public class GetAuthorDetailQuery
    {
        public int AuthorId {get;set;}
        private readonly BookStoreDbContext _context;
        private readonly IMapper _mapper;
        public GetAuthorDetailQuery(BookStoreDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public AuthorDetailAuthorViewModel Handle()
        {
            var author = _context.Authors.SingleOrDefault(x=>x.AuthorIsActive && x.Id == AuthorId);
            if ( author is null)
                throw new InvalidOperationException("Yazar Bulunamadı.");

            // AuthorDetailAuthorViewModel vm = _mapper.Map<AuthorDetailAuthorViewModel>(author);

            AuthorDetailAuthorViewModel asd= new AuthorDetailAuthorViewModel();
            asd.Id=author.Id;
            asd.Name=author.AuthorName;
            asd.Surname=author.AuthorSurname;

            return asd;
        }
    }

    public class AuthorDetailAuthorViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        
        
    }
}