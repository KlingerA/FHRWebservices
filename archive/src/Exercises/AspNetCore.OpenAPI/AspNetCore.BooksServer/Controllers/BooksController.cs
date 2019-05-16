﻿using AspNetCore.BooksServer.Infrastructure;
using AspNetCore.BooksServer.Models;
using AspNetCore.BooksServer.Repositories;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AspNetCore.BooksServer.Controllers
{
    [Route("api/[controller]")]
    public class BooksController : Controller
    {
        public IBookRepository BookRepository { get; set; }
        public ITimeService TimeService { get; set; }

        public BooksController(IBookRepository bookRepository, ITimeService timeService)
        {
            BookRepository = bookRepository;
            TimeService = timeService;
        }
        // GET api/books
        [HttpGet("")]
        public IEnumerable<Book> GetBooks()
        {
            return BookRepository.GetAll();
        }

        // GET api/books/1
        [HttpGet("{id:int}", Name = "BookById")]
        public IActionResult GetBookById(int id)
        {
            var book = BookRepository.GetById(id);
            return book != null ? (IActionResult)Ok(book) : NotFound();
        }

        [HttpPost]
        public IActionResult CreateBook([FromBody] Book book)
        {
            // Während des Model Bindings werden die Validatoren
            // von Book geprüft
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var created = BookRepository.Add(book);
            return Created(Url.Link("BookById", new { Id = created.Id }), created);
        }

        private string GetErrorMessage()
        {
            return string.Join(";", ModelState.Values.SelectMany(v => v.Errors).Select(e => e.ErrorMessage));
        }

        [HttpPut("{id:int}")]
        public IActionResult UpdateBook(int id, [FromBody]Book book)
        {
            // Während des Model Bindings werden die Validatoren
            // von Book geprüft
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            var existing = BookRepository.GetById(id);

            if (existing == null)
            {
                return NotFound();
            }

            book = BookRepository.Update(id, book);
            return Ok(book);
        }

    }
}
