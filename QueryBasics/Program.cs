using Course9;
using Microsoft.EntityFrameworkCore;

ETicaretContext context = new();

var products = await (from prod in context.Products
                      select prod).ToListAsync();

var products2 = await (from prod in context.Products
                       select prod).ToListAsync();

var productSelectMany = await context.Products.SelectMany(p => p.Parts, (p, prt) => new
{
    p.Id,
    p.Name,
    PartName = prt.Name
}).ToListAsync();