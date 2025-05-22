using BusinessLogic.Abstractions;
using BusinessLogic.Dtos.User;
using BusinessLogic.Mappers;
using DataAccess.Abstractions;
using DataAccess.Enums;
using Infrastructure.Abstractions;

namespace BusinessLogic.Services;

internal class UserService(
    IUserRepository userRepository,
    IPasswordHasher passwordHasher,
    IJwtProvider jwtProvider
) : IUserService
{
    public async Task<UserDto> GetById(int id, CancellationToken cancellationToken = default)
    {
        var user = await userRepository.GetByIdAsync(id, cancellationToken);
        return user!.ToUserDto();
    }

    public async Task<string> Login(
        LoginUserDto loginDto,
        CancellationToken cancellationToken = default
    )
    {
        var user = await userRepository.GetByEmailAsync(loginDto.Email, cancellationToken);
        if (user == null)
        {
            throw new BadHttpRequestException("User not found");
        }

        var result = passwordHasher.Verify(loginDto.Password, user.HashedPassword);
        if (result == false)
        {
            throw new BadHttpRequestException("Wrong credentials");
        }

        var token = jwtProvider.GenerateToken(user);

        return token;
    }

    public async Task Register(
        RegisterUserDto registerDto,
        CancellationToken cancellationToken = default
    )
    {
        var hashedPassword = passwordHasher.Generate(registerDto.Password);

        var user = registerDto.ToUserFromRegisterDto();
        user.RoleId = (int)Role.User;
        user.HashedPassword = hashedPassword;

        await userRepository.AddAsync(user, cancellationToken);
    }

    public async Task RegisterAdmin(
        AdminUserDto adminDto,
        CancellationToken cancellationToken = default
    )
    {
        var hashedPassword = passwordHasher.Generate(adminDto.Password);

        var user = adminDto.ToUserFromAdminDto();
        user.RoleId = (int)Role.Admin;
        user.HashedPassword = hashedPassword;

        await userRepository.AddAsync(user, cancellationToken);
    }
}
