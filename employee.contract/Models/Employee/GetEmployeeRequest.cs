using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace employee.contract.Models.Employee
{
	public class GetEmployeeRequest
	{
		public GetEmployeeRequest(Guid id)
		{
			Id = id;
		}

		public Guid Id { get; set; }
	}
}
