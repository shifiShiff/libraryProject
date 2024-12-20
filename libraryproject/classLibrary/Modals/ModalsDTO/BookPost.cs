using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Core.Modals.ModalsDTO
{
    public class BookPost
    {
        public string Name { get; set; }
        public Ecategory Category { get; set; }
        public string Author { get; set; }
        public DateTime DateOfBuying { get; set; }
        public int NumOfPages { get; set; }
    }
}
