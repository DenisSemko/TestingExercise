namespace TestProject1;

public class BookTests
{
    [Fact]
    public void GetAll_ReturnsListOfBooks()
    {
        //Arrange
        var mockRepository = new Mock<IBookRepository>();
        var bookService = new BookService(mockRepository.Object);
        
        List<Book> expectedBooks = new List<Book>()
        {
            new Book() {Id = Guid.NewGuid(), Title = "Test1", Author = "Test1", PublicationDate = DateOnly.FromDateTime(DateTime.Now.AddDays(-1))},
            new Book() {Id = Guid.NewGuid(), Title = "Test2", Author = "Test2", PublicationDate = DateOnly.FromDateTime(DateTime.Now.AddDays(-1))}
        };
        mockRepository.Setup(repository => repository.GetAll()).Returns(expectedBooks);

        //Act
        IReadOnlyCollection<Book> result = bookService.GetAll();

        //Assert
        Assert.Equal(expectedBooks, result);
    }
    
    [Fact]
    public void GetById_ReturnsBook()
    {
        //Arrange
        var mockRepository = new Mock<IBookRepository>();
        var bookService = new BookService(mockRepository.Object);
        
        Book expectedBook = new Book()
        {
            Id = Guid.NewGuid(), 
            Title = "Test1", 
            Author = "Test1", 
            PublicationDate = DateOnly.FromDateTime(DateTime.Now.AddDays(-1))
            
        };
        mockRepository.Setup(repository => repository.GetById(expectedBook.Id)).Returns(expectedBook);

        //Act
        Book result = bookService.GetById(expectedBook.Id);

        //Assert
        Assert.Equal(expectedBook, result);
    }
    
    [Fact]
    public void AddBook_ReturnsValidationException()
    {
        // Arrange
        var mockRepository = new Mock<IBookRepository>();
        var bookService = new BookService(mockRepository.Object);

        Book book = new Book
        {
            Id = Guid.NewGuid(), Author = "Test", PublicationDate = DateOnly.FromDateTime(DateTime.Now)
        };
        
        // Assert
        Assert.Throws<FluentValidation.ValidationException>(() => bookService.Add(book));
    }
    
    [Fact]
    public void AddBook_ReturnsGuid()
    {
        // Arrange
        var mockRepository = new Mock<IBookRepository>();
        var bookService = new BookService(mockRepository.Object);

        Book book = new Book
        {
            Id = Guid.NewGuid(), 
            Title = "Test", 
            Author = "Test", 
            PublicationDate = DateOnly.FromDateTime(DateTime.Now.AddDays(-1))
        };
        mockRepository.Setup(bookRepository => bookRepository.Add(It.IsAny<Book>())).Returns((Book b) => b.Id);
        
        //Act
        Guid result = bookService.Add(book);
        
        // Assert
        Assert.Equal(book.Id, result);
        mockRepository.Verify(bookRepository => bookRepository.Add(It.IsAny<Book>()), Times.Once);
    }
}