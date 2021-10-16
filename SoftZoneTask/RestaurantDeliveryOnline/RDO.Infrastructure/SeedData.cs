using RDO.Core.Entities;
using RDO.Infrastructure.DbContexts;
using System;
using System.Collections.Generic;

namespace RDO.Infrastructure
{
    public class SeedData
    {
        private static DateTime now = DateTime.Now;

        private static bool IsDevelopment { get; set; } = true;

        /// <summary>
        /// Initialize the database.
        /// </summary>
        /// <param name="db">The database context.</param>
        /// <param name="isDevelopment">Determine if this is the development environment.</param>
        public static void Initialize(CommandDbContext db, bool isDevelopment)
        {

            if (db is null)
            {
                throw new ArgumentNullException(nameof(db));
            }

            IsDevelopment = isDevelopment;
            db.Restaurants.AddRange(CreatRestaurants());
            db.SaveChanges();

        }


        private static Restaurant[] CreatRestaurants()
        {
            var restaurants = new List<Restaurant>();

            if (IsDevelopment)
            {
                var devRestaurants = new[]
                {
                    new Restaurant
                    {
                        Id = 1,
                        CreatedOn = now,
                        Name = "A",
                        City = "Egypt",
                        Description="This is the best",
                        Image="01.jpg",
                        Menu=
                        {
                            new Product {Id=1,Name="a1",Description="aaa",Price=10,Image= "01.jpg" },
                            new Product { Id=2,Name = "a1", Description = "aaa", Price = 10, Image = "02.jpg" },
                            new Product { Id=3,Name = "a1", Description = "aaa", Price = 20, Image = "02.jpg" },
                            new Product { Id=4,Name = "a1", Description = "aaa", Price = 10, Image = "03.jpg" },
                            new Product { Id=5,Name = "a1", Description = "aaa", Price = 10, Image = "04.jpg" }
                        }
                    },
                    new Restaurant
                    {
                        Id=2,
                        CreatedOn = now,
                        Name = "B",
                        City = "Egypt",
                        Description="This is the best",
                        Image="02.jpg",
                        Menu=
                        {
                            new Product {Id=6,Name="a1",Description="aaa",Price=10,Image= "02.jpg" },
                            new Product {Id=7, Name = "a1", Description = "aaa", Price = 10, Image = "02.jpg" },
                            new Product { Id=8,Name = "a1", Description = "aaa", Price = 20, Image = "02.jpg" },
                            new Product { Id=9,Name = "a1", Description = "aaa", Price = 10, Image = "03.jpg" },
                            new Product { Id=10,Name = "a1", Description = "aaa", Price = 10, Image = "04.jpg" }
                        }
                    },
                     new Restaurant
                    {
                        Id=3,
                        CreatedOn = now,
                        Name = "C",
                        City = "Egypt",
                        Description="This is the best",
                        Image="03.jpg",
                        Menu=
                        {
                            new Product {Id=11,Name="a1",Description="aaa",Price=10,Image= "03.jpg" },
                            new Product {Id=12, Name = "a1", Description = "aaa", Price = 10, Image = "02.jpg" },
                            new Product { Id=13,Name = "a1", Description = "aaa", Price = 20, Image = "02.jpg" },
                            new Product { Id=14,Name = "a1", Description = "aaa", Price = 10, Image = "03.jpg" },
                            new Product { Id=15,Name = "a1", Description = "aaa", Price = 10, Image = "04.jpg" }
                        }
                    },
                    new Restaurant
                    {
                        Id=4,
                        CreatedOn = now,
                        Name = "D",
                        City = "Egypt",
                        Description="This is the best",
                        Image="04.jpg",
                        Menu=
                        {
                            new Product {Id=16,Name="a1",Description="aaa",Price=10,Image= "04.jpg" },
                            new Product { Id=17,Name = "a1", Description = "aaa", Price = 10, Image = "02.jpg" },
                            new Product { Id=18,Name = "a1", Description = "aaa", Price = 20, Image = "02.jpg" },
                            new Product { Id=19,Name = "a1", Description = "aaa", Price = 10, Image = "03.jpg" },
                            new Product { Id=20,Name = "a1", Description = "aaa", Price = 10, Image = "04.jpg" }
                        }
                    },
                    new Restaurant
                    {
                        Id=5,
                        CreatedOn = now,
                        Name = "D",
                        City = "Egypt",
                        Description="This is the best",
                        Image="05.jpg",
                        Menu=
                        {
                            new Product {Id=21,Name="a1",Description="aaa",Price=10,Image= "05.jpg" },
                            new Product {Id=22, Name = "a1", Description = "aaa", Price = 10, Image = "02.jpg" },
                            new Product { Id=23,Name = "a1", Description = "aaa", Price = 20, Image = "02.jpg" },
                            new Product {Id=24, Name = "a1", Description = "aaa", Price = 10, Image = "03.jpg" },
                            new Product {Id=25, Name = "a1", Description = "aaa", Price = 10, Image = "04.jpg" }
                        }
                    },
                    new Restaurant
                    {
                        Id=6,
                        CreatedOn = now,
                        Name = "D",
                        City = "Egypt",
                        Description="This is the best",
                        Image="06.jpg",
                        Menu=
                        {
                            new Product {Id=26,Name="a1",Description="aaa",Price=10,Image= "06.jpg" },
                            new Product {Id=27, Name = "a1", Description = "aaa", Price = 10, Image = "02.jpg" },
                            new Product {Id=28, Name = "a1", Description = "aaa", Price = 20, Image = "02.jpg" },
                            new Product {Id=29, Name = "a1", Description = "aaa", Price = 10, Image = "03.jpg" },
                            new Product {Id=30, Name = "a1", Description = "aaa", Price = 10, Image = "04.jpg" }
                        }
                    },
                    
                };

                restaurants.AddRange(devRestaurants);
            }

            return restaurants.ToArray();
        }
    }
}
