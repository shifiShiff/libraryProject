using Library.Core.Modals;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Core.Reposetory
{
    public interface IBorrowReposetory
    {
        IEnumerable<Borrow> GetAllBorrows();
        IEnumerable<Borrow> GetBorrowByStatus(bool Isreturn);
        //IEnumerable<Borrow> GetBorrowsByIdWithStatus(string Id, bool? Isreturn = null);
        Subscribe getSubscribeById(string id);
        Book getBookById(int Code);
        Borrow getBorrowById(int Code);
        void AddBorrow(Borrow borrow);
        void UpdateBorrow(Borrow MyBorrow, Book MyBook, Subscribe MySubscribe);
        void DeleteBorrow(Borrow MyBorrow);
    }
}
