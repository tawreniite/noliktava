using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Noliktava2.Models
{
    [Table("SalesLine")]
    public class SalesLineModel
    {
        [Key]
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        public int SaleId { get; set; }

        [ForeignKey("SaleId")]
        public SalesModel Sale { get; set; }

        [Required]
        public int ItemId { get; set; }

        [ForeignKey("ItemId")]
        public ItemModel Item { get; set; }

        [Required]
        public double Quantity { get; set; }
    }
}