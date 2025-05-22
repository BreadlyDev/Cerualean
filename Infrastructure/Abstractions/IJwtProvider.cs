using DataAccess.Entities;

namespace Infrastructure.Abstractions;

public interface IJwtProvider
{
    string GenerateToken(UserEntity user);
}

