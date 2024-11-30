using employee.contract.Models.Employee;
using MediatR;

namespace employee.web.api.Features.Employee.GetAllEmployeeFeature
{
	public record Query() : IRequest<GetAllEmployeeResponse>;
}
