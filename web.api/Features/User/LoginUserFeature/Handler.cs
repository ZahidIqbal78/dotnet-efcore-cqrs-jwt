using employee.contract.Models;
using employee.contract.Models.User;
using employee.web.api.Contexts;
using employee.web.api.Services;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace employee.web.api.Features.User.LoginUserFeature
{
	public class Handler : IRequestHandler<Query, LoginUserTokenResponse>
	{
		private readonly DatabaseContext _context;
		private readonly IConfiguration _configuration;

		public Handler(DatabaseContext context, IConfiguration configuration)
		{
			_context = context;
			_configuration = configuration;
		}

		public async Task<LoginUserTokenResponse> Handle(Query request, CancellationToken cancellationToken)
		{
			var user = await _context.Users.FirstOrDefaultAsync(user => user.Email == request.request.Email);
			if (user == null)
			{
				return new LoginUserTokenResponse(new ErrorResponse
				{
					Title = "Not Found",
					Details = "User not found."
				});
			}

			if (!UserCredentialService.VerifyPassword(request.request.Password, user.PasswordHash))
			{
				return new LoginUserTokenResponse(new ErrorResponse
				{
					Title = "Invalid credentials",
					Details = "The provided user credentials do not match."
				});
			}

			var token = JwtService.GenerateToken(user, _configuration);
			return new LoginUserTokenResponse(token);
		}
	}
}
