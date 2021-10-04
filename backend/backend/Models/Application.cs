using System;

namespace backend.Models
{
    /// <summary>
    ///     Represents form main application
    /// </summary>
    public class Application
	{
        public int Id { get; set; }
		public Applicant Applicant { get; set; }
        public DateTime CreatedDateTime { get; set; }
		public bool IsProcessed { get; set; }
    }
}
