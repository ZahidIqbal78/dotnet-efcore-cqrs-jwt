using employee.web.api.Entities.Interfaces;
using System.ComponentModel.DataAnnotations;

namespace employee.web.api.Entities
{
	public class EmployeeEntity : IEntity
	{
		public Guid Id { get; set; }
		public DateTime CreatedAt { get; set; }
		public DateTime UpdatedAt { get; set; }

		[Required]
		[StringLength(55, ErrorMessage = "First name must not be more than 55 characters long.")]
		public string? FirstName { get; set; }

		[Required]
		[StringLength(55, ErrorMessage = "Last name must not be more than 55 characters long.")]
		public string? LastName { get; set; }

		[Required]
		[EmailAddress]
		[StringLength(320)]
		public string? Email { get; set; }

		[Required]
		[StringLength(25)]
		public string? PhoneNumber { get; set; }

		[Required]
		[StringLength(255)]
		public string? Department { get; set; }

		[Required]
		[StringLength(255)]
		public string? Designation { get;set; }
	}
}
