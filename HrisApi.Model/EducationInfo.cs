using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HrisApi.Model
{
    [Table("EducationInfo")]
    public class EducationInfo : AuditModel
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IDNo { get; set; }
        public string EmployeeCode { get; set; }
        public string ESName { get; set; }
        public string HSName { get; set; }
        public string VSName { get; set; }
        public string CSName { get; set; }
        public string PGSName { get; set; }

        public string ESAddress { get; set; }
        public string HSAddress { get; set; }
        public string VSAddress { get; set; }
        public string CSAddress { get; set; }
        public string PGSAddress { get; set; }


        public string ESInclusiveStartYear { get; set; }
        public string HSInclusiveStartYear { get; set; }
        public string VSInclusiveStartYear { get; set; }
        public string CSInclusiveStartYear { get; set; }
        public string PGSInclusiveStartYear { get; set; }


        public string ESInclusiveEndYear { get; set; }
        public string HSInclusiveEndYear { get; set; }
        public string VSInclusiveEndYear { get; set; }
        public string CSInclusiveEndYear { get; set; }
        public string PGSInclusiveEndYear { get; set; }
        public string CSCourse { get; set; }
        public string VSCourse{ get; set; }
        public string PGSCourse { get; set; }

    }
}
