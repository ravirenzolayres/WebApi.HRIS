using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace HrisApi.Model
{
    [Table("EmployeeCustomSchedule")]
    public class EmployeeCustomSchedule :AuditModel
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IDNo { get; set; }
        public string EmployeeCode { get; set; }
        public string ShiftCode { get; set; }
        public DateTime Date { get; set; }
        public bool IsActive { get; set; }
    }
}
