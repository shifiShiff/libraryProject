using Library.Core.Modals;
using Library.Core.Reposetory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Data.Reposetory
{
    public class BorrowReposetory: IBorrowReposetory
    {
        private readonly DataContext _context;
        public BorrowReposetory(DataContext context)
        {
            _context = context;
        }
        public IEnumerable<Borrow> GetAllBorrows()
        {
            return _context.borrows;
        }
        public IEnumerable<Borrow> GetBorrowByStatus(bool Isreturn)
        {
            return _context.borrows.Where(b => b.IsReturned == Isreturn).ToList();
        }
        public IEnumerable<Borrow> GetBorrowsByIdWithStatus(string Id, bool? Isreturn = null)
        {
            List<Borrow> SelectBorrows = _context.borrows;
            SelectBorrows = SelectBorrows.Where(m => m.Subscriber.Id == Id).ToList();
            if (Isreturn != null)
                SelectBorrows = SelectBorrows.Where(m => m.IsReturned == Isreturn).ToList();
            return SelectBorrows;
        }

        public void AddBorrow(int Code, string Id)
        {
            if (_context.subscribers.FirstOrDefault(o => o.Id == Id) != null
                && _context.books.FirstOrDefault(o => o.Code == Code)!= null
                && _context.books.FirstOrDefault(o => o.Code == Code).IsBorrowing == false)
            {
                if (_context.GetSubscribeFromListById(Id).NumOfCurrentBorrowing < 3)
                {
                    _context.GetBookFromListByCode(Code).IsBorrowing = true;
                    _context.GetSubscribeFromListById(Id).NumOfBorrows++;
                    _context.GetSubscribeFromListById(Id).NumOfCurrentBorrowing++;

                    Borrow borrow = new Borrow();
                    borrow.BorrowBook = _context.GetBookFromListByCode(Code);
                    borrow.Subscriber = _context.GetSubscribeFromListById(Id);
                    borrow.BorrowDate = DateTime.Now;
                    borrow.BackDate = DateTime.Now.AddDays(10);
                    borrow.IsReturned = false;
                    _context.borrows.Add(borrow);
                }
            }
        }

        public void UpdateBorrow(int CodeBorrow,string IdSubscribe, int BookCode)
        {

            Borrow MyBorrow = _context.borrows.FirstOrDefault(o => o.BorrowCode == CodeBorrow);
            Book MyBook =_context.books.FirstOrDefault(b=>b.Code==BookCode);
            Subscribe MySubscribe= _context.subscribers.FirstOrDefault(s=>s.Id==IdSubscribe);

            if (MyBorrow!= null && MyBook!=null && MySubscribe!=null)
            {
                if (MySubscribe.NumOfCurrentBorrowing < 3 && MyBook.IsBorrowing==false)
                {
                    MyBorrow.Subscriber.NumOfCurrentBorrowing--;
                    MyBorrow.Subscriber.NumOfBorrows--;
                    MySubscribe.NumOfCurrentBorrowing++;
                    MySubscribe.NumOfBorrows++;

                    MyBorrow.Subscriber = MySubscribe;
                    MyBorrow.BorrowBook = MyBook;
                }
            }


        }

        public void DeleteBorrow(int BorrowCode)
        {
            Borrow MyBorrow= _context.borrows.FirstOrDefault(b=>b.BorrowCode==BorrowCode);
            if (MyBorrow != null && MyBorrow.IsReturned ==false)
            {
                MyBorrow.BorrowBook.IsBorrowing = false;
                MyBorrow.Subscriber.NumOfCurrentBorrowing--;
                MyBorrow.IsReturned = true;
            }
        }
    }
}
