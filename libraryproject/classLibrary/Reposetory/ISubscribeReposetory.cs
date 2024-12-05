using Library.Core.Modals;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Core.Reposetory
{
    public interface ISubscribeReposetory
    {
        IEnumerable<Subscribe> GetAllSubscribes();
        Subscribe GetSubscribeByIdOrName(string? idOrName = null);
        Subscribe GetIdByName(string Name);
        //IEnumerable<Subscribe> GetFilterSubscribe(bool? IsActive = null, int? NumOfBorrows = null, int? age = null);
        bool AddSubscribe(Subscribe s);
        bool UpdateSubscribe(string id, Subscribe s);
        bool DeleteSubscribe(string id);
    }
}
