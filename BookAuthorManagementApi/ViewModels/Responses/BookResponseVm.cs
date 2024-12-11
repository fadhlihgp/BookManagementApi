namespace BookAuthorManagementApi.ViewModels.Responses;

public class BookResponseVm
{
    public string Id { get; set; }
    
    public string Title { get; set; } = null!;

    public int PublicationYear { get; set; }

    public string Description { get; set; } = null!;
    
    public AuthorResponseBook? Author { get; set; }
    
    public PublisherResponseBook? Publisher { get; set; }
}

public class AuthorResponseBook
{
    public string Id { get; set; } = null!;
    
    public string FullName { get; set; } = null!;

    public string Address { get; set; } = null!;

    public string Phone { get; set; } = null!;

    public DateTime BirthDate { get; set; }
}

public class PublisherResponseBook
{
    public string Id { get; set; } = null!;

    public string Name { get; set; } = null!;

    public string Address { get; set; } = null!;

    public string Phone { get; set; } = null!;
}