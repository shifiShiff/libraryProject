using Library.Core.Interfaces;
using Library.Core.Modals;
using Library.Core.Services;
using Microsoft.AspNetCore.Mvc;


namespace Library.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SubscribeController : ControllerBase
    {
        //private readonly IDataInteface _Data;

        //public SubscribeController(IDataInteface context)
        //{
        //    _Data = context;
        //}

        private readonly ISubscribeService _subscribeService;

        public SubscribeController(ISubscribeService subscribe)
        {
            _subscribeService = subscribe;
        }

        // שליפת רשימת מנויים
        [HttpGet]
        public ActionResult<Subscribe> Get()
        {
            var list= _subscribeService.GetAllSubscribes();
            if(list is null)
                return NotFound("empty list");
            return Ok(list);
        }

        // שליפת פרטי מנוי ע"פ שם או ת.ז
        [HttpGet("get")]
        public ActionResult<Subscribe> Get([FromQuery] string? id = null, [FromQuery] string? name = null)
        {
            var s=_subscribeService.GetSubscribeByIdOrName(id, name);
            if (s is null)
                return NotFound("failed");
            return Ok(s);
        }

        // שליפת ת.ז ע"פ שם 
        [HttpGet("GetId")]
        public ActionResult<string> Get([FromQuery] string Name)
        {
            var id= _subscribeService.GetIdByName(Name);
            if (id == "-1")
                return NotFound(id);
            return Ok(id);

        }


        //סינון רשימת המנויים לפי פעילים /גיל/ מספר השאלות
        [HttpGet("filter")]
        public ActionResult<Subscribe> Get([FromQuery] bool? IsActive = null, [FromQuery] int? NumOfBorrows = null, [FromQuery] int? age = null)
        {
            var list=_subscribeService.GetFilterSubscribe(IsActive, NumOfBorrows, age);
            if (list is null)
                return NotFound("empty list");
            return Ok(list);
        }


        // הוספת מנוי חדש
        [HttpPost]
        public ActionResult<bool> Post([FromBody] Subscribe s)
        {
           if(_subscribeService.AddSubscribe(s))
                return Ok(true);
            return NotFound(false);
        }


        // שינוי פרטי מנוי ע"פ ת.ז
        [HttpPut("{id}")]
        public ActionResult<bool> Put(string id, [FromBody] Subscribe s)
        {
            if(_subscribeService.UpdateSubscribe(id, s))
                return Ok(true) ;
            return NotFound(false);
        }

        // מחיקת מנוי לפי ת.ז
        [HttpDelete("{id}")]
        public ActionResult<bool> Delete(string id)
        {
            if(_subscribeService.DeleteSubscribe(id))
                return Ok(true);
            return NotFound(false);

        }
    }
}
