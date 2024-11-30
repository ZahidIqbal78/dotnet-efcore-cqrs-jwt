using employee.web.api.Entities.Interfaces;
using System.ComponentModel.DataAnnotations;

namespace employee.web.api.Entities
{
	public class UserEntity : IEntity
	{
		public Guid Id { get; set; }
		public DateTime CreatedAt { get; set; }
		public DateTime UpdatedAt { get; set; }

		[Required]
		[EmailAddress]
		public string? Email { get; set; }

		public string? PasswordHash { get; set; }

		[StringLength(500)]
		public string? Remarks { get; set; }
	}
}
