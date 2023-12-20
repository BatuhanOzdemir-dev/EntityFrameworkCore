using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Course9
{
    public static class DataSeeder
    {
        public static async void SeedData(ETicaretContext context)
        {
            List<Product> products = await context.Products.ToListAsync();
            if (products.Count == 0)
            {
                List<Product> Products = new()
                {
                    new()
                    {
                        Id = Guid.NewGuid(),
                        Name = "Kapı1",
                        Price = 100,
                        Quantity = 20
                    },
                    new()
                    {
                        Id = Guid.NewGuid(),
                        Name = "Kapı2",
                        Price = 200,
                        Quantity = 8
                    },
                    new()
                    {
                        Id = Guid.NewGuid(),
                        Name = "Kapı3",
                        Price = 300,
                        Quantity = 2
                    }
                };

                await context.Products.AddRangeAsync(Products);
                await context.SaveChangesAsync();
            }
        }
    }
}
