using System.ComponentModel.DataAnnotations;

namespace BookAuthorManagementApi.ViewModels.Requests;

public class AuthorRequestVm
{
    public string FullName { get; set; } = null!;

    public string Address { get; set; } = null!;

    [RegularExpression(@"^[0-9]*$", ErrorMessage = "Phone must contain only numbers")]
    public string Phone { get; set; } = null!;

    public DateTime BirthDate { get; set; }
}