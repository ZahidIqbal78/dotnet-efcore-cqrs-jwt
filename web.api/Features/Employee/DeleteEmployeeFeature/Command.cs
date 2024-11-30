using employee.contract.Models.Employee;
using MediatR;

namespace employee.web.api.Features.Employee.DeleteEmployeeFeature
{
	public record Command(DeleteEmployeeRequest request) : IRequest<DeleteEmployeeResponse>;
}
