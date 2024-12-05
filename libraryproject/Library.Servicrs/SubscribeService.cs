using Library.Core.Modals;
using Library.Core.Reposetory;
using Library.Core.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Servicrs
{
    public class SubscribeService : ISubscribeService
    {

        private readonly ISubscribeReposetory _subscribeReposetory;
        public SubscribeService(ISubscribeReposetory subscribe)
        {
            _subscribeReposetory = subscribe;
        }

        public IEnumerable<Subscribe> GetAllSubscribes()
        {
            return _subscribeReposetory.GetAllSubscribes();
        }

        public Subscribe GetSubscribeByIdOrName(string? id = null, string? name = null)
        {
            if (id != null)
                return _subscribeReposetory.GetSubscribeByIdOrName(id);
            return _subscribeReposetory.GetSubscribeByIdOrName(name);
        }

        public string GetIdByName(string Name)
        {
            var s = _subscribeReposetory.GetIdByName(Name);
            if (s != null)
                return s.Id;
            return "-1";
        
        }

        public IEnumerable<Subscribe> GetFilterSubscribe(bool? IsActive = null, int? NumOfBorrows = null, int? age = null)
        {
            var SubscribeList = _subscribeReposetory.GetAllSubscribes();

            if (IsActive != null)
                SubscribeList = SubscribeList.Where(Sub => Sub.IsActive == IsActive).ToList();

            if (NumOfBorrows != null)
                SubscribeList = SubscribeList.Where(Sub => Sub.NumOfBorrows > NumOfBorrows).ToList();

            if (age != null)
                SubscribeList = SubscribeList.Where(Sub => Sub.Age > age).ToList();

            return SubscribeList;
        }
        public bool AddSubscribe( Subscribe s)
        {
            return _subscribeReposetory.AddSubscribe(s);
        }
        public bool UpdateSubscribe(string id, Subscribe s)
        {
            return _subscribeReposetory.UpdateSubscribe(id, s);

        }

        public bool DeleteSubscribe(string id)
        {
            return _subscribeReposetory.DeleteSubscribe(id);
        }
    }
}
