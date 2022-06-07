using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace InAndOut.Models
{
    public class Expense
    {
        [Key] //tell that this is the primary key. Idnetifieiable value. Auto increment
        public int Id { get; set; } //property

        [DisplayName("Expense Name")]
        
        //Validation
        [Required]
        public string ExpenseName { get; set; }

        [Required]
        [Range(1,int.MaxValue, ErrorMessage ="Amount must be greater than 0!")]
        public double Amount { get; set; }

    }
}
