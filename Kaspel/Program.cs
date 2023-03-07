using DataBase.Repository;
using Kaspel.Context;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<KaspelContext>(context =>
{
    // SQLite использовал т.к не установлен MSSQL на ноутбук.
    // Т.к используется EF, то это легко менятется
    context.UseSqlite("Data Source = kaspel.db");
});
builder.Services.AddScoped<IKaspelRepository, KaspelRepository>();
builder.Services.AddControllers().AddNewtonsoftJson();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();