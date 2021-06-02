using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using project.Models;

namespace project.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
       
        public DbSet<project.Models.Category> Category { get; set; }
        public DbSet<project.Models.MyOrder> MyOrder { get; set; }
        public DbSet<project.Models.Order> Order { get; set; }
        public DbSet<project.Models.Product> Product { get; set; }
        
    }
}
