using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace zad1.Models
{
    public class AddModel
    {
        [Required(ErrorMessage = "Podaj imię!")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Podaj nazwisko!")]
        public string Surname { get; set; }
    }
}