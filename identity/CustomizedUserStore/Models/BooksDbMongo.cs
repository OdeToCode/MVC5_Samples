using MongoDB.Bson.Serialization;
using MongoDB.Driver;

namespace CustomizedUserStore.Models
{
    public class BooksDbMongo
    {
        private readonly MongoDatabase _db;

        static BooksDbMongo()
        {
            BsonClassMap.RegisterClassMap<User>(cm =>
            {
                cm.AutoMap();
                cm.MapIdField(u => u.Id);
            });
        }

        public BooksDbMongo()
        {
            // assume connection to localhost
            var client = new MongoClient();
            _db = client.GetServer().GetDatabase("MvcIdentityUserStore");            
        }

        public MongoCollection<User> Users
        {
            get
            {
                return _db.GetCollection<User>("users");
            }
        }

        public MongoCollection<Book> Books
        {
            get
            {
                return _db.GetCollection<Book>("books");
            }
        }
    }
}