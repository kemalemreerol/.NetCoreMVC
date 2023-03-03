using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using WebApi.Application.GenreOperations.Commands.CreateGenreCommand;
using WebApi.Application.GenreOperations.Commands.DeleteGenreCommand;
using WebApi.Application.GenreOperations.Commands.UpdateGenreCommand;
using WebApi.Application.GenreOperations.Queries.GetGenreDetail;
using WebApi.Application.GenreOperations.Queries.GetGenres;
using WebApi.DbOperations;

namespace WebApi.Controllers
{
    [ApiController]
    [Route("[controller]s")]
    public class GenreController : ControllerBase
    {
        private readonly BookStoreDbContext _context;
        private readonly IMapper _mapper;

        public GenreController(BookStoreDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult GetGenres()
        {
            GetGenresQuery gry = new GetGenresQuery(_context,_mapper);
            var obj = gry.Handle();
            return Ok(obj);
        }

        [HttpGet("{id}")]
        public IActionResult GetGenreDetail(int id)
        {
            GetGenreDetailQuery gm = new GetGenreDetailQuery(_context,_mapper);
            gm.GenreId = id;
            GetGenreDetailQueryValidator valid = new GetGenreDetailQueryValidator();
            valid.ValidateAndThrow(gm); 
            var ok = gm.Handle();
            return Ok(ok);
        }

        [HttpPost]
        public IActionResult CreateGenre([FromBody]CreateGenreViewModel model)
        {
            CreateGenreCommand create = new CreateGenreCommand(_context);
            create.model=model;
            CreateGenreCommandValidator validate = new CreateGenreCommandValidator();
            validate.ValidateAndThrow(create);
            create.Handle();
            return Ok();
        }

        [HttpPut("{id}")]
        public IActionResult UpdateGenre([FromBody]UpdateGenreViewModel model,int id)
        {
            UpdateGenreCommand update = new UpdateGenreCommand(_context);
            update.GenreId=id;
            update.model=model;
            UpdateGenreCommandValidator validate = new UpdateGenreCommandValidator();
            validate.ValidateAndThrow(update);
            
            update.Handle();
            return Ok();
        }
        
        [HttpDelete("{id}")]
        public IActionResult DeleteGenre(int id)
        {
            DeleteGenreCommand delete = new DeleteGenreCommand(_context);
            delete.GenreId = id;
            DeleteGenreCommandValidator validate = new DeleteGenreCommandValidator();
            validate.ValidateAndThrow(delete);
            delete.Handle();
            return Ok();
        }
    }
}