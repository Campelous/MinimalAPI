using Microsoft.EntityFrameworkCore;
using WebApiMinimal.Context;
using WebApiMinimal.Models;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();

builder.Services.AddDbContext<Context>
    (options => options.UseSqlServer
    ("Data Source=DESKTOP-L4QJGKA;Initial Catalog=MINIMAL_API;User ID=sa;Password=1234   "));

builder.Services.AddSwaggerGen();

var app = builder.Build();

app.UseSwagger();

app.MapPost("AdicionaProduto", async (Produto produto, Context context) =>
{
    context.Produto.Add(produto);
    await context.SaveChangesAsync();
}
    );

app.MapDelete("ExcluirProduto/{Id}", async (int id, Context context) =>
{
    var produtoExcluir = await context.Produto.FirstOrDefaultAsync(p=>p.Id == id);
    if (produtoExcluir != null)
    {
        context.Produto.Remove(produtoExcluir);
        await context.SaveChangesAsync();
    }
}
    );

app.MapPost("ListarProdutos", async ( Context context) =>
{
   return await context.Produto.ToListAsync();
}
    );

app.MapPost("ObterProduto/{Id}", async (int id, Context context) =>
{
   return await context.Produto.FirstOrDefaultAsync(p => p.Id == id);
}
    );

app.UseSwaggerUI();

app.Run();
