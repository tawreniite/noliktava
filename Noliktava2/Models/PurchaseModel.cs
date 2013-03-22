using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Noliktava2.Models
{
    [Table("Purchase")]
    public class PurchaseModel
    {
        [Key]
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        public int VendorId { get; set; }

        [ForeignKey("VendorId")]
        [Display(Name = "Nosaukums")]
        public VendorModel Vendor { get; set; }

        [Required(ErrorMessage = "Izpildes datums ir obligāti jāaizpilda!")]
        [Display(Name = "Izpildes datums")]
        public DateTime Date { get; set; }

        [Display(Name = "Ir izpildīts")]
        public bool IsCompleted { get; set; }
    }
}