﻿using classLibraryCore.Interfaces;
using Library.Modals;
using Microsoft.AspNetCore.Mvc;


namespace Library.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SubscribeController : ControllerBase
    {
        private readonly IDataInteface _Data;

        public SubscribeController(IDataInteface context)
        {
            _Data = context;
        }

       

        // שליפת רשימת מנויים
        [HttpGet]
        public IEnumerable<Subscribe> Get()
        {
            return _Data.subscribers;
        }

        // שליפת פרטי מנוי ע"פ שם או ת.ז
        [HttpGet("get")]
        public Subscribe Get([FromQuery] string? id=null, [FromQuery] string? name = null)
        {
            if(id!=null)
                return _Data.GetSubscribeFromListById(id);
            return _Data.GetSubscribeFromListByName(name);
        }

        // שליפת ת.ז ע"פ שם 
        [HttpGet("GetId")]
        public string Get([FromQuery] string Name)
        {
                return _Data.GetSubscribeFromListByName(Name).Id;
            
        }


        //סינון רשימת המנויים לפי פעילים /גיל/ מספר השאלות
        [HttpGet("filter")]
        public IEnumerable<Subscribe> Get([FromQuery] bool? IsActive = null, [FromQuery] int? NumOfBorrows = null, [FromQuery] int? age = null)
        {
            List<Subscribe> SubscribeList = _Data.subscribers;
            if (IsActive != null)
                SubscribeList = SubscribeList.Where(Sub => Sub.IsActive == IsActive).ToList();

            if (NumOfBorrows != null)
                SubscribeList = SubscribeList.Where(Sub => Sub.NumOfBorrows > NumOfBorrows).ToList();

            if (age != null)
                SubscribeList = SubscribeList.Where(Sub => Sub.Age > age).ToList();

            return SubscribeList;


        }


        // הוספת מנוי חדש
        [HttpPost]
        public void Post([FromBody] Subscribe s)
        {
            _Data.subscribers.Add(s);
        }


        // שינוי פרטי מנוי ע"פ ת.ז
        [HttpPut("{id}")]
        public void Put(string id, [FromBody] Subscribe s)
        {
            Subscribe SubscribeForUpdate = _Data.subscribers.FirstOrDefault(s => s.Id == id);
            if (SubscribeForUpdate != null)
            {
                SubscribeForUpdate.Address = s.Address;
                SubscribeForUpdate.NumOfBorrows = s.NumOfBorrows;
                SubscribeForUpdate.Phone = s.Phone;
                SubscribeForUpdate.Name = s.Name;
                SubscribeForUpdate.Age = s.Age;
                SubscribeForUpdate.IsActive = s.IsActive;
            }

        }

        // מחיקת מנוי לפי ת.ז
        [HttpDelete("{id}")]
        public void Delete(string id)
        {
            _Data.subscribers.FirstOrDefault(o => o.Id == id).IsActive = false;

        }
    }
}
