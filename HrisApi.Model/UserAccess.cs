﻿using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HrisApi.Model
{
    [Table("UserAccess")]
    public class UserAccess: AuditModel
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IDNo { get; set; }
        public string Username { get; set; }
        public string AccessCode { get; set; }
    }
}
