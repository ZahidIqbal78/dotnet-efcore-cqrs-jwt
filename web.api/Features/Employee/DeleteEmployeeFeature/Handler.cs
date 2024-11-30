using employee.contract.Models;
using employee.contract.Models.Employee;
using employee.web.api.Contexts;
using MediatR;

namespace employee.web.api.Features.Employee.DeleteEmployeeFeature
{
	public class Handler : IRequestHandler<Command, DeleteEmployeeResponse>
	{
		private readonly DatabaseContext _context;

		public Handler(DatabaseContext context)
		{
			_context = context;
		}

		public async Task<DeleteEmployeeResponse> Handle(Command request, CancellationToken cancellationToken)
		{
			var employee = await _context.Employees.FindAsync(request.request.Id);

			if (employee == null)
			{
				return new DeleteEmployeeResponse(new ErrorResponse
				{
					Title = "Not Found",
					Details = "Employee with Id not found."
				});
			}

			try
			{
				_context.Employees.Remove(employee);
				await _context.SaveChangesAsync();
				return new DeleteEmployeeResponse(true);
			}
			catch (Exception ex)
			{
				return new DeleteEmployeeResponse(new ErrorResponse
				{
					Title = "Failed",
					Details = "Failed to delete employee.",
					ExceptionMessage = ex.ToString()
				});
			}
		}
	}
}
