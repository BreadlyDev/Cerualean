using BusinessLogic.Dtos.User;

namespace BusinessLogic.Abstractions;

public interface IUserService
{
	Task Register(RegisterUserDto registerDto, CancellationToken cancellationToken = default);
	Task<string> Login(LoginUserDto loginDto, CancellationToken cancellationToken = default);
	Task RegisterAdmin(AdminUserDto adminDto, CancellationToken cancellationToken = default);
	Task<UserDto> GetById(int id, CancellationToken cancellationToken = default);
}

