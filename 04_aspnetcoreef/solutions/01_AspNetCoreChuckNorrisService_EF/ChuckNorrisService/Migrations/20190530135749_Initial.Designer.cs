﻿// <auto-generated />
using ChuckNorrisService.DataAccess;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace ChuckNorrisService.Migrations
{
    [DbContext(typeof(JokeDbContext))]
    [Migration("20190530135749_Initial")]
    partial class Initial
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.4-servicing-10062")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("ChuckNorrisService.Models.Joke", b =>
                {
                    b.Property<string>("Id");

                    b.Property<string>("JokeText")
                        .IsRequired()
                        .HasMaxLength(500);

                    b.HasKey("Id");

                    b.ToTable("Jokes");
                });

            modelBuilder.Entity("ChuckNorrisService.Models.JokeCategory", b =>
                {
                    b.Property<string>("Id");

                    b.Property<string>("JokeId");

                    b.Property<string>("Name");

                    b.HasKey("Id");

                    b.HasIndex("JokeId");

                    b.ToTable("JokeCategories");
                });

            modelBuilder.Entity("ChuckNorrisService.Models.JokeCategory", b =>
                {
                    b.HasOne("ChuckNorrisService.Models.Joke")
                        .WithMany("Categories")
                        .HasForeignKey("JokeId");
                });
#pragma warning restore 612, 618
        }
    }
}
