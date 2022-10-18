using EBackEnd.Data;
using EBackEnd.Service;
using FluentAssertions.Common;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

builder.Services.AddScoped<IClienteService, ClientesService>();
builder.Services.AddScoped<IProdutoService, ProdutosService>();
builder.Services.AddScoped<IVendaService, VendasService>();

builder.Services.AddDbContext<EwaveDbContext>
    (options => options.UseSqlServer
    (connectionString: "Server=WINDOWS11\\SQLEXPRESS; Database=EwaveCrud; Trusted_Connection=True;"));

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseCors(options =>
{
    options.WithOrigins("http://localhost:3000");
    options.AllowAnyMethod();
    options.AllowAnyHeader();
});

app.UseAuthorization();

app.MapControllers();

app.Run();
