﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.EntityFrameworkCore.Storage.Internal;
using MyBookstore.Data;
using System;

namespace MyBookstore.Web.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20180426141748_20180426-01")]
    partial class _2018042601
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.0.0-rtm-26452")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("MyBookstore.Core.Author", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("BirthYear");

                    b.Property<int>("DeathYear");

                    b.Property<string>("Description");

                    b.Property<string>("MiddleName")
                        .HasMaxLength(100);

                    b.Property<string>("Name")
                        .HasMaxLength(100);

                    b.Property<int>("Rate");

                    b.Property<string>("Surname")
                        .HasMaxLength(100);

                    b.HasKey("Id");

                    b.ToTable("Authors");
                });

            modelBuilder.Entity("MyBookstore.Core.AuthorGenre", b =>
                {
                    b.Property<int>("AuthorId");

                    b.Property<int>("GenreId");

                    b.Property<int>("Id");

                    b.HasKey("AuthorId", "GenreId");

                    b.HasIndex("GenreId");

                    b.ToTable("AuthorGenres");
                });

            modelBuilder.Entity("MyBookstore.Core.Book", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("AuthorId");

                    b.Property<string>("Description");

                    b.Property<int>("GenreId");

                    b.Property<bool>("IsAvailable");

                    b.Property<string>("Name");

                    b.Property<int?>("OrderId");

                    b.Property<bool>("PaperBook");

                    b.Property<byte[]>("Picture");

                    b.Property<string>("PictureName");

                    b.Property<int>("Rate");

                    b.HasKey("Id");

                    b.HasIndex("AuthorId");

                    b.HasIndex("OrderId");

                    b.ToTable("Books");
                });

            modelBuilder.Entity("MyBookstore.Core.BookFormat", b =>
                {
                    b.Property<int>("BookId");

                    b.Property<int>("FormatId");

                    b.Property<int>("Id");

                    b.HasKey("BookId", "FormatId");

                    b.HasIndex("FormatId");

                    b.ToTable("BookFormat");
                });

            modelBuilder.Entity("MyBookstore.Core.Format", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Name");

                    b.Property<int?>("OrderId");

                    b.HasKey("Id");

                    b.HasIndex("OrderId");

                    b.ToTable("Formats");
                });

            modelBuilder.Entity("MyBookstore.Core.Genre", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("GenreName");

                    b.HasKey("Id");

                    b.ToTable("Genres");
                });

            modelBuilder.Entity("MyBookstore.Core.GenreBook", b =>
                {
                    b.Property<int>("BookId");

                    b.Property<int>("GenreId");

                    b.Property<int>("Id");

                    b.HasKey("BookId", "GenreId");

                    b.HasIndex("GenreId");

                    b.ToTable("GenreBooks");
                });

            modelBuilder.Entity("MyBookstore.Core.Order", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("CreatedOn");

                    b.Property<string>("OrderNote");

                    b.Property<bool>("PaperBook");

                    b.Property<int>("StateId");

                    b.Property<int>("UserId");

                    b.HasKey("Id");

                    b.HasIndex("StateId");

                    b.HasIndex("UserId");

                    b.ToTable("Orders");
                });

            modelBuilder.Entity("MyBookstore.Core.OrderBook", b =>
                {
                    b.Property<int>("BookId");

                    b.Property<int>("OrderId");

                    b.Property<int>("Id");

                    b.HasKey("BookId", "OrderId");

                    b.HasIndex("OrderId");

                    b.ToTable("OrderBooks");
                });

            modelBuilder.Entity("MyBookstore.Core.Picture", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("BookId");

                    b.Property<bool>("Main");

                    b.Property<string>("Name");

                    b.Property<string>("Path");

                    b.HasKey("Id");

                    b.HasIndex("BookId");

                    b.ToTable("Pictures");
                });

            modelBuilder.Entity("MyBookstore.Core.Review", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("BookId");

                    b.Property<string>("Text");

                    b.Property<int?>("UserId");

                    b.Property<string>("UserName");

                    b.HasKey("Id");

                    b.HasIndex("BookId");

                    b.HasIndex("UserId");

                    b.ToTable("Reviews");
                });

            modelBuilder.Entity("MyBookstore.Core.Role", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Name");

                    b.HasKey("Id");

                    b.ToTable("Roles");
                });

            modelBuilder.Entity("MyBookstore.Core.State", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Name");

                    b.HasKey("Id");

                    b.ToTable("States");
                });

            modelBuilder.Entity("MyBookstore.Core.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<bool>("IsManager");

                    b.Property<string>("Login");

                    b.Property<string>("MiddleName");

                    b.Property<string>("Name");

                    b.Property<string>("Password");

                    b.Property<int>("RoleId");

                    b.Property<string>("Surname");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("MyBookstore.Core.AuthorGenre", b =>
                {
                    b.HasOne("MyBookstore.Core.Author", "Author")
                        .WithMany("AuthorGenres")
                        .HasForeignKey("AuthorId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("MyBookstore.Core.Genre", "Genre")
                        .WithMany("AuthorGenres")
                        .HasForeignKey("GenreId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("MyBookstore.Core.Book", b =>
                {
                    b.HasOne("MyBookstore.Core.Author", "Author")
                        .WithMany("Books")
                        .HasForeignKey("AuthorId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("MyBookstore.Core.Order")
                        .WithMany("Books")
                        .HasForeignKey("OrderId");
                });

            modelBuilder.Entity("MyBookstore.Core.BookFormat", b =>
                {
                    b.HasOne("MyBookstore.Core.Book", "Book")
                        .WithMany("BookFormats")
                        .HasForeignKey("BookId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("MyBookstore.Core.Format", "Format")
                        .WithMany("BookFormats")
                        .HasForeignKey("FormatId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("MyBookstore.Core.Format", b =>
                {
                    b.HasOne("MyBookstore.Core.Order")
                        .WithMany("OrderFormats")
                        .HasForeignKey("OrderId");
                });

            modelBuilder.Entity("MyBookstore.Core.GenreBook", b =>
                {
                    b.HasOne("MyBookstore.Core.Book", "Book")
                        .WithMany("BookGenres")
                        .HasForeignKey("BookId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("MyBookstore.Core.Genre", "Genre")
                        .WithMany("BookGenres")
                        .HasForeignKey("GenreId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("MyBookstore.Core.Order", b =>
                {
                    b.HasOne("MyBookstore.Core.State", "OrderState")
                        .WithMany("Orders")
                        .HasForeignKey("StateId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("MyBookstore.Core.User", "User")
                        .WithMany("UsersOrders")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("MyBookstore.Core.OrderBook", b =>
                {
                    b.HasOne("MyBookstore.Core.Book", "Book")
                        .WithMany()
                        .HasForeignKey("BookId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("MyBookstore.Core.Order", "Order")
                        .WithMany()
                        .HasForeignKey("OrderId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("MyBookstore.Core.Picture", b =>
                {
                    b.HasOne("MyBookstore.Core.Book", "Book")
                        .WithMany("Pictures")
                        .HasForeignKey("BookId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("MyBookstore.Core.Review", b =>
                {
                    b.HasOne("MyBookstore.Core.Book", "Book")
                        .WithMany("Reviews")
                        .HasForeignKey("BookId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("MyBookstore.Core.User")
                        .WithMany("Reviews")
                        .HasForeignKey("UserId");
                });

            modelBuilder.Entity("MyBookstore.Core.User", b =>
                {
                    b.HasOne("MyBookstore.Core.Role", "Role")
                        .WithMany("Users")
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
