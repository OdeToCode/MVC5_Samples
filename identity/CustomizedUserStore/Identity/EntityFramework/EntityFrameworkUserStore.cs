using System;
using System.Data.Entity;
using System.Threading.Tasks;
using CustomizedUserStore.Models;
using Microsoft.AspNet.Identity;

namespace CustomizedUserStore.Identity.EntityFramework
{
    public class EntityFrameworkUserStore : IUserPasswordStore<User> 
    {
        readonly DbContext _db;
        readonly DbSet<User> _users;

        public EntityFrameworkUserStore(DbContext db)
        {
            _db = db;
            _users = _db.Set<User>();
        }

        public Task CreateAsync(User user)
        {
            user.Id = Guid.NewGuid().ToString();
            _users.Add(user);
            return _db.SaveChangesAsync();
        }

        public Task UpdateAsync(User user)
        {
            return _db.SaveChangesAsync();
        }

        public Task DeleteAsync(User user)
        {
            _users.Remove(user);
            return _db.SaveChangesAsync();
        }

        public Task<User> FindByIdAsync(string userId)
        {
            return _users.FindAsync(userId);
        }

        public Task<User> FindByNameAsync(string userName)
        {
            return _users.FirstOrDefaultAsync(u => u.UserName == userName);
        }

        public void Dispose()
        {
            // Context was passed to us, assume someone else will dispose
        }

        public Task SetPasswordHashAsync(User user, string passwordHash)
        {
            user.PasswordHash = passwordHash;
            return _db.SaveChangesAsync();
        }

        public Task<string> GetPasswordHashAsync(User user)
        {
            return Task.FromResult(user.PasswordHash);
        }

        public Task<bool> HasPasswordAsync(User user)
        {
            return Task.FromResult(!String.IsNullOrEmpty(user.PasswordHash));
        }
    }
}