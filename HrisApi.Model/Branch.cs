using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HrisApi.Model
{
    [Table("Branch")]
    public class Branch: AuditModel
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IDNo { get; set; }
        public string BranchCode {get;set;}
        public string BranchName { get; set; }
        public bool IsActive { get; set; }
    }
}
