using employee.contract.Models.Employee;
using employee.web.api.Contexts;
using employee.web.api.ModelExtensions.Employee;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace employee.web.api.Features.Employee.GetAllEmployeeFeature
{
	public class Handler : IRequestHandler<Query, GetAllEmployeeResponse>
	{
		private readonly DatabaseContext _context;

		public Handler(DatabaseContext context)
		{
			_context = context;
		}

		public async Task<GetAllEmployeeResponse> Handle(Query request, CancellationToken cancellationToken = default)
		{
			var employees = await _context.Employees.ToListAsync(cancellationToken);
			return new GetAllEmployeeResponse(employees.ToListDTO(), employees.Count);
		}
	}
}
