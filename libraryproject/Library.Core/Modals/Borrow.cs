namespace Library.Core.Modals
{
    public class Borrow
    {
        public static int Code = 1;
        public int BorrowCode { get; } = Code++;
        public DateTime BorrowDate { get; set; }
        public DateTime BackDate { get; set; }
        public Subscribe Subscriber { get; set; }
        public Book BorrowBook { get; set; }
        public bool IsReturned { get; set; } = false;



    }
}
