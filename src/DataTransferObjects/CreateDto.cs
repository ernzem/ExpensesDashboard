using System;
using System.ComponentModel.DataAnnotations;

namespace ExpensesDashboard.DataTransferObjects
{
    public class CreateDto
    {
        [Required]
        public DateTime Date { get; set; }

        [Required]
        public decimal Sum { get; set; }

        [Required]
        public string Recipent { get; set; }
    }
}   