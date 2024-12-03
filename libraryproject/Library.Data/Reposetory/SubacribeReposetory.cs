using Library.Core.Modals;
using Library.Core.Reposetory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Data.Reposetory
{
    public class SubacribeReposetory : ISubscribeReposetory
    {
        private readonly DataContext _context;
        public SubacribeReposetory(DataContext data)
        {
            _context = data;
        }
        public IEnumerable<Subscribe> GetAllSubscribes()
        {
            return _context.subscribers;
        }
        public Subscribe GetSubscribeByIdOrName(string? id = null, string? name = null)
        {
            if (id != null)
                return _context.subscribers.FirstOrDefault(s => s.Id == id);
            return _context.subscribers.FirstOrDefault(s => s.Name == name);
        }
        public string GetIdByName(string Name)
        {
            Subscribe s = _context.subscribers.FirstOrDefault(s => s.Name == Name);
            if (s != null)
                return s.Id;
            return "-1";
        }
        public IEnumerable<Subscribe> GetFilterSubscribe(bool? IsActive = null, int? NumOfBorrows = null, int? age = null)
        {
            List<Subscribe> SubscribeList = _context.subscribers;
            if (IsActive != null)
                SubscribeList = SubscribeList.Where(Sub => Sub.IsActive == IsActive).ToList();

            if (NumOfBorrows != null)
                SubscribeList = SubscribeList.Where(Sub => Sub.NumOfBorrows > NumOfBorrows).ToList();

            if (age != null)
                SubscribeList = SubscribeList.Where(Sub => Sub.Age > age).ToList();

            return SubscribeList;
        }
        public bool AddSubscribe(Subscribe s)
        {
            _context.subscribers.Add(s);
            return true;
        }
        public bool UpdateSubscribe(string id, Subscribe s)
        {
            Subscribe SubscribeForUpdate = _context.subscribers.FirstOrDefault(s => s.Id == id);
            if (SubscribeForUpdate != null)
            {
                SubscribeForUpdate.Address = s.Address;
                SubscribeForUpdate.NumOfBorrows = s.NumOfBorrows;
                SubscribeForUpdate.Phone = s.Phone;
                SubscribeForUpdate.Name = s.Name;
                SubscribeForUpdate.Age = s.Age;
                SubscribeForUpdate.IsActive = s.IsActive;
                return true;
            }
            return false;

        }
        public bool DeleteSubscribe(string id)
        {
            Subscribe s = _context.subscribers.FirstOrDefault(o => o.Id == id);
            if (s is null)
                return false;
            s.IsActive = false;
            return true;
        }
    }
}
