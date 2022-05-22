using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Data.Entity;

namespace Assignment1_ASP.NET_MVC.Models
{
    public class MyDbContext : DbContext
    {
        public MyDbContext() : base("name = conn")  //it specifies connection string  and should have same name as given in web.sonfig file
        {

        }
        public DbSet<User> Users { get; set; }
    }
}