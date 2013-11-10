using Microsoft.AspNet.Identity;
using MongoDB.Bson.Serialization.Attributes;

namespace CustomizedUserStore.Models
{
    public class User : IUser
    {        
        public string Id { get; set; }
        public string UserName { get; set; }
        public string PasswordHash { get; set; }
    }
}