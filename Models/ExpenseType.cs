using System.ComponentModel.DataAnnotations;

namespace InAndOut.Models
{
    public class ExpenseType
    {
        [Key]
        public int Id { get; set; }

        public string Name { get; set; }
    }
}
