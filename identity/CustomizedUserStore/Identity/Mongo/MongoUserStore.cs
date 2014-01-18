using System;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;
using CustomizedUserStore.Models;
using Microsoft.AspNet.Identity;
using MongoDB.Bson;
using MongoDB.Driver.Builders;
using MongoDB.Driver.Linq;

namespace CustomizedUserStore.Identity.Mongo
{
    public class MongoUserStore : IUserPasswordStore<User> 
    {
        private readonly BooksDbMongo _db;

        public MongoUserStore(BooksDbMongo db)
        {
            _db = db;
        }     

        public Task CreateAsync(User user)
        {
            user.Id = ObjectId.GenerateNewId().ToString();
            _db.Users.Insert(user);
            return Task.FromResult(0);
        }

        public Task UpdateAsync(User user)
        {
            _db.Users.Save(user);
            return Task.FromResult(0);
        }

        public Task DeleteAsync(User user)
        {
            _db.Users.Remove(Query<User>.EQ(u => u.UserName, user.UserName));
            return Task.FromResult(0);
        }

        public Task<User> FindByIdAsync(string userId)
        {
            var user = _db.Users.AsQueryable().FirstOrDefault(u => u.Id == userId);
            return Task.FromResult(user);
        }

        public Task<User> FindByNameAsync(string userName)
        {
            var user = _db.Users.AsQueryable().FirstOrDefault(u => u.UserName == userName);
            return Task.FromResult(user);
        }

        public Task SetPasswordHashAsync(User user, string passwordHash)
        {
            _db.Users.Update(
                Query<User>.EQ(u => u.UserName, user.UserName),
                Update<User>.Set(u => u.PasswordHash, passwordHash));
            
            return Task.FromResult(0);
        }

        public Task<string> GetPasswordHashAsync(User user)
        {
            return Task.FromResult(user.PasswordHash);
        }

        public Task<bool> HasPasswordAsync(User user)
        {
            return Task.FromResult(!String.IsNullOrEmpty(user.PasswordHash));
        }

        public void Dispose()
        {

        }
    }
}