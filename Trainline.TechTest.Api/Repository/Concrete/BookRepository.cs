namespace Trainline.TechTest.Api.Repository.Concrete;

public class BookRepository : IBookRepository
{
    private readonly ApplicationContext _applicationContext;

    public BookRepository(ApplicationContext applicationContext)
    {
        _applicationContext = applicationContext ?? throw new ArgumentNullException(nameof(applicationContext));
    }

    public IReadOnlyCollection<Book> GetAll() =>
        _applicationContext.library.Values;

    public Book GetById(Guid id)
    {
        _applicationContext.library.TryGetValue(id, out Book entity);
        return entity;
    }

    public Guid Add(Book entity)
    {
        if (entity.Id == Guid.Empty)
        {
            entity.Id = Guid.NewGuid();
        }
        
        _applicationContext.library.Add(entity.Id, entity);

        return entity.Id;
    }

    public void Update(Guid key, Book entity)
    {
        if (_applicationContext.library.ContainsKey(key))
        {
            _applicationContext.library[key] = entity;
        }
    }

    public void Delete(Guid key)
    {
        if (_applicationContext.library.ContainsKey(key))
        {
            _applicationContext.library.Remove(key);
        }
    }
}