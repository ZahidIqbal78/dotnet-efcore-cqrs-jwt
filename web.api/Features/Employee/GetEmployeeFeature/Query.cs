using employee.contract.Models.Employee;
using MediatR;

namespace employee.web.api.Features.Employee.GetEmployeeFeature
{
	public record Query(GetEmployeeRequest request) : IRequest<GetEmployeeResponse>;
}