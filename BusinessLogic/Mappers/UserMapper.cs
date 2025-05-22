using BusinessLogic.Dtos.User;
using DataAccess.Entities;

namespace BusinessLogic.Mappers;

public static class UserMapper
{
	public static UserEntity ToUserFromRegisterDto(this RegisterUserDto registerDto)
	{
		var user = new UserEntity
		{
			Email = registerDto.Email,
			UserName = registerDto.UserName,
			HashedPassword = string.Empty
		};

		return user;
	}

	public static UserEntity ToUserFromLoginDto(this LoginUserDto loginDto)
	{
		var user = new UserEntity
		{
			Email = loginDto.Email,
			HashedPassword = string.Empty
		};

		return user;
	}

	public static UserEntity ToUserFromAdminDto(this AdminUserDto adminDto)
	{
		var user = new UserEntity
		{
			Email = adminDto.Email,
			HashedPassword = String.Empty
		};

		return user;
	}

	public static UserDto ToUserDto(this UserEntity userEntity)
	{
		return new UserDto(
			userEntity.UserName,
			userEntity.Email
		);
	}
}

