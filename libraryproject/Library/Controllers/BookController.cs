using Library.Core.Services;
using Library.Core.Modals;
using Library.Core.Modals.ModalsDTO;
using Microsoft.AspNetCore.Mvc;
using Library.Core.Interfaces;
using Library.Servicrs;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Library.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookController : ControllerBase
    {

        //private readonly IDataInteface _Data;



        private readonly IBookService _bookService;

        public BookController(IBookService bookService)
        {
            _bookService = bookService;
        }


        //public BookController(IDataInteface context)
        //{
        //    _Data = context;
        //}


        //שליפת כל רשימת הספרים
        [HttpGet]
        public ActionResult<Book> Get()
        {
            var list = _bookService.GetAllBooks();
            if(list is null)
                return NotFound("empty list");
            return Ok(list);
        }


        //שליפת קוד ספר ע"פ שם ספר (מחליף את סריקת הברקוד
        [HttpGet("BookName/{BookName}")]
        public ActionResult Get(string BookName)
        {
            var bookTmp = _bookService.GetBookCodeByName(BookName);
            if(bookTmp==-1)
               return NotFound(-1);
           return Ok(bookTmp);
        }


        //שליפת פרטי ספר ע"פ קוד
        [HttpGet("{bookCode}")]
        public ActionResult Get(int bookCode)
        {
            var bookTmp = _bookService.GetBookById(bookCode);
            if (bookTmp is null)
                return NotFound("No such a book");
            return Ok(bookTmp);
        }


        //סינון רשימת ספרים לפי: קטגוריה/ לפי האם מושאל
        [HttpGet("filter")]
        public ActionResult<Book> Get([FromQuery] Ecategory? category = null, [FromQuery] bool? IsBorrowed = null)
        {
            var b = _bookService.GetFilterList(category, IsBorrowed);
            if (b != null)
                return Ok(b);
            return NotFound("Empty list");
        }

        // הוספת ספר חדש לרשימת הספרים
        [HttpPost]
        public ActionResult<bool> Post([FromBody] BookPost b)
        {

            if(_bookService.AddBook(b))
                return Ok(true);
            return Ok(false);
        }



        // עדכון ספר ע"פ קוד לפי ספר אחר שמתקבל
        [HttpPut()]
        public ActionResult<bool> Put(int id, [FromBody] BookPost b)
        {
            if(_bookService.UpdateBook(id, b))
                return Ok(true);
            return NotFound(false);
           
        }


        // מחיקת ספר ע"פ קוד
        [HttpDelete("{id}")]
        public ActionResult<bool> Delete(int id)
        {
            if(_bookService.DeleteBook(id))
                return Ok(true);
            return NotFound(false);
        }
    }
}
