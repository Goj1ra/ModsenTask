using FluentValidation;


namespace ModsenTask.API.ViewModels.Validation
{
    public class BookViewModelValidator : AbstractValidator<BookViewModel>
    {
        public BookViewModelValidator()
        {
            RuleFor(x => x.ISBN)
                 .NotEmpty()
                 .MinimumLength(5);

            RuleFor(x => x.Author)
                .NotEmpty()
                .MinimumLength(5);

            RuleFor(x => x.Description)
                .NotEmpty()
                .MinimumLength(5);

            RuleFor(x => x.Genre)
                .NotEmpty()
                .MinimumLength(5);

            RuleFor(x => x.TakenBookTime)
                .NotEmpty();
            
            RuleFor(x => x.NeedBookToReturn)
                .NotEmpty();

        }
    }
}
