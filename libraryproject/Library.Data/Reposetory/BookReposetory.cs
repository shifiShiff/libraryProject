﻿using Library.Core.Modals;
using Library.Core.Reposetory;


namespace Library.Data.Reposetory
{
    public class BookReposetory:IBookReposetory
    {
        private readonly DataContext _Contex;


        public BookReposetory(DataContext data)
        {
            _Contex = data;
        }
        public List<Book> GetAllBooks()
        {
            return _Contex.books;
        }

        public int GetBookCodeByName(string book)
        {
            Book mybook= _Contex.books.FirstOrDefault(b => b.Name == book);
            if(mybook!=null)
                return mybook.Code;
            return -1;
        }

        public Book GetBookById(int id)
        {
            return _Contex.books.FirstOrDefault(book=> book.Code == id);

        }
       public IEnumerable<Book> GetFilterList(Ecategory? category = null, bool? IsBorrowed = null)
        {
            List<Book> BooksList = _Contex.books;
            if (category != null)
                BooksList = BooksList.Where(book => book.Category == category).ToList();

            if (IsBorrowed != null)
                BooksList = BooksList.Where(book => book.IsBorrowing == IsBorrowed).ToList();

            return BooksList;
        }

        public void AddBook(Book b)
        {
            _Contex.books.Add(b);
        }
        public void ChangeBook(int id, Book b)
        {
            var bookToUpdate = _Contex.books.FirstOrDefault(book => book.Code == id);

            if (bookToUpdate != null)
            {
                bookToUpdate.Author = b.Author;
                bookToUpdate.Name = b.Name;
                bookToUpdate.IsBorrowing = b.IsBorrowing;
                bookToUpdate.DateOfBuying = b.DateOfBuying;
                bookToUpdate.NumOfPages = b.NumOfPages;
                bookToUpdate.Category = b.Category;
            }
        }

        public void DeleteBook(int id)
        {
            _Contex.books.Remove(_Contex.books.FirstOrDefault(b => b.Code == id));
        }
    }
}