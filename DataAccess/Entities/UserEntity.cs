using System.ComponentModel.DataAnnotations;

namespace DataAccess.Entities;

public class UserEntity
{
    public int Id { get; set; }
    public string? UserName { get; set; }
    [EmailAddress]
    public required string Email { get; set; }
    public required string HashedPassword { get; set; }

    public int RoleId { get; set; }
    public RoleEntity? Role { get; set; }
}

