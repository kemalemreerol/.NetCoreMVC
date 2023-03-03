using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FluentValidation;

namespace WebApi.Application.GenreOperations.Commands.UpdateGenreCommand
{
    public class UpdateGenreCommandValidator : AbstractValidator<UpdateGenreCommand>
    {
        public UpdateGenreCommandValidator()
        {
            RuleFor(x=>x.model.Name).MinimumLength(4).When(x=>x.model.Name.Trim() != string.Empty);
        }
    }
}