using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BookAuthorManagementApi.Entities;

[Table("Book")]
public class Book
{
    [Key] public string Id { get; set; } = Guid.NewGuid().ToString();

    public string Title { get; set; } = null!;

    public int PublicationYear { get; set; }

    public string Description { get; set; } = null!;
    
    public string AuthorId { get; set; }
    
    public string PublisherId { get; set; }

    public virtual Author Author { get; set; } = null!;
    
    public virtual Publisher Publisher { get; set; } = null!;
}