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
        public VendorModel Vendor { get; set; }

        [Required]
        public DateTime Date { get; set; }

        public bool IsCompleted { get; set; }
    }
}