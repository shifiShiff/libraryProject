using Library.Core.Modals;
using Library.Core.Modals.ModalsDTO;
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
        bool AddBook(BookPost b);
        bool UpdateBook(int id, BookPost b);
        bool DeleteBook(int id);
    }
}
