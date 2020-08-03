using System.ComponentModel.DataAnnotations;

namespace ExpensesDashboard.Models
{
    public class Transaction
    {
        [Key]
        public int Id { get; set; }
        
        [Required]
        [MaxLength(250)]
        public string HowTo { get; set; }
        
        [Required]
        public string Line { get; set; } 
        
        [Required]
        public string Platform { get;set; }
    }
}