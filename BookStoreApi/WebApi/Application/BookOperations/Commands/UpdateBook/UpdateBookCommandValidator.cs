using FluentValidation;

namespace WebApi.BookOperations.UpdateBook
{
    public class UpdateBookCommandValidator : AbstractValidator<UpdateBookCommand>
    {
        public UpdateBookCommandValidator()
        {
            RuleFor(x=>x.BookId).GreaterThan(0);
            RuleFor(x=>x.model.GenreId).NotEmpty().GreaterThan(0);
            RuleFor(x=>x.model.Title).NotEmpty().MinimumLength(4).WithMessage("Başlık en az 4 karakterli olabilir.");
        }
    }
}