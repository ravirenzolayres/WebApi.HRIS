using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace HrisApi.Model
{
    [Table("Employee")]
    public class Employee :AuditModel
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IDNo { get; set; }
        public string EmployeeCode { get; set; }
        public int BioId { get; set; }
        public string CompanyCode { get; set; }
        public string BranchCode { get; set; }
        public string DepartmentCode { get; set; }
        public string PositionCode { get; set; }
        public string EmployeeTypeCode { get; set; }
        public int PersonalInfoId { get; set; }
        public int EducationInfoId { get; set; }
        public string ProfileImg { get; set; }
        public string DefaultShiftCode { get; set; }
        public string Username { get; set; }
        public DateTime? DateHired { get; set; }
        public DateTime? DateRegularized { get; set; }
        public DateTime? DateResigned { get; set; }
        public bool IsActive { get; set; }
    }
}
