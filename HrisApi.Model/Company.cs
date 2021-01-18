using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HrisApi.Model
{
    [Table("Company")]
    public class Company: AuditModel
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IDNo { get; set; }
        public string CompanyCode {get;set;}
        public string CompanyName { get; set; }
        public string CompanyAddress { get; set; }
        public string ContactNumber { get; set; }
        public bool IsActive { get; set; }
    }
}
