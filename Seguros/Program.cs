using Microsoft.EntityFrameworkCore;
using Seguros.Application.Interfaces;
using Seguros.Application.UseCases;
using Seguros.Infrastructure.Data;
using Seguros.Infrastructure.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Controllers + Swagger
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// SQLite (appsettings.json -> ConnectionStrings:DefaultConnection)
builder.Services.AddDbContext<SegurosDbContext>(opt =>
{
    var cs = builder.Configuration.GetConnectionString("DefaultConnection");
    opt.UseSqlite(cs);
});

// DI (Application + Infrastructure)
builder.Services.AddScoped<ISeguroRepository, SeguroRepository>();
builder.Services.AddScoped<SeguroService>();

var app = builder.Build();

// Cria o banco automaticamente (simples pro teste)
using (var scope = app.Services.CreateScope())
{
    var db = scope.ServiceProvider.GetRequiredService<SegurosDbContext>();
    db.Database.EnsureCreated();
}

app.UseStaticFiles();

// Swagger
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();

app.Run();
