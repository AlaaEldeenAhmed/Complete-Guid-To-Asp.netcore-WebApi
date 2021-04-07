using My_Books.Data.Model;
using My_Books.Data.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace My_Books.Data.Services
{
    public class BooksService
    {
        private AppDbContext _Context;
        public BooksService(AppDbContext context)
        {
            _Context = context;
        }

        public void AddBook(BookVM book)
        {
            var _Book = new Book()
            {
                Title = book.Title,
                Description = book.Description,
                IsRead = book.IsRead,
                DateRead = book.IsRead?book.DateRead.Value:null,
                Rate = book.IsRead?book.Rate.Value:null,
                Genre = book.Genre,
                Author = book.Author,
                CoverUrl = book.CoverUrl,
                DateAdded = DateTime.Now
            };

            _Context.Add(_Book);
            _Context.SaveChanges();
        }

        public List<Book> GetAllBook()
        {
            return _Context.Books.ToList();
        }

        public Book GetBookById(int Id)
        {

            return _Context.Books.SingleOrDefault(x=>x.Id == Id);
        }
    }
}
