using Microsoft.EntityFrameworkCore;

namespace Course9;

public class Program
{
    static async Task Main(string[] args)
    {
        ETicaretContext context = new();

        //Uncomment to seed data.
        //SeedData(context);

        Product product1 = await context.Products.FirstOrDefaultAsync(p => p.Name == "Bob") ?? new();
        context.Entry(product1).State = EntityState.Detached;

        Product product2 = product1;
        product2.Id = Guid.NewGuid();
        product2.Price = 401;
        await context.AddAsync(product2);

        await context.SaveChangesAsync();
    }

    public async Task SeedData(ETicaretContext context)
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


public class ETicaretContext : DbContext
{
    public DbSet<Product> Products { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        base.OnConfiguring(optionsBuilder);
        optionsBuilder.UseSqlServer("Data Source=DEIMOS-CM\\SQLEXPRESS;Database=EFCoreGencay;Trusted_Connection=True;Trust Server Certificate=True;");
    }
}

public class Product
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public int Price { get; set; }
    public int Quantity { get; set; }
}
