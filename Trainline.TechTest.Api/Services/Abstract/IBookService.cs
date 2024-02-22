namespace Trainline.TechTest.Api.Services.Abstract;

public interface IBookService
{
    IReadOnlyCollection<Book> GetAll();
    Book GetById(Guid id);
    Guid Add(Book entity);
    void Update(Book entity);
    void Delete(Guid key);
}