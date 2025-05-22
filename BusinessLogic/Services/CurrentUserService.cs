using BusinessLogic.Abstractions;
using DataAccess.Authorization;

namespace BusinessLogic.Services;

internal class CurrentUserService(IHttpContextAccessor httpContextAccessor) : ICurrentUserService
{
    public int UserId
    {
        get
        {
            var context = httpContextAccessor.HttpContext;
            if (context == null)
            {
                Console.WriteLine("HttpContext is null");
                throw new UnauthorizedAccessException("HttpContext is null");
            }

            var userIdClaim = context.User?.FindFirst(CustomClaims.UserId);

            if (userIdClaim == null)
            {
                Console.WriteLine("User ID claim not found");
                throw new UnauthorizedAccessException("User not authenticated");
            }

            return int.Parse(userIdClaim.Value);
        }
    }
}
