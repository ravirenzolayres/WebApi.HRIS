using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HrisApi.Model
{
    [Table("Gender")]
    public class Gender: AuditModel
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IDNo { get; set; }
        public string GenderCode {get;set;}
        public string GenderName { get; set; }
        public bool IsActive { get; set; }
    }
}
