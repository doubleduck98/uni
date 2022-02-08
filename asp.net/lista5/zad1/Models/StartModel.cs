using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace zad1.Models
{
    [Serializable]
    public class StartModel
    {
        [Required(ErrorMessage = "Wpisać imię!")]
        public string Imie { get; set; }
        [Required(ErrorMessage = "Wpisać nazwisko!")]
        public string Nazwisko { get; set; }
        [Required(ErrorMessage = "Wpisać nazwę zajęć!")]
        public string Zajecia { get; set; }
        [Required(ErrorMessage = "Wpisać numer zestawu!")]
        public int Zestaw { get; set; }
        [Required(ErrorMessage = "Podaj liczbę punktów!")]
        public int[] Punkty { get; set; }
    }
}