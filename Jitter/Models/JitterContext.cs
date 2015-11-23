using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace Jitter.Models
{
    public class JitterContext : DbContext //knows to use the default connection string
    {
        //IDbSet, IQueryable
        public DbSet<JitterUser> JitterUsers { get; set; }//Created the table in the database
        public DbSet<Jot> Jots { get; set; } 
        //DbContext is controlled by the Data Annotations
    }
}