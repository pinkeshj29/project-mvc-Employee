using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace project_mvc.Models
{
    public class Employeemodel
    {
        public int Id { get; set; }

        [Required]
        public string EmpName { get; set; }

        [Required]
        [DataType(DataType.EmailAddress)]
        public string Emailid { get; set; }

        [Required]

        public string MobileNo { get; set; }

    }
}


   