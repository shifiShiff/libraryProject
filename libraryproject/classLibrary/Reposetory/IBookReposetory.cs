using Library.Core.Modals;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Core.Reposetory
{
    public interface IBookReposetory
    {
        List<Book> GetAllBooks();

        int GetBookCodeByName(string book);
        Book GetBookById(int id);
        IEnumerable<Book> GetFilterList(Ecategory? category = null, bool? IsBorrowed = null);
        void AddBook(Book b);
        void ChangeBook(int id, Book b);
        void DeleteBook(int id);
    }
}
