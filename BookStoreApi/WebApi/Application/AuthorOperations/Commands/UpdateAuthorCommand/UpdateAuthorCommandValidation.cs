using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FluentValidation;

namespace WebApi.Application.AuthorOperations.Commands.UpdateAuthorCommand
{
    public class UpdateAuthorCommandValidation : AbstractValidator<UpdateAuthorCommand>
    {
        public UpdateAuthorCommandValidation()
        {
            RuleFor(x=>x.AuthorId).GreaterThan(0);
            RuleFor(x=>x.Model.AuthorName).MinimumLength(2);
        }
    }
}