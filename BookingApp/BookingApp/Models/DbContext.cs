using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Security.AccessControl;
using System.Web;
using Microsoft.AspNet.Identity.EntityFramework;

namespace BookingApp.Models
{
    public class DBContext : DbContext 
    {   
        public  DbSet<AppUser> AppUsers { get; set; }

        public  DbSet<User> Users { get; set; }

        public DBContext() : base("name=DdName")
        {            
        }

        public static DBContext Create()
        {
            return new DBContext();
        }
    }
}