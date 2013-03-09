using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Noliktava2.Models
{
    [Table("Sale")]
    public class SalesModel
    {
        [Key]
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        public int ClientId { get; set; }

        [ForeignKey("ClientId")]
        public ClientModel Client { get; set; }

        [Required]
        public DateTime Date { get; set; }

        public bool IsCompleted { get; set; }
    }
}