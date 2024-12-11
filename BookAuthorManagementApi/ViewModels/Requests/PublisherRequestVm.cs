using System.ComponentModel.DataAnnotations;

namespace BookAuthorManagementApi.ViewModels.Requests;

public class PublisherRequestVm
{
    public string Name { get; set; } = null!;

    public string Address { get; set; } = null!;

    [RegularExpression(@"^[0-9]*$", ErrorMessage = "Phone must contain only numbers")]
    public string Phone { get; set; } = null!;
}