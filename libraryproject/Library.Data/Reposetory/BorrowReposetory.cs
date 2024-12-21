using Library.Core.Modals;
using Library.Core.Reposetory;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Data.Reposetory
{
    public class BorrowReposetory : IBorrowReposetory
    {
        private readonly DataContext _context;
        public BorrowReposetory(DataContext context)
        {
            _context = context;
        }
        public IEnumerable<Borrow> GetAllBorrows()
        {
            return _context.borrows.Include(u=> u.BorrowBook).Include(a=> a.Subscriber).ToList();
        }
        public IEnumerable<Borrow> GetBorrowByStatus(bool Isreturn)
        {
            return _context.borrows.Where(b => b.IsReturned == Isreturn).ToList();
        }
        //public IEnumerable<Borrow> GetBorrowsByIdWithStatus(string Id, bool? Isreturn = null)
        //{
        //    return  _context.borrows.ToList() ;

        //}
        public Subscribe getSubscribeById(string id)
        {
            return _context.subscribers.FirstOrDefault(o => o.Id== id);
        }
        public Subscribe getSubscribeById(int id)
        {
            return _context.subscribers.FirstOrDefault(o => o.SubscribeId == id);
        }
        public Book getBookById(int Code)
        {
            return _context.books.FirstOrDefault(o => o.Code == Code);
        }
        public Borrow getBorrowById(int Code)
        {
            return _context.borrows.FirstOrDefault(o => o.BorrowCode == Code);
        }
        public void AddBorrow(Borrow borrow)
        {
            //if (_context.subscribers.FirstOrDefault(o => o.Id == Id) != null
            //    && _context.books.FirstOrDefault(o => o.Code == Code) != null)
            //{
            //    if (_context.books.FirstOrDefault(o => o.Code == Code).IsBorrowing == false)
            //    {
            //        if (_context.subscribers.FirstOrDefault(s => s.Name == Id).NumOfCurrentBorrowing < 3)
            //        {
            //            _context.books.FirstOrDefault(b => b.Code == Code).IsBorrowing = true;
            //            _context.subscribers.FirstOrDefault(s => s.Name == Id).NumOfBorrows++;
            //            _context.subscribers.FirstOrDefault(s => s.Name == Id).NumOfCurrentBorrowing++;

            //            Borrow borrow = new Borrow();
            //            borrow.BorrowBook = _context.books.FirstOrDefault(b => b.Code == Code);
            //            borrow.Subscriber = _context.subscribers.FirstOrDefault(s => s.Name == Id);
            //            borrow.BorrowDate = DateTime.Now;
            //            borrow.BackDate = DateTime.Now.AddDays(10);
            //            borrow.IsReturned = false;
            //            _context.borrows.Add(borrow);
            //            return true;
            //        }
            //    }
            //}
            //return false;


            _context.borrows.Add(borrow);
            _context.SaveChanges();


        }

        public void UpdateBorrow(Borrow MyBorrow, Book MyBook, Subscribe MySubscribe)
        {
            //MyBorrow.Subscriber.NumOfCurrentBorrowing--;
            //MyBorrow.Subscriber.NumOfBorrows--;
            //MySubscribe.NumOfCurrentBorrowing++;
            //MySubscribe.NumOfBorrows++;

            MyBorrow.Subscriber = MySubscribe;
            MyBorrow.BorrowBook = MyBook;
            _context.SaveChanges();

        }

        public void DeleteBorrow(Borrow MyBorrow, Book book, Subscribe subscribe)
        {

            //MyBorrow.BorrowBook.IsBorrowing = false;
            book.IsBorrowing = false;
            //MyBorrow.Subscriber.NumOfCurrentBorrowing--;
            subscribe.NumOfCurrentBorrowing--;
            MyBorrow.IsReturned = true;
            _context.SaveChanges();

        }
    }
}
