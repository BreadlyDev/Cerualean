using BusinessLogic.Abstractions;
using DataAccess.Abstractions;
using DataAccess.Enums;

namespace BusinessLogic.Services;

internal class PermissionService(IUserRepository userRepository) : IPermissionService
{
    public async Task<HashSet<Permission>> GetPermissionsAsync(int userId)
    {
        return await userRepository.GetPermissionsAsync(userId);
    }
}
