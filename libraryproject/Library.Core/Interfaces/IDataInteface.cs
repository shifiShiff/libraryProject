using Library.Core.Modals;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Core.Interfaces
{
    public interface IDataInteface
    {

        List<Book> books { get; set; }
        List<Subscribe> subscribers { get; set; }
        List<Borrow> borrows { get; set; }

        Book GetBookFromListByCode(int code);
        Subscribe GetSubscribeFromListById(string id);

        Subscribe GetSubscribeFromListByName(string name);



    }
}
