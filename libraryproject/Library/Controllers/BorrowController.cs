using Microsoft.AspNetCore.Mvc;
using Library.Core.Services;
using Library.Core.Interfaces;
using Library.Core.Modals;


namespace Library.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BorrowController : ControllerBase
    {
        //private readonly IDataInteface _Data;

        //public BorrowController(IDataInteface context)
        //{
        //    _Data = context;
        //}


        private readonly IBorrowService _borrowService;
        public BorrowController(IBorrowService borrowService)
        {
            _borrowService = borrowService;
        }

        // שליפת רשימת השאלות
        [HttpGet]
        public IEnumerable<Borrow> Get()
        {
            return _borrowService.GetAllBorrows();
        }

        // שליפת רשימת השאלות שלא הוחזרו
        [HttpGet("select")]
        public IEnumerable<Borrow> Get([FromQuery] bool Isreturn)
        {
           return _borrowService.GetBorrowByStatus(Isreturn);
        }

        //שליפת השאלות לפי מנוי עם אופציה לשלוח האם השאלות שהוחזרו או לא
        [HttpGet("{Id}")]
        public IEnumerable<Borrow> Get(string Id, [FromQuery] bool? Isreturn = null)
        {
            return _borrowService.GetBorrowsByIdWithStatus(Id, Isreturn);
        }


        //השאלת ספר לפי קוד ספר ות.ז של לקוח
        [HttpPost("{Code},{Id}")]
        public void Post(int Code, string Id)
        {

            _borrowService.AddBorrow(Code, Id);
        }


        //שינוי פרטי השאלה ע"פ קוד השאלה
        [HttpPut]
        public void Put(int CodeBorrow, string IdSubscribe, int BookCode)
        {
           _borrowService.UpdateBorrow(CodeBorrow, IdSubscribe, BookCode);    

        }

        // החזרת השאלה ע"פ קוד השאלה
        [HttpDelete("{BorrowCode}")]
        public void Delete(int BorrowCode)
        {
           _borrowService.DeleteBorrow(BorrowCode);

        }
    }
}
