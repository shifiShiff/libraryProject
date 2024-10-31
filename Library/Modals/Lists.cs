namespace Library.Modals
{
    public class Lists
    {
        public Lists()
        {
        }

        public static List<Book> books = new List<Book>() { new Book() { Name = "Dudi&Udi", Category = Ecategory.children,Author="Lion", IsBorrowing = false },
        new Book() { Name = "Shatul", Category = Ecategory.adult,Author="Sapir", IsBorrowing = false},
        new Book() { Name = "Nan", Category = Ecategory.teenage,Author="Frid", IsBorrowing = false } };

        static List<Subscribe> subscribers = new List<Subscribe>() { new Subscribe() {Id="214860728",Name="Shifi Shiff",Address="Yabrov 8",Phone="0527132865",IsActive=true },
       new Subscribe() {Id="214587925",Name="Racheli Levi",Address="R Akiva 8",Phone="05425525887",IsActive=true },
       new Subscribe() {Id="256415841",Name="Ruti Choen",Address="Desler",Phone="0586555465",IsActive=true }};


        static List<Borrow> borrows = new List<Borrow>();
    }
}
