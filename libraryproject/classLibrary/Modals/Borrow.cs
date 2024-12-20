using System.ComponentModel.DataAnnotations;

namespace Library.Core.Modals
{
    public class Borrow
    {
        //public static int CodeB = 1;

        [Key]
        public int BorrowCode { get; set; } 
        public DateTime BorrowDate { get; set; }
        public DateTime BackDate { get; set; }
        public int SubscriberSubscribeId { get; set; }
        public Subscribe Subscriber { get; set; }
        public int BorrowBookCode { get; set; }
        public Book BorrowBook { get; set; }
        public bool IsReturned { get; set; } = false;



    }
}
