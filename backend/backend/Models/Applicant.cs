using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace backend.Models
{
    public class Applicant
    {
		public int Id { get; set; }
		public int ApplicationId { get; set; }
		public string LastName { get; set; }
		public string FirstName { get; set; }
		public string LastNameLatin { get; set; }
		public string FirstNameLatin { get; set; }
		public string BirthCountry { get; set; }
		public string BirthCity { get; set; }
		public DateTime BirthDate { get; set; }
		public string CompletedEducation { get; set; }
		public string PhoneNumber { get; set; }
		public string Email { get; set; }
		public string Address { get; set; }
		public string PassportSeriesAndNumber { get; set; }
		public string PassportСountryIssuer { get; set; }
		public DateTime PassportValidDate { get; set; }
        public string PhotoName { get; set; }
		[NotMapped] public IFormFile Photo { get; set; }
		public string FamilyStatus { get; set; }
		public Spouse Spouse { get; set; }
		public bool HasChildren { get; set; }
		public List<Child> Children { get; set; }
	}
}
