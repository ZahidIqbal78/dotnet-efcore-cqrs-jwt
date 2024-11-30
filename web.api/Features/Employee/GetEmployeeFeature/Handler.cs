using employee.contract.Models;
using employee.contract.Models.Employee;
using employee.web.api.Contexts;
using employee.web.api.ModelExtensions.Employee;
using MediatR;

namespace employee.web.api.Features.Employee.GetEmployeeFeature
{
	public class Handler : IRequestHandler<Query, GetEmployeeResponse>
	{
		private readonly DatabaseContext _context;

		public Handler(DatabaseContext context)
		{
			_context = context;
		}

		public async Task<GetEmployeeResponse> Handle(Query request, CancellationToken cancellationToken = default)
		{
			var employee = await _context.Employees.FindAsync(request.request.Id);
			if (employee == null)
			{
				return new GetEmployeeResponse(new ErrorResponse
				{
					Title = "Not Found",
					Details = "Employee with Id not found."
				});
			}
			return new GetEmployeeResponse(employee.ToDTO());
		}
	}
}
