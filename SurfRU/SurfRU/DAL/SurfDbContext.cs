using System;
using System.Data.Entity;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SurfRU.Models.DBModels;

namespace SurfRU.DAL
{
    public class SurfDbContext : DbContext
    {
        static SurfDbContext()
        {
            Database.SetInitializer(new SurfDbInitializer());
        }

        public SurfDbContext() : base("SurfRUDatabase")
        { }

        public DbSet<User> Users { get; set; }

        public DbSet<Post> Posts { get; set; }
    }
}