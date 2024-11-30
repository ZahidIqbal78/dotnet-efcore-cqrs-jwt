using employee.contract.Models.Employee;
using MediatR;

namespace employee.web.api.Features.Employee.UpdateEmployeeFeature
{
	public record Command(UpdateEmployeeRequest request) : IRequest<UpdateEmployeeResponse>;
}
