using employee.contract.Models;
using employee.contract.Models.Employee;
using employee.web.api.Contexts;
using employee.web.api.ModelExtensions.Employee;
using MediatR;

namespace employee.web.api.Features.Employee.UpdateEmployeeFeature
{
	public class Handler : IRequestHandler<Command, UpdateEmployeeResponse>
	{
		private readonly DatabaseContext _context;

		public Handler(DatabaseContext context)
		{
			_context = context;
		}

		public async Task<UpdateEmployeeResponse> Handle(Command request, CancellationToken cancellationToken)
		{
			var employee = await _context.Employees.FindAsync(request.request.Id);

			if (employee == null)
			{
				return new UpdateEmployeeResponse(new ErrorResponse
				{
					Title = "Not Found",
					Details = "Employee with ID not found."
				});
			}

			try
			{
				employee.FirstName = request.request.FirstName;
				employee.LastName = request.request.LastName;
				employee.PhoneNumber = request.request.PhoneNumber;
				employee.Department = request.request.Department;
				employee.Designation = request.request.Designation;
				employee.Email = request.request.Email;
				employee.UpdatedAt = DateTime.UtcNow;

				var result = _context.Employees.Update(employee);
				await _context.SaveChangesAsync();

				return new UpdateEmployeeResponse(employee.ToDTO());
			}
			catch (Exception ex)
			{
				return new UpdateEmployeeResponse(new ErrorResponse
				{
					Title = "Failed",
					Details = "Failed to update employee.",
					ExceptionMessage = ex.ToString()
				});
			}
			
		}
	}
}
