using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Noliktava2.Models
{
    [Table("Employee")]
    public class EmployeeModel
    {
        [Key]
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [StringLength(20)]
        [Required(ErrorMessage = "Lietotājvārds ir obligāti jāaizpilda!")]
        [Display(Name="Lietotājvārds")]
        public string UserName { get; set; }

        [Required]
        public int PositionId { get; set; }

        [ForeignKey("PositionId")]
        public PositionModel Position { get; set; }

        [StringLength(20)]
        [Display(Name = "Telefona numurs")]
        public string TelephoneNumber { get; set; }

        [StringLength(30)]
        [Required(ErrorMessage="Uzvārds ir obligāti jāaizpilda!")]
        [Display(Name = "Uzvārds")]
        public string LastName { get; set; }

        [StringLength(30)]
        [Required(ErrorMessage = "Vārds ir obligāti jāaizpilda!")]
        [Display(Name = "Vārds")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Darba uzsākšanas datums ir obligāti jāaizpilda!")]
        [Display(Name = "Sākuma datums")]
        public DateTime FromDate { get; set; }

        [Display(Name = "Beigu datums")]
        public DateTime? ToDate { get; set; }
    }
}