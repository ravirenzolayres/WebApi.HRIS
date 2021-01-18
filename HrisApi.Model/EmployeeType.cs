using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace HrisApi.Model
{
    [Table("EmployeeType")]
    public class EmployeeType :AuditModel
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IDNo { get; set; }
        public string EmployeeTypeCode { get; set; }
        public string EmployeeTypeName { get; set; }
        public bool IsActive { get; set; }

    }
}
