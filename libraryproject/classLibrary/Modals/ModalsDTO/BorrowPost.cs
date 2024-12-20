using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Core.Modals.ModalsDTO
{
    internal class BorrowPost
    {
        public DateTime BorrowDate { get; set; }
        //public DateTime BackDate { get; set; }
        //public  int IdSubscribe { get; set; }
        public Subscribe Subscriber { get; set; }
        //public int IdBook { get; set; }
        public Book BorrowBook { get; set; }

    }
}
