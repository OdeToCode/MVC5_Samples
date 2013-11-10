using System.Data.Entity;

namespace CustomizedUserStore.Models
{
    public class BooksDbEf : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Book> Books { get; set; }
    }
}