namespace BookAuthorManagementApi.ViewModels.Responses;

public class AuthorResponseVm
{
    public string Id { get; set; }
    
    public string FullName { get; set; } = null!;

    public string Address { get; set; } = null!;

    public string Phone { get; set; } = null!;

    public DateTime BirthDate { get; set; }
    
    public IEnumerable<BookResponseVm> Books { get; set; }
}