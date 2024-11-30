using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace employee.contract.Models.Employee
{
	public class UpdateEmployeeRequest
	{
		[JsonIgnore]
		public Guid? Id { get; set; }
		public string? FirstName { get; set; }

		public string? LastName { get; set; }

		public string? Email { get; set; }

		public string? PhoneNumber { get; set; }

		public string? Department { get; set; }

		public string? Designation { get; set; }
	}
}
