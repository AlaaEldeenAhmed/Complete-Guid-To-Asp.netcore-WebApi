using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using My_Books.Data.Services;
using My_Books.Data.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace My_Books.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        public BooksService _bookservice;
        public BooksController(BooksService booksService)
        {
            _bookservice = booksService;
        }

        [HttpGet("Get-All-Books")]
        public IActionResult GetAllBooks()
        {
            var AllBooks = _bookservice.GetAllBook();
            return Ok(AllBooks);
        }

        [HttpGet("Get-Book-bYId/{Id}")]
        public IActionResult GetBookById(int Id)
        {
            var Book = _bookservice.GetBookById(Id);
            return Ok(Book);
        }

        [HttpPost("Add-Book")]
        public IActionResult AddBook([FromBody]BookVM book )
        {

            _bookservice.AddBook(book);
            return Ok();

        }
    }
}
