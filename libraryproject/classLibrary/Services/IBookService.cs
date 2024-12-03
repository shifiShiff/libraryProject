using Library.Core.Modals;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Core.Services
{
    public interface IBookService
    {
         List<Book> GetAllBooks();

        int GetBookCodeByName(string book);
        Book GetBookById(int id);
        IEnumerable<Book> GetFilterList(Ecategory? category = null, bool? IsBorrowed = null);
        bool AddBook(Book b);
        bool UpdateBook(int id, Book b);
        bool DeleteBook(int id);
    }
}
