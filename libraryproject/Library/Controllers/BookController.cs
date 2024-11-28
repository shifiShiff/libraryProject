using Library.Core.Services;
using Library.Core.Modals;
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
        public IEnumerable<Book> Get()
        {
            return _bookService.GetAllBooks();
        }


        //שליפת קוד ספר ע"פ שם ספר (מחליף את סריקת הברקוד
        [HttpGet("BookName/{BookName}")]
        public int Get(string BookName)
        {
           return _bookService.GetBookCodeByName(BookName);
        }


        //שליפת פרטי ספר ע"פ קוד
        [HttpGet("{bookCode}")]
        public ActionResult Get(int bookCode)
        {
            var bookTmp = _bookService.GetBookById(bookCode);
            if (bookTmp is null)
                return NotFound();
            return Ok(bookTmp);
        }


        //סינון רשימת ספרים לפי: קטגוריה/ לפי האם מושאל
        [HttpGet("filter")]
        public IEnumerable<Book> Get([FromQuery] Ecategory? category = null, [FromQuery] bool? IsBorrowed = null)
        {
            return _bookService.GetFilterList(category, IsBorrowed);
        }

        // הוספת ספר חדש לרשימת הספרים
        [HttpPost]
        public void Post([FromBody] Book b)
        {
            _bookService.AddBook(b);
        }



        // עדכון ספר ע"פ קוד לפי ספר אחר שמתקבל
        [HttpPut()]
        public void Put(int id, [FromBody] Book b)
        {

            _bookService.ChangeBook(id, b);
        }


        // מחיקת ספר ע"פ קוד
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            _bookService.DeleteBook(id);
        }
    }
}
