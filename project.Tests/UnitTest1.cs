using System;
using Xunit;
using project.Models;
using project.Data;

namespace project.Tests
{
    public class DummyDataDBInitializer
    {
        public DummyDataDBInitializer()
        {
        }



        public void Seed(ApplicationDbContext context)
        {
            context.Database.EnsureDeleted();
            context.Database.EnsureCreated();

            context.Category.AddRange(
                new Category() { Name = "Phone" },
                new Category() { Name = "TV" },
                new Category() { Name = "Laptop" },
                new Category() { Name = "Radio" }
            );

            context.Product.AddRange(
                new Product() { Name = "Apple XS MAX", ShortDescription = "Test Description 1", LongDescriprion = "Test Description 1",CategoryId = 1, Price = 5000, IsPreferred =true },
                new Product() {Name = "Apple XS MAX", ShortDescription = "Test Description 1", LongDescriprion = "Test Description 1", CategoryId = 1, Price = 5000, IsPreferred = true }
            );


            context.Order.AddRange(
               new Order() { Username = "User", ProductId =1, DateTime = DateTime.Now,  Count = 4, Total = 2500 },
               new Order() { Username = "User", ProductId = 1, DateTime = DateTime.Now, Count = 4, Total = 2500 }
           );
            context.MyOrder.AddRange(
              new MyOrder() { UserId = 1, ProductId = 1, DateTime = DateTime.Now, Count = 4, Total = 2500 },
              new MyOrder() { UserId = 1, ProductId = 1, DateTime = DateTime.Now, Count = 4, Total = 2500 }
          );
            context.SaveChanges();
        }
    }
}
