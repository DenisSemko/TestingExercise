namespace Trainline.TechTest.Api.Validators;

public class BookValidator : AbstractValidator<Book>
{
    public BookValidator()
    {
        RuleFor(book => book.Id).NotNull().NotEmpty().WithMessage("Book Id cannot be empty.");
        RuleFor(book => book.Title).NotNull().NotEmpty().WithMessage("Title cannot be empty.");
        RuleFor(book => book.Author).NotNull().NotEmpty().WithMessage("Authors must have at least one name.");
        RuleFor(book => book.PublicationDate).NotNull().Must(BeInThePast).WithMessage("Publication date must be in the past.");
    }
    
    private bool BeInThePast(DateOnly publicationDate)
    {
        return publicationDate < DateOnly.FromDateTime(DateTime.Now);
    }
}