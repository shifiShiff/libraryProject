using Library.Core.Modals;
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
        bool AddSubscribe(Subscribe s);
        bool UpdateSubscribe(string id, Subscribe s);
        bool DeleteSubscribe(string id);

    }
}
