﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.Serialization;

namespace AspNetCore.EFRepository.Models
{
    public class Book
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Isbn { get; set; }
        [Required]
        public string Title { get; set; }
        public decimal Price { get; set; }

        public DateTime? ReleaseDate { get; set; }

        [IgnoreDataMember]
        public string TopSecret { get; set; }

        public ICollection<BookAuthorRel> AuthorRelations { get; set; }

        [Range(0, 10)]
        public int Rating { get; set; }

        public Book()
        {
        }

        public Book(string isbn, string title, decimal price, DateTime? releaseDate = null, int rating = 0)
        {
            Isbn = isbn;
            Title = title;
            Price = price;
            ReleaseDate = releaseDate;
            Rating = rating;
        }
    }
}