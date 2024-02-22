namespace Trainline.TechTest.Api.Controllers;

[ApiController]
[Route("v1/api/[controller]")]
public class BookController : Controller
{
    private readonly IBookService _bookService;

    public BookController(IBookService bookService)
    {
        _bookService = bookService ?? throw new ArgumentNullException(nameof(bookService));
    }

    [HttpGet]
    [ProducesResponseType(typeof(IReadOnlyCollection<Book>), (int)HttpStatusCode.OK)]
    public ActionResult<IReadOnlyCollection<Book>> GetAll()
    {
        IReadOnlyCollection<Book> books = _bookService.GetAll();
        return Ok(books);
    }

    [HttpGet("{id:guid}")]
    [ProducesResponseType(typeof(Book), (int)HttpStatusCode.OK)]
    public ActionResult<Book> GetById(Guid id)
    {
        Book book = _bookService.GetById(id);

        return Ok(book);
    }
    
    [HttpPost]
    [ProducesResponseType((int)HttpStatusCode.Created)]
    public ActionResult<Guid> Add([FromBody] Book entity)
    {
        Guid result = _bookService.Add(entity);
        return CreatedAtAction(nameof(Add), result);
    }
    
    [HttpPut]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesDefaultResponseType]
    public ActionResult Update([FromBody] Book entity)
    {
        _bookService.Update(entity);
        
        return NoContent();
    }
    
    [HttpDelete("{id}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesDefaultResponseType]
    public ActionResult Delete(Guid id)
    {
        _bookService.Delete(id);
        return NoContent();
    }
}