using System.ComponentModel.DataAnnotations;

namespace ExpensesDashboard.DataTransferObjects
{
    public class CommandUpdateDto
    {
        [Required] // required for "400 Bad Request" message.It's more informative & gives information to the client about missing data
        [MaxLength(250)]
        public string HowTo { get; set; }
        
        [Required] // required for "400 Bad Request" message.It's more informative & gives information to the client about missing data
        public string Line { get; set; } 
        
        [Required] // required for "400 Bad Request" message.It's more informative & gives information to the client about missing data
        public string Platform { get;set; }    
    }
}   