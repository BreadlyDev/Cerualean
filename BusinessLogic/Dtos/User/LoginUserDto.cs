using System.ComponentModel.DataAnnotations;

namespace BusinessLogic.Dtos.User;

public record LoginUserDto(
    [EmailAddress]
    string Email,
    string Password
);
