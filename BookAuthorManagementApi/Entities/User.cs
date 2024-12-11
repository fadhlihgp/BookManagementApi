using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BookAuthorManagementApi.Entities;

[Table("User")]
public class User
{
    [Key] public string Id { get; set; } = Guid.NewGuid().ToString();

    public string UserName { get; set; } = null!;

    public string Password { get; set; } = null!;

    public string Role { get; set; } = null!;
}