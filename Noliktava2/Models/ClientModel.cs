using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Noliktava2.Models
{
    [Table("Client")]
    public class ClientModel
    {
        [Key]
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public int EmployeeId { get; set; }

        [ForeignKey("EmployeeId")]
        public EmployeeModel Responsible { get; set; }

        [StringLength(20)]
        public string TelephoneNumber { get; set; }

        [StringLength(30)]
        [Required]
        public string Name { get; set; }

        [StringLength(50)]
        [Required]
        public string Address { get; set; }

    }
}