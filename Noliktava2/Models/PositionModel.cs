using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Noliktava2.Models
{
    [Table("Position")]
    public class PositionModel
    {
        [Key]
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [StringLength(20)]
        [Required]
        public string Code { get; set; }

        [StringLength(100)]
        [Required]
        public string Name { get; set; }
    }
}