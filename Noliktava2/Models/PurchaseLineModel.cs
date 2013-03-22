using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Noliktava2.Models
{
    [Table("PurchaseLine")]
    public class PurchaseLineModel
    {
        [Key]
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        public int PurchaseId { get; set; }

        [ForeignKey("PurchaseId")]
        public PurchaseModel Purchase { get; set; }

        [Required]
        public int ItemId { get; set; }

        [ForeignKey("ItemId")]
        [Display(Name = "Preces nosaukums")]
        public ItemModel Item { get; set; }

        [Required(ErrorMessage = "Daudzums ir obligāti jāaizpilda!")]
        [Display(Name = "Daudzums")]
        public double Quantity { get; set; }
    }
}