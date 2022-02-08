using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace zad1.Models
{
	public class EditModel
	{
		public int Id { get; set; }
		[Required(ErrorMessage= "Podaj imię!")]
		public string Name { get; set; }
		[Required(ErrorMessage = "Podaj nazwisko!")]
		public string Surname { get; set; }
	}
}