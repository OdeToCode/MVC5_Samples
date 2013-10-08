using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace CustomizedMemebershipModel.Models
{
    public class MovieDb : IdentityDbContext
    {
        public MovieDb() : base("DefaultConnection")
        {

        }

        public DbSet<Movie> Movies { get; set; }
    }
}