using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Noliktava2.Models
{
    [Table("Item")]
    public class ItemModel
    {
        [Key]
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [StringLength(30)]
        [Required(ErrorMessage = "Nosaukums ir obligāti jāaizpilda!")]
        [Display(Name = "Nosaukums")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Cena ir obligāti jāaizpilda!")]
        [Display(Name = "Cena")]
        public double Price { get; set; }
    }
}