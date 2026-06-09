using DataBaseFirst.Data;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<G8DatabaseFirstContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

//app.MapGet("api/Clientes", async (G8DatabaseFirstContext context) =>
//{
//    var lista = await context.Clientes
//    .AsNoTracking()
//    .ToListAsync();

//    return Results.Ok(lista);
//}).WithDescription("Lista de todos los clientes");

//app.MapPost("api/Clientes", async (G8DatabaseFirstContext context, Cliente cliente) =>
//{
//    context.Clientes.Add(cliente);
//    await context.SaveChangesAsync();

//    return Results.Created($"/api/Clientes/{cliente.IdCliente}", cliente);
//}).WithDescription("Añadir un cliente");

app.MapGet("api/Usuarios", async (G8DatabaseFirstContext context) =>
{
    var lista = await context.Usuarios
    .AsNoTracking()
    .ToListAsync();

    return Results.Ok(lista);
}).WithDescription("Lista de todos los clientes");

app.MapPost("api/Usuarios", async (G8DatabaseFirstContext context, Usuario usuario) =>
{
    context.Usuarios.Add(usuario);
    await context.SaveChangesAsync();

    return Results.Created($"/api/Usuarios/{usuario.Id}", usuario);
}).WithDescription("Añadir un Usuario");

app.Run();
