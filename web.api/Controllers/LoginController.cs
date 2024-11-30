using Asp.Versioning;
using employee.contract.Models.Employee;
using employee.contract.Models.User;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace employee.web.api.Controllers
{
	[Route("api/v{version:apiVersion}/[controller]")]
	[ApiController]
	[ApiVersion("1.0")]
	public class LoginController : ControllerBase
	{
		private readonly IMediator _mediator;

		public LoginController(IMediator mediator)
		{
			_mediator = mediator;
		}

		[HttpPost]
		[ProducesResponseType(typeof(LoginUserTokenResponse), StatusCodes.Status200OK)]
		public async Task<IActionResult> Login([FromBody, Required]LoginUserRequest request)
		{
			var command = new Features.User.LoginUserFeature.Query(request);
			var response = await _mediator.Send(command);
			return Ok(response);
		}
	}
}
