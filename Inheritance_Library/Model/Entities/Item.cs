using System.ComponentModel.DataAnnotations.Schema;

namespace Model.Entities;

[Table("ITEMS")]
public class Item
{
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }
    [Column("TITLE")]
    public string? Title { get; set; }
    [Column("AUTHOR")]
    public string? Author { get; set; }
    [Column("PUBLISHED_DATE")]
    public DateTime PublishedDate { get; set; }
    [Column("ISBN")]
    public string? ISBN { get; set; }

    public BookDetails? BookDetails;

    public int AuthorId { get; set; }
    public Author? BookAuthor;

    public List<BookManagement> BorrowedBooks;

}