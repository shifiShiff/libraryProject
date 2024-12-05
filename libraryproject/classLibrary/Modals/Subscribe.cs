using System.ComponentModel.DataAnnotations;

namespace Library.Core.Modals
{
    public class Subscribe
    {
        [Key]
        public int SubscribeId { get; set; }
        public string Id { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }
        public bool IsActive { get; set; } = true;
        public int NumOfBorrows { get; set; } = 0;
        public int NumOfCurrentBorrowing { get; set; } = 0;



    }
}
