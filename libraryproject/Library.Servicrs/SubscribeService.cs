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
            return _subscribeReposetory.GetSubscribeByIdOrName(id, name);
        }

        public string GetIdByName(string Name)
        {
            return _subscribeReposetory.GetIdByName(Name);
        }

        public IEnumerable<Subscribe> GetFilterSubscribe(bool? IsActive = null, int? NumOfBorrows = null, int? age = null)
        {
            return _subscribeReposetory.GetFilterSubscribe(IsActive, NumOfBorrows, age);
        }
        public bool AddSubscribe( Subscribe s)
        {
            return _subscribeReposetory.AddSubscribe(s);
        }
        public bool UpdateSubscribe(string id,Subscribe s)
        {
            return _subscribeReposetory.UpdateSubscribe(id, s);
        }

        public bool DeleteSubscribe(string id)
        {
           return _subscribeReposetory.DeleteSubscribe(id);
        }
    }
}
