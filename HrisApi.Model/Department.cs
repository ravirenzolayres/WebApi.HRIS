using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HrisApi.Model
{
    [Table("Department")]
    public class Department: AuditModel
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IDNo { get; set; }
        public string DepartmentCode {get;set;}
        public string DepartmentName { get; set; }
        public bool IsActive { get; set; }
    }
}
