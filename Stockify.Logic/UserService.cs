using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Stockify.Data;
using Stockify.Objects;

namespace Stockify.Logic;

/// <summary>
/// Service responsible for managing users via ASP.NET Identity's UserManager.
/// Supports CRUD operations, pagination, and password resets.
/// </summary>
public class UserService : IUserService
{
    private readonly UserManager<ApplicationUser> _userManager;

    public UserService(UserManager<ApplicationUser> userManager)
    {
        _userManager = userManager;
    }

    /// <summary>
    /// Retrieves all users.
    /// </summary>
    public async Task<List<ApplicationUser>> GetAllAsync()
    {
        return await _userManager.Users.ToListAsync();
    }

    /// <summary>
    /// Retrieves a user by their ID.
    /// </summary>
    public async Task<ApplicationUser?> GetByIdAsync(string id)
    {
        return await _userManager.Users.FirstOrDefaultAsync(u => u.Id == id);
    }

    /// <summary>
    /// Creates a new user with the provided email and password.
    /// </summary>
    public async Task<IdentityResult> AddAsync(string email, string password)
    {
        var user = new ApplicationUser
        {
            UserName = email,
            Email = email
        };

        var result = await _userManager.CreateAsync(user, password);
        return result;
    }

    /// <summary>
    /// Updates an existing user's email and username by their ID.
    /// </summary>
    public async Task<IdentityResult> UpdateAsync(string id, string email)
    {
        var user = await _userManager.FindByIdAsync(id);
        if (user == null)
            return IdentityResult.Failed(new IdentityError { Description = "User not found." });

        user.UserName = email;
        user.Email = email;

        return await _userManager.UpdateAsync(user);
    }

    /// <summary>
    /// Resets a user's password by their ID.
    /// </summary>
    public async Task<IdentityResult> UpdatePasswordAsync(string id, string password)
    {
        var user = await _userManager.FindByIdAsync(id);
        if (user == null)
            return IdentityResult.Failed(new IdentityError { Description = "User not found." });

        var resetToken = await _userManager.GeneratePasswordResetTokenAsync(user);
        var result = await _userManager.ResetPasswordAsync(user, resetToken, password);

        return result;
    }

    /// <summary>
    /// Deletes a user by passing an ApplicationUser instance.
    /// </summary>
    public async Task<IdentityResult> DeleteAsync(ApplicationUser user)
    {
        return await _userManager.DeleteAsync(user);
    }

    /// <summary>
    /// Deletes a user by their ID.
    /// </summary>
    public async Task<IdentityResult> DeleteByIdAsync(string id)
    {
        var user = await _userManager.FindByIdAsync(id);
        if (user == null)
            return IdentityResult.Failed(new IdentityError { Description = "User not found." });

        return await _userManager.DeleteAsync(user);
    }

    /// <summary>
    /// Returns a paginated list of users with optional sorting.
    /// </summary>
    public async Task<PaginatedResult<ApplicationUser>> GetPagedAsync(int pageNumber, int pageSize, string sortBy, bool ascending)
    {
        var query = _userManager.Users.AsQueryable();

        // Apply sorting
        query = (sortBy.ToLower(), ascending) switch
        {
            ("name", true) => query.OrderBy(u => u.UserName),
            ("name", false) => query.OrderByDescending(u => u.UserName),
            _ => query.OrderBy(u => u.UserName) // default
        };

        var totalCount = await query.CountAsync();

        var items = await query
            .Skip((pageNumber - 1) * pageSize)
            .Take(pageSize)
            .ToListAsync();

        return new PaginatedResult<ApplicationUser>
        {
            Items = items,
            TotalCount = totalCount
        };
    }
}



/*
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Stockify.Data;
using Stockify.Objects;
namespace Stockify.Logic;

public class UserService : IUserService
{
    private readonly UserManager<ApplicationUser> _userManager;

    public UserService(UserManager<ApplicationUser> userManager)
    {
        _userManager = userManager;
    }

    public async Task<List<ApplicationUser>> GetAllAsync()
    {
        return await _userManager.Users.ToListAsync();
    }

    public async Task<ApplicationUser?> GetByIdAsync(string id)
    {
        return await _userManager.Users.FirstOrDefaultAsync(u => u.Id == id);
    }

    public async Task<IdentityResult> AddAsync(string email, string password)
    {
        var user = new ApplicationUser
        {
            UserName = email,
            Email = email
        };

        var result = await _userManager.CreateAsync(user, password);

        return result; // You can check result.Succeeded or return errors
    }

    public async Task<IdentityResult> UpdateAsync(string id, string email)
    {
        var user = await _userManager.FindByIdAsync(id);

        if (user == null)
            return IdentityResult.Failed(new IdentityError { Description = "User not found." });

        user.UserName = email;
        user.Email = email;

        return await _userManager.UpdateAsync(user);
    }

    public async Task<IdentityResult> UpdatePasswordAsync(string id, string password)
    {
        var user = await _userManager.FindByIdAsync(id);
        if (user == null)
            return IdentityResult.Failed(new IdentityError { Description = "User not found." });

        var resetToken = await _userManager.GeneratePasswordResetTokenAsync(user);
        var result = await _userManager.ResetPasswordAsync(user, resetToken, password);

        return result;
    }


    public async Task<IdentityResult> DeleteAsync(ApplicationUser user)
    {
        return await _userManager.DeleteAsync(user);
    }


    public async Task<IdentityResult> DeleteByIdAsync(string id)
    {
        var user = await _userManager.FindByIdAsync(id);
        if (user == null)
            return IdentityResult.Failed(new IdentityError { Description = "User not found." });
        return await _userManager.DeleteAsync(user);
    }

    public async Task<PaginatedResult<ApplicationUser>> GetPagedAsync(int pageNumber, int pageSize, string sortBy, bool ascending)
    {
        var query = _userManager.Users.AsQueryable();

        // Apply sorting
        query = (sortBy.ToLower(), ascending) switch
        {
            ("name", true) => query.OrderBy(u => u.UserName),
            ("name", false) => query.OrderByDescending(u => u.UserName),
            _ => query.OrderBy(u => u.UserName) // default
        };

        var totalCount = await query.CountAsync();

        var items = await query
            .Skip((pageNumber - 1) * pageSize)
            .Take(pageSize)
            .ToListAsync();

        return new PaginatedResult<ApplicationUser>
        {
            Items = items,
            TotalCount = totalCount
        };
    }
}
*/