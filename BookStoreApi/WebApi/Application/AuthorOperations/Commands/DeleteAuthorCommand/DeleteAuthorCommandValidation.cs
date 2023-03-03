using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FluentValidation;

namespace WebApi.Application.AuthorOperations.Commands.DeleteAuthorCommand
{
    public class DeleteAuthorCommandValidation : AbstractValidator<DeleteAuthorCommand>
    {
        public DeleteAuthorCommandValidation()
        {
            RuleFor(x=>x.AuthorId).GreaterThan(0);
        }
    }
}