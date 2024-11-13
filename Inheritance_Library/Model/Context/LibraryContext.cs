using Microsoft.EntityFrameworkCore;
using Model.Entities;

namespace Model.Context;

public class LibraryContext : DbContext
{
    #region DBSets

    public DbSet<Item> Items { get; set; }
    public DbSet<Person> Persons { get; set; }

    #endregion
    
    public LibraryContext(DbContextOptions<LibraryContext> options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        builder.Entity<Item>()
            .HasDiscriminator<string>("ITEM_TYPE")
            .HasValue<Novel>("NOVEL")
            .HasValue<NonFiction>("NON_FICTION")
            .HasValue<Textbook>("TEXTBOOK")
            .HasValue<Biography>("BIOGRAPHY")
            .HasValue<ScienceFiction>("SCIENCE_FICTION")
            .HasValue<Fantasy>("FANTASY")
            .HasValue<Mystery>("MYSTERY");

        builder.Entity<Librarian>().ToTable("LIBRARIANS");
        builder.Entity<Author>().ToTable("AUTHORS");
        builder.Entity<Customer>().ToTable("CUSTOMERS");

        builder.Entity<BookDetails>()
            .HasOne<Item>(s => s.Book)
            .WithOne(s => s.BookDetails)
            .HasForeignKey<BookDetails>(s => s.Id);

        builder.Entity<Author>()
            .HasMany<Item>(s => s.Books)
            .WithOne(s => s.BookAuthor)
            .HasForeignKey(s => s.AuthorId);

        //Book Management


        builder.Entity<BookManagement>()
            .HasKey(s => new { s.CustomerId, s.BookId, s.LibrarianId });

        builder.Entity<BookManagement>()
            .HasOne<Customer>(s => s.Customer)
            .WithMany(s => s.BorrowedBooks)
            .HasForeignKey(s => s.CustomerId);

        builder.Entity<BookManagement>()
            .HasOne<Item>(s => s.Book)
            .WithMany(s => s.BorrowedBooks)
            .HasForeignKey(s => s.BookId);

        builder.Entity<BookManagement>()
            .HasOne<Librarian>(s => s.LoanLibrarian)
            .WithMany(s => s.LoanedBooks)
            .HasForeignKey(s => s.LibrarianId);

        builder.Entity<BookManagement>()
            .HasOne<Librarian>(s => s.ReturnLibrarian)
            .WithMany(s => s.ReturnedBooks)
            .HasForeignKey(s => s.ReturnLibrarianId);

        base.OnModelCreating(builder);
    }
}