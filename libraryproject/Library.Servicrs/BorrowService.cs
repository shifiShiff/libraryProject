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
    public class BorrowService: IBorrowService
    {
        private readonly IBorrowReposetory _borrowReposetory;
        public BorrowService(IBorrowReposetory borrowReposetory)
        {
            _borrowReposetory = borrowReposetory;
        }

        public IEnumerable<Borrow> GetAllBorrows()
        {
            return _borrowReposetory.GetAllBorrows();
        }
        public IEnumerable<Borrow> GetBorrowByStatus( bool Isreturn)
        {
            return _borrowReposetory.GetBorrowByStatus(Isreturn);
        }
        public IEnumerable<Borrow> GetBorrowsByIdWithStatus(string Id,bool? Isreturn = null)
        {
            var SelectBorrows = _borrowReposetory.GetAllBorrows();
            SelectBorrows = SelectBorrows.Where(m => m.Subscriber.Id == Id).ToList();
            if (SelectBorrows != null && Isreturn != null)
                SelectBorrows = SelectBorrows.Where(m => m.IsReturned == Isreturn).ToList();
            return SelectBorrows.ToList();

        }

        public bool AddBorrow(int Code, string Id)
        {
            var s = _borrowReposetory.getSubscribeById(Id);
            var b = _borrowReposetory.getBookById(Code);

            if (s !=null && b != null)
            {
                if (b.IsBorrowing == false && s.NumOfCurrentBorrowing < 3)
                {
                    b.IsBorrowing = true;
                    s.NumOfBorrows++;
                    s.NumOfCurrentBorrowing++;

                    Borrow borrow = new Borrow();
                    borrow.BorrowBook = b;
                    borrow.Subscriber = s;
                    borrow.BorrowDate = DateTime.Now;
                    borrow.BackDate = DateTime.Now.AddDays(10);
                    borrow.IsReturned = false;
                    _borrowReposetory.AddBorrow(borrow);
                    return true;
                }
            }
            return false;
        }
        public bool UpdateBorrow(int CodeBorrow, string IdSubscribe, int BookCode)
        {

            var borrow = _borrowReposetory.getBorrowById(CodeBorrow);
            var subscribe= _borrowReposetory.getSubscribeById(IdSubscribe);
            var book = _borrowReposetory.getBookById(BookCode);
            if (borrow != null && book != null && subscribe != null)
            {
                if (subscribe.NumOfCurrentBorrowing < 3 && book.IsBorrowing == false)
                {
                    _borrowReposetory.UpdateBorrow(borrow, book, subscribe);
                    return true;
                }
            }
            return false;
        }
        public bool DeleteBorrow(int BorrowCode)
        {
            var borrow =_borrowReposetory.getBorrowById(BorrowCode);
            if (borrow != null && borrow.IsReturned == false)
            {
                _borrowReposetory.DeleteBorrow(borrow);
                return true;
            }
            return false ;
        }

    }
}
