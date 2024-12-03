using Library.Core.Modals;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Core.Services
{
    public interface IBorrowService
    {
        IEnumerable<Borrow> GetAllBorrows();
        IEnumerable<Borrow> GetBorrowByStatus(bool Isreturn);
        IEnumerable<Borrow> GetBorrowsByIdWithStatus(string Id, bool? Isreturn = null);
        bool AddBorrow(int Code, string Id);
        bool UpdateBorrow(int CodeBorrow, string IdSubscribe, int BookCode);
        bool DeleteBorrow(int BorrowCode);
    }
}
