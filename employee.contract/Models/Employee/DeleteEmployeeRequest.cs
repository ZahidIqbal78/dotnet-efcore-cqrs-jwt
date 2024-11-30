using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace employee.contract.Models.Employee
{
	public class DeleteEmployeeRequest
	{
		public DeleteEmployeeRequest(Guid id)
		{
			Id = id;
		}

		public Guid Id { get; set; }
	}
}
