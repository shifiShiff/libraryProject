using Library.Core.Modals;
using Library.Core.Reposetory;
using Library.Core.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Servicrs
{
    public class BookService:IBookService
    {
        private readonly IBookReposetory _bookReposetory;

        public BookService(IBookReposetory bookreposetory)
        {
                _bookReposetory= bookreposetory;
        }

        public List<Book> GetAllBooks()
        {
            return _bookReposetory.GetAllBooks();
        }


        public int GetBookCodeByName(string book)
        {
            return _bookReposetory.GetBookCodeByName(book);
        }

        public Book GetBookById(int id) {
           return _bookReposetory.GetBookById(id);
        }

        public IEnumerable<Book> GetFilterList(Ecategory? category = null, bool? IsBorrowed = null)
        {
            return _bookReposetory.GetFilterList(category, IsBorrowed);
        }

        public bool AddBook(Book b)
        {
            return _bookReposetory.AddBook(b);
        }
        public bool UpdateBook(int id,Book b)
        {
            return _bookReposetory.UpdateBook(id,b);
        }
        public bool DeleteBook(int id)
        { 
           return _bookReposetory.DeleteBook(id);

        }

    }
}
