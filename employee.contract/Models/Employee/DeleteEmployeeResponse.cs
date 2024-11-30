using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace employee.contract.Models.Employee
{
	public class DeleteEmployeeResponse
	{
		public DeleteEmployeeResponse(ErrorResponse error)
		{
			Error = error;
			Success = false;
		}

		public DeleteEmployeeResponse(bool success)
		{
			Success = success;
			Error = null;
		}

		public DeleteEmployeeResponse() { }

		public bool? Success { get; set; }

		public ErrorResponse? Error { get; set; }
	}
}
