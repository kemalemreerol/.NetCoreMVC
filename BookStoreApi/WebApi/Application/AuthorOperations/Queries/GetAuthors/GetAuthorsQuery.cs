using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using WebApi.DbOperations;

namespace WebApi.Application.AuthorOperations.Queries.GetAuthors
{
    public class GetAuthorsQuery
    {
        private readonly BookStoreDbContext _context;
        private readonly IMapper _mapper;
        public GetAuthorsQuery(BookStoreDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }


        public List<AuthorViewModel> Handle()
        {
            var response= _context.Authors.Where(x=>x.AuthorIsActive).OrderBy(x=>x.Id);
            List<AuthorViewModel> avm = _mapper.Map<List<AuthorViewModel>>(response);
            return avm;
        }
    }

    public class AuthorViewModel
    {
        public int Id { get; set; }
        public string authorName { get; set; }
        public string authorSurname { get; set; }
    }
}