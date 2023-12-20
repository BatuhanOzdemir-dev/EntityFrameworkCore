using Microsoft.EntityFrameworkCore;

namespace Course9;

public class Program
{
    static async Task Main(string[] args)
    {
        ETicaretContext context = new();

        Product product1 = await context.Products.FirstOrDefaultAsync(p => p.Name == "Kapı2") ?? new();
        context.Entry(product1).State = EntityState.Detached;

        Product product2 = product1;
        product2.Id = Guid.NewGuid();
        product2.Price = 401;
        await context.AddAsync(product2);

        await context.SaveChangesAsync();
    }
}