using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace FIT5032_Week08A.Models
{
    public class SendEmailViewModel
    {
        [Display(Name = "Email address")]
        [Required(ErrorMessage = "Please enter an email address.")]
        [RegularExpression("^((?!;).)*$", ErrorMessage = "sql protect")]
        [EmailAddress(ErrorMessage = "Invalid Email Address")]
        public string ToEmail { get; set; }

        [Required(ErrorMessage = "Please enter a subject.")]
        [RegularExpression("^((?!;).)*$", ErrorMessage = "sql protect")]
        public string Subject { get; set; }

        [Required(ErrorMessage = "Please enter the contents")]
        [RegularExpression("^((?!;).)*$", ErrorMessage = "sql protect")]
        public string Contents { get; set; }

        public HttpPostedFileBase Upload { get; set; }
    }
}