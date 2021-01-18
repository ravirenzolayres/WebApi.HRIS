using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HrisApi.Model
{
    [Table("Position")]
    public class Position: AuditModel
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IDNo { get; set; }
        public string PositionCode {get;set;}
        public string PositionName { get; set; }
        public bool IsActive { get; set; }
    }
}
