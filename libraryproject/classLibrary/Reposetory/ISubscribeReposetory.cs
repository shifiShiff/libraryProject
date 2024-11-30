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
        Subscribe GetSubscribeByIdOrName(string? id = null, string? name = null);
        string GetIdByName(string Name);
        IEnumerable<Subscribe> GetFilterSubscribe(bool? IsActive = null, int? NumOfBorrows = null, int? age = null);
        void AddSubscribe(Subscribe s);
        void ChangeSubscribe(string id, Subscribe s);
        void DeleteSubscribe(string id);
    }
}
