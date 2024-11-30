using employee.contract.Models.User;
using MediatR;

namespace employee.web.api.Features.User.LoginUserFeature
{
	public record Query(LoginUserRequest request): IRequest<LoginUserTokenResponse>;
}
