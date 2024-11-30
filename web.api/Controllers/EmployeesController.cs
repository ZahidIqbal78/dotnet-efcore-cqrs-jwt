using Asp.Versioning;
using employee.contract.Models;
using employee.contract.Models.Employee;
using employee.web.api.ModelExtensions.Employee;
using MediatR;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace employee.web.api.Controllers
{
	[Route("api/v{version:apiVersion}/[controller]")]
	[ApiController]
	[ApiVersion("1.0")]
	[Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
	public class EmployeesController : ControllerBase
	{
		// TODO: Refactor by moving this controller to employee.contract so that the endpoints can be picked up by other applications.

		private readonly IMediator _mediator;

		public EmployeesController(IMediator mediator)
		{
			_mediator = mediator;
		}

		[HttpPost]
		[ProducesResponseType(typeof(AddEmployeeResponse), StatusCodes.Status200OK)]
		public async Task<IActionResult> AddEmployee(AddEmployeeRequest request)
		{
			var command = new Features.Employee.AddEmployeeFeature.Command(request);
			var employee = await _mediator.Send(command);
			return Ok(employee);
		}

		[HttpGet]
		[ProducesResponseType(typeof(GetAllEmployeeResponse), StatusCodes.Status200OK)]
		public async Task<IActionResult> GetAll()
		{
			var query = new Features.Employee.GetAllEmployeeFeature.Query();
			var employees = await _mediator.Send(query);
			return Ok(employees);
		}

		[HttpGet("{id}")]
		[ProducesResponseType(typeof(GetEmployeeResponse), StatusCodes.Status200OK)]
		[ProducesResponseType(typeof(ErrorResponse), StatusCodes.Status404NotFound)]
		public async Task<IActionResult> Get(Guid id)
		{
			var query = new Features.Employee.GetEmployeeFeature.Query(new GetEmployeeRequest(id));
			var employee = await _mediator.Send(query);
			// Todo: Handle not found.
			return Ok(employee);
		}

		[HttpPut("{id}")]
		[ProducesResponseType(typeof(GetEmployeeResponse), StatusCodes.Status200OK)]
		[ProducesResponseType(typeof(ErrorResponse), StatusCodes.Status404NotFound)]
		public async Task<IActionResult> Update(
			[FromRoute] Guid id,
			[FromBody, Required] UpdateEmployeeRequest request)
		{
			request.Id = id;
			var command = new Features.Employee.UpdateEmployeeFeature.Command(request);
			var employee = await _mediator.Send(command);
			// Todo: Handle not found.
			// Todo: Handle internal server error:500
			return Ok(employee);
		}

		[HttpDelete("{id}")]
		[ProducesResponseType(typeof(DeleteEmployeeResponse), StatusCodes.Status200OK)]
		[ProducesResponseType(typeof(ErrorResponse), StatusCodes.Status404NotFound)]
		public async Task<IActionResult> Delete(
			[FromRoute] Guid id)
		{
			var command = new Features.Employee.DeleteEmployeeFeature.Command(new DeleteEmployeeRequest(id));
			var response = await _mediator.Send(command);
			// Todo: Handle not found.
			// Todo: Handle internal server error:500
			return Ok(response);
		}

	}
}
