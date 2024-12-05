using Library.Core.Interfaces;
using Library.Core.Modals;
using Microsoft.EntityFrameworkCore;

namespace Library.Data
{
    public class DataContext: DbContext
    {

        public DbSet<Book> books { get; set; } 
        public DbSet<Subscribe> subscribers { get; set; }
        public DbSet<Borrow> borrows { get; set; }

        //= new List<Book>();{new Book() { Name = "Dudi&Udi", Category = Ecategory.children,Author="Lion", IsBorrowing = true,DateOfBuying=new DateTime(2024,9,23),NumOfPages=50 },
        //new Book() { Name = "Shatul", Category = Ecategory.adult,Author="Sapir", IsBorrowing = false,DateOfBuying=new DateTime(2024,5,12),NumOfPages=600},
        //new Book() {  Name = "Nan", Category = Ecategory.teenage,Author="Frid", IsBorrowing = false,DateOfBuying=new DateTime(2022,1,3),NumOfPages=250 } };



        // = new List<Subscribe>();{ new Subscribe() {Id="214860728",Name="Shifi Shiff",Address="Yabrov 8",Phone="0527132865",IsActive=true,Age=8,NumOfBorrows=7 },
        //new Subscribe() {Id="214587925",Name="Racheli Levi",Address="R Akiva 8",Phone="05425525887",IsActive=true,Age=17,NumOfBorrows=20 },
        //new Subscribe() {Id="256415841",Name="Ruti Choen",Address="Desler",Phone="0586555465",IsActive=true,Age=12,NumOfBorrows=15 }};




        // = new List<Borrow>(); {new Borrow(){BorrowDate=DateTime.Now,BackDate=DateTime.Now.AddDays(10),
        //    BorrowBook=new Book(){ Name = "Nan", Category = Ecategory.teenage,Author="Frid", IsBorrowing = true,DateOfBuying=new DateTime(2022,1,3),NumOfPages=250 }
        //    ,Subscriber=new Subscribe() {Id="214860728",Name="Shifi Shiff",Address="Yabrov 8",Phone="0527132865",IsActive=true,Age=8,NumOfBorrows=7 }} ,};

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=(localdb)\MSSQLLocalDB;Database=sample_shifi_shiff");
        }


        //public Book GetBookFromListByCode(int code)
        //{
        //    return books.FirstOrDefault(b => b.Code == code);
        //}
        //public Subscribe GetSubscribeFromListById(string id)
        //{
        //    return subscribers.FirstOrDefault(s => s.Id == id);
        //}
        //public Subscribe GetSubscribeFromListByName(string name)
        //{
        //    return subscribers.FirstOrDefault(s => s.Name == name);
        //}
    }
}
