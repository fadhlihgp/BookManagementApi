namespace BookAuthorManagementApi.ViewModels.Responses;

public class PublisherResponseVm
{
    public string Id { get; set; }

    public string Name { get; set; } = null!;

    public string Address { get; set; } = null!;

    public string Phone { get; set; } = null!;
    
    public IEnumerable<BookResponseVm> Books { get; set; }
}