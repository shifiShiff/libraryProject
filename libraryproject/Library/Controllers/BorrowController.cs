using Library.Modals;
using Microsoft.AspNetCore.Mvc;
using Library.Services;
using classLibraryCore.Interfaces;


namespace Library.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BorrowController : ControllerBase
    {
        private readonly IDataInteface _Data;

        public BorrowController(IDataInteface context)
        {
            _Data = context;
        }

        // שליפת רשימת השאלות
        [HttpGet]
        public IEnumerable<Borrow> Get()
        {
            return _Data.borrows;
        }

        // שליפת רשימת השאלות שלא הוחזרו
        [HttpGet("select")]
        public Borrow Get([FromQuery] bool Isreturnl)
        {
            return _Data.borrows.FirstOrDefault(b => b.IsReturned==false);
        }

        //שליפת השאלות לפי מנוי עם אופציה לשלוח האם השאלות שהוחזרו או לא
        [HttpGet("{Id}")]
        public IEnumerable<Borrow> Get(string Id, [FromQuery] bool? Isreturn = null)
        {
            List<Borrow> SelectBorrow = _Data.borrows;
            SelectBorrow = SelectBorrow.Where(m => m.Subscriber.Id == Id).ToList();
            if (Isreturn != null)
                SelectBorrow = SelectBorrow.Where(m => m.IsReturned == Isreturn).ToList();
            return SelectBorrow;
        }


        //השאלת ספר לפי קוד ספר ות.ז של לקוח
        [HttpPost("{Code},{Id}")]
        public void Post(int Code, string Id)
        {

            if (_Data.subscribers.FirstOrDefault(o => o.Id == Id) != null
                && _Data.books.FirstOrDefault(o => o.Code == Code).IsBorrowing == false)
            {
                if (_Data.subscribers.FirstOrDefault(o => o.Id == Id).NumOfCurrentBorrowing < 3)
                {
                    _Data.books.FirstOrDefault(o => o.Code == Code).IsBorrowing = true;
                    _Data.subscribers.FirstOrDefault(o => o.Id == Id).NumOfBorrows++;
                    _Data.subscribers.FirstOrDefault(o => o.Id == Id).NumOfCurrentBorrowing++;

                    Borrow borrow = new Borrow();
                    borrow.BorrowBook = _Data.GetBookFromListByCode(Code);
                    borrow.Subscriber = _Data.GetSubscribeFromListById(Id);
                    borrow.BorrowDate = DateTime.Now;
                    borrow.BackDate = DateTime.Now.AddDays(10);
                    borrow.IsReturned = false;
                    _Data.borrows.Add(borrow);
                }
            }
        }

        
        //שינוי פרטי השאלה ע"פ קוד השאלה
        [HttpPut("{Code}")]
        public void Put(int Code, [FromBody] Borrow b)
        {
            //בדיקה האם יש כזה קוד השאלה
            if (_Data.borrows.FirstOrDefault(o => o.BorrowCode == Code) != null)
            {
                //שינוי ספר ושחרור הספר הקודם
                _Data.books.FirstOrDefault(o => o.Code == b.BorrowBook.Code).IsBorrowing = true;
                _Data.borrows.FirstOrDefault(o => o.BorrowCode == Code).BorrowBook.IsBorrowing=false;

                //שינוי מנוי ושחרור המנוי הקודם
                _Data.subscribers.FirstOrDefault(o => o.Id == b.Subscriber.Id).NumOfBorrows++;
                _Data.subscribers.FirstOrDefault(o => o.Id == b.Subscriber.Id).NumOfCurrentBorrowing++;

                _Data.borrows.FirstOrDefault(o => o.BorrowCode == Code).Subscriber.NumOfBorrows--;
                _Data.borrows.FirstOrDefault(o => o.BorrowCode == Code).Subscriber.NumOfCurrentBorrowing--;


                Borrow BorrowForUpdate = _Data.borrows.FirstOrDefault(o => o.BorrowCode == Code);
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
            if (_Data.borrows.FirstOrDefault(o => o.BorrowCode == BorrowCode && o.IsReturned == false) != null)
            {
                _Data.borrows.FirstOrDefault(o => o.BorrowCode == BorrowCode).BorrowBook.IsBorrowing = false;
                _Data.borrows.FirstOrDefault(o => o.BorrowCode == BorrowCode).Subscriber.NumOfCurrentBorrowing--;
                _Data.borrows.FirstOrDefault(o => o.BorrowCode == BorrowCode).IsReturned = true;
            }

        }
    }
}
