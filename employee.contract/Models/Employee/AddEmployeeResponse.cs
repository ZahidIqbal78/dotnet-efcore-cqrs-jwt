using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace employee.contract.Models.Employee
{
	public class AddEmployeeResponse
	{
		public AddEmployeeResponse(ErrorResponse error)
		{
			Error = error;
		}

		public AddEmployeeResponse(EmployeeData data)
		{
			Employee = data;
		}

		public AddEmployeeResponse() { }

		public EmployeeData? Employee { get; set; }

		public ErrorResponse? Error { get; set; }
	}
}
