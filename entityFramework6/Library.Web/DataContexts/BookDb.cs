using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using Library.Entities;

namespace Library.Web.DataContexts
{
    public class BookDb : DbContext
    {
        public BookDb() : base("DefaultConnection")
        {

        }

        public DbSet<Book> Books { get; set; }
    }
}