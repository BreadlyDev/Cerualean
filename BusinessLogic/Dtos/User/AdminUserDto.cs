using System.ComponentModel.DataAnnotations;

namespace BusinessLogic.Dtos.User;

public record AdminUserDto(
    [EmailAddress] string Email,
    string Password
);
