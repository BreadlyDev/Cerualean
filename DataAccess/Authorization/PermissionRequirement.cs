using DataAccess.Enums;
using Microsoft.AspNetCore.Authorization;

namespace DataAccess.Authorization;

public class PermissionRequirement(Permission[] permissions) : IAuthorizationRequirement
{
    public Permission[] Permissions { get; set; } = permissions;
}

