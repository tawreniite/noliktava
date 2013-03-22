using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Noliktava2.Models
{
    [Table("Vendor")]
    public class VendorModel
    {
        [Key]
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        public int EmployeeId { get; set; }

        [ForeignKey("EmployeeId")]
        [Display(Name = "Atbildīgais darbinieks")]
        public EmployeeModel Responsible { get; set; }

        [StringLength(20)]
        [Required(ErrorMessage = "Telefona numurs ir obligāti jāaizpilda!")]
        [Display(Name = "Telefona numurs")]
        public string TelephoneNumber { get; set; }

        [StringLength(30)]
        [Required(ErrorMessage = "Nosaukums ir obligāti jāaizpilda!")]
        [Display(Name = "Nosaukums")]
        public string Name { get; set; }

        [StringLength(50)]
        [Required(ErrorMessage = "Adrese ir obligāti jāaizpilda!")]
        [Display(Name = "Adrese")]
        public string Address { get; set; }

    }
}