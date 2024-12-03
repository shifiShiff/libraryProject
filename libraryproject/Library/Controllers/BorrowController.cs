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
        public ActionResult<Borrow> Get()
        {
            var list= _borrowService.GetAllBorrows();
            if (list is null)
                return NotFound("empty list");
            return Ok(list);
        }

        // שליפת רשימת השאלות שלא הוחזרו
        [HttpGet("select")]
        public ActionResult<Borrow> Get([FromQuery] bool Isreturn)
        {
            var list=_borrowService.GetBorrowByStatus(Isreturn);
            if (list is null)
                return NotFound("empty list");
            return Ok(list);
        }

        //שליפת השאלות לפי מנוי עם אופציה לשלוח האם השאלות שהוחזרו או לא
        [HttpGet("{Id}")]
        public ActionResult<Borrow> Get(string Id, [FromQuery] bool? Isreturn = null)
        {
            var list=_borrowService.GetBorrowsByIdWithStatus(Id, Isreturn);
            if (list is null)
                return NotFound("empty list");
            return Ok(list);
        }


        //השאלת ספר לפי קוד ספר ות.ז של לקוח
        [HttpPost("{Code},{Id}")]
        public ActionResult<bool> Post(int Code, string Id)
        {

            if(_borrowService.AddBorrow(Code, Id))
                return Ok(true);
            return NotFound("failed");
        }


        //שינוי פרטי השאלה ע"פ קוד השאלה
        [HttpPut]
        public ActionResult<bool> Put(int CodeBorrow, string IdSubscribe, int BookCode)
        {
           if(_borrowService.UpdateBorrow(CodeBorrow, IdSubscribe, BookCode))
                return Ok(true);
            return NotFound("failed");

        }

        // החזרת השאלה ע"פ קוד השאלה
        [HttpDelete("{BorrowCode}")]
        public ActionResult<bool> Delete(int BorrowCode)
        {
           if(_borrowService.DeleteBorrow(BorrowCode))
                return Ok(true);
            return NotFound("failed");

        }
    }
}
