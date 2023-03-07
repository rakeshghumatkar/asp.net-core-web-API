using BookStoreWebAPI.Data;
using BookStoreWebAPI.Repository;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
//string connString = builder.Configuration.GetConnectionString("BookStoreDB");

// Add services to the container.

//builder.Services.AddControllers().AddNewtonsoftJson();
builder.Services.AddControllers();
builder.Services.AddTransient<IBooksRepo, BooksRepo>();
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

//Oneway to write Connection String
//builder.Services.AddDbContext<DbContextBook>(options=>options.UseSqlServer("Server=.;Database=BookStoreAPI;Integrated Security = true"));

builder.Services.AddDbContext<DbContextBook>(options =>
{
    //Correct Way to Define Connection string
    //options.UseSqlServer(builder.Configuration.GetConnectionString("BookStoreDB"));
    options.UseInMemoryDatabase("BookStoreDB");

});

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

app.UseAuthorization();

app.MapControllers();

app.Run();
