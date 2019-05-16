﻿using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using AspNetCore.EFBasics;

namespace AspNetCore.EFBasics.Migrations
{
    [DbContext(typeof(BookDbContext))]
    [Migration("20170518180028_InitialDbStructure")]
    partial class InitialDbStructure
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "1.1.2")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("AspNetCore.EFBasics.Models.Author", b =>
                {
                    b.Property<int>("Id");

                    b.Property<int>("Age");

                    b.Property<string>("FirstName");

                    b.Property<string>("LastName");

                    b.HasKey("Id");

                    b.ToTable("Authors");
                });

            modelBuilder.Entity("AspNetCore.EFBasics.Models.Book", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Isbn")
                        .IsRequired();

                    b.Property<decimal>("Price");

                    b.Property<DateTime?>("ReleaseDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Title")
                        .IsRequired();

                    b.Property<string>("TopSecret");

                    b.HasKey("Id");

                    b.ToTable("Books");
                });

            modelBuilder.Entity("AspNetCore.EFBasics.Models.BookAuthorRel", b =>
                {
                    b.Property<int>("BookId");

                    b.Property<int>("AuthorId");

                    b.HasKey("BookId", "AuthorId");

                    b.HasIndex("AuthorId");

                    b.ToTable("BookAuthorRel");
                });

            modelBuilder.Entity("AspNetCore.EFBasics.Models.BookAuthorRel", b =>
                {
                    b.HasOne("AspNetCore.EFBasics.Models.Author", "Author")
                        .WithMany("BookRelations")
                        .HasForeignKey("AuthorId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("AspNetCore.EFBasics.Models.Book", "Book")
                        .WithMany("AuthorRelations")
                        .HasForeignKey("BookId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
        }
    }
}
