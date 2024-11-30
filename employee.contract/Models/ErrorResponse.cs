using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace employee.contract.Models
{
	public class ErrorResponse
	{
		public string? Title { get; set; }
		public string? Details { get; set; }
		public string? ExceptionMessage { get;set; }
	}
}
