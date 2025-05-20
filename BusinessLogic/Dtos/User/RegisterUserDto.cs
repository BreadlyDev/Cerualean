using System.ComponentModel.DataAnnotations;

namespace BusinessLogic.Dtos.User;

public record RegisterUserDto(
    string UserName,
    [EmailAddress]
    string Email,
    string Password
);

