﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace employee.contract.Models.User
{
	public class LoginUserRequest
	{
		public string? Email { get; set; }

		public string? Password { get; set; }
	}
}
