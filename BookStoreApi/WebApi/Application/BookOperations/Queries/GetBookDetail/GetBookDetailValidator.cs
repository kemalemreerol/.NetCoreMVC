using FluentValidation;

namespace WebApi.BookOperations.GetBookDetail
{
    public class GetBookDetailValidator : AbstractValidator<GetBookDetailQuery>
    {
       public GetBookDetailValidator()
       {
          RuleFor(x=>x.BookId).GreaterThan(0);
       }
    }
}