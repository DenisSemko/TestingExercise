namespace Trainline.TechTest.Api.Services.Concrete;

public class BookService : IBookService
{
    private readonly IBookRepository _bookRepository;
    private readonly BookValidator _bookValidator;

    public BookService(IBookRepository bookRepository)
    {
        _bookRepository = bookRepository ?? throw new ArgumentNullException(nameof(bookRepository));
        _bookValidator = new BookValidator();
    }

    public IReadOnlyCollection<Book> GetAll() => 
        _bookRepository.GetAll();

    public Book GetById(Guid id) => 
        _bookRepository.GetById(id);

    public Guid Add(Book entity)
    {
        _bookValidator.Validate(entity, options => options.ThrowOnFailures());

        return _bookRepository.Add(entity);
    }

    public void Update(Book entity)
    {
        _bookValidator.Validate(entity, options => options.ThrowOnFailures());
        
        _bookRepository.Update(entity.Id, entity);
    }

    public void Delete(Guid key) => 
        _bookRepository.Delete(key);
}