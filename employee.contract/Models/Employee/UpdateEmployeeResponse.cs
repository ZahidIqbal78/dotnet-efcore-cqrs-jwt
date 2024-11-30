using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace employee.contract.Models.Employee
{
	public class UpdateEmployeeResponse
	{
		public UpdateEmployeeResponse(ErrorResponse error)
		{
			Error = error;
		}

		public UpdateEmployeeResponse(EmployeeData data)
		{
			Employee = data;
		}

		public UpdateEmployeeResponse() { }

		public EmployeeData? Employee { get; set; }

		public ErrorResponse? Error { get; set; }
	}
}
