using AutoMapper;
using Library.Core.Modals;
using Library.Core.Modals.ModalsDTO;
using Library.Core.Reposetory;
using Library.Core.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Servicrs
{
    public class BookService : IBookService
    {
        private readonly IBookReposetory _bookReposetory;
        private readonly IMapper _mappre;

        public BookService(IBookReposetory bookreposetory, IMapper mapper)
        {
            _bookReposetory = bookreposetory;
            _mappre = mapper;
        }

        public List<Book> GetAllBooks()
        {
            return _bookReposetory.GetAllBooks();
        }


        public int GetBookCodeByName(string book)
        {
            var mybook = _bookReposetory.GetBookCodeByName(book);
            if (mybook != null)
                return mybook.Code;
            return -1;
        }

        public Book GetBookById(int id)
        {

            var mybook = _bookReposetory.GetBookById(id);
            if (mybook != null)
                return mybook;
            return null;
        }

        public IEnumerable<Book> GetFilterList(Ecategory? category = null, bool? IsBorrowed = null)
        {
            var BooksList = _bookReposetory.GetAllBooks();
            if (category != null)
                BooksList = BooksList.Where(book => book.Category == category).ToList();

            if (IsBorrowed != null)
                BooksList = BooksList.Where(book => book.IsBorrowing == IsBorrowed).ToList();

            return BooksList;

        }

        public bool AddBook(BookPost b)
        {
            var tmp = _mappre.Map<Book>(b);
            return _bookReposetory.AddBook(tmp);
        }
        public bool UpdateBook(int id, BookPost b)
        {
            var tmp = _mappre.Map<Book>(b);
            return _bookReposetory.UpdateBook(id, tmp);
        }
        public bool DeleteBook(int id)
        {
            return _bookReposetory.DeleteBook(id);

        }

    }
}
