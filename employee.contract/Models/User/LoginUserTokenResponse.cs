using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace employee.contract.Models.User
{
	public class LoginUserTokenResponse
	{
		public LoginUserTokenResponse(ErrorResponse? error)
		{
			Error = error;
			Token = null;
		}

		public LoginUserTokenResponse(string? token)
		{
			Token = token;
			Error = null;
		}

		public ErrorResponse? Error { get; set; }
		public string? Token { get; set; }
	}
}
