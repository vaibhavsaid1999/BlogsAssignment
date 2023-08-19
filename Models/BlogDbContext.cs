using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace BlogManagement.Models
{
    public class BlogDbContext : DbContext
    {
        public BlogDbContext() : base(ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString)
        {
        }
        public DbSet<Post> Posts { get; set; }
       
    }
}