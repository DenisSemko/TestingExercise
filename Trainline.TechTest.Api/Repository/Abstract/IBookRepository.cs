namespace Trainline.TechTest.Api.Repository.Abstract;

public interface IBookRepository
{
    IReadOnlyCollection<Book> GetAll();
    Book GetById(Guid id);
    Guid Add(Book entity);
    void Update(Guid key, Book entity);
    void Delete(Guid key);
}