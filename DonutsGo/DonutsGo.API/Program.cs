using DonutsGo.Application.Services;
using DonutsGo.DataAccess;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<IProductService,ProductService>();


//builder.Services.AddTransient<IDataAccessDemo, DataAccessDemo>();
//builder.Services.AddScoped<IDataAccessDemo, DataAccessDemo>();
builder.Services.AddSingleton<IDataAccessDemo, DataAccessDemo>();




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

app.Run();
