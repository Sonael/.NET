using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();

builder.Services.AddSwaggerGen();


builder.Services.AddDbContext<APPDbContext>(options => options.UseInMemoryDatabase("Clientes"));

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
}

app.UseSwagger();

app.MapGet("/Clientes", async (APPDbContext dbContext) => await dbContext.Clientes.ToListAsync());

app.MapGet("/Clientes/{id}", async (int id,APPDbContext dbContext) => 
await dbContext.Clientes.FirstOrDefaultAsync(a => a.Id == id));

app.MapPost("/Clientes", async (Cliente cliente, APPDbContext dbContext) => 
{
    dbContext.Clientes.Add(cliente);
    await dbContext.SaveChangesAsync();

    return cliente;
});

app.MapPut("/Clientes/{id}", async (int id, Cliente cliente, APPDbContext dbContext) => 
{
    dbContext.Entry(cliente).State = EntityState.Modified;
    await dbContext.SaveChangesAsync();

    return cliente;
});

app.MapDelete("/Clientes/{id}", async (int id, APPDbContext dbContext) => 
{
    var cliente = await dbContext.Clientes.FirstOrDefaultAsync(a => a.Id == id);

    if (cliente != null)
    {
        dbContext.Remove(cliente);
        await dbContext.SaveChangesAsync();
    }

    return;
});

app.UseSwaggerUI();

app.Run();

public class Cliente
{
    public int Id { get; set; }

    public string? Nome { get; set; }
}

public class APPDbContext : DbContext
{
    public APPDbContext(DbContextOptions options) : base(options)
    {

    }

    public DbSet<Cliente> Clientes { get; set; }
}