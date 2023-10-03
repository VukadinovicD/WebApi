using Microsoft.EntityFrameworkCore;
using AspNetCoreWebApiTask1.Entities;

namespace AspNetCoreWebApiTask1.DBContext;

public class BookstoreContext : DbContext
{
    public DbSet<Bookstore> Bookstore { get; set; } = null!;

    public DbSet<Book> Book { get; set; } = null!;

    public DbSet<SpecialBook> SpecialBook { get; set; } = null!;


    public BookstoreContext(DbContextOptions<BookstoreContext> options) : base(options) {}

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Bookstore>().HasData(
            new Bookstore("Library1")
            {
                Id = 1
            },
            new Bookstore("Library2")
            {
                Id = 2
            },
            new Bookstore("Library3")
            {
                Id =  3
            }
        );

        modelBuilder.Entity<Book>().HasData(
            new Book("Book1")
            {
                Id = 1,
                BookstoreId = 1
            },
            new Book("Book2")
            {
                Id = 2,
                BookstoreId = 1
            },
            new Book("Book3")
            {
                Id = 3,
                BookstoreId = 2
            },
            new Book("Book4")
            {
                Id = 4,
                BookstoreId = 3
            },
            new Book("Book5")
            {
                Id = 5,
                BookstoreId = 3
            },
            new Book("Book6")
            {
                Id = 6,
                BookstoreId = 3
            }
        );

         modelBuilder.Entity<SpecialBook>().HasData(
            new SpecialBook("Book8", "SpecialEdition 1")
            {
                Id = 8,
                BookstoreId = 1
            },
            new SpecialBook("Book9", "SpecialEdition 2")
            {
                Id = 9,
                BookstoreId = 2
            },
            new SpecialBook("Book10", "SpecialEdition 3")
            {
                Id = 10,
                BookstoreId = 3
            },
            new SpecialBook("Book11", "SpecialEdition 4")
            {
                Id = 11,
                BookstoreId = 3
            }
        );
        base.OnModelCreating(modelBuilder);
    }
}
