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
        [Required]
        public string UserName { get; set; }

        [Required]
        public int PositionId { get; set; }

        [ForeignKey("PositionId")]
        public PositionModel Position { get; set; }

        [StringLength(20)]
        public string TelephoneNumber { get; set; }

        [StringLength(30)]
        [Required]
        public string LastName { get; set; }

        [StringLength(30)]
        [Required]
        public string FirstName { get; set; }

        [Required]
        public DateTime FromDate { get; set; }

        public DateTime? ToDate { get; set; }
    }
}