namespace Model.Entities;

public class BookManagement
{
    public int CustomerId { get; set; }
    public Customer Customer { get; set; }

    public int BookId { get; set; }
    public Item Book { get; set; }

    public DateTime LoanDate { get; set; }
    public DateTime DueDate { get; set; }

    public int LibrarianId { get; set; }
    public Librarian LoanLibrarian { get; set; }

    public int? ReturnLibrarianId { get; set; }
    public Librarian? ReturnLibrarian { get; set; }

    public DateTime? ReturnDate { get; set; }

}