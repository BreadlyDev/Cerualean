using DataAccess.Enums;

namespace BusinessLogic.Abstractions;

public interface IPermissionService
{
    Task<HashSet<Permission>> GetPermissionsAsync(int userId);
}

