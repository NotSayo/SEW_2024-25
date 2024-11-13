namespace Model.Entities;

public class Author : Person {
    public string? Biography { get; set; }

    public List<Item> Books;
}
// Abgeleitete Klasse für Kunden
public class Customer : Person {
    public DateTime MembershipDate { get; set; }
    public List<BookManagement> BorrowedBooks;
}
// Abgeleitete Klasse für Bibliothekare
public class Librarian : Person {
    public string? EmployeeId { get; set; }

    public List<BookManagement> LoanedBooks;
    public List<BookManagement> ReturnedBooks;
}