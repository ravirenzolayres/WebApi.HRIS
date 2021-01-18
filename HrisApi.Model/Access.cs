using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HrisApi.Model
{
    [Table("Access")]
    public class Access: AuditModel
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IDNo { get; set; }
        public string AccessCode {get;set;}
        public string AccessName { get; set; }
        public bool IsActive { get; set; }
    }
}
