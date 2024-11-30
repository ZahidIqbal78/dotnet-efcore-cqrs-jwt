using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace employee.contract.Models.Employee
{
	public class GetEmployeeResponse
	{
		public GetEmployeeResponse(ErrorResponse error)
		{
			Error = error;
		}

		public GetEmployeeResponse(EmployeeData data)
		{
			Employee = data;
		}

		public GetEmployeeResponse() { }

		public EmployeeData? Employee { get; set; }

		public ErrorResponse? Error { get; set; }
	}
}
