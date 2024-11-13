namespace Model.Entities;

public class BookDetails
{
    public int Id { get; set; }

    public Item Book;

    public int TotalCopies { get; set; }

    public int BorrowedCopies { get; set; }

    public int AvailableCopies { get; set; }
}