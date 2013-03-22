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

        [Required(ErrorMessage = "Datums ir obligāti jāaizpilda!")]
        [Display(Name = "Datums")]
        public DateTime Date { get; set; }

        [Display(Name = "Ir izpildīts")]
        public bool IsCompleted { get; set; }
    }
}