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
        IEnumerable<Borrow> GetBorrowsByIdWithStatus(string Id, bool? Isreturn = null);
        void AddBorrow(int Code, string Id);
        void UpdateBorrow(int Code, Borrow b);
        void DeleteBorrow(int BorrowCode);
    }
}
