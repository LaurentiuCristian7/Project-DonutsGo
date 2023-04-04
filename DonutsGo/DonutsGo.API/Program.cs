using DonutsGo.Application.Services;
using DonutsGo.DataAccess;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped<IProductService,ProductService>();
builder.Services.AddScoped<IUserService, UserService>();


builder.Services.AddDbContext<DatabaseContext>(options =>
{
    options.UseSqlServer("Data Source=(LocalDb)\\MSSQLLocalDB;Initial Catalog=DonutsGo;Integrated Security=True");
});



var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.UseCors(corsPolicyBuilder =>
{
    corsPolicyBuilder.AllowAnyOrigin()
            .AllowAnyHeader()
            .AllowAnyMethod();
});

app.Run();
