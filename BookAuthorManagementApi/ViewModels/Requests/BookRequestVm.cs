namespace BookAuthorManagementApi.ViewModels.Requests;

public class BookRequestVm
{
    public string Title { get; set; } = null!;

    public int PublicationYear { get; set; }

    public string Description { get; set; } = null!;
    
    public string AuthorId { get; set; }
    
    public string PublisherId { get; set; }
}