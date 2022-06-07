using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace InAndOut.Models
{
    public class Item
    {
        [Key] //tell that this is the primary key. Idnetifieiable value. Auto increment
        public int Id { get; set; } //property
        public string Borrower { get; set; }
        public string Lender { get; set; }

        [DisplayName("Item name")] //can edit UI rather than ItemName
        public string ItemName { get; set; }

    }
}
