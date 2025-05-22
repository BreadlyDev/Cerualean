using DataAccess.Entities;
using DataAccess.Enums;

namespace DataAccess.Abstractions;

public interface IUserRepository
{
    Task AddAsync(UserEntity user, CancellationToken cancellationToken = default);
    Task<UserEntity?> GetByIdAsync(int id, CancellationToken cancellationToken = default);
    Task<UserEntity?> GetByUserNameAsync(string userName, CancellationToken cancellationToken = default);
    Task<UserEntity?> GetByEmailAsync(string email, CancellationToken cancellationToken = default);
    Task UpdateByIdAsync(int id, UserEntity user, CancellationToken cancellationToken = default);
    Task DeleteByIdAsync(int id, CancellationToken cancellationToken = default);
    Task<HashSet<Permission>> GetPermissionsAsync(int userId);
}

