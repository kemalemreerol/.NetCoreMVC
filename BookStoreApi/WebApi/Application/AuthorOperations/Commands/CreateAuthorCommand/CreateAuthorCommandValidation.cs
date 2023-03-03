using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FluentValidation;

namespace WebApi.Application.AuthorOperations.Commands.CreateAuthorCommand
{
    public class CreateAuthorCommandValidation : AbstractValidator<CreateAuthorCommand>
    {
        public CreateAuthorCommandValidation()
        {
            RuleFor(x=>x.Model).NotEmpty();
        }
    }
}