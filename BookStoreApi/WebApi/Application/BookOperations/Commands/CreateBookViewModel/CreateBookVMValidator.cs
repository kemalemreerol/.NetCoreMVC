using System;
using FluentValidation;

namespace WebApi.BookOperations.CreateBookViewModel
{
    public class CreateBookVMValidator : AbstractValidator<CreateBookVM>
    {
       public CreateBookVMValidator()
       {
          RuleFor(c=>c.Model.GenreId).GreaterThan(0);
          RuleFor(c=>c.Model.PageCount).GreaterThan(0);
          RuleFor(c=>c.Model.PublishDate.Date).NotEmpty().LessThan(DateTime.Now.Date);
          RuleFor(c=>c.Model.Title).NotEmpty().MinimumLength(4);
       }
    }
}