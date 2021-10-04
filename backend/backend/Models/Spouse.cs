using Microsoft.AspNetCore.Http;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace backend.Models
{
    public class Spouse
    {
		public int Id { get; set; }
		public int ApplicantId { get; set; }
		public string FirstNameLatin { get; set; }
		public string LastNameLatin { get; set; }
		public string BirthCountry { get; set; }
		public string BirthCity { get; set; }
		public DateTime BirthDate { get; set; }
		public string CompletedEducation { get; set; }
		public string PassportSeriesAndNumber { get; set; }
		public string PassportСountryIssuer { get; set; }
		public DateTime PassportValidDate { get; set; }
		public string PhotoName { get; set; }
		[NotMapped] public IFormFile Photo { get; set; }
	}
}
