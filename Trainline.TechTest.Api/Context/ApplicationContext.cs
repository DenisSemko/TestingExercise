namespace Trainline.TechTest.Api.Context;

public class ApplicationContext
{
    public Dictionary<Guid, Book> library { get;  } = new Dictionary<Guid, Book>();
}