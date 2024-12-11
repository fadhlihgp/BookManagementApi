using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BookAuthorManagementApi.Entities;

[Table("Publisher")]
public class Publisher
{
    [Key] public string Id { get; set; } = Guid.NewGuid().ToString();

    public string Name { get; set; } = null!;

    public string Address { get; set; } = null!;

    public string Phone { get; set; } = null!;

    public bool IsDeleted { get; set; } = false;
    
    public virtual ICollection<Book> Books { get; set; } = new List<Book>();
}