using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ExpensesDashboard.Models
{
    public class Transaction
    {
        [Key]
        [Required]
        public int Id { get; set; }

        [Required]
        public DateTime Date { get; set; }

        [Required]
        [Column(TypeName = "decimal(18,2)")]
        public decimal Sum { get; set; }

        [Required]
        public string Recipent { get; set; }

        public string Note { get; set; }

        public string AccountNr { get; set; }

        public string TransactionId { get; set; }
    }
}