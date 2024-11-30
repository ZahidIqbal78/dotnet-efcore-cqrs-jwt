using employee.contract.Models.Employee;
using employee.web.api.Contexts;
using employee.web.api.Entities;
using employee.web.api.ModelExtensions.Employee;
using MediatR;

namespace employee.web.api.Features.Employee.AddEmployeeFeature
{
	public class Handler : IRequestHandler<Command, AddEmployeeResponse>
	{
		private readonly DatabaseContext _context;

		public Handler(DatabaseContext context)
		{
			_context = context;
		}

		public async Task<AddEmployeeResponse> Handle(Command request, CancellationToken cancellationToken = default)
		{
			try
			{
				var employee = new EmployeeEntity();
				employee = request.request.ToEntity();
				employee.CreatedAt = DateTime.UtcNow;
				employee.UpdatedAt = DateTime.UtcNow;
				_context.Employees.Add(employee);
				await _context.SaveChangesAsync(cancellationToken);
				return new AddEmployeeResponse(employee.ToDTO());
			}
			catch (Exception ex)
			{
				return new AddEmployeeResponse(new contract.Models.ErrorResponse
				{
					Title = "Failed",
					Details = "Failed to add employee.",
					ExceptionMessage = ex.ToString()
				});
			}
		}
	}
}
