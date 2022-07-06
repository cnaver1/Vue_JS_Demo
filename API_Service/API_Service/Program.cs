using API_Service.Classes;
using API_Service.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;


var builder = WebApplication.CreateBuilder(args);

var configurationBuilder = new ConfigurationBuilder().AddJsonFile("appsettings.json", optional: false);
// Add services to the container.
builder.Configuration.AddJsonFile("appsettings.json");

builder.Services.AddDbContext<MyContext>(options => options.UseSqlServer(builder.Configuration["ConnectionStrings:MyDatabase"]));

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddTransient<IPostService, PostService>();

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
