using AutoMapper;
using WebApi.Application.AuthorOperations.Commands.CreateAuthorCommand;
using WebApi.Application.AuthorOperations.Commands.UpdateAuthorCommand;
using WebApi.Application.AuthorOperations.Queries.GetAuthorDetail;
using WebApi.Application.AuthorOperations.Queries.GetAuthors;
using WebApi.Application.GenreOperations.Queries.GetGenreDetail;
using WebApi.Application.GenreOperations.Queries.GetGenres;
using WebApi.BookOperations.CreateBookViewModel;
using WebApi.BookOperations.GetBookDetail;
using WebApi.BookOperations.GetBooks;
using WebApi.BookOperations.UpdateBook;
using WebApi.Common;
using WebApi.Entities;



namespace WebApi.AutoMappers
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<CreateBookModel, Book>();
            CreateMap<Book, BookDetailVM>().ForMember(desc=>desc.GenreId,opt=>opt.MapFrom(src=>src.Genre.Name));
            CreateMap<Book,BooksViewModel>().ForMember(desc=>desc.Genre, opt=>opt.MapFrom(src=>src.Genre.Name));

            CreateMap<Genre, GenresViewModel>();
            CreateMap<Genre, GenreDetailsViewModel>();
            
            CreateMap<Author, AuthorViewModel>();
            CreateMap<Author, AuthorDetailAuthorViewModel>();
            // CreateMap<Author, UpdateAuthorViewModel>();
            CreateMap<CreateAuthorViewModel,Author>();
            
        }
    }
}