using Library.Modals;
using Microsoft.AspNetCore.Mvc;
using Library.Helper;


namespace Library.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BorrowController : ControllerBase
    {
        // שליפת רשימת השאלות
        [HttpGet]
        public IEnumerable<Borrow> Get()
        {
            return Data.borrows;
        }

        // שליפת רשימת השאלות שלא הוחזרו
        [HttpGet("select")]
        public Borrow Get([FromQuery] bool Isreturnl)
        {
            return Data.borrows.FirstOrDefault(b => b.IsReturned==false);
        }

        //שליפת השאלות לפי מנוי עם אופציה לשלוח האם השאלות שהוחזרו או לא
        [HttpGet("{Id}")]
        public IEnumerable<Borrow> Get(string Id, [FromQuery] bool? Isreturn = null)
        {
            List<Borrow> SelectBorrow = Data.borrows;
            SelectBorrow = SelectBorrow.Where(m => m.Subscriber.Id == Id).ToList();
            if (Isreturn != null)
                SelectBorrow = SelectBorrow.Where(m => m.IsReturned == Isreturn).ToList();
            return SelectBorrow;
        }


        //השאלת ספר לפי קוד ספר ות.ז של לקוח
        [HttpPost("{Code},{Id}")]
        public void Post(int Code, string Id)
        {

            if (Data.subscribers.FirstOrDefault(o => o.Id == Id) != null
                && Data.books.FirstOrDefault(o => o.Code == Code).IsBorrowing == false)
            {
                if (Data.subscribers.FirstOrDefault(o => o.Id == Id).NumOfCurrentBorrowing < 3)
                {
                    Data.books.FirstOrDefault(o => o.Code == Code).IsBorrowing = true;
                    Data.subscribers.FirstOrDefault(o => o.Id == Id).NumOfBorrows++;
                    Data.subscribers.FirstOrDefault(o => o.Id == Id).NumOfCurrentBorrowing++;

                    Borrow borrow = new Borrow();
                    borrow.BorrowBook = Data.GetBookFromListByCode(Code);
                    borrow.Subscriber = Data.GetSubscribeFromListById(Id);
                    borrow.BorrowDate = DateTime.Now;
                    borrow.BackDate = DateTime.Now.AddDays(10);
                    borrow.IsReturned = false;
                    Data.borrows.Add(borrow);
                }
            }
        }

        
        //שינוי פרטי השאלה ע"פ קוד השאלה
        [HttpPut("{Code}")]
        public void Put(int Code, [FromBody] Borrow b)
        {
            //בדיקה האם יש כזה קוד השאלה
            if (Data.borrows.FirstOrDefault(o => o.BorrowCode == Code) != null)
            {
                //שינוי ספר ושחרור הספר הקודם
                Data.books.FirstOrDefault(o => o.Code == b.BorrowBook.Code).IsBorrowing = true;
                Data.borrows.FirstOrDefault(o => o.BorrowCode == Code).BorrowBook.IsBorrowing=false;

                //שינוי מנוי ושחרור המנוי הקודם
                Data.subscribers.FirstOrDefault(o => o.Id == b.Subscriber.Id).NumOfBorrows++;
                Data.subscribers.FirstOrDefault(o => o.Id == b.Subscriber.Id).NumOfCurrentBorrowing++;

                Data.borrows.FirstOrDefault(o => o.BorrowCode == Code).Subscriber.NumOfBorrows--;
                Data.borrows.FirstOrDefault(o => o.BorrowCode == Code).Subscriber.NumOfCurrentBorrowing--;


                Borrow BorrowForUpdate = Data.borrows.FirstOrDefault(o => o.BorrowCode == Code);
                BorrowForUpdate.Subscriber = b.Subscriber;
                BorrowForUpdate.BorrowBook = b.BorrowBook;
                BorrowForUpdate.BorrowDate = b.BorrowDate;
                BorrowForUpdate.BackDate = b.BackDate;
                BorrowForUpdate.IsReturned = b.IsReturned;


            }
    

        }

        // החזרת השאלה ע"פ קוד השאלה
        [HttpDelete("{BorrowCode}")]
        public void Delete(int BorrowCode)
        {
            if (Data.borrows.FirstOrDefault(o => o.BorrowCode == BorrowCode && o.IsReturned == false) != null)
            {
                Data.borrows.FirstOrDefault(o => o.BorrowCode == BorrowCode).BorrowBook.IsBorrowing = false;
                Data.borrows.FirstOrDefault(o => o.BorrowCode == BorrowCode).Subscriber.NumOfCurrentBorrowing--;
                Data.borrows.FirstOrDefault(o => o.BorrowCode == BorrowCode).IsReturned = true;
            }

        }
    }
}
