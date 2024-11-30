using employee.contract.Models.Employee;
using MediatR;

namespace employee.web.api.Features.Employee.AddEmployeeFeature
{
	public record Command(AddEmployeeRequest request) : IRequest<AddEmployeeResponse>;
}
