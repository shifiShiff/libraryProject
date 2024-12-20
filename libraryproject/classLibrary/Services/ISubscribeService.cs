using Library.Core.Modals;
using Library.Core.Modals.ModalsDTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Core.Services
{
    public interface ISubscribeService
    {
        IEnumerable<Subscribe> GetAllSubscribes();
        Subscribe GetSubscribeByIdOrName(string? id = null, string? name = null);
        string GetIdByName(string Name);
        IEnumerable<Subscribe> GetFilterSubscribe(bool? IsActive = null, int? NumOfBorrows = null, int? age = null);
        bool AddSubscribe(SubscribePost s);
        bool UpdateSubscribe(string id, SubscribePut s);
        bool DeleteSubscribe(string id);

    }
}
