using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SalehAjax.Models
{
    public class Person
    {
        [Display(Name = "Order")]
        public int Id { get; set; }
        [Required(ErrorMessage = "your name")]
        [Display(Name = "person name")]
        public string Name { get; set; }
        [Required(ErrorMessage = "your city")]
        [Display(Name = "person city")]
        public string City { get; set; }
    }
}