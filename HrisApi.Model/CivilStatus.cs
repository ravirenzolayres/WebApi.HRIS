using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HrisApi.Model
{
    [Table("CivilStatus")]
    public class CivilStatus : AuditModel
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IDNo { get; set; }
        public string CivilStatusCode { get;set;}
        public string CivilStatusName { get; set; }
        public bool IsActive { get; set; }
    }
}
