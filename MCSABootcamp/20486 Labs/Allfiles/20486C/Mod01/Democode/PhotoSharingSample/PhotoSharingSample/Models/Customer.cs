using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PhotoSharingApplication.Models
{
    public class Customer
    {
        public int Id { get; set; }
        [DisplayName("First Name")]
        [Required(ErrorMessage="Mandatory")]
        [StringLength(25, ErrorMessage = "Name cannot be so long")]
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
}