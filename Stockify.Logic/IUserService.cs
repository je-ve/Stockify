using Microsoft.AspNetCore.Identity;
using Stockify.Objects;
namespace Stockify.Logic;

public interface IUserService
{
    Task<IdentityResult> AddAsync(string email, string password);
    Task<IdentityResult> DeleteAsync(ApplicationUser user);
    Task<IdentityResult> DeleteByIdAsync(string id);
    Task<List<ApplicationUser>> GetAllAsync();
    Task<ApplicationUser?> GetByIdAsync(string id);
    Task<PaginatedResult<ApplicationUser>> GetPagedAsync(int pageNumber, int pageSize, string sortBy, bool ascending);
    Task<IdentityResult> UpdateAsync(string id, string userName);
    Task<IdentityResult> UpdatePasswordAsync(string id, string password);
}