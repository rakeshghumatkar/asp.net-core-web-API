using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BookStoreWebAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace BookStoreWebAPI.Data
{
    public class DbContextBook : DbContext
    {
        public DbContextBook(DbContextOptions<DbContextBook> options) : base(options)
        {
        }

        public DbSet<Books> Books {get; set;}
        // Oneway to write Connection string
        // protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        // {
        //     optionsBuilder.UseSqlServer("Server=.;Database=BookStoreAPI;Integrated Security = true");
        //     base.OnConfiguring(optionsBuilder);
        // }
    }
}