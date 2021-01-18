using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace HrisApi.Model
{
    [Table("Holiday")]
    public class Holiday : AuditModel
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IDNo { get; set; }
        public string HolidayCode { get; set; }
        public string HolidayName { get; set; }
        public DateTime Date { get; set; } 
        public bool IsFixed { get; set; }
        public bool IsActive { get; set; }
    }
}
