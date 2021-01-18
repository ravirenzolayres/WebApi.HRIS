using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HrisApi.Model
{
    [Table("BioLogs")]
    public class BioLogs : AuditModel
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IDNo { get; set; }
        public string EmployeeCode {get;set;}
        public int BioId { get; set; }
        public DateTime Date { get; set; }
        public string Time { get; set; }
        public int LogType { get; set; }
        public bool IsActive { get; set; }
    }
}
