using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace HrisApi.Model
{
    [Table("HolidayType")]
    public class HolidayType : AuditModel
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IDNo { get; set; }
        public string HolidayTypeCode { get; set; }
        public string HolidayTypeName { get; set; }
        public bool IsActive { get; set; }
    }
}
