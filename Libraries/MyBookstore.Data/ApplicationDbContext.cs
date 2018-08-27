using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using MyBookstore.Core;
using System;

namespace MyBookstore.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser, ApplicationRole, Guid>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
                    : base(options)
        {
        }

        public DbSet<Book> Books { get; set; }
        public DbSet<State> States { get; set; }
        public DbSet<OrderBook> OrderBooks { get; set; }
        public DbSet<BookFormat> BookFormat { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Review> Reviews { get; set; }
        public DbSet<Author> Authors { get; set; }
        public DbSet<Genre> Genres { get; set; }
        public DbSet<Format> Formats { get; set; }
        public DbSet<GenreBook> GenreBooks { get; set; }
        public DbSet<AuthorGenre> AuthorGenres { get; set; }
        public DbSet<BookFormat> BookFormats { get; set; }
        public DbSet<Picture> Pictures { get; set; }
        public DbSet<ShoppingCartItem> ShoppingCartItems { get; set; }


        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<ShoppingCartItem>()
                .HasOne(bc => bc.User)
                .WithMany(b => b.ShoppingCartItems)
                .HasForeignKey(bc => bc.UserId);

            builder.Entity<ShoppingCartItem>()
                .HasOne(bc => bc.Book)
                .WithMany(c => c.ShoppingCartItems)
                .HasForeignKey(bc => bc.BookId);

            builder.Entity<Picture>()
              .HasOne(a => a.Book)
              .WithMany(b => b.Pictures)
              .HasForeignKey(a => a.BookId);

            builder.Entity<Book>()
              .HasOne(a => a.Author)
              .WithMany(b => b.Books)
              .HasForeignKey(a => a.AuthorId);

            builder.Entity<GenreBook>()
              .HasKey(bc => new { bc.BookId, bc.GenreId });

            builder.Entity<GenreBook>()
                .HasOne(bc => bc.Book)
                .WithMany(b => b.BookGenres)
                .HasForeignKey(bc => bc.BookId);

            builder.Entity<GenreBook>()
                .HasOne(bc => bc.Genre)
                .WithMany(c => c.BookGenres)
                .HasForeignKey(bc => bc.GenreId);

            builder.Entity<AuthorGenre>()
                .HasKey(bc => new { bc.AuthorId, bc.GenreId });

            builder.Entity<AuthorGenre>()
                .HasOne(bc => bc.Author)
                .WithMany(b => b.AuthorGenres)
                .HasForeignKey(bc => bc.AuthorId);

            builder.Entity<AuthorGenre>()
                .HasOne(bc => bc.Genre)
                .WithMany(c => c.AuthorGenres)
                .HasForeignKey(bc => bc.GenreId);

            builder.Entity<Review>()
              .HasOne(a => a.Book) // 
              .WithMany(b => b.Reviews)
              .HasForeignKey(a => a.BookId);


            builder.Entity<BookFormat>()
                .HasKey(bc => new { bc.BookId, bc.FormatId });

            builder.Entity<BookFormat>()
                .HasOne(bc => bc.Book)
                .WithMany(b => b.BookFormats)
                .HasForeignKey(bc => bc.BookId);

            builder.Entity<BookFormat>()
                .HasOne(bc => bc.Format)
                .WithMany(c => c.BookFormats)
                .HasForeignKey(bc => bc.FormatId);

            builder.Entity<Order>()
             .HasOne(a => a.OrderState)
             .WithMany(b => b.Orders)
             .HasForeignKey(a => a.StateId);

            builder.Entity<OrderBook>()
               .HasKey(bc => new { bc.BookId, bc.OrderId });

        }
    }
}
