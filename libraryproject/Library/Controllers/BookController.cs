using Library.Helper;
using Library.Modals;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Library.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookController : ControllerBase
    {


        public BookController()
        {
            
        }
       
        //שליפת כל רשימת הספרים
        [HttpGet]
        public IEnumerable<Book> Get()
        {
            return Data.books;
        }


        //שליפת קוד ספר ע"פ שם ספר (מחליף את סריקת הברקוד
        [HttpGet("BookName/{BookName}")]
        public int Get(string BookName)
        {        
            return Data.books.FirstOrDefault(b => b.Name == BookName).Code;
        }


        //שליפת פרטי ספר ע"פ קוד
        [HttpGet("{bookCode}")]
        public ActionResult Get(int bookCode)
        {
            var bookTmp= Data.GetBookFromListByCode(bookCode);
            if (bookTmp is null)
                return NotFound();
            return Ok(bookTmp);
        }


        //סינון רשימת ספרים לפי: קטגוריה/ לפי האם מושאל
        [HttpGet("filter")]
        public IEnumerable<Book> Get([FromQuery] Ecategory? category=null,  [FromQuery] bool? IsBorrowed = null)
        {
            List<Book> BooksList = Data.books;
            if (category != null)
                BooksList = BooksList.Where(book => book.Category == category).ToList();
            
            if (IsBorrowed != null)
                BooksList = BooksList.Where(book => book.IsBorrowing == IsBorrowed).ToList();

            return BooksList;


        }

        // הוספת ספר חדש לרשימת הספרים
        [HttpPost]
        public void Post([FromBody]Book b)
        {
            Data.books.Add(b);
        }



        // עדכון ספר ע"פ קוד לפי ספר אחר שמתקבל
        [HttpPut()]
        public void Put(int id,[FromBody] Book b)
        {

            var bookToUpdate = Data.books.FirstOrDefault(book => book.Code == id);

            if (bookToUpdate != null)
            {
                bookToUpdate.Author = b.Author;
                bookToUpdate.Name = b.Name;
                bookToUpdate.IsBorrowing = b.IsBorrowing;
                bookToUpdate.DateOfBuying = b.DateOfBuying;
                bookToUpdate.NumOfPages = b.NumOfPages;
                bookToUpdate.Category = b.Category;
            }
        }


        // מחיקת ספר ע"פ קוד
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            Data.books.Remove(Data.books.FirstOrDefault(b=>b.Code==id));
        }
    }
}
