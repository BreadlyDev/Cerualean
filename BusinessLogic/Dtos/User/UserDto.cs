using System.ComponentModel.DataAnnotations;

namespace BusinessLogic.Dtos.User;

public record UserDto(
	string UserName,
	[EmailAddress]
	string Email
);