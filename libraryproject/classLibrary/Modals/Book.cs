namespace Library.Core.Modals
{
    public enum Ecategory
    {
        children,
        teenage,
        adult
    };
    public class Book
    {
        public static int codeBook = 1;

        public int Code { get; } = codeBook++;
        public string Name { get; set; }
        public Ecategory Category { get; set; }
        public string Author { get; set; }
        public bool IsBorrowing { get; set; } = false;
        public DateTime DateOfBuying { get; set; }
        public int NumOfPages { get; set; }


        

    }
}
