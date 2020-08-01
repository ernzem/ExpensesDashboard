using System.ComponentModel.DataAnnotations;

namespace ExpensesDashboard.DataTransferObjects
{
    public class CommandReadDto
    {
        [Key]
        public int Id { get; set; }
        
        [Required]
        [MaxLength(250)]
        public string HowTo { get; set; }
        
        [Required]
        public string Line { get; set; }        
    }
}   