using System.Security.Claims;
using BusinessLogic.Abstractions;

namespace BusinessLogic.Services;

public class CurrentUserService : ICurrentUserService
{
	public int UserId { get; }

	public CurrentUserService(IHttpContextAccessor httpContextAccessor)
	{
		var context = httpContextAccessor.HttpContext;

		var userIdClaim = context?.User?.FindFirst(ClaimTypes.NameIdentifier)
						  ?? throw new UnauthorizedAccessException("User not authenticated");

		UserId = int.Parse(userIdClaim.Value);
	}
}
