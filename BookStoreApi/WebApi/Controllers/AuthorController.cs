using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using WebApi.Application.AuthorOperations.Commands.CreateAuthorCommand;
using WebApi.Application.AuthorOperations.Commands.DeleteAuthorCommand;
using WebApi.Application.AuthorOperations.Commands.UpdateAuthorCommand;
using WebApi.Application.AuthorOperations.Queries.GetAuthorDetail;
using WebApi.Application.AuthorOperations.Queries.GetAuthors;
using WebApi.DbOperations;

namespace WebApi.Controllers
{
    [Route("[controller]s")]
    public class AuthorController : Controller
    {
        private readonly BookStoreDbContext _context;
         private readonly IMapper _mapper;

        public AuthorController(BookStoreDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
 
        [HttpGet]
        public IActionResult GetAuthors()
        {
            GetAuthorsQuery model = new GetAuthorsQuery(_context,_mapper);
            var response = model.Handle();
            return Ok(response);
        }
    
       [HttpGet("{id}")]
       public IActionResult GetAuthorDetail(int id)
       {

            GetAuthorDetailQuery model = new GetAuthorDetailQuery(_context,_mapper);

            model.AuthorId=id;
            
            GetAuthorDetailQueryValidator validate = new GetAuthorDetailQueryValidator();
            validate.ValidateAndThrow(model);

            var response= model.Handle();

            return Ok(response);
       }

       [HttpPost]
       public IActionResult AuthorPost([FromBody]CreateAuthorViewModel Model)
       {
           CreateAuthorCommand res = new CreateAuthorCommand(_context,_mapper);
           res.Model=Model;
           CreateAuthorCommandValidation validate = new CreateAuthorCommandValidation();
           validate.ValidateAndThrow(res);

           res.Handle();
           return Ok();
       }

       [HttpDelete("{id}")]
       public IActionResult DeleteAuthor(int id)
       {
          DeleteAuthorCommand cm = new DeleteAuthorCommand(_context);
          cm.AuthorId=id;

          DeleteAuthorCommandValidation validate = new DeleteAuthorCommandValidation();
          validate.ValidateAndThrow(cm);

          cm.Handle();
          return Ok();
       }

       [HttpPut("{id}")]
       public IActionResult UpdateAuthor([FromBody]UpdateAuthorViewModel Model, int id)
       {
          UpdateAuthorCommand up = new UpdateAuthorCommand(_context,_mapper);
          up.Model=Model;
          up.AuthorId=id;

          UpdateAuthorCommandValidation validate = new UpdateAuthorCommandValidation();
          validate.ValidateAndThrow(up);

          up.Handle();
          return Ok();
       }
    }
}