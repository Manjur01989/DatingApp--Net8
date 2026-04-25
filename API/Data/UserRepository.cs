using System;
using API.Entities;
using API.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace API.Data;

public class UserRepository(AppDbContext _context) : IUserRepository
{
    //public async Task<AppUser?> GetUserByIdAsync(int id)
    //{
    //    return await _context.Users.Include(x => x.Photos).FirstOrDefaultAsync(x => x.Id == id);
    //}

    //public async Task<IEnumerable<AppUser?>> GetUserByUsernameAsyncList(string username)
    //{
    //    return await _context.Users
    //    .Include(x => x.Photos).Where(x => x.UserName == username).ToListAsync();
    //}

    //public async Task<AppUser?> GetUserByUsernameAsync(string username)
    //{
    //    return await _context.Users
    //    .Include(x => x.Photos).SingleOrDefaultAsync(x => x.UserName == username);
    //}

    //public async Task<IEnumerable<AppUser>> GetUsersAsync()
    //{
    //    return await _context.Users.Include(x => x.Photos).ToListAsync();
    //}

    //public async Task<bool> SaveAllAsync()
    //{
    //    return await _context.SaveChangesAsync() > 0;
    //}

    //public void Update(AppUser user)
    //{
    //    _context.Entry(user).State = EntityState.Modified;
    //}
    public Task<AppUser?> GetUserByIdAsync(int id)
    {
        throw new NotImplementedException();
    }

    public Task<AppUser?> GetUserByUsernameAsync(string username)
    {
        throw new NotImplementedException();
    }

    public Task<IEnumerable<AppUser?>> GetUserByUsernameAsyncList(string username)
    {
        throw new NotImplementedException();
    }

    public Task<IEnumerable<AppUser>> GetUsersAsync()
    {
        throw new NotImplementedException();
    }

    public Task<bool> SaveAllAsync()
    {
        throw new NotImplementedException();
    }

    public void Update(AppUser user)
    {
        throw new NotImplementedException();
    }
}
