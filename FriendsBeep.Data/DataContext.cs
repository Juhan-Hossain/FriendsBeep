
using FriendsBeep.Entities.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace FriendsBeep.Data
{
    public class DataContext : DbContext
    {
        public DataContext( DbContextOptions options) : base(options)
        {

        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Data Source=BS-161\\SQLEXPRESS;" + "Initial Catalog=FriendsBeep;" + "Integrated Security=True;" + "MultipleActiveResultSets = True;");
            }
        }


        public DbSet<AppUser> Users { get; set; }
        public DbSet<Message> Messages { get; set; }
    }
}
