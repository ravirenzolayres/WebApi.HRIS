using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace HrisApi.Model
{
    [Table("Shift")]
    public class Shift :AuditModel
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IDNo { get; set; }
        public string ShiftCode { get; set; }
        public string ShiftName { get; set; }
        public string ShiftIn { get; set; }
        public string ShiftOut { get; set; }
        public string ND1ShiftIn { get; set; }
        public string ND1ShiftOut { get; set; }
        public string ND2ShiftIn { get; set; }
        public string ND2ShiftOut { get; set; }
        public string ND3ShiftIn { get; set; }
        public string ND3ShiftOut { get; set; }
        [Column(TypeName = "decimal(18,2)")]
        public decimal HoursWork { get; set; }
        [Column(TypeName = "decimal(18,2)")]
        public decimal GracePeriod { get; set; }
        [Column(TypeName = "decimal(18,2)")]
        public decimal Brk { get; set; }
        public bool IsRestday { get; set; }
        public bool IsActive { get; set; }
    }
}
