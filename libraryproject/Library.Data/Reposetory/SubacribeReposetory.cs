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
            return _context.subscribers.ToList();
        }
        public Subscribe GetSubscribeByIdOrName(string? idOrName= null)
        {  
                return _context.subscribers.FirstOrDefault(s => s.Id == idOrName);
        }
        public Subscribe GetIdByName(string Name)
        {
            return _context.subscribers.FirstOrDefault(s => s.Name == Name);
            
        }
        //public IEnumerable<Subscribe> GetFilterSubscribe()
        //{
        //   return  _context.subscribers.ToList();
           
        //}
        public bool AddSubscribe(Subscribe s)
        {
            _context.subscribers.Add(s);
            _context.SaveChanges();
            return true;
        }
        public bool UpdateSubscribe(string id, Subscribe s)
        {
            var SubscribeForUpdate= _context.subscribers.FirstOrDefault(s => s.Id == id);
            if (SubscribeForUpdate != null)
            {
                SubscribeForUpdate.Address = s.Address;
                SubscribeForUpdate.NumOfBorrows = s.NumOfBorrows;
                SubscribeForUpdate.Phone = s.Phone;
                SubscribeForUpdate.Name = s.Name;
                SubscribeForUpdate.Age = s.Age;
                SubscribeForUpdate.IsActive = s.IsActive;
                _context.SaveChanges();

                return true;
            }
            return false;
        }


    
        public bool DeleteSubscribe(string id)
        {
            var s = _context.subscribers.FirstOrDefault(o => o.Id == id);
            if (s is null)
                return false;
            s.IsActive = false;
            _context.SaveChanges();
            return true;
            
            
        }
    }
}
