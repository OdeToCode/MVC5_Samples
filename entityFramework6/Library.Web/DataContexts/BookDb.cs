using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using Library.Entities;
using System.Diagnostics;

namespace Library.Web.DataContexts
{
    public class BookDb : DbContext
    {
        public BookDb() : base("DefaultConnection")
        {
            Database.Log = message => Debug.Write(message);
        }

        public DbSet<Book> Books { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.HasDefaultSchema("library");
            base.OnModelCreating(modelBuilder);
        }
    }
}