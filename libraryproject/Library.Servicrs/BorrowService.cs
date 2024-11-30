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
            return _borrowReposetory.GetBorrowsByIdWithStatus(Id,Isreturn);
        }

        public void AddBorrow(int Code, string Id)
        {
            _borrowReposetory.AddBorrow(Code, Id);
        }
        public void UpdateBorrow(int CodeBorrow, string IdSubscribe, int BookCode)
        {
            _borrowReposetory.UpdateBorrow(CodeBorrow,IdSubscribe,BookCode);
        }
        public void DeleteBorrow(int BorrowCode)
        {
            _borrowReposetory.DeleteBorrow(BorrowCode);
        }

    }
}
