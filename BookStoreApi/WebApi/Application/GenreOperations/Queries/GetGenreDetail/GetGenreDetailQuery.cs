using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using WebApi.DbOperations;

namespace WebApi.Application.GenreOperations.Queries.GetGenreDetail
{
    public class GetGenreDetailQuery
    {
        private readonly BookStoreDbContext _context;
        private readonly IMapper _mapper;
        public int GenreId {get;set;}

        public GetGenreDetailQuery(BookStoreDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public GenreDetailsViewModel Handle()
        {
            var genre = _context.Genres.SingleOrDefault(x=>x.IsActive && x.Id==GenreId);
            if(genre is null)
               throw new InvalidOperationException("Kitap türü bulunamadı.");
            

            GenreDetailsViewModel gm = _mapper.Map<GenreDetailsViewModel>(genre);
            return gm;
        }


    }

    public class GenreDetailsViewModel
    {
        public int Id {get;set;}
        public string Name { get; set; }
    }
}