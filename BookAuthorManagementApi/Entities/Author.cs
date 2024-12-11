using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BookAuthorManagementApi.Entities;

[Table("Author")]
public class Author
{
    [Key] public string Id { get; set; } = Guid.NewGuid().ToString();

    public string FullName { get; set; } = null!;

    public string Address { get; set; } = null!;

    public string Phone { get; set; } = null!;

    public DateTime BirthDate { get; set; }

    public bool IsDeleted { get; set; } = false;
    
    public virtual ICollection<Book> Books { get; set; } = new List<Book>();
}