using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace HrisApi.Model
{
    [Table("ShiftWeekly")]
    public class ShiftWeekly :AuditModel
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IDNo { get; set; }
        public string ShiftCode { get; set; }
        public int Day { get; set; }
        public bool IsActive { get; set; }
    }
}
