using Library.Core.Interfaces;
using Library.Core.Modals;


namespace Library.Core.Interfaces
{
    public class FakeData : IDataInteface
    {

        public List<Book> books { get; set; } = new List<Book>() {
        new Book() { Name = "Dudi&Udi", Category = Ecategory.children,Author="Lion", IsBorrowing = false,DateOfBuying=new DateTime(2024,9,23),NumOfPages=50 },
        new Book() { Name = "Shatul", Category = Ecategory.adult,Author="Sapir", IsBorrowing = false,DateOfBuying=new DateTime(2024,5,12),NumOfPages=600},
        new Book() { Name = "Nan", Category = Ecategory.teenage,Author="Frid", IsBorrowing = false,DateOfBuying=new DateTime(2022,1,3),NumOfPages=250 } };


        public List<Subscribe> subscribers { get; set; } = new List<Subscribe>() { new Subscribe() {Id="214860728",Name="Shifi Shiff",Address="Yabrov 8",Phone="0527132865",IsActive=true,Age=8,NumOfBorrows=7 },
       new Subscribe() {Id="214587925",Name="Racheli Levi",Address="R Akiva 8",Phone="05425525887",IsActive=true,Age=17,NumOfBorrows=20 },
       new Subscribe() {Id="256415841",Name="Ruti Choen",Address="Desler",Phone="0586555465",IsActive=true,Age=12,NumOfBorrows=15 }};



        public List<Borrow> borrows { get; set; } = new List<Borrow>();
        List<Book> IDataInteface.books { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public Book GetBookFromListByCode(int code)
        {
            return books.FirstOrDefault(b => b.Code == code);
        }
        public Subscribe GetSubscribeFromListById(string id)
        {
            return subscribers.FirstOrDefault(s => s.Id == id);
        }
        public Subscribe GetSubscribeFromListByName(string name)
        {
            return subscribers.FirstOrDefault(s => s.Name == name);
        }

        Book IDataInteface.GetBookFromListByCode(int code)
        {
            throw new NotImplementedException();
        }
    }
}
