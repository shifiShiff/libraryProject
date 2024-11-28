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
        public IEnumerable<Subscribe> Get()
        {
            return _subscribeService.GetAllSubscribes();
        }

        // שליפת פרטי מנוי ע"פ שם או ת.ז
        [HttpGet("get")]
        public Subscribe Get([FromQuery] string? id = null, [FromQuery] string? name = null)
        {
            return _subscribeService.GetSubscribeByIdOrName(id, name);
        }

        // שליפת ת.ז ע"פ שם 
        [HttpGet("GetId")]
        public string Get([FromQuery] string Name)
        {
            return _subscribeService.GetIdByName(Name);

        }


        //סינון רשימת המנויים לפי פעילים /גיל/ מספר השאלות
        [HttpGet("filter")]
        public IEnumerable<Subscribe> Get([FromQuery] bool? IsActive = null, [FromQuery] int? NumOfBorrows = null, [FromQuery] int? age = null)
        {
            return _subscribeService.GetFilterSubscribe(IsActive, NumOfBorrows, age);
        }


        // הוספת מנוי חדש
        [HttpPost]
        public void Post([FromBody] Subscribe s)
        {
           _subscribeService.AddSubscribe(s);
        }


        // שינוי פרטי מנוי ע"פ ת.ז
        [HttpPut("{id}")]
        public void Put(string id, [FromBody] Subscribe s)
        {
            _subscribeService.ChangeSubscribe(id, s);
        }

        // מחיקת מנוי לפי ת.ז
        [HttpDelete("{id}")]
        public void Delete(string id)
        {
            _subscribeService.DeleteSubscribe(id);

        }
    }
}
