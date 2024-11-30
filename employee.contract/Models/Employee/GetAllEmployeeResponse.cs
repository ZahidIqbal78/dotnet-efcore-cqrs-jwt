using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace employee.contract.Models.Employee
{
	public class GetAllEmployeeResponse
	{
		public GetAllEmployeeResponse()
		{
				
		}

		public GetAllEmployeeResponse(ErrorResponse error)
		{
			Error = error;
		}

		public GetAllEmployeeResponse(List<EmployeeData>? employees)
		{
			Employees = employees;
		}

		public GetAllEmployeeResponse(List<EmployeeData>? employees, int count)
		{
			Employees = employees;
			Count = count;
		}

		public int Count { get; set; } = 0;

		public List<EmployeeData>? Employees { get; set; }

		public ErrorResponse? Error { get; set; }
	}
}
