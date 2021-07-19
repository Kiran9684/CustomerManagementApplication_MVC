using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace LibraryApplication.Models
{
    public class Customer
    {
        [Required]
        public int CustomerID { get; set; }
       [Required(ErrorMessage ="Customer Name Required")]
        public string CustomerName {get;set;}
        
        public string City { get; set; }
        [Required][StringLength(100)]
        public string Address { get; set; }
    }
}